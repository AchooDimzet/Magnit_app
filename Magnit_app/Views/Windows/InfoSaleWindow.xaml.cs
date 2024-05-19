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
    /// Логика взаимодействия для InfoSaleWindow.xaml
    /// </summary>
    public partial class InfoSaleWindow : Window
    {
        Sales Sales = new Sales();
        List<ProductSales> products = new List<ProductSales>();
        public InfoSaleWindow(Sales sales)
        {
            InitializeComponent();

            Sales = sales;
            products = sales.ProductSales.ToList();

            SpData.DataContext = Sales;
            UpdateDgSource();
        }
        private void UpdateDgSource()
        {
            DgProducts.ItemsSource = null;
            DgProducts.ItemsSource = products;
        }
    }
}
