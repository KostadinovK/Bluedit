using System.ComponentModel.DataAnnotations;

namespace BlueditServer.Models.RequestModels.Identity
{
    public class RegisterRequestModel
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
