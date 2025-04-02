using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Presentation.Areas.Admin.Models.Dtos.UserDtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrarı boş bırakılamaz.")]
        public string ConfirmPassword { get; set; }
    }
}
