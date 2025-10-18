using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Media_Web_Server
{
    public partial class MediaRepoConnection
    {
        private string? serverIp = "192.168.4.81";
        private int port = 5001;
        string? messageToSend = "SELECT%ALL%FROM%MOVIES%WHERE%TITLE%EQUALS%U-571";
        public JsonDocument? jsonResponse;
        public string? rawString;


        public void GetIPOfMediaRepo()
        {
            //at a later point this will grab the IP 
            //of the media repo the program is pulling from
            //and set the obj variables to this

        }

        public MediaRepoConnection()
        {
            // Default constructor
        }
        public MediaRepoConnection(string serverIp, int port, string messageToSend)
        {
            this.serverIp = serverIp;
            this.port = port;
            this.messageToSend = messageToSend;
        }

        public async Task ConnectAsync()
        {
            try
            {
                using TcpClient client = new TcpClient();
                await client.ConnectAsync(this.serverIp, port);
                using NetworkStream stream = client.GetStream();

                // Send message with null terminator
                byte[] requestBytes = Encoding.UTF8.GetBytes(messageToSend + '\0');
                await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

                // Receive response
                byte[] buffer = new byte[4096];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                string responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                
                //This can probably be adjusted or removed later
                this.rawString = responseJson;
                
                SetJsonResponse(responseJson);
                //return responseJson;
            }
            catch (Exception ex)
            {
                WriteLine("Error: " + ex.Message);
            }
        }

        public void SetJsonResponse(string responseJson) 
        { 
            this.jsonResponse = JsonDocument.Parse(responseJson);
        }

        public string GetJsonResponseString()
        {
            if (jsonResponse != null)
            {
                return jsonResponse.RootElement.ToString();
            }
            return string.Empty;
        }

        //public void ParseJsonResponse(string responseJson)
        //{
        //    try
        //    {
        //        JsonDocument jsonDoc = JsonDocument.Parse(responseJson);
        //        jsonResponse = jsonDoc;
        //        if(jsonDoc.RootElement.TryGetProperty("title", out JsonElement titleElement))
        //        {
        //            Console.WriteLine($"Title: {titleElement.GetString()}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("JSON does not contain 'title' field.");
        //        }
        //    }
        //    catch (JsonException ex)
        //    {
        //        Console.WriteLine("JSON parsing error: " + ex.Message);
        //    }
        //}

        //public async Task StreamFromDatabaseToFFmpeg(Stream videoStream, string rtmpUrl)
        //{
        //    var startInfo = new ProcessStartInfo
        //    {
        //        FileName = "ffmpeg",
        //        Arguments = $"-re -i - -c copy -f flv \"{rtmpUrl}\"",  // <-- note the "-" means stdin
        //        RedirectStandardInput = true,
        //        RedirectStandardError = true,
        //        UseShellExecute = false,
        //        CreateNoWindow = true
        //    };

        //    using var ffmpeg = new Process { StartInfo = startInfo };
        //    ffmpeg.Start();

        //    await videoStream.CopyToAsync(ffmpeg.StandardInput.BaseStream);  // push to stdin
        //    ffmpeg.StandardInput.BaseStream.Close();

        //    string errors = await ffmpeg.StandardError.ReadToEndAsync();  // optional
        //    Console.WriteLine(errors);

        //    ffmpeg.WaitForExit();
        //}
    }
}
