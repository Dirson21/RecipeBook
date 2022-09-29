using Application.Dto;
using Domain;

namespace Application.Builders
{
    public interface ITagBuilder
    {
        List<Tag> BuildFromTagDto(List<TagDto> tags);
    }
}
