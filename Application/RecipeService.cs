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
        private readonly ITagRepository _tagRepository;
        private readonly UserManager<UserAccount> _userManager;

        public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository,  IRecipeConverter recipeConverter, IJwtGenerator jwtGenerator, UserManager<UserAccount> userManager, ITagRepository tagRepository)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _recipeConverter = recipeConverter;
            _userManager = userManager;
            _tagRepository = tagRepository;
        }

        public int CreateRecipe(RecipeDto recipeDto, Guid recipeId)
        {

            Recipe recipe = _recipeConverter.ConvertToRecipe(recipeDto, new Recipe { Id = recipeDto.Id});
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


        public RecipeDto GetRecipeById(int id, Guid useAccountId = new Guid())
        {

            Recipe recipe = _recipeRepository.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            return _recipeConverter.ConvertToRecipeDto(recipe, useAccountId);

        }

        public RecipeDto GetRecipeByName(string name, Guid userAccount = new Guid())
        {
            Recipe recipe = _recipeRepository.GetByName(name);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }

            return _recipeConverter.ConvertToRecipeDto(recipe, userAccount);
        }

        public List<RecipeDto> GetRecipes(Guid userAccount = new Guid())
        {
            return _recipeRepository.GetAll().ConvertAll(c => _recipeConverter.ConvertToRecipeDto(c, userAccount));
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

        public List<RecipeDto> SearchRecipe(string search, Guid userAccountId, int start, int count)
        {
           
            Tag tag = _tagRepository.GetByName(search);

            List<Recipe> recipe = _recipeRepository.SearchByNameTag(search, tag, start, count);


            return recipe.ConvertAll(x => _recipeConverter.ConvertToRecipeDto(x, userAccountId));
        }

        public RecipeDto GetRecipeDay(Guid userAccountId)
        {

            Recipe recipeDay = _recipeRepository.GetRecipeDay(DateTime.Now);

            if (recipeDay == null)
            {
                return new RecipeDto();
            }


            return _recipeConverter.ConvertToRecipeDto(recipeDay, userAccountId); 

        }
    }
}
