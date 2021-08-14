using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TaskingoApp.Services;

namespace TaskingoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ILoginServices, LoginServices>();
            serviceCollection.AddSingleton<ILogger, Logger>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
