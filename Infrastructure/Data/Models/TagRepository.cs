using Domain;
using Domain.Repositoy;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Models
{
    public class TagRepository : ITagRepository
    {
        private readonly DbSet<Tag> _tag;

        public TagRepository(RecipeBookDbContext dbContext)
        {
            _tag = dbContext.Set<Tag>();
        }

        public Tag GetById(int tagId)
        {
            return _tag.FirstOrDefault(x => x.Id == tagId);
        }

        public Tag GetByName(string name)
        {
            return _tag.FirstOrDefault(x => x.Name == name);
        }

    }
}
