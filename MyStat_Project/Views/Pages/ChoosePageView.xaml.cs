using MyStat_Project.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace MyStat_Project.Views.Pages
{
    /// <summary>
    /// Interaction logic for ChoosePageView.xaml
    /// </summary>
    public partial class ChoosePageView : Page
    {
        public ChoosePageView()
        {
            InitializeComponent();
            DataContext = new ChoosePageViewModel();
        }
    }
}
