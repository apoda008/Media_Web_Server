using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

partial class Program
{
    static async Task Connect()
    {
        string serverIp = "192.168.4.81";  // Replace with actual IP
        int port = 5001;                // Replace with actual port
        string messageToSend = "GET TITLE Firewalker";

        try
        {
            using TcpClient client = new TcpClient();
            await client.ConnectAsync(serverIp, port);

            using NetworkStream stream = client.GetStream();

            // Send message
            //DONT FORGET NULL TERMINATOR
            byte[] requestBytes = Encoding.UTF8.GetBytes(messageToSend + '\0');
            await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

            // Receive response
            byte[] buffer = new byte[4096];
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

            string responseJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Raw response:\n" + responseJson);

            // Parse JSON
            JsonDocument jsonDoc = JsonDocument.Parse(responseJson);
            if (jsonDoc.RootElement.TryGetProperty("title", out JsonElement statusElement))
            {
                Console.WriteLine($"Status: {statusElement.GetString()}");
            }
            else
            {
                Console.WriteLine("JSON does not contain 'status' field.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
