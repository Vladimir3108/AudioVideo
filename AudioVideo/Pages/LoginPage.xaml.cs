﻿using System;
using System.Collections.Generic;
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

namespace AudioVideo.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            App.CurrentUser = null;
        }


        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TechniquePage());
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = App.AudioSalon.User.Where(p => p.Login == TBoxLogin.Text && p.Password == PBoxPassword.Password)
                .FirstOrDefault();
            if (currentUser != null)
            {
                App.CurrentUser= currentUser;
                NavigationService.Navigate(new TechniquePage());
            }
            else
            {
                MessageBox.Show("Пользователь не найден.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
