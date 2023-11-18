using LessonMVVM.Commands;
using LessonMVVM.Services;
using MyStat_Project.Models;
using MyStat_Project.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class AdminLoginPageViewModel:NotificationService
    {
        private Admin Admin;
        private Admin admin_1;
        public Academy academies { get => academies1; set { academies1 = value; OnPropertyChanged(); } }
        private ObservableCollection<Academy_group> Groups;
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        public ICommand? EnterMainMenuCommand { get; set; }
        private Student student1;
        private Academy academies1;
        private Academy_group group1;

        public Academy_group group_ { get => group1; set { group1 = value; OnPropertyChanged(); } }

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public ICommand? EnterAdminMenuCommand { get; set; }
        public Admin admin { get => Admin; set => Admin = value; }
        public Admin admin_ { get => admin_1; set => admin_1 = value; }
        public AdminLoginPageViewModel()
        {
            admin_ = new();
            admin = new Admin();
            admin.name = "admin";
            admin.surname = "admin";
            admin.email = "admin@gmail.com";
            admin.password = "admin123";
            student_ = new Student();
            var folder = new DirectoryInfo("../../../DataBase");
            var fullPath = Path.Combine(folder.FullName, "StepIt.json");
            var jsonText = File.ReadAllText(fullPath);
            academies = JsonSerializer.Deserialize<Academy>(jsonText);
            groups = new ObservableCollection<Academy_group>(academies!.groups);
            EnterMainMenuCommand = new RelayCommand(Enter, CanEnter);
            EnterAdminMenuCommand = new RelayCommand(Enter, CanEnter);
        }
        public void Enter(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new AdminMenuPageView();
            MainMenuView.DataContext = new AdminMenuPageViewModel(academies, student_, group_, groups);

            window.NavigationService.Navigate(MainMenuView);
            admin_ = new();
        }
        public bool CanEnter(object? parameter)
        {

            
            return admin_.email == admin.email && admin_.password == admin.password;


        }
    }
}

