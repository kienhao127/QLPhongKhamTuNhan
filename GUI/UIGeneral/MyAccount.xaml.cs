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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLPhongKhamTuNhan.GUI.UIGeneral
{
    /// <summary>
    /// Interaction logic for MyAccount.xaml
    /// </summary>
    public partial class MyAccount : Page
    {
        public MyAccount()
        {
            InitializeComponent();
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];
            User myaccount = DataManager.getInstance().getUserWithID(currentUser.id);
            DataContext = myaccount;
            if(myaccount.id != 1)
            {
                DataContext = myaccount;
            }
            if(currentUser.role_id == 1)
            {
                tblRole.Text = "Admin";
            }
            if(currentUser.role_id == 2)
            {
                tblRole.Text = "Bác sĩ";
            }
            if (currentUser.role_id == 3)
            {
                tblRole.Text = "Tiếp tân";
            }
        }

        private void btnSaveUserDB_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];
            //Kiem tra du lieu trong cac o da duoc dien day du chua
            if (txtAddUsername.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
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
            //Truong hop co doi password
            if (txtNewPassword.Password != "")
            {
                if (txtNewPassword.Password != txtConfirmNewPass.Password)
                {
                    MessageBox.Show("Mật khẩu mới nhập lại không khớp. Vui lòng nhập lại!");
                    txtNewPassword.Password = "";
                    txtConfirmNewPass.Password = "";
                    return;
                }
                //Ma hoa password
                string outputPassword = "";
                using (MD5 md5Hash = MD5.Create())
                {
                    outputPassword = GetMd5Hash(md5Hash, txtNewPassword.Password.ToString());
                }
                try
                {
                    User editUser = new User(txtAddUsername.Text, txtAddFullname.Text, outputPassword, txtAddEmail.Text, currentUser.role_id);
                    editUser.id = Convert.ToInt32(txtUserId.Text);
                    int id = DataManager.getInstance().updateUser(editUser);
                    MessageBox.Show("Cập nhật người dùng thành công!");
                    User myaccount = DataManager.getInstance().getUserWithID(currentUser.id);
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
                    User editUser = new User(txtAddUsername.Text, txtAddFullname.Text, txtNewPassword.Password, txtAddEmail.Text, currentUser.role_id);
                    editUser.id = Convert.ToInt32(txtUserId.Text);
                    int id = DataManager.getInstance().updateUserNoPass(editUser);
                    MessageBox.Show("Cập nhật người dùng thành công!");
                    User myaccount = DataManager.getInstance().getUserWithID(currentUser.id);
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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                Application.Current.Properties["UserInfo"] = null;
                LoginWindow login = new LoginWindow();
                login.Show();
                parentWindow.Close();
            }
        }
    }
}
