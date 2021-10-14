using System;
using System.Collections.Generic;

namespace BlueditServer.Data.Models
{
    public class Community
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string Description { get; set; }

        public string HeadImageUrl { get; set; }

        public string CoverImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }


        public ICollection<CommunityUser> Users { get; set; } = new HashSet<CommunityUser>();

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
