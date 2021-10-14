using System.ComponentModel.DataAnnotations;

namespace BlueditServer.Models.RequestModels.Community
{
    public class CreateCommunityRequestModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string HeadImageUrl { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
