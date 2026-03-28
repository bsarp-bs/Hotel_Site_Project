using System.ComponentModel.DataAnnotations;

namespace WEB_UI.UI_DTO.LoginDTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Kullanici adi bos birakilamaz")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Sifre bos birakilamaz")]
        public string? Password { get; set; }
    }
}
