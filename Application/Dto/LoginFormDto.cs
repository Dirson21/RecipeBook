using System.ComponentModel.DataAnnotations;

namespace Application.Dto
{
    public class LoginFormDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
