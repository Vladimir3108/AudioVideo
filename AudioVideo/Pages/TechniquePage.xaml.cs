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
            ListTechnique.ItemsSource = App.AudioSalon.Catalog.ToList();
            if(App.CurrentUser == null)
                BtnAdd.Visibility = Visibility.Hidden;
            else if (App.CurrentUser.RoleID == 2)
                BtnAdd.Visibility = Visibility.Hidden;

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

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
