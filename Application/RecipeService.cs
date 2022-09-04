using Application.Dto;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Domain;
using Application.Converters;
using Domain.Repositoy;
using Domain.UoW;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeConverter _recipeConverter;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly UserManager<UserAccount> _userManager;

        public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository,  IRecipeConverter recipeConverter, IJwtGenerator jwtGenerator, UserManager<UserAccount> userManager)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _recipeConverter = recipeConverter;
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
        }

        public int CreateRecipe(RecipeDto recipeDto, Guid recipeId)
        {

            Recipe recipe = _recipeConverter.ConvertToRecipe(recipeDto);
            recipe.UserAccountId = recipeId;
            recipe = _recipeRepository.Create(recipe);
            _unitOfWork.Commit();

            return recipe.Id;
        }

        public void DeleteRecipe(int recipeId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }


            _recipeRepository.Delete(recipe);
            _unitOfWork.Commit();
        }


        public RecipeDto GetRecipeById(int id, Guid recipeOwnerId = new Guid())
        {

            Recipe recipe = _recipeRepository.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            return _recipeConverter.ConvertToRecipeDto(recipe, recipeOwnerId);

        }

        public RecipeDto GetRecipeByName(string name, Guid recipeOwnerId = new Guid())
        {
            Recipe recipe = _recipeRepository.GetByName(name);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }

            return _recipeConverter.ConvertToRecipeDto(recipe, recipeOwnerId);
        }

        public List<RecipeDto> GetRecipes(Guid recipeOwnerId = new Guid())
        {
            return _recipeRepository.GetAll().ConvertAll(c => _recipeConverter.ConvertToRecipeDto(c, recipeOwnerId));
        }

        public List<RecipeDto> GetRecipes(int start, int count, Guid recipeOwnerId = new Guid())
        {
            return _recipeRepository.GetAll(start, count).ConvertAll(c => _recipeConverter.ConvertToRecipeDto(c, recipeOwnerId));
        }

        public int UpdateRecipe(RecipeDto recipeDto)
        {
            Recipe recipeData = _recipeRepository.GetById(recipeDto.Id);
            if (recipeData == null)
            {
                throw new Exception("Данного рецепта не существует");
            }

            Recipe recipe = _recipeConverter.ConvertToRecipe(recipeDto, recipeData);


            _recipeRepository.Update(recipe);
            _unitOfWork.Commit();
            return recipe.Id;
        }

        public void LikeRecipe(int recipeId, Guid userAccountId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Данного пользователя не существует");
            }

            _recipeRepository.Like(recipe, user);
            _unitOfWork.Commit();
        }

        public void FavoriteRecipe(int recipeId, Guid userAccountId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Данного пользователя не существует");
            }

            _recipeRepository.Favorite(recipe, user);
            _unitOfWork.Commit();
        }

        public void RemoveLikeRecipe(int recipeId, Guid userAccountId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Данного пользователя не существует");
            }

            _recipeRepository.RemoveLike(recipe, user);
            _unitOfWork.Commit();
        }

        public void RemoveFavoriteRecipe(int recipeId, Guid userAccountId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            UserAccount user = _userManager.FindByIdAsync(userAccountId.ToString()).GetAwaiter().GetResult();
            if (user == null)
            {
                throw new Exception("Данного пользователя не существует");
            }

            _recipeRepository.RemoveFavorite(recipe, user);
            _unitOfWork.Commit();
        }
    }
}
