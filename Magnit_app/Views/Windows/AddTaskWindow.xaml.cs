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
    /// Логика взаимодействия для AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        private Worker_tasks currentTask;

        public AddTaskWindow()
        {
            InitializeComponent();
            CbWorker.ItemsSource = AppData.Context.Workers.ToList();
        }

        public AddTaskWindow(Worker_tasks selectedTask)
        {
            InitializeComponent();
            currentTask = selectedTask;

            DataContext = currentTask;

            CbWorker.ItemsSource = AppData.Context.Workers.ToList();

            CbWorker.SelectedIndex = selectedTask.Id_worker;
            TbTextOfTask.Text = selectedTask.Task_text;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentTask == null)
                {
                    AppData.Context.Worker_tasks.Add(new Worker_tasks()
                    {
                        Id_worker = (CbWorker.SelectedItem as Workers).Id,
                        Task_text = TbTextOfTask.Text,
                        DateOfTask = DateTime.Now,
                        Is_comleted = false
                    });
                    AppData.Context.SaveChanges();
                    this.Close();
                }
                else
                {
                    currentTask.Id_worker = (CbWorker.SelectedItem as Workers).Id;
                    currentTask.Task_text = TbTextOfTask.Text;
                    currentTask.DateOfTask = currentTask.DateOfTask;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте правильность введенной информации" + ex, "Ошибка");
            }
        }
    }
}
