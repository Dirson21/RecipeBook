using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IImageService
    {
        void addRecipeImage(int recipeId, IFormFile image);
    }
}
