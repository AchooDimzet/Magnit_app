using Magnit_app.Classes;
using Magnit_app.Entities;
using Microsoft.Win32;
using System;
using System.IO;
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
using System.Windows.Shapes;

namespace Magnit_app.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private Product_items currentProduct;
        byte[] _image = null;
        public AddProductWindow()
        {
            InitializeComponent();
            CbCategory.ItemsSource = AppData.Context.Product_category.ToList();
        }

        public AddProductWindow(Product_items selectedProduct)
        {
            InitializeComponent();
            currentProduct = selectedProduct;

            DataContext = currentProduct;

            CbCategory.ItemsSource = AppData.Context.Product_category.ToList();

            TbName.Text = selectedProduct.Name;
            TbQuantity.Text = selectedProduct.Quantity.ToString();
            CbCategory.SelectedIndex = selectedProduct.Category;
            TbPrice.Text = selectedProduct.Price.ToString();

            _image = selectedProduct.Photo;

            Image.DataContext = _image;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text != null || TbQuantity.Text != null || CbCategory.SelectedIndex != -1 || TbPrice.Text != null)
            {
                if (currentProduct == null)
                {
                    AppData.Context.Product_items.Add(new Product_items()
                    {

                        Name = TbName.Text,
                        Quantity = Convert.ToInt32(TbQuantity.Text),
                        Category = (CbCategory.SelectedItem as Product_category).Id,
                        Price = Convert.ToInt32(TbPrice.Text),
                        Photo = _image
                    });
                    AppData.Context.SaveChanges();
                    this.Close();
                }
                else
                {
                    currentProduct.Name = TbName.Text;
                    currentProduct.Quantity = Convert.ToInt32(TbQuantity.Text);
                    currentProduct.Category = (CbCategory.SelectedItem as Product_category).Id;
                    currentProduct.Price = Convert.ToInt32(TbPrice.Text);
                    currentProduct.Photo = _image;
                    AppData.Context.SaveChanges();
                    this.Close();
                }
            }
            //TODO: Добавить Try-Catch
            else
            {
                MessageBox.Show("Проверьте правильность введенной информации", "Ошибка");
            }
        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images |*.png; *.jpg";
            if (ofd.ShowDialog() == true)
            {
                _image = File.ReadAllBytes(ofd.FileName);
                Image.DataContext = _image;
            }
        }
    }
}
