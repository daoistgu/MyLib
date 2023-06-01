using Microsoft.EntityFrameworkCore;
using MyLib.BookService.Common;
using MyLib.BookService.Domain;

namespace MyLib.BookService.EntityFrameworkCore;
public class BookServiceDbContext : DbContext, IEfCoreDbContext
{
    public BookServiceDbContext()
    {

    }
    public const string ConnectionString =
  "host=localhost;" +
  "port=5432;" +
  "User ID=postgres;" +
  "password=123;" +
  "database=BookServiceDb;";
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }
}
