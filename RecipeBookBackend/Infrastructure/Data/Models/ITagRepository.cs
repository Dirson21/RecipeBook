using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Models
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        List<Tag> GetAll(int start, int count);

        Tag GetById(int tagId);

        Tag GetByName(string name);

        int AddRecipeToTag(Tag tag, Recipe recipe);
        
        Tag Create (Tag tag);
        int Update (Tag tag);
        void Delete (Tag tag);
    }
}
