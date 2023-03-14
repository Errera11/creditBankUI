using Microsoft.EntityFrameworkCore;
using MyApp.Data.Interfaces;
using MyApp.Data.Mocks;
using MyApp.Data;
using MyApp.Data.Repository;

using MyApp.Data.Models;
using Microsoft.Extensions.DependencyInjection;


 var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<RazorPagesCreditContext>(options =>
   // options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesCreditContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesCreditContext' not found.")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddDbContext<MyAppDbContext>(options =>
//    options.UseSqlite("Data Source=MyApp.db"));

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddTransient<ICredit, MockCredit>();
builder.Services.AddSingleton<CreditCart>();
builder.Services.AddTransient<ApplyCredit>();
builder.Services.AddSingleton<ClientCredit>();
builder.Services.AddSingleton<AuthRep>();

builder.Services.AddSingleton<AuthModel>();


//builder.Services.AddTransient<ICredit, MockCredit>();
//builder.Services.AddTransient<ICredit, CreditRepository>();
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile("dbsettings.json",
//                       optional: true,
//                       reloadOnChange: true);
//});
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connectionString));



var app = builder.Build();
app.UseSession();

//using (var scope = app.Services.CreateScope())
//{
//    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
//    DBObjects.Initial(content);
//}


app.UseStatusCodePages();
app.UseStaticFiles();
//app.UseMvcWithDefaultRoute();
//app.UseMvc(routes =>
//{
//    routes.MapRoute(name: "Default", template: "{controller=Credits}/{action=List}/{id?}");
//    routes.MapRoute(name: "CreditCart", template: "{controller=CreditCart}/{action=Index}/{id?}");
//});
app.MapControllerRoute(name: "default",
               pattern: "{controller=Credits}/{action=List}/{id?}");
app.MapControllerRoute(name: "CreditCart",
               pattern: "{controller=CreditCart}/{Index}/");
app.Run();

