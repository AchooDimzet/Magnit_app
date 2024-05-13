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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magnit_app.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPG.xaml
    /// </summary>
    public partial class AuthPG : Page
    {
        public AuthPG()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxLogin.Text.Equals("") && PBPassword.Password.Equals(""))
            {
                //переписать остальные месседжы
                MessageBox.Show("заполните пол логин и пароль", "а где", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                Workers user = AppData.Context.Workers.Where(p => p.Login == TBoxLogin.Text && p.Password == PBPassword.Password).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("неправильно введён логин или пароль", "а где", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                AppData.currentUser = user;
                AppData.MainFrame.Navigate(new TasksPage());
            }
            catch
            {
                MessageBox.Show("заполните поля логина и пароля", "а где", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void BtnFogPass_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Для восстановления данных напишите на почту MagnitAppHelp@gneg.com, указав в письме свой логин, выданный вам до этого.");
        }
    }
}
