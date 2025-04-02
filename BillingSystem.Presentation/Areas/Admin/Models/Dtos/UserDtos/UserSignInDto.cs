using System.ComponentModel.DataAnnotations;

namespace BillingSystem.Presentation.Areas.Admin.Models.Dtos.UserDtos
{
    public class UserSignInDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string Password { get; set; }
    }
}
