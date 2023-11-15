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
        private ObservableCollection<Student> Student_;
        public Guid id { get; set; }

        public Teacher teacher 
        { get => Teacher_;
            set
            {
                Teacher_ = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Student> student 
        { get => Student_;
            set {
                Student_ = value;
                OnPropertyChanged();

            } 
        }

        public Academy_group(Teacher teacher_,ObservableCollection<Student> student_)
        {
            Teacher_ = teacher_;
            Student_ = student_;
            id = Guid.NewGuid();
        }

        public Academy_group()
        {
            
        }
    }
}
