using System;
using BlueditServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueditServer.Data.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post
                .HasOne(p => p.Creator)
                .WithMany(u => u.Posts)
                .OnDelete(DeleteBehavior.Restrict);

            post
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
