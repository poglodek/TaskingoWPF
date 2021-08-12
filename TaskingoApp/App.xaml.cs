using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
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
