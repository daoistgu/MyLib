namespace MyLib.BookInfoService.Application.Contracts;
public interface IBookinfoService
{
    Task<BookInfoDto> AddBookInfo(Guid id);
}
