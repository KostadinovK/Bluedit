namespace BlueditServer.Models.ResponseModels
{
    public class UserAuthResponseModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }

        public bool IsAdmin { get; set; }
    }
}
