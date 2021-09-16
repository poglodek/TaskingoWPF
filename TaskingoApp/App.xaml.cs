using System.Windows;
using TaskingoApp.Config;

namespace TaskingoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            new ConfigReader().ReadConfig();
            MyMapper.Initialize();
        }
    }


}
