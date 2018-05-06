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
    /// Interaction logic for AddSickness.xaml
    /// </summary>
    public partial class AddSickness : Window
    {
        public AddSickness(Sickness sick)
        {
            InitializeComponent();
            if (sick == null)
            {
                btnEditSickness.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAddSickness.Visibility = Visibility.Hidden;
                DataContext = sick;
                lblTitle.Content = "CHỈNH SỬA LOẠI BỆNH";
            }
        }

        private void btnAddSickness_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            //Kiem tra loai benh da ton tai chua
            List<Sickness> listSickness = DataManager.getInstance().getAllSickness();

            foreach (var s in listSickness)
            {
                if (s.name == txtNameSickness.Text)
                {
                    MessageBox.Show("Tên loại bệnh đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }
            //Kiem tra cac truong du lieu da nhap du chua
            if (txtNameSickness.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại bệnh!");
                return;
            }

            //Thoa man cac dieu kien va tien hanh insert vao database
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            Sickness addSick = new Sickness();
            addSick.name = txtNameSickness.Text;
            addSick.noted = txtNotedSickness.Text;

            try
            {
                int id = DataManager.getInstance().insertSickness(addSick, currentUser.id);
                MessageBox.Show("Thêm loại bệnh thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Thêm loại bệnh thất bại!");
            }
        }

        private void btnEditSickness_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            //Kiem tra thuoc da ton tai chua
            List<Sickness> listSickness = DataManager.getInstance().getAllSickness();

            foreach (var s in listSickness)
            {
                if (s.name == txtNameSickness.Text)
                {
                    MessageBox.Show("Tên loại bệnh đã tồn tại. Vui lòng nhập tên khác!");
                    return;
                }
            }
            //Kiem tra cac truong du lieu da nhap du chua
            if (txtNameSickness.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại bệnh!");
                return;
            }

            //Thoa man cac dieu kien va tien hanh cap nhat du lieu
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            Sickness editSick = new Sickness();
            editSick.id = Convert.ToInt32(txtSickId.Text);
            editSick.name = txtNameSickness.Text;
            editSick.noted = txtNotedSickness.Text;

            try
            {
                int id = DataManager.getInstance().updateSickness(editSick, currentUser.id);
                MessageBox.Show("Cập nhật loại bệnh thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật loại bệnh thất bại!");
            }
        }
    }
}
