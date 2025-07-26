using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;

namespace VideoStreamServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StreamController : ControllerBase
    {
        [HttpGet("{fileName}")]
        public IActionResult GetVideo(string fileName)
        {
            //string filePath = Path.Combine("Videos", fileName);
            string filePath = "C:\\Users\\dan_a\\Desktop\\TestLocationForRepo\\Media_Repository\\Media_Movies\\U571.mp4";
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return File(stream, "video/mp4", enableRangeProcessing: true);
        }
    }
}