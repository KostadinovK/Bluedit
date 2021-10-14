namespace BlueditServer.Models.ResponseModels.Community
{
    public class CommunityResponseModel
    {
        public string Id { get; set; }

        public string HeadImageUrl { get; set; }

        public string Name { get; set; }

        public string CreatorId { get; set; }

        public bool UserHasJoined { get; set; }
    }
}
