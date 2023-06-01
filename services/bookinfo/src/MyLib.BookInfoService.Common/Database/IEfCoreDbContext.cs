using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace MyLib.BookInfoService.Common;
public interface IEfCoreDbContext : IDbContext
{
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Update<T>(T entity) where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
