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
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class TeacherLoginPageViewModel:NotificationService
    {
        public Academy academies { get => academies1; set { academies1 = value; OnPropertyChanged(); } }
        private ObservableCollection<Academy_group> Groups;
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        public ICommand? TeacherEnterCommand { get; set; }
        private Student student1;
        private Academy academies1;
        private Academy_group group1;
        private Teacher teacher1;

        public Teacher teacher_ { get => teacher1; set => teacher1 = value; }
        public Academy_group group_ { get => group1; set { group1 = value; OnPropertyChanged(); } }

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public TeacherLoginPageViewModel()
        {
            student_ = new Student();
            teacher_ = new Teacher();
            var folder = new DirectoryInfo("../../../DataBase");
            var fullPath = Path.Combine(folder.FullName, "StepIt.json");
            var jsonText = File.ReadAllText(fullPath);
            academies = JsonSerializer.Deserialize<Academy>(jsonText);
            groups = new ObservableCollection<Academy_group>(academies!.groups);
            TeacherEnterCommand = new RelayCommand(Enter, CanEnter);
        }

        public void Enter(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new TeacherMenuPageView();
            MainMenuView.DataContext = new TeacherMenuPageViewModel(academies, group_, groups);

            window.NavigationService.Navigate(MainMenuView);
            group_ = new();
            teacher_ = new();
        }
        public bool CanEnter(object? parameter)
        {

            bool found = false;


            for (int j = 0; j < academies.groups.Count; j++)
            {
                Academy_group group = academies.groups[j];
                if(group.teacher != null)
                if(teacher_.email == group.teacher.email && teacher_.password == group.teacher.password)
                {
                    group_ = group;
                    found = true;
                    break;
                }

            }

            return found;



        }
    }
}
