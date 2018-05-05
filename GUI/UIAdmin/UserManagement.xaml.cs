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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLPhongKhamTuNhan.GUI.UIAdmin
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        public UserManagement()
        {
            InitializeComponent();
            DataContext = DataManager.getInstance().getAllUser();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser newUser = new AddUser(null);
            newUser.ShowDialog();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            User item = userDataGrid.SelectedItem as User;
            AddUser editUser = new AddUser(item);
            editUser.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            User item = userDataGrid.SelectedItem as User;
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteUser(item.id, currentUser.id);
                MessageBox.Show("Xóa người dùng thành công!");
            }
            catch
            {
                MessageBox.Show("Xóa người dùng thất bại!");
            }
        }
    }
}
