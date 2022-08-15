using Domain;
using Services.Dto;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Services.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly RecipeBookDbContext _dbContext;

        public TagService(ITagRepository tagRepository, RecipeBookDbContext dbContext, IRecipeRepository recipeRepository)
        {
            _tagRepository = tagRepository;
            _dbContext = dbContext;
            _recipeRepository = recipeRepository;
        }

        public void AddRecipeToTag(int tagId, int recipeId)
        {
            Tag tag = _tagRepository.GetById(tagId);
            if (tag == null)
            {
                throw new Exception("Данного тега не существует)");
            }
            Recipe recipe = _recipeRepository.GetById(recipeId);
            if (recipe == null)
            {
                throw new Exception("Данного рецепта не существует)");
            }

            _tagRepository.AddRecipeToTag(tag, recipe);
            _dbContext.Commit();
        }

        public TagDto getTagByName(string name)
        {
            return _tagRepository.GetByName(name).ConvertToTagDto();
        }

        public List<TagDto> getTags()
        {
            return _tagRepository.GetAll().ConvertAll(x => x.ConvertToTagDto());
        }

        public List<TagDto> getTags(int start, int count)
        {
            return _tagRepository.GetAll(start, count).ConvertAll(x => x.ConvertToTagDto());
        }

    }
}
