using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public interface IUserAccountConverter
    {
        public UserAccount RegistrationFormToUserAccount(RegistrationFormDto registrationForm);
    }
}
