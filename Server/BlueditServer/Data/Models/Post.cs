using System;
using System.Collections.Generic;

namespace BlueditServer.Data.Models
{
    public class Post
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public string Text { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }

        public string CommunityId { get; set; }

        public Community Community { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ImagesUrl { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
