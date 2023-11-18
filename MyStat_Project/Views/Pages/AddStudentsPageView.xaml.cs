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

namespace MyStat_Project.Views.Pages
{
    /// <summary>
    /// Interaction logic for AddStudentsPageView.xaml
    /// </summary>
    public partial class AddStudentsPageView : Page
    {
        public AddStudentsPageView()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMenuPageView());
        }
    }
}
