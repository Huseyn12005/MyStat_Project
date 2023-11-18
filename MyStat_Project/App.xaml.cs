using MyStat_Project.Models;
using MyStat_Project.ViewModels.WindowViewModels;
using MyStat_Project.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyStat_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Main(object sender, StartupEventArgs e)
        {

            // DOWORK

            var mainView = new MainView();
            mainView.DataContext = new MainViewModel();
            mainView.ShowDialog();



        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }
    }
}
