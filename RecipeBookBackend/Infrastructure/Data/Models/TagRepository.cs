using Domain;
using Domain.Repositoy;
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

      

        public List<Tag> GetAll()
        {
            return _dbContext.Tag.OrderBy(x => x.Id).Include(x => x.Recipes).ThenInclude(x => x.Ingredients)
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
    }
}
