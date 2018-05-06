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

namespace QLPhongKhamTuNhan.GUI.UIReceptionist
{
    /// <summary>
    /// Interaction logic for CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Window
    {
        Patient patient = new Patient();
        public CreatePatient()
        {
            InitializeComponent();
        }

        public CreatePatient(Patient p)
        {
            InitializeComponent();
            txtHoTen.Text = p.full_name;
            txtNamSinh.Text = p.year_of_birth.ToString();
            txtDiaChi.Text = p.address;
            if (p.sex == "Nam")
            {
                cboGioiTinh.SelectedIndex = 0;
            }
            else
            {
                cboGioiTinh.SelectedIndex = 1;
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            patient.full_name = txtHoTen.Text;
            patient.year_of_birth = Convert.ToInt32(txtNamSinh.Text);
            patient.address = txtDiaChi.Text;
            patient.sex = cboGioiTinh.SelectedIndex == 0 ? "Nam" : "Nữ";
            DataManager.getInstance().insertPatient(patient);
            Close();
        }
    }
}
