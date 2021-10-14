using System;
using System.Threading.Tasks;
using BlueditServer.Data;
using BlueditServer.Data.Models;
using BlueditServer.Models.RequestModels.Community;
using Microsoft.EntityFrameworkCore;

namespace BlueditServer.Services.Community
{
    public class CommunityService : ICommunityService
    {
        private readonly BlueditDbContext context;

        public CommunityService(BlueditDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> HasCommunityAsync(string name)
        {
            return await context.Communities.AnyAsync(c => c.Name == name);
        }

        public async Task CreateCommunityAsync(CreateCommunityRequestModel model, string userId)
        {
            if (await HasCommunityAsync(model.Name))
            {
                throw new ArgumentException("Community with that name already exists");
            }

            var community = new Data.Models.Community
            {
                Name = model.Name,
                Description = model.Description,
                HeadImageUrl = model.HeadImageUrl,
                CoverImageUrl = model.CoverImageUrl,
                CreatedOn = DateTime.UtcNow,
                CreatorId = userId
            };

            await context.Communities.AddAsync(community);

            await context.SaveChangesAsync();
        }
    }
}
