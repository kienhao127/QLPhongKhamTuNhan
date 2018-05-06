using Manager;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                lblPass.Content = "Mật khẩu mới:";
                lblConfirmPass.Content = "Nhập lại mật khẩu mới:";
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
            if (txtAddUsername.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }
            if (txtAddPassword.Password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            if (txtAddConfirmPass.Password == "")
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu!");
                return;
            }
            if (txtAddFullname.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên!");
                return;
            }
            if (txtAddEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }
            //Kiem tra password nhap lai da khop chua
            if (txtAddPassword.Password != txtAddConfirmPass.Password)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp. Vui lòng nhập lại!");
                txtAddPassword.Password = "";
                txtAddConfirmPass.Password = "";
                return;
            }
            //Ma hoa password
            string outputPassword = "";
            using (MD5 md5Hash = MD5.Create())
            {
                outputPassword = GetMd5Hash(md5Hash, txtAddPassword.Password.ToString());
            }
            //Kiem tra username da ton tai hay chua
            List<User> listUser = DataManager.getInstance().getAllUser();
            foreach (var u in listUser)
            {
                if(u.name == txtAddUsername.Text)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng nhập tên khác");
                    txtAddUsername.Text = "";
                    return;
                }
            }
            //Thoa man cac dieu kien tien hanh insert vao database
            try
            {
                User newUser = new User(txtAddUsername.Text, txtAddFullname.Text, outputPassword, txtAddEmail.Text, selectRole + 1);
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
            if(txtAddUsername.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }
            if(txtAddFullname.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên!");
                return;
            }
            if(txtAddEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }
            //Truong hop co doi password
            if(txtAddPassword.Password != "")
            {
                if(txtAddPassword.Password != txtAddConfirmPass.Password)
                {
                    MessageBox.Show("Mật khẩu mới nhập lại không khớp. Vui lòng nhập lại!");
                    txtAddPassword.Password = "";
                    txtAddConfirmPass.Password = "";
                    return;
                }
                //Ma hoa password
                string outputPassword = "";
                using (MD5 md5Hash = MD5.Create())
                {
                    outputPassword = GetMd5Hash(md5Hash, txtAddPassword.Password.ToString());
                }
                try
                {
                    User editUser = new User(txtAddUsername.Text, txtAddFullname.Text, outputPassword, txtAddEmail.Text, selectRole + 1);
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
            else //Truong hop khong doi password
            {
                try
                {
                    User editUser = new User(txtAddUsername.Text, txtAddFullname.Text, txtAddPassword.Password, txtAddEmail.Text, selectRole + 1);
                    editUser.id = Convert.ToInt32(txtUserId.Text);
                    int id = DataManager.getInstance().updateUserNoPass(editUser);
                    MessageBox.Show("Cập nhật người dùng thành công!");
                    Close();
                }
                catch
                {
                    MessageBox.Show("Cập nhật người dùng thất bại!");
                }
            }
            
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
