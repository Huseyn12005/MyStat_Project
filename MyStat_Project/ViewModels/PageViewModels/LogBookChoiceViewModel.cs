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
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class LogBookChoiceViewModel
    {
        public ICommand? EnterAdminCommand { get; set; }
        public ICommand? EnterTeacherCommand { get; set; }
        public LogBookChoiceViewModel()
        {
            EnterAdminCommand = new RelayCommand(EnterAdmin);
            EnterTeacherCommand = new RelayCommand(EnterTeacher);
        }

        public void EnterAdmin(object? parameter)
        {
            var window = parameter as Page;
            var AdminEnterView = new AdminLoginPageView();
            AdminEnterView.DataContext = new AdminLoginPageViewModel();
            window.NavigationService.Navigate(AdminEnterView);
        }

        public void EnterTeacher(object? parameter)
        {

            var window = parameter as Page;
            var TeacherEnterView = new TeacherLoginPageVIew();
            TeacherEnterView.DataContext = new AdminLoginPageViewModel();
            window.NavigationService.Navigate(TeacherEnterView);
        }
    }
}
