using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueditServer.Controllers
{
    [AllowAnonymous]
    public class TestController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It is working...");
        }
    }
}
