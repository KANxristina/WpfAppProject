
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppProject.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Guid id;
        private string firstName;
        private string lastName;
        private string fullName;
         
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyRaised("FirstName");
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyRaised("LastName");
            }

        }
         public string FullName
        {
            get { return fullName=firstName+" "+lastName; }
            set 
            {
                fullName = value;
                OnPropertyRaised("FullName");
            }
        }
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
