using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserService
    {
        public Guid Registration(RegistrationFormDto registrationForm);

        public TokenView Login(LoginFormDto loginForm);

        public UserAccount GetUserById(string id);

    }
}
