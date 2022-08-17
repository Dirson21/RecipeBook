using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ITagService
    {
        List<TagDto> GetTags();

        TagDto GetTagByName(string name);



    }
}
