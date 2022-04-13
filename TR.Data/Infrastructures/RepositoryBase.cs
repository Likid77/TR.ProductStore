using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TR.Data.Infrastructures
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private IDatabaseFactory _dbFactory;
        DbSet<T> dbSet { get { return _dbFactory.DataContext.Set<T>(); } }

        public RepositoryBase(IDatabaseFactory dbFactory) => _dbFactory = dbFactory;

        public virtual void Add(T entity) => dbSet.Add(entity);

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _dbFactory.DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity) => dbSet.Remove(entity);

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(long id) => dbSet.Find(id);

        public virtual T GetById(string id) => dbSet.Find(id);

        public IEnumerable<T> GetAll() => dbSet.AsEnumerable();

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> myDbSet = dbSet;
            if(where != null)
                myDbSet = myDbSet.Where(where);
            return myDbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> where) => dbSet.Where(where).FirstOrDefault<T>();
    }
}
