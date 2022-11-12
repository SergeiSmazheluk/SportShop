using Microsoft.EntityFrameworkCore;
using SportShop.Context.Business;
using SportShop.Context.Data;
using SportShop.Context.Data.Repositories;
using SportShop.Domain.Interfaces;
using SportShop.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryDbContext>(opts => 
{
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();

builder.Services.AddTransient<IServiceManager, ServiceManager>();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "pagination",
    pattern: "Products/Page{productPage:int}",
    defaults: new { Controller = "Home", action = "Index", productPage = 1 });

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
