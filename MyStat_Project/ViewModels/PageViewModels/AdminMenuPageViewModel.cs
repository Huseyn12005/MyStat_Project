using LessonMVVM.Commands;
using MyStat_Project.Models;
using MyStat_Project.ViewModels.WindowViewModels;
using MyStat_Project.Views.Pages;
using MyStat_Project.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LessonMVVM.Services;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class AdminMenuPageViewModel:NotificationService
    {
        private Academy academy1;
        private Student student1;
        private Academy_group currentGroup;
        private int Total;
        private IOrderedEnumerable<Student> students;
        public IOrderedEnumerable<Student> sortedStudentsAll { get => SortedStudentsAll; set { SortedStudentsAll = value; OnPropertyChanged(); } }

        public Academy academy { get => academy1; set { academy1 = value; OnPropertyChanged(); } }

        public Student CurrentStudent { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public Academy_group CurrentGroup { get => currentGroup; set { currentGroup = value; OnPropertyChanged(); } }
        public IOrderedEnumerable<Student> SortedStudents { get => students; set { students = value; OnPropertyChanged(); } }
        private ObservableCollection<Academy_group> Groups;
        private IOrderedEnumerable<Student> SortedStudentsAll;

        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        private Admin Admin;

        public ICommand? AllStudentsCommand { get; set; }
        public ICommand? AddStudentsCommand { get; set; }
        public Admin admin { get => Admin; set => Admin = value; }

        public AdminMenuPageViewModel(Academy academy_, Student student_, Academy_group group_, ObservableCollection<Academy_group> groups_)
        {
            academy = academy_;
            CurrentStudent = student_;
            CurrentGroup = group_;

            groups = groups_;
            SortedStudentsAll = groups.SelectMany(group => group.students).OrderByDescending(student => student.diamonds + student.coins);
            AllStudentsCommand = new RelayCommand(EnterAllStudents);
            AddStudentsCommand = new RelayCommand(EnterAddStudents);
        }

        public void EnterAllStudents(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new AllStudentsPageView();
            MainMenuView.DataContext = new AllStudentsPageViewModel(groups, SortedStudentsAll);

            window.NavigationService.Navigate(MainMenuView);

        }

        public void EnterAddStudents(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new AddStudentsPageView();
            MainMenuView.DataContext = new AddStudentsPageViewModel(groups);

            window.NavigationService.Navigate(MainMenuView);

        }
    }
}
