using LessonMVVM.Services;
using MyStat_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class MainMenuViewModel : NotificationService
    {
        private Academy academy1;
        private Student student1;
        private Academy_group currentGroup;
        private int Total;

        public Academy academy { get => academy1; set { academy1 = value; OnPropertyChanged(); } }

        public Student CurrentStudent { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public Academy_group CurrentGroup { get => currentGroup; set { currentGroup = value; OnPropertyChanged(); } }
        public int total { get => Total; set { Total = value; OnPropertyChanged(); } }
        public MainMenuViewModel(Academy academy_, Student student_, Academy_group group_)
        {
            academy = academy_;
            CurrentStudent = student_;
            CurrentGroup = group_;
            total = CurrentStudent.diamonds + CurrentStudent.coins;
        }



    }
}
