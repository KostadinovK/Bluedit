using BlueditServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueditServer.Data.EntityConfigurations
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder
                .HasKey(un => new { un.UserId, un.NotificationId });

            builder
                .HasOne(un => un.User)
                .WithMany(un => un.Notifications)
                .HasForeignKey(un => un.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(un => un.Notification);
        }
    }
}
