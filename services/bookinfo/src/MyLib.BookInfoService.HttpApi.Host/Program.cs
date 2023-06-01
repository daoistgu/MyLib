using MyLib.BookInfoService.Application.Contracts;
using MyLib.BookInfoService.Application;
using MyLib.BookInfoService.Common;
using MyLib.BookInfoService.EntityFrameworkCore;
using MyLib.BookService.Grpc;
using MyLib.BookInfoService.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEfCoreDbContext, BookInfoServiceDbContext>();
builder.Services.AddGrpcClient<BookManagementGrpc.BookManagementGrpcClient>(cfg =>
{
    //
    //7234
    //5066
    cfg.Address = new Uri("https://localhost:7234");
});
builder.Services.AddTransient<IRepository<BookInfo,Guid>,Repository<BookInfo,Guid>>();
builder.Services.AddTransient<IBookinfoService,BookInfoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
