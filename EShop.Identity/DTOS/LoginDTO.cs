using System.ComponentModel.DataAnnotations;

namespace EShop.Identity.DTOS
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
