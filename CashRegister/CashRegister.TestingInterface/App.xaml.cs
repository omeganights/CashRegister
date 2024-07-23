using CashRegister.FileProcessing.Factories.Interfaces;
using CashRegister.FileProcessing.Factories;
using CashRegister.FileProcessing.Services.Interfaces;
using CashRegister.FileProcessing.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CashRegister.TestingInterface
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddScoped<IFileProcessingService, FileProcessingService>();
            services.AddScoped<IChangeCalculatorFactory, ChangeCalculatorFactory>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }

    
}
