using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public static class UserExtention
    {
        public static UserDto ConvertToIngridientDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                Description = user.Description,
                
            };
        }
        public static User ConvertToIngridient(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Login = userDto.Login,
                Password = userDto.Password,
                Description = userDto.Description,

            };
        }
    }
}
