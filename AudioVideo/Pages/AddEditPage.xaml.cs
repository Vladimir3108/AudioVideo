using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        Catalog _catalog = new Catalog();
        private byte[] image = null;
        public AddEditPage(Catalog correctCatalog)
        {
            InitializeComponent();

            if (correctCatalog != null)
            {
                _catalog = correctCatalog;
            }

            DataContext = _catalog;

            ComboTech.ItemsSource = App.AudioSalon.TechniqueType.ToList();
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите вернуться назад?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.GoBack();
            }
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image | *.png; *.avif; *.jpeg; *.jpg";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == true)
            {
                image = File.ReadAllBytes(openFileDialog.FileName);
                TechImage.Source = new ImageSourceConverter().ConvertFrom(image) as ImageSource;

                _catalog.Image = image;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_catalog.Name))
                errors.AppendLine("Введите название!");

            if (_catalog.TechniqueType == null)
                errors.AppendLine("Укажите тип техники!");

            if (_catalog.Amount < 0)
                errors.AppendLine("Укажите кол-во техники");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_catalog.CatalogID == 0)
                App.AudioSalon.Catalog.Add(_catalog);

            try
            {
                App.AudioSalon.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
