using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStat_Project.Models
{
    public class Student : NotificationService
    {
        private string? Name;
        private string? Surname;
        private string? Father;
        private string? Username;
        private string? Email;
        private int Diamonds;
        private int Coins;
        private ObservableCollection<int>? Marks;
        private string? Password;

        public string password
        {
            get => Password;
            set
            {
                Password = value;
                OnPropertyChanged();
            }
        }
  
        public ObservableCollection<int> marks
        {
            get => Marks!;
            set
            {
                Marks = value;
                OnPropertyChanged();
            }
        }

        public string username
        {
            get => Username;
            set
            {
                Username = value;
                OnPropertyChanged();
            }
        }
        public string email
        {
            get => Email;
            set
            {
                Email = value;
                OnPropertyChanged();
            }
        }
        public int diamonds
        {
            get => Diamonds;
            set
            {
                Diamonds = value;
                OnPropertyChanged();
            }
        }
        public int coins
        {
            get => Coins;
            set
            {
                Coins = value;
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

        public string father
        {
            get => Father!;
            set
            {
                Father = value;
                OnPropertyChanged();
            }
        }

        public Student(string name_, string surname_, string father_, string username_)
        {

            Name = name_;
            Surname = surname_;
            Father = father_;
            Username = username_;
            Email = username_ + "gmail.com";
            Diamonds = 0;
            Coins = 0;
            Marks = new ObservableCollection<int>();
        }
        public override string ToString() => $"{name} {username} {father}";
        public Student()
        {
            Name = null;
            Surname = null;
            Father = null;
            Username = null;
            Email = null;
            Diamonds = 0;
            Coins = 0;
            Marks = new ObservableCollection<int>();
        }
    }
}
