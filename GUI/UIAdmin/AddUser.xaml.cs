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
        public AddUser()
        {
            InitializeComponent();
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
            User newUser = new User(txtAddUsername.Text, txtAddFullname.Text, txtAddPassword.Password, txtAddEmail.Text, selectRole + 1);
            int id = DataManager.getInstance().insertUser(newUser);
        }
    }
}
