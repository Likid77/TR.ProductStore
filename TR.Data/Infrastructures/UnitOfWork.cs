using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly IDatabaseFactory _dbFactory;

        public UnitOfWork(IDatabaseFactory dbFactory) => _dbFactory = dbFactory;

        public void Commit() => _dbFactory.DataContext.SaveChanges();
        
        public IRepositoryBase<T> GetRepository<T>() where T : class => new RepositoryBase<T>(_dbFactory);

        public void Dispose() => _dbFactory.Dispose();        

    }
}
