﻿
using MyLib.BookInfoService.Common;

namespace MyLib.BookInfoService.Domain;
public class BookInfo : Entity<Guid>
{
    public Guid BookId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}
