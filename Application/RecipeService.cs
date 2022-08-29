using Application.Dto;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Domain;
using Application.Converters;
using Domain.Repositoy;
using Domain.UoW;

namespace Application
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeConverter _recipeConverter;
        private readonly IJwtGenerator _jwtGenerator;

        public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository,  IRecipeConverter recipeConverter, IJwtGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _recipeConverter = recipeConverter;
            _jwtGenerator = jwtGenerator;
        }

        public int CreateRecipe(RecipeDto recipeDto, string authHeader)
        {
            Guid userAccountId;

            var authParam = authHeader.Split(" ");
            if (authParam[0].ToLower() == "bearer")
            {
                string jwtToken = authParam[1];
                userAccountId = _jwtGenerator.getNameId(jwtToken);
                if (userAccountId == Guid.Empty)
                {
                    throw new Exception("Неверный токен");
                }
            }
            else
            {
                throw new Exception("Неверный тип авторизации");
            }

            Recipe recipe = _recipeConverter.ConvertToRecipe(recipeDto);
            recipe.UserAccountId = userAccountId;
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

        public RecipeDto GetRecipeById(int id)
        {

            Recipe recipe = _recipeRepository.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            return _recipeConverter.ConvertToRecipeDto(recipe);

        }

        public RecipeDto GetRecipeByName(string name)
        {
            return _recipeConverter.ConvertToRecipeDto(_recipeRepository.GetByName(name));
        }

        public List<RecipeDto> GetRecipes()
        {
            return _recipeRepository.GetAll().ConvertAll(c => _recipeConverter.ConvertToRecipeDto(c));
        }

        public List<RecipeDto> GetRecipes(int start, int count)
        {
            return _recipeRepository.GetAll(start, count).ConvertAll(c => _recipeConverter.ConvertToRecipeDto(c));
        }

        public int UpdateRecipe(int recipeId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }

            int id = _recipeRepository.Update(recipe);
            _unitOfWork.Commit();
            return id;
        }
    }
}
