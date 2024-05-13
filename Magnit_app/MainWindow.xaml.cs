using Magnit_app.Classes;
using Magnit_app.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Magnit_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string title;
        public MainWindow()
        {
            InitializeComponent();
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new AuthPG());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            title = (((Frame)sender).Content as Page).Title;
            if (title == "AuthPG")
            {
                BrdInfo.Visibility = Visibility.Hidden;
                BrdMenu.Visibility = Visibility.Hidden;
                StMenu.Visibility = Visibility.Hidden;
                BtnBack.Visibility = Visibility.Hidden;
                BtnBackTM.Visibility = Visibility.Hidden;
            }
            else
            {
                BrdInfo.Visibility = Visibility.Visible;
                BrdMenu.Visibility = Visibility.Visible;
                StMenu.Visibility = Visibility.Visible;
                BtnBack.Visibility = Visibility.Visible;
                BtnBackTM.Visibility = Visibility.Visible;
                TBName.Text = AppData.currentUser.First_name;
                TextBLastName.Text = AppData.currentUser.Last_name;
                if (title == "MainMenuPG")
                {
                    BrdInfo.Visibility = Visibility.Visible;
                    BrdMenu.Visibility = Visibility.Visible;
                    StMenu.Visibility = Visibility.Visible;
                    BtnBack.Visibility = Visibility.Hidden;
                    BtnBackTM.Visibility = Visibility.Hidden;
                }
            }
        }



        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AboutPG());
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из системы?", "Выход из системы",
    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                AppData.MainFrame.Navigate(new AuthPG());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.GoBack();
        }

        private void BtnBackTM_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new AuthPG());
        }

        private void BtnWorkers_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new WorkersPage());
        }

        private void BtnTasks_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new TasksPage());
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new ProductsPage());
        }

        private void BtnSales_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new SalesPage());
        }
    }
}
