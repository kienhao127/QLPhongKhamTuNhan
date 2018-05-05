﻿using Manager;
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
    /// Interaction logic for AddUseMedicine.xaml
    /// </summary>
    public partial class AddUseMedicine : Window
    {
        public AddUseMedicine(UserMedicine use)
        {
            InitializeComponent();
            if (use == null)
            {
                btnEditUseMedicine.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAddUseMedicine.Visibility = Visibility.Hidden;
                DataContext = use;
            }
        }

        private void btnAddUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            UserMedicine addUse = new UserMedicine();
            addUse.name = txtNameUseMedicine.Text;
            addUse.detail = txtDetailUseMedicine.Text;

            try
            {
                int id = DataManager.getInstance().insertUseMedicine(addUse, currentUser.id);
                MessageBox.Show("Thêm cách dùng thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Thêm cách dùng thất bại!");
            }
        }

        private void btnEditUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            UserMedicine editUse = new UserMedicine();
            editUse.id = Convert.ToInt32(txtUseId.Text);
            editUse.name = txtNameUseMedicine.Text;
            editUse.detail = txtDetailUseMedicine.Text;

            try
            {
                int id = DataManager.getInstance().updateUseMedicine(editUse, currentUser.id);
                MessageBox.Show("Cập nhật cách dùng thành công!");
                Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật cách dùng thất bại!");
            }
        }
    }
}
