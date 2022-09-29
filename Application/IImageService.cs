using Microsoft.AspNetCore.Http;

namespace Application
{
    public interface IImageService
    {
        void addRecipeImage(int recipeId, IFormFile image);
    }
}
