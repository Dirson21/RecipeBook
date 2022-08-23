using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Infrastructure.Data;
using Application;
using Infrastructure.Data.Models;
using Application.Converters;
using Domain.Repositoy;
using Domain.UoW;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<IUnitOfWork,RecipeBookDbContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString, b => b.MigrationsAssembly("RecipeBookBackend"));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

});



builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddScoped<IRecipeConverter, RecipeConverter>();

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddDefaultIdentity<UserAccount>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<RecipeBookDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
