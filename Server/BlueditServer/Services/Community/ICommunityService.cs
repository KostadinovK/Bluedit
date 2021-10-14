using System.Threading.Tasks;
using BlueditServer.Models.RequestModels.Community;

namespace BlueditServer.Services.Community
{
    public interface ICommunityService
    {
        Task<bool> HasCommunityAsync(string name);

        Task CreateCommunityAsync(CreateCommunityRequestModel model, string userId);
    }
}
