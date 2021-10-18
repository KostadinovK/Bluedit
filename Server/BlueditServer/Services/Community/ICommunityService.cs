using System.Collections.Generic;
using System.Threading.Tasks;
using BlueditServer.Models.RequestModels.Community;
using BlueditServer.Models.ResponseModels.Community;

namespace BlueditServer.Services.Community
{
    public interface ICommunityService
    {
        Task<bool> HasCommunityAsync(string name);

        Task CreateCommunityAsync(CreateCommunityRequestModel model, string userId);

        Task<IList<CommunityResponseModel>> GetAllAsync(string userId);

        Task<IList<CommunityResponseModel>> SearchAsync(string search, string userId);

        Task<IList<CommunityResponseModel>> GetAllCommunitiesThatAreNotJoinedOrCreatedByUserAsync(string userId);
    }
}
