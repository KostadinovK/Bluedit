using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlueditServer.Models.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlueditServer.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Data.Models.User> userManager;

        private readonly string secret;

        public IdentityService(IConfiguration configuration, UserManager<Data.Models.User> userManager)
        {
            this.userManager = userManager;

            secret = configuration["Secret"];
        }

        private string GenerateJwtToken(string userId, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

        public async Task<UserAuthResponseModel> RegisterAsync(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords doesn't match!");
            }

            var user = await userManager.FindByNameAsync(username);

            if (user != null)
            {
                throw new ArgumentException("There is already an user with that username!");
            }

            var newUser = new Data.Models.User
            {
                UserName = username
            };

            var res = await userManager.CreateAsync(newUser, password);

            if (!res.Succeeded)
            {
                throw new ArgumentException("A problem occured with the registration please try again");
            }

            var token = GenerateJwtToken(newUser.Id, newUser.UserName);

            var roles = await userManager.GetRolesAsync(newUser);

            return new UserAuthResponseModel()
            {
                IsAdmin = roles.Contains("Admin"),
                Id = newUser.Id,
                Token = token,
                Username = newUser.UserName
            };
        }

        public async Task<UserAuthResponseModel> LoginAsync(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new ArgumentException("There is no user with that username!");
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);

            if (!isPasswordValid)
            {
                throw new ArgumentException("Incorrect password!");
            }

            var token = GenerateJwtToken(user.Id, user.UserName);

            var roles = await userManager.GetRolesAsync(user);

            return new UserAuthResponseModel()
            {
                IsAdmin = roles.Contains("Admin"),
                Id = user.Id,
                Token = token,
                Username = user.UserName
            };
        }
    }
}
