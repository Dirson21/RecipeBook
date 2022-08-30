using Application.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builders
{
    public interface ITagBuilder
    {
        List<Tag> buildFromTagDto(List<TagDto> tags);
    }
}
