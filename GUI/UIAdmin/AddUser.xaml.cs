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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser(User u)
        {
            InitializeComponent();
            if(u != null)
            {
                lblTitle.Content = "CHỈNH SỬA NGƯỜI DÙNG";
                DataContext = u;
                u.role_id = u.role_id - 1;
                btnAddUserDB.Visibility = Visibility.Hidden;
            }
            else
            {
                User us = new User();
                DataContext = us;
                us.role_id = 0;
                btnEditUserDB.Visibility = Visibility.Hidden;
            }
        }

        private void btnAddUserDB_Click(object sender, RoutedEventArgs e)
        {
            var selectRole = cbRole.SelectedIndex;
            //Kiem tra du lieu trong cac o da duoc dien day du chua
            if(txtAddUsername.Text == "" || txtAddPassword.Password == "" || txtAddConfirmPass.Password == "" || txtAddFullname.Text == "" || txtAddEmail.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ");
                return;
            }
            try
            {
                User newUser = new User(txtAddUsername.Text, txtAddFullname.Text, txtAddPassword.Password, txtAddEmail.Text, selectRole + 1);
                int id = DataManager.getInstance().insertUser(newUser);
                MessageBox.Show("Thêm người dùng thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Thêm người dùng thất bại!");
            }
        }

        private void btnEditUserDB_Click(object sender, RoutedEventArgs e)
        {
            var selectRole = cbRole.SelectedIndex;
            //Kiem tra du lieu trong cac o da duoc dien day du chua
            if (txtAddUsername.Text == "" || txtAddPassword.Password == "" || txtAddConfirmPass.Password == "" || txtAddFullname.Text == "" || txtAddEmail.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đầy đủ");
                return;
            }
            try
            {
                User editUser = new User(txtAddUsername.Text, txtAddFullname.Text, txtAddPassword.Password, txtAddEmail.Text, selectRole + 1);
                editUser.id = Convert.ToInt32(txtUserId.Text);
                int id = DataManager.getInstance().updateUser(editUser);
                MessageBox.Show("Cập nhật người dùng thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật người dùng thất bại!");
            }
        }
    }
}
