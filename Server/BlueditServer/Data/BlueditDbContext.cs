using System.Linq;
using BlueditServer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueditServer.Data
{
    public class BlueditDbContext : IdentityDbContext<User, IdentityRole<string>, string>
    {
        public BlueditDbContext(DbContextOptions<BlueditDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserNotification> UsersNotifications { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Community> Communities { get; set; }

        public DbSet<CommunityUser> CommunitiesUsers { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
