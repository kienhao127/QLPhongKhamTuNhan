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

namespace QLPhongKhamTuNhan.GUI.UIAdmin
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Window
    {
        public AddMedicine(FullMedicine medicine)
        {
            InitializeComponent();
            List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();
            cbUnitMedicine.DataContext = listUnit;
            if (medicine == null)
            {
                btnEditMedicine.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAddMedicine.Visibility = Visibility.Hidden;
                DataContext = medicine;
            }
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            //Kiem tra thuoc da ton tai chua
            List<FullMedicine> listMedicine = DataManager.getInstance().getAllMedicine();

            foreach (var m in listMedicine)
            {
                if(m.name == txtNameMedicine.Text)
                {
                    MessageBox.Show("Tên thuốc đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }
            //Kiem tra cac truong du lieu da nhap du chua
            if(txtNameMedicine.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                return;
            }

            if(cbUnitMedicine.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính của thuốc!");
                return;
            }

            if(txtUnitPriceMedicine.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá của thuốc!");
                return;
            }

            if(txtSmallestMedicine.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng tối thiểu của thuốc!");
                return;
            }

            //Thoa man cac dieu kien va tien hanh insert vao database
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            UnitMedicine unit = cbUnitMedicine.SelectedItem as UnitMedicine;

            FullMedicine addMedicine = new FullMedicine();
            addMedicine.name = txtNameMedicine.Text;
            addMedicine.another_name = txtAnotherNameMedicine.Text;
            addMedicine.unit_id = unit.id;
            addMedicine.unit_name = unit.name;
            addMedicine.unit_price = Convert.ToInt64(txtUnitPriceMedicine.Text);
            addMedicine.num_smallest_unit = Convert.ToInt32(txtSmallestMedicine.Text);

            try
            {
                int id = DataManager.getInstance().insertMedicine(addMedicine, currentUser.id);
                MessageBox.Show("Thêm thuốc thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Thêm thuốc thất bại!");
            }
        }

        private void btnEditMedicine_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            //Kiem tra thuoc da ton tai chua
            List<FullMedicine> listMedicine = DataManager.getInstance().getAllMedicine();

            foreach (var m in listMedicine)
            {
                if (m.name == txtNameMedicine.Text)
                {
                    MessageBox.Show("Tên thuốc đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }
            //Kiem tra cac truong du lieu da nhap du chua
            if (txtNameMedicine.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                return;
            }

            if (cbUnitMedicine.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính của thuốc!");
                return;
            }

            if (txtUnitPriceMedicine.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá của thuốc!");
                return;
            }

            if (txtSmallestMedicine.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng tối thiểu của thuốc!");
                return;
            }

            //Thoa man cac dieu kien va tien hanh cap nhat du lieu
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            UnitMedicine unit = cbUnitMedicine.SelectedItem as UnitMedicine;

            FullMedicine editMedicine = new FullMedicine();
            editMedicine.id = Convert.ToInt32(txtMedicineId.Text);
            editMedicine.name = txtNameMedicine.Text;
            editMedicine.another_name = txtAnotherNameMedicine.Text;
            editMedicine.unit_id = unit.id;
            editMedicine.unit_name = unit.name;
            editMedicine.unit_price = Convert.ToInt64(txtUnitPriceMedicine.Text);
            editMedicine.num_smallest_unit = Convert.ToInt32(txtSmallestMedicine.Text);

            try
            {
                int id = DataManager.getInstance().updateMedicine(editMedicine, currentUser.id);
                MessageBox.Show("Cập nhật thuốc thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật thuốc thất bại!");
            }
        }

        private void txtUnitPriceMedicine_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtSmallestMedicine_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
