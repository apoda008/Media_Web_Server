using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace VideoStreamServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        // adjust to whatever chunk size makes sense for you (e.g. 64KB)
        private const int BufferSize = 64 * 1024;

        [HttpGet("{filename}")]
        public async Task GetVideo(string filename, CancellationToken cancellationToken)
        {
            // tell the client it's a stream of unknown total length
            Response.StatusCode = 200;
            Response.ContentType = "video/mp4";          // no seeking supported
            Response.Headers.Add("Accept-Ranges", "bytes");            // seeking?
            Response.Headers.Add("Transfer-Encoding", "chunked");     // force chunked mode

            // open your TCP connection
            using var client = new TcpClient();
            await client.ConnectAsync("192.168.4.81", 5001, cancellationToken);
            using var sourceStream = client.GetStream();

            var buffer = new byte[BufferSize];
            int bytesRead;

            // loop: read a chunk from TCP, write it to the response, flush immediately
            while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
            {
                await Response.Body.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                await Response.Body.FlushAsync(cancellationToken);
            }
        }
    }

}

