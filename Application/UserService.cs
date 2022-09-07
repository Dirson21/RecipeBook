using Application.Dto;
using Application.Converters;
using Domain;
using Domain.UoW;
using Microsoft.AspNetCore.Identity;
using Domain.Repository;

namespace Application
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly IUserAccountConverter _userConverter;
        private readonly IRecipeConverter _recipeConverter;
        private readonly IJwtGenerator _jwtGenerator;
       


        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager, IUserAccountConverter userConverter, IJwtGenerator jwtGenerator,
            IRecipeConverter recipeConverter)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _userConverter = userConverter;
            _jwtGenerator = jwtGenerator;
            _recipeConverter = recipeConverter;
        }

        public UserAccountDto GetUserById(string id)
        {
            var user = _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
            
            if (user == null)
            {
                throw new Exception("Пользователя не существует");
            }

            return _userConverter.ConvertToUserAccountDto(user);
        }

        public List<RecipeDto> GetUserFavoriteRecipes(Guid userAccountId)
        {
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Пользователя не существует");
            }

            return _userRepository.GetUserFavoriteRecipes(user).ConvertAll(s => _recipeConverter.ConvertToRecipeDto(s,user.Id));

        }

        public int GetUserFavoriteRecipesCount(Guid userAccountId)
        {
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Пользователя не существует");
            }

            return _userRepository.GetUserFavoriteRecipesCount(user);
        }

        public int GetUserLikesCount(Guid userAccountId)
        {
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Пользователя не существует");
            }

            return _userRepository.GetUserLikesCount(user);
        }

        public List<RecipeDto> GetUserRecipes(Guid userAccountId)
        {
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Пользователя не существует");
            }

            return _userRepository.GetUserRecipes(user).ConvertAll(s => _recipeConverter.ConvertToRecipeDto(s, user.Id));
        }

        public TokenView Login(LoginFormDto loginForm)
        {

            UserAccount user = _userManager.FindByNameAsync(loginForm.Login).GetAwaiter().GetResult();
           
            if (user == null)
            {
         
                throw new Exception("Неверный логин или пароль");
            }
           
            var authResult = _signInManager.CheckPasswordSignInAsync(user, loginForm.Password, false).GetAwaiter().GetResult();
            if (!authResult.Succeeded)
            {
               
                throw new Exception("Неверный логин или пароль");
            }

            TokenView tokenView = new TokenView
            {
                JwtToken = _jwtGenerator.CreateToken(user),
                Login = user.UserName,
                Id =  user.Id.ToString(),
                Name = user.Name
            };

            return tokenView;
        }

        public Guid Registration(RegistrationFormDto registrationForm)
        {

            UserAccount user = _userConverter.RegistrationFormToUserAccount(registrationForm);

            var result = _userManager.CreateAsync(user, registrationForm.Password).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            return user.Id;
        }

        public Guid UpdateUser(UserAccountDto userAccountDto)
        {
            UserAccount user = _userManager.FindByIdAsync(userAccountDto.Id.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Пользователя не существует");
            }
            var result = _userManager.UpdateAsync(_userConverter.ConvertToUserAccount(userAccountDto, user)).GetAwaiter().GetResult();

            return user.Id;

        }
    }
}
