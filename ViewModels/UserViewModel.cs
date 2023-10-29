using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppProject.Models;

namespace WpfAppProject.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<UserModel> userList;

        public UserViewModel()
        {
            InitializeList();
        }

        public ObservableCollection<UserModel> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

        public void InitializeList()
        {
            ObservableCollection<UserModel> list = new ObservableCollection<UserModel>
            {
                new UserModel{ Id=new Guid("3aa0a135-3a35-47a1-88a7-1770860a1a65"), FirstName="Elena", LastName="Kanaki",FullName="Elena Kanaki"  }
            };
            UserList = list;
        }

        public ObservableCollection<UserModel> AddUser(ObservableCollection<UserModel> users,string firstName, string lastName)
        {
            UserModel user = new UserModel { Id = Guid.NewGuid(), FirstName = firstName, LastName = lastName, FullName = firstName + " " + lastName };
            users.Add(user);     
            return users;
        }
        public ObservableCollection<UserModel> RemoveUser(ObservableCollection<UserModel> users, Guid id, string firstName, string lastName)
        {
            UserModel userToRemove =(UserModel)users.Where(x=>x.Id==id && x.FirstName==firstName && x.LastName==lastName).FirstOrDefault();
            users.Remove(userToRemove);
            return users; 
        }
        public ObservableCollection<UserModel> UpdateUser(ObservableCollection<UserModel> users, Guid id, string newFirstName, string newLastName)
        {
            UserModel userToUpdate = (UserModel)users.Where(x => x.Id ==id).FirstOrDefault();
            userToUpdate.FirstName = newFirstName;
            userToUpdate.LastName = newLastName;
            return users;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
