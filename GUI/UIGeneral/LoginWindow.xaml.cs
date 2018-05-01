using Helper;
using Manager;
using QLPhongKhamTuNhan.GUI.UIReport;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace QLPhongKhamTuNhan.GUI.UIGeneral
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //   int iLogIn = relatedUser.logIn(txtUserName.Text, txtPassword.Password);
            User currentUser = DataManager.getInstance().login(txtUserName.Text, txtPassword.Password);

            if (currentUser != null)
            {
                if (Application.Current.Properties["UserInfo"] == null)
                {
                    Application.Current.Properties["UserInfo"] = currentUser;
                }

                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }
    }
}
