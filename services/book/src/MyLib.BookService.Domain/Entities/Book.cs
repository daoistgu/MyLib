using MyLib.BookService.Common;
namespace MyLib.BookService.Domain;
public class Book : Entity<Guid>
{
    public string Name { get; set; }
    public string Title { get; set; }
}
