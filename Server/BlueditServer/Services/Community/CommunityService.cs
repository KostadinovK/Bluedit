using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueditServer.Data;
using BlueditServer.Models.RequestModels.Community;
using BlueditServer.Models.ResponseModels.Community;
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

        public async Task<IList<CommunityResponseModel>> GetAllAsync(string userId)
        {
            var communities = await context.Communities.Where(c => !c.IsDeleted)
                .Select(c => new CommunityResponseModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    HeadImageUrl = c.HeadImageUrl,
                    UserHasJoined = c.Users.Any(u => u.UserId == userId),
                    CreatorId = c.CreatorId
                })
                .ToListAsync();

            return communities;
        }

        public async Task<IList<CommunityResponseModel>> SearchAsync(string search, string userId)
        {
            var communities = await context.Communities.Where(c => !c.IsDeleted && c.Name.Contains(search))
                .Select(c => new CommunityResponseModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    HeadImageUrl = c.HeadImageUrl,
                    UserHasJoined = c.Users.Any(u => u.UserId == userId),
                    CreatorId = c.CreatorId
                })
                .ToListAsync();

            return communities;
        }

        public async Task<IList<CommunityResponseModel>> GetAllCommunitiesThatAreNotJoinedOrCreatedByUserAsync(string userId)
        {
            var communities = await context.Communities.Where(c =>
                !c.IsDeleted && c.CreatorId != userId && c.Users.All(u => u.UserId != userId))
                .Select(c => new CommunityResponseModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    HeadImageUrl = c.HeadImageUrl,
                    UserHasJoined = false,
                    CreatorId = c.CreatorId
                })
                .ToListAsync();

            return communities;
        }
    }
}
