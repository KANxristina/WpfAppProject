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
         //   userList = UserList;
          //  userList.CollectionChanged += UserList_CollectionChanged;
        }
        //private void UserList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    OnPropertyChanged("UserList");
        //}
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

        public ObservableCollection<UserModel> AddUser(string firstName, string lastName)
        {
            List<UserModel> list = new List<UserModel>
            {
                new UserModel{ Id=Guid.NewGuid(), FirstName =firstName, LastName=lastName, FullName=firstName+" "+lastName }
            };
            foreach (var user in list)
            {
                UserList.Add(user);
            }
            return UserList;

        }
        public ObservableCollection<UserModel> RemoveUser(ObservableCollection<UserModel> userlist, Guid id, string firstName, string lastName)
        {         
            var userToRemove = userlist.Where(x=>x.Id==id && x.FirstName==firstName && x.LastName==lastName).FirstOrDefault();
            userList.Remove(userToRemove);
            return userList;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
