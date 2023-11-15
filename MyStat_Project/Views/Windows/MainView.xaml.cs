using MyStat_Project.ViewModels.WindowViewModels;
using System.Windows.Navigation;

namespace MyStat_Project.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : NavigationWindow
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
