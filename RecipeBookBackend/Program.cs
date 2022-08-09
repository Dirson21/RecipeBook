
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddScoped<IRecipeService, RecipeService>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
