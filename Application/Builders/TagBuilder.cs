using Application.Converters;
using Application.Dto;
using Domain;
using Domain.Repositoy;

namespace Application.Builders
{
    public class TagBuilder : ITagBuilder
    {
        private readonly ITagRepository _tagRepository;

        public TagBuilder(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public List<Tag> BuildFromTagDto(List<TagDto> tags)
        {
            var result = new List<Tag>();

            if (tags != null)
            {
                var uniqueTags = tags.Distinct();
                foreach (var tagDto in uniqueTags)
                {
                    Tag tag = _tagRepository.GetByName(tagDto.Name);
                    if (tag != null)
                    {
                        result.Add(tag);
                    }
                    else
                    {
                        result.Add(tagDto.ConvertToTag());
                    }
                }
            }
            return result;
        }
    }
}
