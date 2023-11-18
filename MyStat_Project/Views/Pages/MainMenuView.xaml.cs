using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace MyStat_Project.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : Page
    {
        public MainMenuView()
        {
            InitializeComponent();
        }

        private void LogOut_Enter(object sender, MouseEventArgs e)
        {
            Uri uri = new Uri("../../StaticFiles/ImageFiles/hover-logout.png", UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage(uri);
            logout.Source = bitmapImage;
        }

        private void LogOut_Leave(object sender, MouseEventArgs e)
        {
            Uri uri = new Uri("../../StaticFiles/ImageFiles/logout.png", UriKind.Relative);
            BitmapImage bitmapImage = new BitmapImage(uri);
            logout.Source = bitmapImage;
        }

        private void LogOut_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MyStatLoginPageView());
        }
    }
}
