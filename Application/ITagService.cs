using Application.Dto;

namespace Application
{
    public interface ITagService
    { 
        TagDto GetTagByName(string name);
    }
}
