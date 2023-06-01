using MyLib.BookService.Application;
using MyLib.BookService.Common;
using MyLib.BookService.Domain;
using MyLib.BookService.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEfCoreDbContext, BookServiceDbContext>();
builder.Services.AddGrpc();
builder.Services.AddTransient<IRepository<Book, Guid>, Repository<Book, Guid>>();
var app = builder.Build();
app.MapGrpcService<BookManagementGrpcService>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
