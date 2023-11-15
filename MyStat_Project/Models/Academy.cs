using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyStat_Project.Models
{
    public class Academy:NotificationService
    {
        private ObservableCollection<Academy_group> Groups;

        public ObservableCollection<Academy_group> groups
        { get => Groups;
            set
            {
                Groups = value;
                OnPropertyChanged();
            }
        }

        public Academy(ObservableCollection<Academy_group> groups_)
        {
            Groups = groups_;
        }

        public Academy()
        {
            
        }
    }
}
