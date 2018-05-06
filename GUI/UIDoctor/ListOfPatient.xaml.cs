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
using QLPhongKhamTuNhan.GUI.UIDoctor;
using QLPhongKhamTuNhan.Model;
using Manager;

namespace QLPhongKhamTuNhan.GUI.UIDoctor
{
    /// <summary>
    /// Interaction logic for ListOfPatient.xaml
    /// </summary>
    public partial class ListOfPatient : Page
    {
        public ListOfPatient()
        {
            InitializeComponent();
            List<Patient> listPatient = new List<Patient>();
            listPatient = DataManager.getInstance().getListPatientForDoctor();

            DataContext = listPatient;
        }
        
        private void btnLapPhieuKhamBenh_Click(object sender, RoutedEventArgs e)
        {
            var p = (Patient)patientDataGrid.SelectedItem;
            string code = DataManager.getInstance().getExamCode(p.id);
            LapPhieuKhamBenh phieu = new LapPhieuKhamBenh(p, code);
            phieu.ShowDialog();
            
        }
    }
}
