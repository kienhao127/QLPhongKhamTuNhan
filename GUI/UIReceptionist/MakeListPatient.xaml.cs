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
using QLPhongKhamTuNhan.GUI.UIReceptionist;
using QLPhongKhamTuNhan.Model;

namespace QLPhongKhamTuNhan.GUI.UIReceptionist
{
    /// <summary>
    /// Interaction logic for MakeListPatient.xaml
    /// </summary>
    public partial class MakeListPatient : Page
    {
        public MakeListPatient()
        {
            InitializeComponent();
            currentDay.Text = DateTime.Today.ToShortDateString();
            List<Patient> listPatient = new List<Patient>();
            for (int i = 0; i < 10; i++)
            {
                var data = new Patient { id = 1, full_name = "Test2", address = "add", is_delete = false, sex = "Nam", year_of_birth = 1996 };
                listPatient.Add(data);
            }

            DataContext = listPatient;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //CreateBill bill = new CreateBill();
            //bill.ShowDialog();
        }

        private void btnCreatePatient_Click(object sender, RoutedEventArgs e)
        {
            CreatePatient createPatient = new CreatePatient();
            createPatient.ShowDialog();
        }
    }
}
