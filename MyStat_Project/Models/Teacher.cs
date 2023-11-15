using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStat_Project.Models
{
    public class Teacher : NotificationService
    {
        private Guid Id;
        private string? Name;
        private string? Surname;
        private string? Email;
        private string? Password;

        public string email
        {
            get => Email;
            set
            {
                Email = value;
                OnPropertyChanged();
            }
        }

        public string password
        {
            get => Password;
            set
            {
                Password = value;
                OnPropertyChanged();
            }
        }

        public Guid id
        {
            get => Id;
            set
            {
                Id = value;
                OnPropertyChanged();
            }
        }
        public string name
        {
            get => Name!;
            set
            {
                Name = value;
                OnPropertyChanged();
            }
        }
        public string surname
        {
            get => Surname!;
            set
            {
                Surname = value;
                OnPropertyChanged();
            }
        }

        public Teacher(string name_,string surname_, string? email_, string? password_)
        {
            Name = name_;
            Surname = surname_;
            Email = email_;
            Password = password_;
        }

        public Teacher()
        {
            
        }
    }
}
