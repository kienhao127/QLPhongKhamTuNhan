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

namespace QLPhongKhamTuNhan.GUI.UIAdmin
{
    /// <summary>
    /// Interaction logic for AddUnitMedicine.xaml
    /// </summary>
    public partial class AddUnitMedicine : Window
    {
        public AddUnitMedicine(UnitMedicine unit)
        {
            InitializeComponent();
            if (unit == null)
            {
                btnEditUnit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAddUnit.Visibility = Visibility.Hidden;
                DataContext = unit;
            }
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            //Kiem tra don vi thuoc da ton tai chua
            List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();

            foreach (var u in listUnit)
            {
                if (u.name == txtNameUnit.Text)
                {
                    MessageBox.Show("Tên đơn vị thuốc đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }
            //Kiem tra cac truong du lieu da nhap du chua
            if (txtNameUnit.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị!");
                return;
            }

            //Thoa man cac dieu kien va tien hanh insert vao database
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            UnitMedicine addUnit = new UnitMedicine();
            addUnit.name = txtNameUnit.Text;

            try
            {
                int id = DataManager.getInstance().insertUnitMedicine(addUnit, currentUser.id);
                MessageBox.Show("Thêm đơn vị thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Thêm đơn vị thất bại!");
            }
        }

        private void btnEditUnit_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            //Kiem tra don vi thuoc da ton tai chua
            List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();

            foreach (var u in listUnit)
            {
                if (u.name == txtNameUnit.Text)
                {
                    MessageBox.Show("Tên đơn vị thuốc đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }
            //Kiem tra cac truong du lieu da nhap du chua
            if (txtNameUnit.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên thuốc!");
                return;
            }

            //Thoa man cac dieu kien va tien hanh insert cập nhật dữ liệu
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            UnitMedicine editUnit = new UnitMedicine();
            editUnit.id = Convert.ToInt32(txtUnitId.Text);
            editUnit.name = txtNameUnit.Text;

            try
            {
                int id = DataManager.getInstance().updateUnitMedicine(editUnit, currentUser.id);
                MessageBox.Show("Cập nhật đơn vị thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật đơn vị thất bại!");
            }
        }
    }
}
