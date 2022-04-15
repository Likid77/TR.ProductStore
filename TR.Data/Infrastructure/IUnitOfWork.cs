namespace TR.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IRepositoryBase<T> GetRepository<T>() where T : class;
    }
}
