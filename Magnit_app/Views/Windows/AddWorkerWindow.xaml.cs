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
            //CbDepartment.ItemsSource = AppData.Context.Departments.Where(p => p.IsValid == true).ToList();
            //CbEducationType.ItemsSource = AppData.Context.EducationTypes.ToList();
            //List<Departments> departments = new List<Departments>();
            ////departments = AppData.Context.Departments.ToList();
            ////education = AppData.Context.EducationTypes.ToList
        }
        //public AddWorkerWindow(Workers selectedWorker)
        //{
            //InitializeComponent();
        //    currentWorker = selectedWorker;

        //    DataContext = currentWorker;

        //    CbDepartment.ItemsSource = AppData.Context.Departments.Where(p => p.IsValid == true).ToList();
        //    CbEducationType.ItemsSource = AppData.Context.EducationTypes.ToList();

        //    TbFirstName.Text = selectedWorker.FirstName;
        //    TbLastName.Text = selectedWorker.LastName;
        //    TbPatronymic.Text = selectedWorker.Patronymic;
        //    CbDepartment.SelectedIndex = selectedWorker.Department_Id;
        //    TbJob.Text = selectedWorker.Job;
        //    TbPhone.Text = selectedWorker.Phone;
        //    CbEducationType.SelectedIndex = selectedWorker.EducationType_Id;
        //    TbInstitution.Text = selectedWorker.Institution;
        //    TbSpecialisation.Text = selectedWorker.Specialisation;
        //    TbLogin.Text = selectedWorker.Login;
        //    TbPassword.Password = selectedWorker.Password;
        //    if (selectedWorker.Role == true)
        //    {
        //        CbRole.SelectedIndex = 0;
        //    }
        //    else
        //        CbRole.SelectedIndex = 1;
            
        //    _image = selectedWorker.Photo;

        //    Image.DataContext = _image;
        //}

        //private void BtnSave_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (currentWorker == null)
        //        {
        //            AppData.Context.Workers.Add(new Workers()
        //            {
        //                FirstName = TbFirstName.Text,
        //                LastName = TbLastName.Text,
        //                Patronymic = TbPatronymic.Text,
        //                Department_Id = (CbDepartment.SelectedItem as Departments).Id,
        //                Job = TbJob.Text,
        //                Phone = TbPhone.Text,
        //                EducationType_Id = (CbEducationType.SelectedItem as EducationTypes).Id,
        //                Institution = TbInstitution.Text,
        //                Specialisation = TbSpecialisation.Text,
        //                Login = TbLogin.Text,
        //                Password = TbPassword.Password,
        //                Photo = _image,
        //                Role = CbRole.SelectedIndex == 0,
        //                IsValid = true
        //                });
        //            AppData.Context.SaveChanges();
        //            this.Close();
        //        }
        //        else
        //        {
        //            currentWorker.FirstName = TbFirstName.Text;
        //            currentWorker.LastName = TbLastName.Text;
        //            currentWorker.Patronymic = TbPatronymic.Text;
        //            currentWorker.Department_Id = (CbDepartment.SelectedItem as Departments).Id;
        //            currentWorker.Job = TbJob.Text;
        //            currentWorker.Phone = TbPhone.Text;
        //            currentWorker.EducationType_Id = (CbEducationType.SelectedItem as EducationTypes).Id;
        //            currentWorker.Institution = TbInstitution.Text;
        //            currentWorker.Specialisation = TbSpecialisation.Text;
        //            currentWorker.Login = TbLogin.Text;
        //            currentWorker.Password = TbPassword.Password;
        //            currentWorker.Photo = _image;
        //            if (CbRole.SelectedIndex == 0)
        //                currentWorker.Role = true;
        //            else
        //                currentWorker.Role = false;
        //            currentWorker.IsValid = true;
        //            AppData.Context.SaveChanges();
        //            this.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
            
        //}

        //private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Images |*.png; *.jpg";
        //    if (ofd.ShowDialog() == true)
        //    {
        //        _image = File.ReadAllBytes(ofd.FileName);
        //        Image.DataContext = _image;
        //}
        //}
    }
}
