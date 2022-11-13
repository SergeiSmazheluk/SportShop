using Microsoft.EntityFrameworkCore;
using SportShop.Context.Business;
using SportShop.Context.Data;
using SportShop.Context.Data.Repositories;
using SportShop.Domain.Interfaces;
using SportShop.Infrastructure;
using SportShop.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();

builder.Services.AddTransient<IServiceManager, ServiceManager>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

builder.Services.AddTransient<CartFeatures>(SessionCart.GetCart);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

app.MapControllerRoute(
	name: "categoryPage",
	pattern: "Products/{category}/Page{productPage:int}",
	defaults: new { Controller = "Home", action = "Index" });

app.MapControllerRoute(
	name: "shoppingCart",
	pattern: "Cart",
	defaults: new { Controller = "Cart", action = "Index" });

app.MapControllerRoute(
	name: "category",
	pattern: "Products/{category}",
	defaults: new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute(
	name: "pagination",
	pattern: "Products/Page{productPage:int}",
	defaults: new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute(
	name: "default",
	pattern: "/",
	defaults: new { Controller = "Home", action = "Index" });

app.MapControllerRoute(
	name: "checkout",
	pattern: "Checkout",
	defaults: new { Controller = "Order", action = "Checkout" });

app.MapControllerRoute(
	name: "remove",
	pattern: "Remove",
	defaults: new { Controller = "Cart", action = "Remove" });

SeedData.EnsurePopulated(app);

app.Run();

