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
    /// Логика взаимодействия для SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        public SalesPage()
        {
            InitializeComponent();
            UpdateDgSource();
        }

        private void UpdateDgSource()
        {
            SalesDG.ItemsSource = AppData.Context.Sales.ToList();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddSaleWindow window = new AddSaleWindow();
            window.ShowDialog();
            UpdateDgSource();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxSearch.Text != "")
            {
                SalesDG.ItemsSource = null;
                SalesDG.ItemsSource = AppData.Context.Sales.Where(p => p.Workers.First_name.Contains(TBoxSearch.Text) || p.Workers.Last_name.Contains(TBoxSearch.Text) || p.Workers.Patronimyc.Contains(TBoxSearch.Text) || p.Date.ToString().Contains(TBoxSearch.Text)).ToList();
            }
            else
                UpdateDgSource();
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            InfoSaleWindow window = new InfoSaleWindow((sender as Button).DataContext as Sales);
            window.ShowDialog();
        }

        private void Refresh_Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateDgSource();
        }
    }
}
