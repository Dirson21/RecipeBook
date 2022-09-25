namespace Domain.UoW
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
