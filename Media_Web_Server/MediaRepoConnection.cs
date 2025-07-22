using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Media_Web_Server
{
    public class MediaRepoConnection
    {
        private string? serverIp = "192.168.4.81";
        private int port = 5001;
        string? messageToSend = "GET TITLE Firewalker";
        JsonDocument? jsonResponse;


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

        public async Task<string> ConnectAsync()
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
                return responseJson;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public void ParseJsonResponse(string responseJson)
        {
            try
            {
                JsonDocument jsonDoc = JsonDocument.Parse(responseJson);
               jsonResponse = jsonDoc;
            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON parsing error: " + ex.Message);
                //return null;
            }
        }
    }
}
