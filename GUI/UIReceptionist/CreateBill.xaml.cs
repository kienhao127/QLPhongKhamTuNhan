using Manager;
using QLPhongKhamTuNhan.Model;
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

namespace QLPhongKhamTuNhan.GUI.UIReceptionist
{
    /// <summary>
    /// Interaction logic for CreateBill.xaml
    /// </summary>
    public partial class CreateBill : Window
    {
        Patient p = new Patient();
        string code = "";
        long feeExam = 0;
        int feeMedicine = 0;
        public CreateBill(Patient patient, string code)
        {
            InitializeComponent();
            p = patient;
            this.code = code;
            txtHoTen.Text = p.full_name;
            txtNgayKham.Text = Utils.helper.getDateTimeNow();
            feeExam = DataManager.getInstance().getFeeExam();
            txtTienKham.Text = feeExam.ToString();
            feeMedicine = DataManager.getInstance().getFeeMedicine(code);
            txtTienThuoc.Text = feeMedicine.ToString();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DataManager.getInstance().updateMedicineExam(code, feeExam, feeMedicine);
            Close();
        }
    }
}
