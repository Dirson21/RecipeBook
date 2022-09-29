using Application.Dto;
using Domain;

namespace Application.Converters
{
    public interface IUserAccountConverter
    {
        public UserAccount RegistrationFormToUserAccount(RegistrationFormDto registrationForm);
        public UserAccountDto ConvertToUserAccountDto(UserAccount userAccount);
        public UserAccount ConvertToUserAccount(UserAccountDto userAccountDto, UserAccount userAccount);
    }
}
