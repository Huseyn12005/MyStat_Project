using LessonMVVM.Commands;
using LessonMVVM.Services;
using MyStat_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyStat_Project.ViewModels.PageViewModels
{
    class AddStudentsPageViewModel:NotificationService
    {
        private ObservableCollection<Academy_group> Groups;
        public ObservableCollection<Academy_group> groups { get => Groups; set { Groups = value; OnPropertyChanged(); } }
        private Student student1;
        private string groupName1;

        public Student student_ { get => student1; set { student1 = value; OnPropertyChanged(); } }
        public string groupName { get => groupName1; set { groupName1 = value; OnPropertyChanged(); } }
        public ICommand? SaveCommand { get; set; }
        public ICommand? CancelCommand { get; set; }
        public AddStudentsPageViewModel(ObservableCollection<Academy_group> groups_)
        {
            student_ = new Student();
            groups = groups_;
            //SaveCommand = new RelayCommand(Save, CanSave);
            //CancelCommand = new RelayCommand(CancelPage);
        }
    }
}
