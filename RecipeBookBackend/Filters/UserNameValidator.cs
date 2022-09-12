using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;


namespace RecipeBookBackend.Filters
{
    public class UserNameValidator : IUserValidator<UserAccount>
    {
        public Task<IdentityResult>  ValidateAsync(UserManager<UserAccount> manager, UserAccount user)
        {

            List<IdentityError> errors = new List<IdentityError>();

            var res =  manager.FindByNameAsync(user.UserName).GetAwaiter().GetResult();

            if (res != null)
            {
                errors.Add(new IdentityError
                {
                    Description = "Данный логин уже существует"
                });
            }
            if (user.UserName.Contains(" "))
            {
                errors.Add(new IdentityError
                {
                    Description = "Логин не должен содержать пробелов"
                }) ;
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
