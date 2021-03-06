using System.Threading.Tasks;
using BlueditServer.Models.RequestModels.Identity;
using BlueditServer.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueditServer.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService service)
        {
            this.identityService = service;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            var user = await identityService.RegisterAsync(model.Username, model.Password, model.ConfirmPassword);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            var user = await identityService.LoginAsync(model.Username, model.Password);

            return Ok(user);
        }
    }
}
