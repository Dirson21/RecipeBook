using Dto;
using Infrastructure.Data;
using Infrastructure.Data.RecipeModel;
using Domain;
using Services.Converters;

namespace Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeBookDbContext _dbContext;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(RecipeBookDbContext dbContext, IRecipeRepository recipeRepository)
        {
            _dbContext = dbContext;
            _recipeRepository = recipeRepository;
        }

        public int CreateRecipe(RecipeDto recipe)
        {
            int id = _recipeRepository.Create(recipe.ConvertToRecipe());
            _dbContext.Commit();
            return id;
        }

        public void DeleteRecipe(RecipeDto recipe)
        {
            _recipeRepository.Delete(recipe.ConvertToRecipe());
            _dbContext.Commit();
        }

        public RecipeDto GetRecipeById(int id)
        {

            return _recipeRepository.GetById(id).ConvertToRecipeDto();
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

        public int UpdateRecipe(RecipeDto recipe)
        {
            int id = _recipeRepository.Update(recipe.ConvertToRecipe());
            _dbContext.Commit();
            return id;
        }
    }
}
