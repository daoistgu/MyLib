using MyLib.BookInfoService.Application.Contracts;
using MyLib.BookInfoService.Common;
using MyLib.BookInfoService.Domain;
using MyLib.BookService.Grpc;

namespace MyLib.BookInfoService.Application;
public class BookInfoService : IBookinfoService
{
    private readonly BookManagementGrpc.BookManagementGrpcClient _client;
    private readonly IRepository<BookInfo, Guid> _repository;

    public BookInfoService(IRepository<BookInfo, Guid> repository, BookManagementGrpc.BookManagementGrpcClient client)
    {
        _repository = repository;
        _client = client;
    }
    public async Task<BookInfoDto> AddBookInfo(Guid id)
    {

        var request = await _client.GetBookAsync(new GetBookGrpcRequest { Id = id.ToString() });
        var bookInfo = new BookInfo()
        {

            Title = request.Title,
            Name = request.Name,
            Author = "Artur",
            Price = 200,
            Count = 2,
            Description = "Good",
            Id = new Guid(),
            BookId = id,
        };
        var bookInfoDto = new BookInfoDto()
        {
            Title = request.Title,
            Name = request.Name,
            Author = "Artur",
            Price = 200,
            Count = 2,
            Description = "Good",
        };
        await _repository.InsertAsync(bookInfo);
        return bookInfoDto;
    }
}
