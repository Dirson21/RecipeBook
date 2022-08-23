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
            UserAccount userAccount = new UserAccount();
            userAccount.Login = registrationForm.Login;
            userAccount.UserName = registrationForm.Login;
            userAccount.EmailConfirmed = true;
            return userAccount;
        }
    }
}
