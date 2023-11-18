using LessonMVVM.Commands;
using MyStat_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class AdminLoginPageViewModel
    {
        private Admin Admin;
        public ICommand? EnterAdminMenuCommand { get; set; }
        public Admin admin { get => Admin; set => Admin = value; }
        public AdminLoginPageViewModel()
        {
            admin = new Admin();
            admin.name = "admin";
            admin.surname = "admin";
            admin.email = "admin@gmail.com";
            admin.password = "admin123";
            EnterAdminMenuCommand = new RelayCommand(Enter, CanEnter);
        }
        public void Enter(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new MainMenuView();
            MainMenuView.DataContext = new MainMenuViewModel(academies, student_, group_, groups);

            window.NavigationService.Navigate(MainMenuView);
            group_ = new();
            student_ = new();
        }
        public bool CanEnter(object? parameter)
        {

            



        }
    }
}

