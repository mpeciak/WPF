using BHP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BHP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // laczymy MainWindow z MainWindowViewModel
            MainWindow window = new MainWindow();
            window.DataContext = new MainWindowViewModel();
            window.Show();
        }
        
    }
}
