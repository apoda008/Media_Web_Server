using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace VideoStreamServer.Controllers
{


    //THIS ALSO WORKS BUT IT LOADS THE ENTIRE FILE INTO BROWSER BEFORE IT STREAMS
    [Route("[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        //NONE BUFFERED IMPLEMENTATION
        [HttpGet("{filename}")]
        public async Task GetVideo()
        {
            Response.StatusCode = 200;
            Response.ContentType = "video/mp4";
            Response.Headers.Add("Accept-Ranges", "none"); // Optional: video won't support scrubbing

            // Example: Get stream from external source
            Stream sourceStream = await GetExternalVideoStreamAsync();

            if (sourceStream == null)
            {
                Response.StatusCode = 404;
                await Response.Body.WriteAsync(Encoding.UTF8.GetBytes("Stream not found"));
                return;
            }

            // Copy the external stream directly to the HTTP response stream
            await sourceStream.CopyToAsync(Response.Body);
            await Response.Body.FlushAsync(); // Ensure all data is pushed
        }

        // Simulated external video stream (could be a TCP connection, HTTP, or custom protocol)
        private async Task<Stream> GetExternalVideoStreamAsync()
        {
            var client = new TcpClient();
            await client.ConnectAsync("192.168.4.81", 5001); // Replace with your source server

            NetworkStream stream = client.GetStream();
            return stream; // Keep the stream open for copying
        }
    }
}



//THIS WORKED BUT IS NOT AN EXTERNAL STREAM 
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class StreamController : ControllerBase
//    {
//        [HttpGet("{fileName}")]
//        public IActionResult GetVideo(string fileName)
//        {
//            //string filePath = Path.Combine("Videos", fileName);
//            string filePath = "C:\\Users\\dan_a\\Desktop\\TestLocationForRepo\\Media_Repository\\Media_Movies\\U571.mp4";
//            if (!System.IO.File.Exists(filePath))
//                return NotFound();

//            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
//            return File(stream, "video/mp4", enableRangeProcessing: true);
//        }
//    }
//}