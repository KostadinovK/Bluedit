using Microsoft.AspNetCore.Mvc;

namespace BlueditServer.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It is working...");
        }
    }
}
