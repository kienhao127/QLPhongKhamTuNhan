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
            var role = new Dictionary<int, string>
            {
                [1] = "Admin",
                [2] = "Bác sĩ",
                [3] = "Tiếp tân"
            };
            cbRole.DataContext = role;
        }

        private void btnAddUserDB_Click(object sender, RoutedEventArgs e)
        {
            var selectRole = cbRole.SelectedItem;
        }
    }
}
