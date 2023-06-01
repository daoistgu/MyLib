using Microsoft.EntityFrameworkCore;
using MyLib.BookInfoService.Common;
using MyLib.BookInfoService.Domain;

namespace MyLib.BookInfoService.EntityFrameworkCore;
public class BookInfoServiceDbContext : DbContext, IEfCoreDbContext
{
    public BookInfoServiceDbContext()
    {
        
    }
    public const string ConnectionString =
  "host=localhost;" +
  "port=5432;" +
  "User ID=postgres;" +
  "password=123;" +
  "database=BookInfoServiceDb;";
    public DbSet<BookInfo> Bookinfos { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }
}
