using BlueditServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueditServer.Data.EntityConfigurations
{
    public class CommunityConfiguration : IEntityTypeConfiguration<Community>
    {
        public void Configure(EntityTypeBuilder<Community> community)
        {
            community
                .HasOne(c => c.Creator)
                .WithMany(u => u.CreatedCommunities)
                .OnDelete(DeleteBehavior.Restrict);

            community
                .HasMany(c => c.Posts)
                .WithOne(p => p.Community)
                .HasForeignKey(p => p.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
