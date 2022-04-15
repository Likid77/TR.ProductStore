using Microsoft.EntityFrameworkCore;

namespace TR.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContext _dataContext;
        public DbContext DataContext { get { return _dataContext; } }
        public DatabaseFactory() { _dataContext = new TRContext(); }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
