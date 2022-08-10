using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITagService
    {
        List<TagDto> getTags();
        List<TagDto> getTags(int start, int count);

        void AddRecipeToTag(int tagId, int recipeId);

        int CreateTag(TagDto tag);
        int UpdateTag(TagDto tag);
        void DeleteTag(int id);

    }
}
