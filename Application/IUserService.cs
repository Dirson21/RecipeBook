using Application.Dto;

namespace Application
{
    public interface IUserService
    {
        public Guid Registration(RegistrationFormDto registrationForm);

        public TokenView Login(LoginFormDto loginForm);

        public UserAccountDto GetUserById(string id);

        List<RecipeDto> GetUserRecipes(Guid userAccountId);

        List<RecipeDto> GetUserFavoriteRecipes(Guid userAccountId);

        public int GetUserFavoriteRecipesCount(Guid userAccountId);

        public int GetUserLikesCount(Guid userAccountId);

        public Guid UpdateUser(UserAccountDto userAccountDto);

    }
}
