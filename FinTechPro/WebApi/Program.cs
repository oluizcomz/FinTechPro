using Domain.Interfaces.IAccount;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IUser;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IGenerics;
using Entities;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces.ICategoryService;
using Domain.Services.CategoryService;
using Domain.Interfaces.IExpenseService;
using Domain.Interfaces.IAccountService;
using Domain.Services.ExpenseService;
using Domain.Services.AccountService;
using Domain.Interfaces.IUserService;
using Domain.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();
 
// Interface and Repository
builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<ICategory, RepositoryCategory>();
builder.Services.AddSingleton<IExpense, RepositoryExpense>();
builder.Services.AddSingleton<IAccount, RepositoryAccount>();
builder.Services.AddSingleton<IUser, RepositoryUser>();



// Servece and Domain
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton< IExpenseService, ExpenseService > ();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IUserService, UserService>();

//Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Teste.Securiry.Bearer",
            ValidAudience = "Teste.Securiry.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
        };

        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
/* if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
//}
var devClient = "http://localhost:4200";

app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devClient));
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
