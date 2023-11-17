using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MyStat_Project.Models
{
    public class Academy_group : NotificationService
    {
        private Teacher Teacher_;
        private ObservableCollection<Student> Students;
        private string Name;

        public string name
        {
            get => Name;
            set
            {
                Name = value;
                OnPropertyChanged();
            }
        }
        public Guid id { get; set; }

        public Teacher teacher 
        { get => Teacher_;
            set
            {
                Teacher_ = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Student> students 
        { get => Students;
            set {
                Students = value;
                OnPropertyChanged();

            } 
        }

        public Academy_group(string name_, Teacher teacher_,ObservableCollection<Student> student_)
        {
            Name=name_;
            Teacher_ = teacher_;
            Students = student_;
            id = Guid.NewGuid();
        }

        public Academy_group()
        {
            
        }
    }
}
