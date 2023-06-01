using Microsoft.AspNetCore.Mvc;
using MyLib.BookInfoService.Application.Contracts;

namespace MyLib.BookInfoService.HttpApi.Host;
[Route("bookinfo")]
public class BookInfoController : ControllerBase
{
    private readonly IBookinfoService _bookinfoService;

    public BookInfoController(IBookinfoService bookinfoService)
    {
        _bookinfoService = bookinfoService;
    }
    [HttpPost("addBookInfo/{id}")]
    public async Task<IActionResult> AddBookInfoAsync(Guid id)
    {
        var item = await _bookinfoService.AddBookInfo(id);
        return Ok(item);
    }
}
