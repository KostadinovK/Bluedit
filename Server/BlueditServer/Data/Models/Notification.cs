using System;

namespace BlueditServer.Data.Models
{
    public class Notification
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ActionLink { get; set; }
    
    }
}
