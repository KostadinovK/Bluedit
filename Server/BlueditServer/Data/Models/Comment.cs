using System;

namespace BlueditServer.Data.Models
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Text { get; set; }

        public string PostId { get; set; }

        public Post Post { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public DateTime WrittenOn { get; set; }
    }
}
