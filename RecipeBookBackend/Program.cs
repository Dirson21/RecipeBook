using Application;
using Application.Builders;
using Application.Converters;
using Application.Options;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain;
using Domain.Repository;
using Domain.Repositoy;
using Domain.UoW;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipeBookBackend.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<IUnitOfWork, RecipeBookDbContext>(c =>
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

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
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

    options.Password.RequiredLength = 0;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<RecipeBookDbContext>();

builder.Services.AddTransient<IPasswordValidator<UserAccount>,
    UserPasswordValidator>(serv => new UserPasswordValidator(8));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserAccountConverter, UserAccountConverter>();
builder.Services.AddScoped<ITagBuilder, TagBuilder>();
builder.Services.AddScoped<IRecipeActionBuilder, RecipeActionBuilder>();

builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

Console.WriteLine(builder.Configuration["TokenKey"]);

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = key,
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler("/error");

app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
