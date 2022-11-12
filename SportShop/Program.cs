using Microsoft.EntityFrameworkCore;
using SportShop.Context.Data;
using SportShop.Context.Data.Repositories;
using SportShop.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryDbContext>(opts => 
{
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

builder.Services.AddTransient<IRepositoryManager, RepositoryManager>();

var app = builder.Build();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
