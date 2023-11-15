using MyStat_Project.ViewModels.PageViewModels;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyStat_Project.Views.Pages
{
    /// <summary>
    /// Interaction logic for MyStatLoginPageView.xaml
    /// </summary>
    public partial class MyStatLoginPageView : Page
    {
        public MyStatLoginPageView()
        {
            InitializeComponent();
            DataContext = new MyStatLoginPageViewModel();

            
        }

    }
}
