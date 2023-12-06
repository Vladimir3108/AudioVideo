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
        Catalog catalog = new Catalog();
        private byte[] image = null;
        public AddEditPage(Catalog _catalog)
        {
            InitializeComponent();
            if (_catalog != null)
            {
                catalog = _catalog;
            }
            DataContext = catalog;

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
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(catalog.Name))
                errors.AppendLine("Введите название!");

            if (catalog.TechniqueType == null)
                errors.AppendLine("Укажите тип техники!");

            //if (string.IsNullOrWhiteSpace(_currentProduct.ProductDescription))
            //    errors.AppendLine("Введите описание!");

            //if (_currentProduct.ProductManufacter == null)
            //    errors.AppendLine("Выберите производителя!");

            //if (_currentProduct.ProductCategory == null)
            //    errors.AppendLine("Выберите категорию!");

            //if (_currentProduct.ProductCost <= 0)
            //    errors.AppendLine("Введите цену!");

            //if (_currentProduct.ProductDiscountAmount < 0)
            //    errors.AppendLine("Введите скидку (если скидки нет - укажите 0)!");

            //if (_currentProduct.ProductQuantityInStock < 0)
            //    errors.AppendLine("Введите кол-во продукта (если продукта нет - укажите 0)!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }



            try
            {
                VideoAudioSalonEntities.GetContext().SaveChanges();
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
