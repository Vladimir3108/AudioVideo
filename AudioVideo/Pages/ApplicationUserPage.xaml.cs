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
    /// Логика взаимодействия для ApplicationUserPage.xaml
    /// </summary>
    public partial class ApplicationUserPage : Page
    {
        Catalog _catalog = new Catalog();
        Applications _applications = new Applications();
        public ApplicationUserPage(Catalog correctCatalog)
        {
            InitializeComponent();

            if (correctCatalog != null)
            {
                _catalog = correctCatalog;
            }

            DataContext = _catalog;
        }

        public ApplicationUserPage(Applications correctApplication)
        {
            InitializeComponent();
            _applications = correctApplication;
            DataContext= _applications;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите вернуться назад?", "Уведомление",MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                NavigationService.GoBack();
            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder= new StringBuilder();
            if(String.IsNullOrEmpty(TxtDescription.Text)) 
            {
                stringBuilder.AppendLine("Введите причину возврата");
            }
            if (stringBuilder.Length > 0)
            {
                MessageBox.Show(stringBuilder.ToString());
                return;
            }
            if(_applications.ApplicationID == 0)
            {
                //var applications = new Applications
                //{
                //    UserID = App.CurrentUser.UserID,
                //    CatalogID = _catalog.CatalogID,
                //    Description = TxtDescription.Text
                //};
                App.AudioSalon.Applications.Add(_applications);
                App.AudioSalon.SaveChanges();
                MessageBox.Show("Заявка успешно создана");
            }
            else
            {
                App.AudioSalon.SaveChanges();
                MessageBox.Show("Заявка успешно отредактирована");
            }
            
            NavigationService.GoBack();
        }
    }
}
