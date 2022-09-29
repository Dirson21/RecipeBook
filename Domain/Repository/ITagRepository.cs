namespace Domain.Repositoy
{
    public interface ITagRepository
    {
        Tag GetById(int tagId);
        Tag GetByName(string name);
    }
}
