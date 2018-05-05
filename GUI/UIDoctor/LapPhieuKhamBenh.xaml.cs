using Manager;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utils;

namespace QLPhongKhamTuNhan.GUI.UIDoctor
{
    /// <summary>
    /// Interaction logic for LapPhieuKhamBenh.xaml
    /// </summary>
    public partial class LapPhieuKhamBenh : Window
    {
        Patient p = new Patient(); 
        public LapPhieuKhamBenh(Patient patient)
        {
            InitializeComponent();
            cboLoaiBenh.ItemsSource = DataManager.getInstance().getListSicknessName();
            p = patient;
            tbTenBanhNhan.Text = p.full_name;
            tbNgayKham.Text = helper.getDateTimeNow();

            Prescription data = new Prescription();
            donThuocDataGrid.Items.Add(data);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void btnThemThuoc_Click(object sender, RoutedEventArgs e)
        {
            Prescription data = new Prescription();
            donThuocDataGrid.Items.Add(data);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cboTenThuoc_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            cmb.ItemsSource = DataManager.getInstance().getListMedicineName();
        }
    }
}
