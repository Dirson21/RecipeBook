using Services.Dto;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Domain;
using Services.Converters;

namespace Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeBookDbContext _dbContext;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ITagRepository _tagRepository;

        public RecipeService(RecipeBookDbContext dbContext, IRecipeRepository recipeRepository,  ITagRepository tagRepository)
        {
            _dbContext = dbContext;
            _recipeRepository = recipeRepository;
            _tagRepository = tagRepository;
        }

        public int CreateRecipe(RecipeDto recipeDto)
        {
            RecipeConverter converter = new RecipeConverter(_tagRepository); 
            Recipe recipe = _recipeRepository.Create(converter.ConvertToRecipe(recipeDto));
            _dbContext.Commit();
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
            _dbContext.Commit();
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
            _dbContext.Commit();
            return id;
        }
    }
}
