﻿using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;

//Think I am kind of boned here. Might have to actually implement this in the Razor component
//since the webpage will need to access each chunk of the video. This may prove difficult to build 
//outside of the component.

namespace Media_Web_Server
{
    public partial class MediaRepoConnection
    {
        public async Task<byte[]?> GetVideo()
        {
           using TcpClient client = new TcpClient();
            await client.ConnectAsync(this.serverIp, port);
            using NetworkStream stream = client.GetStream();

            byte[] requestBytes = Encoding.UTF8.GetBytes(messageToSend + '\0');
            await stream.WriteAsync(requestBytes, 0, requestBytes.Length);

            byte[] buffer = new byte[5000];

            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead > 0)
            {
                byte[] videoData = new byte[bytesRead];
                Array.Copy(buffer, videoData, bytesRead);
                return videoData;
            }
            else
            {
                return null; // No data received
            }

        }

    }
}
