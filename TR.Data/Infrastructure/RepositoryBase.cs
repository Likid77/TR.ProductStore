using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TR.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDatabaseFactory _dbFactory;
        DbSet<T> DbSet { get { return _dbFactory.DataContext.Set<T>(); } }

        public RepositoryBase(IDatabaseFactory dbFactory) => _dbFactory = dbFactory;

        public virtual void Add(T entity) => DbSet.Add(entity);

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            _dbFactory.DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity) => DbSet.Remove(entity);

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = DbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                DbSet.Remove(obj);
        }

        public virtual T GetById(long id) => DbSet.Find(id);

        public virtual T GetById(string id) => DbSet.Find(id);

        public IEnumerable<T> GetAll() => DbSet.AsEnumerable();

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null)
        {
            IQueryable<T> myDbSet = DbSet;
            if (condition != null)
                myDbSet = myDbSet.Where(condition);
            return myDbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> where) => DbSet.Where(where).FirstOrDefault<T>();
    }
}
