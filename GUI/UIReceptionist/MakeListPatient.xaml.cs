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
using Manager;

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
            listPatient = DataManager.getInstance().getListPatient();

            DataContext = listPatient;
        }
        
        private void btnCreatePatient_Click(object sender, RoutedEventArgs e)
        {
            CreatePatient createPatient = new CreatePatient();
            createPatient.ShowDialog();

            patientDataGrid.ItemsSource = null;
            patientDataGrid.ItemsSource = DataManager.getInstance().getListPatient();
            

        }

        private void btnCreateBill_Click(object sender, RoutedEventArgs e)
        {
            Patient p = (Patient)patientDataGrid.SelectedItem;
            int status = DataManager.getInstance().getMedicalExamStatus(p.id);
            string code = DataManager.getInstance().getExamCode(p.id);
            if (status == 0)
            {
                CreateBill bill = new CreateBill(p, code);
                bill.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bệnh nhân chưa khám");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CreatePatient createPatient = new CreatePatient((Patient) patientDataGrid.SelectedItem);
            createPatient.ShowDialog();
            patientDataGrid.ItemsSource = null;
            patientDataGrid.ItemsSource = DataManager.getInstance().getListPatient();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Patient p = (Patient)patientDataGrid.SelectedItem;
            DataManager.getInstance().deletePatient(p.id);
            MessageBox.Show("Xóa thành công");
            patientDataGrid.ItemsSource = null;
            patientDataGrid.ItemsSource = DataManager.getInstance().getListPatient();

        }
    }
}
