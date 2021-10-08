namespace BlueditServer.Data.Models
{
    public class UserNotification
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public string NotificationId { get; set; }

        public Notification Notification { get; set; }
    }
}
