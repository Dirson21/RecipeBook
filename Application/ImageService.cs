using Domain;
using Domain.Repositoy;
using Domain.UoW;
using Microsoft.AspNetCore.Http;


namespace Application
{
    public class ImageService : IImageService
    {
        private readonly string _rootPath = "wwwroot/Data/Recipe";
        private readonly IRecipeRepository _recipeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public void addRecipeImage(int recipeId, IFormFile image)
        {
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует");
            }

            int month = DateTime.Now.Month;
            string path = $"{_rootPath}\\{month}\\";
            string filename = "";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            bool isfilename = false;
            for (int i = 0; i < 10; i++)
            {
                filename = Path.ChangeExtension(Path.GetRandomFileName(), ".png");
                if (!File.Exists(path + filename))
                {
                    isfilename = true;
                    break;
                }
            }
            if (!isfilename)
            {
                throw new Exception("Что-то пошло не так :(");
            }


            using (FileStream fileStream = File.Create(path + filename))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
            }


            recipe.Image = $"{month}\\{filename}";
            _recipeRepository.Update(recipe);
            _unitOfWork.Commit();
        }
    }
}
