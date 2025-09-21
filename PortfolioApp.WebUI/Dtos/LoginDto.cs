using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.WebUI.Dtos
{
    public class LoginDto
    {
        [Required, MinLength(5),MaxLength(100)]
        public string Username { get; set; }
        [Required, MinLength(8), MaxLength(32)]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
