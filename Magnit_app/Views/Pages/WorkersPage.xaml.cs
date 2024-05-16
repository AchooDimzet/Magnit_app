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
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        public WorkersPage()
        {
            InitializeComponent();
            UpdateDgSource();
        }

        private void UpdateDgSource()
        {
            var workers = AppData.Context.Workers.Where(p => p.IsDeleted == false).ToList();
            WorkersDG.ItemsSource = workers;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow window = new AddWorkerWindow();
            window.ShowDialog();
            UpdateDgSource();
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDgSource();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow window = new AddWorkerWindow((sender as Button).DataContext as Workers);
            window.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var workers = WorkersDG.SelectedItem as Workers;
                    workers.IsDeleted = true;
                    AppData.Context.SaveChanges();
                    UpdateDgSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Info_Button_Click(object sender, RoutedEventArgs e)
        {
            InfoWorker window = new InfoWorker((sender as Button).DataContext as Workers);
            window.ShowDialog();
        }
    }
}
