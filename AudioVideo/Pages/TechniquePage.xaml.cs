using System;
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
            TextSort.SelectedIndex = 0;
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

        public void update()
        {
            var Tech = App.AudioSalon.Catalog.ToList();

            Tech = Tech.Where(p => p.Name.ToLower().Contains(TextSearch.Text.ToLower())).ToList();

            if (TextSort.SelectedIndex == 1)
            {
                Tech = Tech.OrderBy(p => p.SellingPrice).ToList();
            }
            else if(TextSort.SelectedIndex == 2)
            {
                Tech = Tech.OrderByDescending(p => p.SellingPrice).ToList();
            }
            else
            {
                Tech = Tech.ToList();
            }

            ListTechnique.ItemsSource = Tech;
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                App.AudioSalon.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListTechnique.ItemsSource = App.AudioSalon.Catalog.ToList();
            }
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void TextSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void BtnApp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationPage());
        }

        private void BtnUserApp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationUserPage((sender as Button).DataContext as Catalog));
        }
    }
}
