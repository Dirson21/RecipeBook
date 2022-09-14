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
        private readonly DbSet<Tag> _tag;

        public TagRepository(RecipeBookDbContext dbContext)
        {
            _tag = dbContext.Set<Tag>();
        }

        public List<Tag> GetAll()
        {
            return _tag.OrderBy(x => x.Id).Include(x => x.Recipes).ThenInclude(x => x.IngredientHeaders)
                    .Include(x => x.Recipes).ThenInclude(x => x.CookingSteps).ToList();
        }

        public Tag GetById(int tagId)
        {
            return _tag.FirstOrDefault(x => x.Id == tagId);
        }

        public Tag GetByName(string name)
        {
            return _tag.Include(s => s.Recipes).ThenInclude(s => s.CookingSteps)
                .Include(s => s.Recipes).ThenInclude(s => s.IngredientHeaders).ThenInclude(s => s.Ingredients)
                .Include(s => s.Recipes).ThenInclude(s => s.UserAccount).FirstOrDefault(x => x.Name == name);
        }

    }
}
