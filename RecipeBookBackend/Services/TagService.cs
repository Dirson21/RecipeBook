using Domain;
using Services.Dto;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Services.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositoy;

namespace Services
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagRepository;
        private readonly RecipeBookDbContext _dbContext;

        public TagService(ITagRepository tagRepository, RecipeBookDbContext dbContext)
        {
            _tagRepository = tagRepository;
            _dbContext = dbContext;
        }

        public TagDto getTagByName(string name)
        {
            return _tagRepository.GetByName(name).ConvertToTagDto();
        }

        public List<TagDto> getTags()
        {
            return _tagRepository.GetAll().ConvertAll(x => x.ConvertToTagDto());
        }
    }
}
