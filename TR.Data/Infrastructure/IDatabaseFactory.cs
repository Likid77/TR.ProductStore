using Microsoft.EntityFrameworkCore;

namespace TR.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        DbContext DataContext { get; }
    }
}
