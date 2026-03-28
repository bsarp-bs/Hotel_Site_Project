using System.ComponentModel.DataAnnotations;

namespace API.DtoLayer
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "İsim alanı boş kalamaz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş kalamaz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı boş kalamaz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail alanı boş kalamaz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş kalamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş kalamaz")]
        [Compare("Password", ErrorMessage = "Şifreler aynı olmalı")]
        public string ConfirmPassword { get; set; }
    }
}
