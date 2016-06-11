namespace MyUp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}