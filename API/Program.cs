using AutoMapper;
using CrossCutting.Profiles;
using Data.Context;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Services;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddDbContext<AppFinanceiroContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("AppFinanceiro")));
builder.Services.AddAutoMapper(typeof(PeopleProfile), typeof(AccountProfile), typeof(CardProfile), typeof(TransactionProfile));

builder.Services.AddTransient<IMapper, Mapper>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<IPeopleRepository, PeopleRepository>();
builder.Services.AddTransient<IPeopleService, PeopleService>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
