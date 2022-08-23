using Application.Dto;
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

        public void login();

    }
}
