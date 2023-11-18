using LessonMVVM.Commands;
using LessonMVVM.Services;
using MaterialDesignThemes.Wpf;
using MyStat_Project.ViewModels.WindowViewModels;
using MyStat_Project.Views.Pages;
using MyStat_Project.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    public class ChoosePageViewModel : NotificationService
    {
        public ICommand? EnterMyStatCommand { get; set; }
        public ICommand? EnterLogBookCommand { get; set; }

        public ChoosePageViewModel()
        {
            EnterMyStatCommand = new RelayCommand(EnterMyStat);
            EnterLogBookCommand = new RelayCommand(EnterLogBook);
        }

        public void EnterMyStat(object? parameter)
        {

            var addView = new MyStatMainView();
            addView.DataContext = new MyStatMainViewModel();
            addView.ShowDialog();
        }

        public void EnterLogBook(object? parameter)
        {

            var addView = new LogBookMainView();
            addView.DataContext = new LogBookMainViewModel();
            addView.ShowDialog();
        }
    }
}
