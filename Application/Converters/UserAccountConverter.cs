using Application.Dto;
using Domain;

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

        public UserAccountDto ConvertToUserAccountDto(UserAccount userAccount)
        {
            UserAccountDto userDto = new()
            {
                Id = userAccount.Id,
                Login = userAccount.UserName,
                Name = userAccount.Name,
                Description = userAccount.Description == null ? "" : userAccount.Description
            };

            return userDto;
        }

        public UserAccount ConvertToUserAccount(UserAccountDto userAccountDto, UserAccount userAccount)
        {
            userAccount.Id = userAccountDto.Id;
            userAccount.Name = userAccountDto.Name;
            userAccount.Description = userAccountDto.Description;
            userAccount.UserName = userAccountDto.Login;

            return userAccount;

        }
    }
}
