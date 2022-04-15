using System.Linq.Expressions;
using TR.Data.Infrastructure;

namespace TR.ServicePattern
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork utwk = new UnitOfWork(factory);
        public Service(IUnitOfWork unitOfWork) { utwk = unitOfWork; }
        //private readonly IUnitOfWork utwk; // private par défaut (optionnelle)

        public virtual void Add(TEntity entity) => utwk.GetRepository<TEntity>().Add(entity);
        public virtual void Update(TEntity entity) => utwk.GetRepository<TEntity>().Update(entity);
        public virtual void Delete(TEntity entity) => utwk.GetRepository<TEntity>().Delete(entity);
        public virtual void Delete(Expression<Func<TEntity, bool>> where) => utwk.GetRepository<TEntity>().Delete(where);
        public virtual TEntity GetById(long id) => utwk.GetRepository<TEntity>().GetById(id);
        public virtual TEntity GetById(string id) => utwk.GetRepository<TEntity>().GetById(id);
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null) => utwk.GetRepository<TEntity>().GetMany(filter);
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where) => utwk.GetRepository<TEntity>().Get(where);
        public virtual void Dispose() => utwk.Dispose();
        public void Commit()
        { try { utwk.Commit(); } catch (Exception ex) { throw; } }

    }
}
