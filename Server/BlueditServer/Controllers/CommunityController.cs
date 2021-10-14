using System.Security.Claims;
using System.Threading.Tasks;
using BlueditServer.Models.RequestModels.Community;
using BlueditServer.Services.Community;
using Microsoft.AspNetCore.Mvc;

namespace BlueditServer.Controllers
{
    public class CommunityController : ApiController
    {
        private readonly ICommunityService communityService;

        public CommunityController(ICommunityService communityService)
        {
            this.communityService = communityService;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CreateCommunityRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            if (!model.HeadImageUrl.StartsWith("https://"))
            {
                return BadRequest("Head Image Url should start with 'https://'");
            }

            if (!string.IsNullOrEmpty(model.CoverImageUrl) && !model.CoverImageUrl.StartsWith("https://"))
            {
                return BadRequest("Cover Image Url should start with 'https://'");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await communityService.CreateCommunityAsync(model, userId);

            return Ok();
        }
    }
}
