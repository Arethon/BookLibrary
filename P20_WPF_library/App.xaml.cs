using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using P20_Shared_Library.Configuration;
using P20_Shared_Library.Services;
using P20_WPF_library.ViewModels;
using P20_WPF_library.Views;

namespace P20_WPF_library
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {
        IConfiguration _configuration;
        IServiceProvider _serviceProvider;

        public App()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            _configuration = builder.Build();


            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            var appSettings = ConfigureAppSettings(services);
            ConfigureAppServices(services);
            ConfigureViewModels(services);
            ConfigureViews(services);
            ConfigureHttpClients(services, appSettings);
        }

        private AppSettings ConfigureAppSettings(ServiceCollection services)
        {
            var appSettingsSection = _configuration.GetSection(nameof(AppSettings));
            var settings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection); // zarejestrowanie AppSettings w kontenerze DI
            return settings;
        }

        private void ConfigureHttpClients(ServiceCollection services, AppSettings appSettings)
        {
            // tutaj konfigurujemy HttpClient

            var urliBulder = new UriBuilder(appSettings.BaseApiUrl)
            {
                Path = appSettings.BooksEndpoint.BaseUrl
            };

            //żeby skonfigurować HttpClienta, musimy dodać pakiet Microsoft.Extensions.Http
            services.AddHttpClient<IBooksService, BookService>(client => client.BaseAddress = urliBulder.Uri);
        }

        private void ConfigureViews(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<BookWindowView>();
            services.AddTransient<NewBookWindowView>();
        }

        private void ConfigureViewModels(ServiceCollection services)
        {
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<BookWindowViewModel>();
            services.AddTransient<NewBookWindowViewModel>();
        }

        private void ConfigureAppServices(ServiceCollection services)
        {
            services.AddTransient<IBooksService, BookService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }


}
