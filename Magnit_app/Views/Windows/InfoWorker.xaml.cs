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
    /// Логика взаимодействия для InfoWorker.xaml
    /// </summary>
    public partial class InfoWorker : Window
    {
        byte[] _image = null;
        public InfoWorker(Workers selectedWorker)
        {
            InitializeComponent();
            //TbFirstName.Text = selectedWorker.FirstName;
            //TbLastName.Text = selectedWorker.LastName;
            //TbPatronymic.Text = selectedWorker.Patronymic;
            //CbDepartment.Text = selectedWorker.Departments.Name;
            //TbJob.Text = selectedWorker.Job;
            //TbPhone.Text = selectedWorker.Phone;
            //CbEducationType.Text = selectedWorker.EducationTypes.Name;
            //TbInstitution.Text = selectedWorker.Institution;
            //TbSpecialisation.Text = selectedWorker.Specialisation;
            //TbLogin.Text = selectedWorker.Login;
            //_image = selectedWorker.Photo;

            //Image.DataContext = _image;
        }
    }
}
