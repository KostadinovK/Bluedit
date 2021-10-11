using System.Threading.Tasks;
using BlueditServer.Models.ResponseModels;

namespace BlueditServer.Services.Identity
{
    public interface IIdentityService
    {
        Task<UserAuthResponseModel> RegisterAsync(string username, string password, string confirmPassword);

        Task<UserAuthResponseModel> LoginAsync(string username, string password);
    }
}
