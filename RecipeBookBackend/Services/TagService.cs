using Domain;
using Application.Dto;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Application.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<TagDto> GetTags()
        {
            return _tagRepository.GetAll().ConvertAll(x => x.ConvertToTagDto());
        }
    }
}
