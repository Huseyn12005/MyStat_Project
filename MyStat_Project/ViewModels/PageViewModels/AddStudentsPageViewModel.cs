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
    class AddStudentsPageViewModel:NotificationService
    {
        private Academy academies1;
        public Academy academies { get => academies1; set { academies1 = value; OnPropertyChanged(); } }
        private Academy_group group1;
        public Academy_group group_ { get => group1; set { group1 = value; OnPropertyChanged(); } }
        public ICommand? BackCommand { get; set; }
        private ObservableCollection<Academy_group> Groups;
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        private Student student1;
        private string groupName1;

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public string groupName { get => groupName1; set { groupName1 = value; OnPropertyChanged(); } }
        public ICommand? SaveCommand { get; set; }
        public AddStudentsPageViewModel(Academy academy_, ObservableCollection<Academy_group> groups_)
        {
            academies = academy_;
            student_ = new Student();
            groups = groups_;
            SaveCommand = new RelayCommand(Save, CanSave);
            BackCommand = new RelayCommand(BackPage);
        }
        public void BackPage(object? parameter)
        {
            var window = parameter as Page;
            var MainMenuView = new AdminMenuPageView();
            MainMenuView.DataContext = new AdminMenuPageViewModel(academies, student_, group_, groups);

            window.NavigationService.Navigate(MainMenuView);

        }
        public void Save(object? parameter)
        {
            for (var i = 0; i < groups.Count; i++)
            {
                Academy_group group = groups[i];
                if(groupName == group.name)
                {
                    student_.email = student_.username + "@gmail.com";
                    group.students.Add(student_);
                    break;
                }
            }

            student_ = new();

            var folder = new DirectoryInfo("../../../DataBase");
            var fullPath = Path.Combine(folder.FullName, "StepIt.json");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonText = JsonSerializer.Serialize(academies, options);
            File.WriteAllText(fullPath, jsonText);



        }
        public bool CanSave(object? parameter)
        {
            return !string.IsNullOrEmpty(student_!.name) &&
                !string.IsNullOrEmpty(groupName) &&
                   !string.IsNullOrEmpty(student_!.username) &&
                   !string.IsNullOrEmpty(student_!.surname) &&
                   !string.IsNullOrEmpty(student_!.father) &&
                   !string.IsNullOrEmpty(student_!.password);
        }
    }
}
