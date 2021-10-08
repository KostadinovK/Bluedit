using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BlueditServer.Data.Models
{
    public class User : IdentityUser
    {
        public User ()
        {
            Id = Guid.NewGuid().ToString();
            RegisteredOn = DateTime.UtcNow;
        }

        public DateTime RegisteredOn { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? BannedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; } = new HashSet<IdentityUserRole<string>>();

        public ICollection<UserNotification> Notifications { get; set; } = new HashSet<UserNotification>();

        public ICollection<Community> CreatedCommunities { get; set; } = new HashSet<Community>();

        public ICollection<CommunityUser> JoinedCommunities { get; set; } = new HashSet<CommunityUser>();

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
