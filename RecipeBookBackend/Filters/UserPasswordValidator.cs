using Domain;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace RecipeBookBackend.Filters
{
    public class UserPasswordValidator : IPasswordValidator<UserAccount>
    {
        public int RequiredLength { get; set; }

        public UserPasswordValidator(int lenght)
        {
            RequiredLength = lenght;
        }

        public Task<IdentityResult> ValidateAsync(UserManager<UserAccount> manager, UserAccount user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (string.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Минимальная длина пароля равна {RequiredLength}",
                    Code = "InvalidPassword"

                });
            }

            string pattern = "^[a-zA-Z0-9!#$%&?]+$";

            if (!Regex.IsMatch(password, pattern))
            {
                errors.Add(new IdentityError
                {
                    Description = "",
                    Code = "InvalidPassword"
                });
            }

            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
