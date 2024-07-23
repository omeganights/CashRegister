using CashRegister.FileProcessing.Factories;
using CashRegister.FileProcessing.Factories.Interfaces;
using CashRegister.FileProcessing.Services;
using CashRegister.FileProcessing.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddOptions();
builder.Services.AddScoped<IFileProcessingService, FileProcessingService>();
builder.Services.AddScoped<IChangeCalculatorFactory, ChangeCalculatorFactory>();

var app = builder.Build();

app.Run();