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
    class TeacherMenuPageViewModel:NotificationService
    {
        public string[] marks { get; set; }
        public string[] christals { get; set; }
        private Academy academy1;
        private Student student1;
        private Academy_group currentGroup;
        private IOrderedEnumerable<Student> studentss;
        public IOrderedEnumerable<Student> sortedStudentsAll { get => SortedStudentsAll; set { SortedStudentsAll = value; OnPropertyChanged(); } }

        public Academy academy { get => academy1; set { academy1 = value; OnPropertyChanged(); } }

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public Academy_group CurrentGroup { get => currentGroup; set { currentGroup = value; OnPropertyChanged(); } }
        public IOrderedEnumerable<Student> SortedStudents { get => studentss; set { studentss = value; OnPropertyChanged(); } }
        private ObservableCollection<Academy_group> Groups;
        private IOrderedEnumerable<Student> SortedStudentsAll;
        private int mark1;
        private int christal1;

        public ICommand? BackCommand { get; set; }
        public ICommand? SaveCommand { get; set; }
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        public int mark_ { get => mark1; set => mark1 = value; }
        public int christal_ { get => christal1; set => christal1 = value; }
        public TeacherMenuPageViewModel(Academy academy_,Academy_group group_,ObservableCollection<Academy_group> groups_)
        {
            student_ = new();
            academy = academy_;
            CurrentGroup = group_;
            SortedStudents = CurrentGroup.students.OrderByDescending(student => student.diamonds + student.coins);
            BackCommand = new RelayCommand(BackPage);
            SaveCommand = new RelayCommand(Save, CanSave);
            marks = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            christals = new string[]{ "1", "2", "3"};
        }

        public void BackPage(object? parameter)
        {
            var window = parameter as Page;
            var TeacherEnterView = new TeacherLoginPageVIew();
            TeacherEnterView.DataContext = new TeacherLoginPageViewModel();
            window.NavigationService.Navigate(TeacherEnterView);

        }

        public void Save(object? parameter)
        {
            for(var i = 0; i < CurrentGroup.students.Count(); i++)
            {
                Student studentt = CurrentGroup.students[i];
                if(student_ == studentt)
                {
                    studentt.diamonds += christal_;
                    studentt.total += christal_;
                    studentt.marks.Add(mark_);

                    if(mark_ == 12)
                    {
                        studentt.coins += 5;
                        studentt.total += 5;
                    }
                    else if (mark_ == 11)
                    {
                        studentt.coins += 4;
                        studentt.total += 4;
                    }
                    else if (mark_ == 10)
                    {
                        studentt.coins += 3;
                        studentt.total += 3;
                    }
                    else if (mark_ == 9)
                    {
                        studentt.coins += 2;
                        studentt.total += 2;
                    }
                    else if (mark_ == 8)
                    {
                        studentt.coins += 1;
                        studentt.total += 1;
                    }
                }
            }

            student_ = new();
            mark_ = new();
            christal_ = new();

            var folder = new DirectoryInfo("../../../DataBase");
            var fullPath = Path.Combine(folder.FullName, "StepIt.json");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonText = JsonSerializer.Serialize(academy, options);
            File.WriteAllText(fullPath, jsonText);



        }
        public bool CanSave(object? parameter)
        {
            return !string.IsNullOrEmpty(student_!.name) &&
                !(mark_ == 0) &&
                   !(christal_==0);
        }
    }
}
