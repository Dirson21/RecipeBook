using Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class RegistrationFormDto
    {

        [Required]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 8)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
