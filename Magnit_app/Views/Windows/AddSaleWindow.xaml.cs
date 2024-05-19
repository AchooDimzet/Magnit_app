using Magnit_app.Classes;
using Magnit_app.Entities;
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
using System.Windows.Shapes;

namespace Magnit_app.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSaleWindow.xaml
    /// </summary>
    public partial class AddSaleWindow : Window
    {
        Sales Sales = new Sales();
        List<ProductSales> products = new List<ProductSales>();
        public AddSaleWindow()
        {
            InitializeComponent();
            CbProducts.ItemsSource = AppData.Context.Product_items.ToList();

            Sales.Workers = AppData.currentUser;
            Sales.Date = DateTime.Now.ToShortDateString();

            SpData.DataContext = Sales;
            UpdateDgSource();
        }
        private void UpdateDgSource()
        {
            DgProducts.ItemsSource = null;
            DgProducts.ItemsSource = products;
        }//Обновление списка продуктов

        public AddSaleWindow(Sales sales)
        {
            InitializeComponent();
            CbProducts.ItemsSource = AppData.Context.Product_items.ToList();

            Sales = sales;
            products = sales.ProductSales.ToList();

            SpData.DataContext = Sales;
            UpdateDgSource();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            products.Remove(DgProducts.SelectedItem as ProductSales);
            UpdateDgSource();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TbCount.Text, out int quantity) == true && CbProducts.SelectedItem != null)
            {
                var product = CbProducts.SelectedItem as Product_items;
                if ((AppData.Context.Product_items.FirstOrDefault(p => p.Article_number == product.Article_number).Quantity - quantity) < 0)
                {
                    MessageBox.Show($"Количество товара {product.Name} на складе меньше указанного! \nОстаток товара составляет {product.Quantity} единиц");
                }
                else
                {
                    products.Add(new ProductSales
                    {
                        Count = quantity,
                        Product_items = product,
                        Sales = Sales
                    });
                    UpdateDgSource();
                }
            }
            else
                MessageBox.Show("Введено не корректное значение!");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count != 0) //Проверяем есть ли продукты в заказе
            {
                Sales.ProductSales = products;
                foreach (var product in products)
                {
                    var currentProduct = AppData.Context.Product_items.FirstOrDefault(p => p.Name == product.Product_items.Name);
                    currentProduct.Quantity = currentProduct.Quantity - product.Count;
                }
                AppData.Context.Sales.Add(Sales);
                AppData.Context.SaveChanges();
                this.Close();
            }
            else
                MessageBox.Show("Не добавлено ни одного продукта!");
        }
    }
}
