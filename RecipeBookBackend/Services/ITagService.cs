using Services.Dto;
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

        TagDto getTagByName(string name);

        void AddRecipeToTag(int tagId, int recipeId);


    }
}
