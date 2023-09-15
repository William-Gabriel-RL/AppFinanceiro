using Data.Interfaces;
using Data.Repositories;
using Services;
using Services.Interfaces;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICardRepository, CardRepository>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<ICardTypeRepository, CardTypeRepository>();
builder.Services.AddTransient<ICardTypeService, CardTypeService>();
builder.Services.AddTransient<IPeopleRepository, IPeopleRepository>();
builder.Services.AddTransient<IPeopleService, PeopleService>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
