using BlueditServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueditServer.Data.EntityConfigurations
{
    public class CommunityUserConfiguration : IEntityTypeConfiguration<CommunityUser>
    {
        public void Configure(EntityTypeBuilder<CommunityUser> builder)
        {
            builder
                .HasKey(uc => new { uc.UserId, uc.CommunityId });

            builder
                .HasOne(uc => uc.User)
                .WithMany(uc => uc.JoinedCommunities)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(uc => uc.Community)
                .WithMany(uc => uc.Users)
                .HasForeignKey(uc => uc.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
