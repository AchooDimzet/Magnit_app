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
    /// Логика взаимодействия для TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
            UpdateDgSource();
            
        }
        private void UpdateDgSource()
        {
            var tasks = AppData.Context.Worker_tasks.Where(p => p.Is_comleted == false).ToList();
            WorkersDG.ItemsSource = tasks;
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow window = new AddTaskWindow((sender as Button).DataContext as Worker_tasks);
            window.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите завершить задачу?", "Завершение задачи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    var tasks = WorkersDG.SelectedItem as Worker_tasks;
                    tasks.Is_comleted = true;
                    AppData.Context.SaveChanges();
                    UpdateDgSource();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDgSource();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow window = new AddTaskWindow();
            window.ShowDialog();
            UpdateDgSource();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxSearch.Text != "")
            {
                WorkersDG.ItemsSource = null;
                WorkersDG.ItemsSource = AppData.Context.Sales.Where(p => p.Workers.First_name.Contains(TBoxSearch.Text) || p.Workers.Last_name.Contains(TBoxSearch.Text) || p.Workers.Patronimyc.Contains(TBoxSearch.Text) || p.Date.ToString().Contains(TBoxSearch.Text)).ToList();
            }
            else
                UpdateDgSource();
        }
    }
}
