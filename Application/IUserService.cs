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
        UserDto Login(string login, string password);

        UserDto Logout();

        string Registration(UserDto user);

    }
}
