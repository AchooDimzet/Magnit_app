using Magnit_app.Classes;
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

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDgSource();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
