using Magnit_app.Classes;
using Magnit_app.Entities;
using Magnit_app.Views.Windows;
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

namespace Magnit_app.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            UpdateDgSource();
        }

        private void UpdateDgSource()
        {
            var products = AppData.Context.Product_items.ToList();
            ProductsDG.ItemsSource = products;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow((sender as Button).DataContext as Product_items);
            window.ShowDialog();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow();
            window.ShowDialog();
            UpdateDgSource();
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDgSource();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxSearch.Text != "")
            {
                ProductsDG.ItemsSource = null;
                ProductsDG.ItemsSource = AppData.Context.Product_items.Where(p => p.Article_number.ToString().Contains(TBoxSearch.Text) || p.Name.Contains(TBoxSearch.Text)).ToList();
            }
            else
                UpdateDgSource();
        }
    }
}
