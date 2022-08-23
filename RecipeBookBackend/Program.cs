using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Infrastructure.Data;
using Application;
using Infrastructure.Data.Models;
using Application.Converters;
using Domain.Repositoy;
using Domain.UoW;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain;
using Domain.Repository;
using RecipeBookBackend;
using Application.Options;
using System.Text;

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

builder.Services.AddDefaultIdentity<UserAccount>(options => 
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
  
    options.Password.RequiredLength = 5;   // минимальна€ длина
    options.Password.RequireNonAlphanumeric = false;   // требуютс€ ли не алфавитно-цифровые символы
    options.Password.RequireLowercase = false; // требуютс€ ли символы в нижнем регистре
    options.Password.RequireUppercase = false; // требуютс€ ли символы в верхнем регистре
    options.Password.RequireDigit = false; // требуютс€ ли цифры
    options.SignIn.RequireConfirmedAccount = true; 

}).AddEntityFrameworkStores<RecipeBookDbContext>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserAccountConverter, UserAccountConverter>();

builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

Console.WriteLine(builder.Configuration["TokenKey"]);

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироватьс€ издатель при валидации токена
            ValidateIssuer = true,
            // строка, представл€юща€ издател€
            ValidIssuer = AuthOptions.ISSUER,
            // будет ли валидироватьс€ потребитель токена
            ValidateAudience = true,
            // установка потребител€ токена
            ValidAudience = AuthOptions.AUDIENCE,
            // будет ли валидироватьс€ врем€ существовани€
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = key,
            // валидаци€ ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });


builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
