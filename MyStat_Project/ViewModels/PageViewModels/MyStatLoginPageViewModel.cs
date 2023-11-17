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
        public ObservableCollection<Academy> academies { get; set; }
        public ICommand? EnterMainMenuCommand { get; set; }
        private Student? student1;
        public Student? student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }

        public MyStatLoginPageViewModel()
        {
            string filePath = "../../../DataBase/StepIt.json";
            string jsonData = File.ReadAllText(filePath);
            academies = JsonSerializer.Deserialize<ObservableCollection<Academy>>(jsonData);
            EnterMainMenuCommand = new RelayCommand(Enter, CanEnter);
        }

        public void Enter(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new MainMenuView();
            MainMenuView.DataContext = new MainMenuViewModel(academies);

            window.NavigationService.Navigate(MainMenuView);


        }
        public bool CanEnter(object? parameter)
        {

            bool found = false;

            for (int i = 0; i < academies.Count; i++)
            {
                Academy academy = academies[i];

                for (int j = 0; j < academy.groups.Count; j++)
                {
                    Academy_group group = academy.groups[j];

                    for (int k = 0; k < group.students.Count; k++)
                    {
                        Student student = group.students[k];

                        if (student.username == student_!.username && student.password == student_.password)
                        {

                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }
            student_ = new();
            return found;
        }
    }
}
    

