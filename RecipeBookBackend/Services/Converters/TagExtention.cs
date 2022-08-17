using Domain;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Converters
{
    public static class TagExtention
    {
        public static TagDto ConvertToTagDto (this Tag tag)
        {
            
            return new TagDto
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public static Tag ConvertToTag(this TagDto tagDto)
        {
            return new Tag
            {
                Id = tagDto.Id,
                Name = tagDto.Name
            };
        }
    }
}
