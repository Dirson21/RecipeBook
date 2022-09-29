using Application.Converters;
using Application.Dto;
using Domain.Repositoy;
using Domain.UoW;

namespace Application
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public TagDto GetTagByName(string name)
        {
            return _tagRepository.GetByName(name).ConvertToTagDto();
        }
    }
}
