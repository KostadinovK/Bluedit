using System.ComponentModel.DataAnnotations;

namespace BlueditServer.Models.RequestModels.Identity
{
    public class LoginRequestModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
