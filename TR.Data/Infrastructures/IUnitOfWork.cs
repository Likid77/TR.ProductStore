using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Data.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IRepositoryBase<T> GetRepository<T>() where T : class;
    }
}
