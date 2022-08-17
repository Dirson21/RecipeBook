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
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IRecipeConverter _recipeConverter;

        public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository recipeRepository,  IRecipeConverter recipeConverter)
        {
            _UnitOfWork = unitOfWork;
            _recipeRepository = recipeRepository;
            _recipeConverter = recipeConverter;
        }

        public int CreateRecipe(RecipeDto recipeDto)
        {
            Recipe recipe = _recipeRepository.Create(_recipeConverter.ConvertToRecipe(recipeDto));
            _UnitOfWork.Commit();
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
            _UnitOfWork.Commit();
        }

        public RecipeDto GetRecipeById(int id)
        {

            Recipe recipe = _recipeRepository.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }
            return recipe.ConvertToRecipeDto();

        }

        public RecipeDto GetRecipeByName(string name)
        {
            return _recipeRepository.GetByName(name).ConvertToRecipeDto();
        }

        public List<RecipeDto> GetRecipes()
        {
            RecipeDto recipeDto = new RecipeDto
            {
                Id = 1,
                Name = "Клубничная панна-котта",
                Description = "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой",
                Image = "assets\\img\\pana-kota.png",
                CookingTime = 35,
                CountPerson = 5
            };

            return _recipeRepository.GetAll().ConvertAll(c => c.ConvertToRecipeDto());
        }

        public List<RecipeDto> GetRecipes(int start, int count)
        {
            return _recipeRepository.GetAll(start, count).ConvertAll(c => c.ConvertToRecipeDto());
        }

        public int UpdateRecipe(int recipeId)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }

            int id = _recipeRepository.Update(recipe);
            _UnitOfWork.Commit();
            return id;
        }
    }
}
