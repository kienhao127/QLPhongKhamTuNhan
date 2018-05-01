using System;
using System.Collections.Generic;
using System.Windows;
using QLPhongKhamTuNhan.GUI.UIAdmin;
using QLPhongKhamTuNhan.GUI.UIGeneral;
using QLPhongKhamTuNhan.GUI.UIReceptionist;
using QLPhongKhamTuNhan.GUI.UIDoctor;
using QLPhongKhamTuNhan.GUI.UIReport;
using Manager;

namespace QLPhongKhamTuNhan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model.User currentUser = new Model.User();
        public MainWindow()
        {
            InitializeComponent();
            currentUser = (Model.User)Application.Current.Properties["UserInfo"];
            List<int> listFunc = DataManager.getInstance().getRoleFunction(currentUser.role_id);
            setRold(listFunc);
            Main.Content = new Home();
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Dashboard();
        }

        private void btnMakeListPatientMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MakeListPatient();
        }

        private void btnListPatientMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ListOfPatient();
        }

        private void btnTurnOverMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Turnover();
        }

        private void btnMedicineMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Medicine();
        }

        private void btnRegulationMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Regulation();
        }

        private void btnUserMenu_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new UserManagement();
        }

        void setRold(List<int> listFunc)
        {
            if (!listFunc.Contains(Convert.ToInt32(btnDashboard.Tag)))
            {
                btnDashboard.Visibility = Visibility.Collapsed;
            }
            if (!listFunc.Contains(Convert.ToInt32(btnListPatientMenu.Tag)))
            {
                btnListPatientMenu.Visibility = Visibility.Collapsed;
            }
            if (!listFunc.Contains(Convert.ToInt32(btnMakeListPatientMenu.Tag)))
            {
                btnMakeListPatientMenu.Visibility = Visibility.Collapsed;
            }
            if (!listFunc.Contains(Convert.ToInt32(btnMedicineMenu.Tag)))
            {
                btnMedicineMenu.Visibility = Visibility.Collapsed;
            }
            if (!listFunc.Contains(Convert.ToInt32(btnRegulationMenu.Tag)))
            {
                btnRegulationMenu.Visibility = Visibility.Collapsed;
            }
            if (!listFunc.Contains(Convert.ToInt32(btnTurnOverMenu.Tag)))
            {
                btnTurnOverMenu.Visibility = Visibility.Collapsed;
            }
            if (!listFunc.Contains(Convert.ToInt32(btnUserMenu.Tag)))
            {
                btnUserMenu.Visibility = Visibility.Collapsed;
            }
        }
    }
}
