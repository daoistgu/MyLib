using Grpc.Core;
using MyLib.BookService.Common;
using MyLib.BookService.Domain;
using MyLib.BookService.Grpc;

namespace MyLib.BookService.Application;
public class BookManagementGrpcService : BookManagementGrpc.BookManagementGrpcBase
{
    private readonly IRepository<Book, Guid> _repository;

    public BookManagementGrpcService(IRepository<Book, Guid> repository)
    {
        _repository = repository;
    }

    public async override Task<GetBookGrpcResponse> GetBook(GetBookGrpcRequest request, ServerCallContext context)
    {
        var book = await _repository.GetAsync(Guid.Parse(request.Id));
        return new GetBookGrpcResponse
        {
            Name = book.Name,
            Title = book.Title
        };
    }
}
