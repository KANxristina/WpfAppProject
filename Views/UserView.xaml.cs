﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppProject.Models;
using WpfAppProject.ViewModels;

namespace WpfAppProject.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private UserViewModel userViewModel;
        private ObservableCollection<UserModel> userlist;
        public UserView()
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
            userlist=new ObservableCollection<UserModel>();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newList = userViewModel.AddUser(txtFirstName.Text, txtLastName.Text);
            cbUsers.ItemsSource = null;
            cbUsers.ItemsSource = newList;
            userlist = newList;

        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel userViewModel = new UserViewModel();
            UserModel user = (UserModel)cbUsers.SelectedItem;
            
            var newList = userViewModel.RemoveUser(userlist,user.Id,txtFirstName.Text, txtLastName.Text);
            cbUsers.ItemsSource = null;
            cbUsers.ItemsSource = newList;
        }
    }
}
