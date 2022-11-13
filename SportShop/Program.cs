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

app.MapControllerRoute(
      "categoryPage",
      "Products/{category}/Page{productPage:int}",
      new { Controller = "Home", action = "Index" });

app.MapControllerRoute(
      "shoppingCart",
      "Cart",
      new { Controller = "Cart", action = "Index" });

app.MapControllerRoute(
      "category",
      "{category}",
      new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute(
    "pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute(
      "default",
      "/",
      new { Controller = "Home", action = "Index" });

app.MapControllerRoute(
	  "checkout",
	  "Checkout",
	  new { Controller = "Order", action = "Checkout" });

app.MapControllerRoute(
	  "remove",
	  "Remove",
	  new { Controller = "Cart", action = "Remove" });

app.UseSession();

SeedData.EnsurePopulated(app);

app.Run();
