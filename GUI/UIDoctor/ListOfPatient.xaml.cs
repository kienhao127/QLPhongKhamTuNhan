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
            for (int i = 0; i < 10; i++)
            {
                
                listPatient = DataManager.getInstance().getListPatient();
            }

            DataContext = listPatient;
        }
        
        private void btnLapPhieuKhamBenh_Click(object sender, RoutedEventArgs e)
        {
            var p = (Patient)patientDataGrid.SelectedItem;
            int n = DataManager.getInstance().countMedicalExam();
            string code = "";
            if (n < 40)
            {
                code = Utils.helper.createExamCode() + String.Format("{0:000}", n);
                DataManager.getInstance().insertMedicalExam(code, p.id, ((Model.User)Application.Current.Properties["UserInfo"]).id);

                LapPhieuKhamBenh phieu = new LapPhieuKhamBenh(p, code);
                phieu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đã vượt qua mức quy định khám bệnh trong ngày");
            }
        }
    }
}
