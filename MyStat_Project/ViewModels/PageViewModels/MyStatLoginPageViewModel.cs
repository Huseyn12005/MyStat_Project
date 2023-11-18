using LessonMVVM.Commands;
using LessonMVVM.Services;
using MyStat_Project.Models;
using MyStat_Project.ViewModels.WindowViewModels;
using MyStat_Project.Views.Pages;
using MyStat_Project.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyStat_Project.ViewModels.PageViewModels
{
    public class MyStatLoginPageViewModel : NotificationService
    {
        public Academy academies { get => academies1; set { academies1 = value; OnPropertyChanged(); } }
        private ObservableCollection<Academy_group> Groups;
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        public ICommand? EnterMainMenuCommand { get; set; }
        private Student student1;
        private Academy academies1;
        private Academy_group group1;

        public Academy_group group_ { get => group1; set { group1 = value; OnPropertyChanged(); } }

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }

        public MyStatLoginPageViewModel()
        {
            student_ = new Student();
            var folder = new DirectoryInfo("../../../DataBase");
            var fullPath = Path.Combine(folder.FullName, "StepIt.json");
            var jsonText = File.ReadAllText(fullPath);
            academies = JsonSerializer.Deserialize<Academy>(jsonText);
            groups = new ObservableCollection<Academy_group>(academies!.groups);
            EnterMainMenuCommand = new RelayCommand(Enter, CanEnter);
        }

        public void Enter(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new MainMenuView();
            MainMenuView.DataContext = new MainMenuViewModel(academies,student_,group_);

            window.NavigationService.Navigate(MainMenuView);
            group_ = new();
            student_ = new();
        }
        public bool CanEnter(object? parameter)
        {

            bool found = false;


            for (int j = 0; j < academies.groups.Count; j++)
            {
                Academy_group group = academies.groups[j];

                for (int k = 0; k < group.students.Count; k++)
                {
                    Student student = group.students[k];

                    if (student_.username == student.username && student_.password == student.password)
                    {
                        group_ = group;
                        student_ = student;
                        found = true;
                        break;
                    }
                }
            }

            return found;



        }
    }
}
    

