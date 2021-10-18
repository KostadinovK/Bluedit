using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlueditServer.Models.RequestModels.Community;
using BlueditServer.Models.ResponseModels.Community;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string search)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IList<CommunityResponseModel> communities = new List<CommunityResponseModel>();

            if (!string.IsNullOrEmpty(search))
            {
                communities = await communityService.SearchAsync(search, userId);
            }
            else
            {
                communities = await communityService.GetAllAsync(userId);
            }

            return Ok(communities);
        }

        [HttpGet]
        [Route(nameof(GetAllCommunitiesThatAreNotJoinedOrCreatedByUser))]
        public async Task<IActionResult> GetAllCommunitiesThatAreNotJoinedOrCreatedByUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var communities = await communityService.GetAllCommunitiesThatAreNotJoinedOrCreatedByUserAsync(userId);

            return Ok(communities);
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(CreateCommunityRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data is not valid");
            }

            if (model.Name.Contains(' '))
            {
                return BadRequest("Name should be only one word");
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
