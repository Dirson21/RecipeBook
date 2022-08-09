using RecipeBookBackend.Domain;
using RecipeBookBackend.Dto;

namespace RecipeBookBackend.Services
{
    public class RecipeService : IRecipeService
    {
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

            return new List<RecipeDto>() { recipeDto };
        }
    }
}
