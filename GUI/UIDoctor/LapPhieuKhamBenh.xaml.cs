using Manager;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
        List<Prescription> listPrescription = new List<Prescription>();
        Prescription prescription = new Prescription();
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
            taoDonThuoc();
            Close();
        }

        private void btnThemThuoc_Click(object sender, RoutedEventArgs e)
        {
            if ((prescription.medicine_id == 0) || (prescription.unit_id == 0) || (prescription.amount == 0) || (prescription.use_id == 0))
            {
                MessageBox.Show("Hàng thuốc trống hoặc không hợp lệ");
                return;
            }
            Prescription data = new Prescription();
            donThuocDataGrid.Items.Add(data);
            prescription = new Prescription();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void taoDonThuoc()
        {
            if ((prescription.medicine_id == 0) || (prescription.unit_id == 0) || (prescription.amount == 0) || (prescription.use_id == 0))
            {
                MessageBox.Show("Hàng thuốc trống hoặc không hợp lệ");
                return;
            }
            int n = donThuocDataGrid.Items.Count;
            foreach (DataRowView row in donThuocDataGrid.SelectedItems)
            {
                string text = row.Row.ItemArray[0].ToString();
            }
        }

        private void cboTenThuoc_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            cmb.ItemsSource = DataManager.getInstance().getListMedicineName();
        }

        private void cboTenThuoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            int id = DataManager.getInstance().getMedicineID(cbo.SelectedItem.ToString());
            if (id != -1)
            {
                prescription.medicine_id = id;
            }
        }

       

        private void cboDonViThuoc_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            cmb.ItemsSource = DataManager.getInstance().getListUnitName();
        }
        private void cboDonViThuoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            int id = DataManager.getInstance().getUnitID(cbo.SelectedItem.ToString());
            if (id != -1)
            {
                prescription.unit_id = id;
            }
        }


        private void tbCachDung_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            cmb.ItemsSource = DataManager.getInstance().getListUseName();
        }

        private void tbCachDung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            int id = DataManager.getInstance().getUseID(cbo.SelectedItem.ToString());
            if (id != -1)
            {
                prescription.use_id = id;
            }
        }

        private void txtSoLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text != "")
            {
                prescription.amount = Convert.ToInt32(txt.Text);
            }
        }
    }
}
