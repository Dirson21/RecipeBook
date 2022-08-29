using Application.Dto;
using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public class UserAccountConverter : IUserAccountConverter
    {
    

        public UserAccount RegistrationFormToUserAccount(RegistrationFormDto registrationForm)
        {
            UserAccount userAccount = new()
            {
                Name = registrationForm.Name,
                UserName = registrationForm.Login,
                EmailConfirmed = true
            };
            return userAccount;
        }

        public UserAccount ConvertToUserAccount(UserAccountDto userAccount)
        {
            UserAccount user = new()
            {
                Id = userAccount.Id,
                UserName = userAccount.Login,
                Name = userAccount.Name,
                Description = userAccount.Description
            };

            return user;
        }

        public UserAccountDto ConvertToUserAccountDto(UserAccount userAccount)
        {
            UserAccountDto userDto = new()
            {
                Id = userAccount.Id,
                Login = userAccount.UserName,
                Name = userAccount.Name,
                Description = userAccount.Description
            };

            return userDto;
        }
    }
}
