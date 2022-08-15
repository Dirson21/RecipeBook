using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public class TagRepository : ITagRepository
    {
        private readonly RecipeBookDbContext _dbContext;

        public TagRepository(RecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddRecipeToTag(Tag tag, Recipe recipe)
        {
            tag.Recipes.Add(recipe);
            return _dbContext.Tag.Update(tag).Entity.Id;
        }

        public Tag Create(Tag tag)
        {
            return _dbContext.Tag.Add(tag).Entity;
        }

        public void Delete(Tag tag)
        {
            _dbContext.Tag.Remove(tag);
        }

        public List<Tag> GetAll()
        {
            return _dbContext.Tag.OrderBy(x => x.Id).Include(x => x.Recipes).ThenInclude(x => x.Ingridients)
                    .Include(x => x.Recipes).ThenInclude(x => x.CookingSteps).ToList();
        }

        public List<Tag> GetAll(int start, int count)
        {
            return _dbContext.Tag.OrderBy(x => x.Id).Skip(start).Take(count).Include(x => x.Recipes).ThenInclude(x => x.Ingridients)
                .Include(x => x.Recipes).ThenInclude(x => x.CookingSteps).ToList();
        }

        public Tag GetById(int tagId)
        {
            return _dbContext.Tag.FirstOrDefault(x => x.Id == tagId);
        }

        public Tag GetByName(string name)
        {
            return _dbContext.Tag.FirstOrDefault(x => x.Name == name);
        }

        public int Update(Tag tag)
        {
            return _dbContext.Tag.Update(tag).Entity.Id;
        }
    }
}
