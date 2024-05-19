using Microsoft.Win32;
using Magnit_app.Classes;
using Magnit_app.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        private Workers currentWorker;
        byte[] _image = null;

        public AddWorkerWindow()
        {
            InitializeComponent();
            CbRole.ItemsSource = AppData.Context.Roles.ToList();
            List<Roles> roles = new List<Roles>();
            CbStore.ItemsSource = AppData.Context.Store.ToList();
            CbGender.ItemsSource = AppData.Context.Gender.ToList();
            //departments = AppData.Context.Departments.ToList();
            //education = AppData.Context.EducationTypes.ToList
        }
        public AddWorkerWindow(Workers selectedWorker)
        {
            InitializeComponent();
            currentWorker = selectedWorker;

            DataContext = currentWorker;

            CbRole.ItemsSource = AppData.Context.Roles.ToList();
            CbGender.ItemsSource = AppData.Context.Gender.ToList();
            CbStore.ItemsSource = AppData.Context.Store.ToList();

            TbFirstName.Text = selectedWorker.First_name;
            TbLastName.Text = selectedWorker.Last_name;
            TbPatronymic.Text = selectedWorker.Patronimyc;
            CbRole.SelectedIndex = selectedWorker.Id_role;
            CbGender.SelectedIndex = selectedWorker.Gender;
            TbPhone.Text = selectedWorker.Phone;
            TbAdress.Text = selectedWorker.Adress;
            CbStore.SelectedIndex = selectedWorker.Id_store;
            TbLogin.Text = selectedWorker.Login;
            TbPassword.Password = selectedWorker.Password;

            _image = selectedWorker.Photo;

            Image.DataContext = _image;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentWorker == null)
                {
                    AppData.Context.Workers.Add(new Workers()
                    {
                        First_name = TbFirstName.Text,
                        Last_name = TbLastName.Text,
                        Patronimyc = TbPatronymic.Text,
                        Id_role = (CbRole.SelectedItem as Roles).Id,
                        Gender1 = (CbGender.SelectedItem as Gender),
                        Phone = TbPhone.Text,
                        Adress = TbAdress.Text,
                        Id_store = (CbStore.SelectedItem as Store).Id,
                        Login = TbLogin.Text,
                        Password = TbPassword.Password,
                        Photo = _image,
                        IsDeleted = false
                    });
                    AppData.Context.SaveChanges();
                    this.Close();
                }
                else
                {
                    currentWorker.First_name = TbFirstName.Text;
                    currentWorker.Last_name = TbLastName.Text;
                    currentWorker.Patronimyc = TbPatronymic.Text;
                    currentWorker.Id_role = (CbRole.SelectedItem as Roles).Id;
                    currentWorker.Gender = (CbGender.SelectedItem as Gender).Id;
                    currentWorker.Phone = TbPhone.Text;
                    currentWorker.Id_store = (CbStore.SelectedItem as Store).Id;
                    currentWorker.Login = TbLogin.Text;
                    currentWorker.Password = TbPassword.Password;
                    currentWorker.Photo = _image;
                    currentWorker.IsDeleted = false;
                    AppData.Context.SaveChanges();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте правильность введенной информации" + ex, "Ошибка");
            }
        
}

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images |*.png; *.jpg";
            if (ofd.ShowDialog() == true)
            {
                _image = File.ReadAllBytes(ofd.FileName);
                Image.DataContext = _image;
            }
        }
    }
}
