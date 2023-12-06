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
    /// Логика взаимодействия для TechniquePage.xaml
    /// </summary>
    public partial class TechniquePage : Page
    {
        public TechniquePage()
        {
            
            InitializeComponent();
            update();
            if (App.CurrentUser == null)
                BtnAdd.Visibility = Visibility.Hidden;
            else if (App.CurrentUser.RoleID == 2)
                BtnAdd.Visibility = Visibility.Hidden;

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage((sender as Button).DataContext as Catalog));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var DelTech = (sender as Button).DataContext as Catalog;
            if(MessageBox.Show($"Вы уверены ,что хотите удалить данный товар {DelTech.Name}?","Уведомление",MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                App.AudioSalon.Catalog.Remove(DelTech);
                App.AudioSalon.SaveChanges();
                update();
            }
        }

        private void update()
        {
            ListTechnique.ItemsSource = App.AudioSalon.Catalog.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(null));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться назад?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }
    }
}
