using LessonMVVM.Commands;
using LessonMVVM.Services;
using MyStat_Project.Models;
using MyStat_Project.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class AllStudentsPageViewModel:NotificationService
    {
        private Admin Admin;
        private Admin admin_1;
        public Academy academies { get => academies1; set { academies1 = value; OnPropertyChanged(); } }
      
        public ICommand? EnterMainMenuCommand { get; set; }
        private Student student1;
        private Academy academies1;
        private Academy_group group1;

        public Academy_group group_ { get => group1; set { group1 = value; OnPropertyChanged(); } }

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public ICommand? BackCommand { get; set; }
        private ObservableCollection<Academy_group> Groups;
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        private IOrderedEnumerable<Student> SortedStudentsAll;
        public IOrderedEnumerable<Student> sortedStudentsAll { get => SortedStudentsAll; set { SortedStudentsAll = value; OnPropertyChanged(); } }
        public AllStudentsPageViewModel(ObservableCollection<Academy_group> groups_, IOrderedEnumerable<Student> SortedStudentsAll_)
        {
            groups = groups_;
            sortedStudentsAll = SortedStudentsAll_;
            BackCommand = new RelayCommand(BackPage);
        }
        public void BackPage(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new AdminMenuPageView();
            MainMenuView.DataContext = new AdminMenuPageViewModel(academies, student_, group_, groups);

            window.NavigationService.Navigate(MainMenuView);

        }
    }
}
