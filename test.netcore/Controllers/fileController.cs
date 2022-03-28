using Microsoft.AspNetCore.Mvc;
using test.netcore.Model;

namespace file.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class fileController : ControllerBase
    {

        [HttpPost]
        public ActionResult Post([FromForm] fileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.fileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.formFile.CopyTo(stream);

                    string filetype = Path.GetExtension(file.fileName);

                    if (filetype != ".csv")
                        return BadRequest("file type not accepted.");
                    else
                    {
                        return StatusCode(StatusCodes.Status202Accepted);
                    }
                }   
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}