using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")] //Вводимый пользователем текст не будет виден
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
