using Manager;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Regulation.xaml
    /// </summary>
    public partial class Regulation : Page
    {
        public Regulation()
        {
            InitializeComponent();
            dpApplyDate.SelectedDate = DateTime.Today;
            List<ChangeRegulation> listReg = DataManager.getInstance().getAllRegulation();
            foreach (var row in listReg)
            {
                if (row.name_function == "fee")
                {
                    if(row.date_apply < DateTime.Now)
                    {
                        txtFeeExam.Text = row.value_apply.ToString();
                        txtFeeOld.Text = row.value_apply.ToString();
                    }
                    else
                    {
                        txtFeeExam.Text = row.value_old.ToString();
                        txtFeeOld.Text = row.value_old.ToString();
                    }
                    txtFeeId.Text = row.id_function.ToString();
                }
                if (row.name_function == "patient")
                {
                    if (row.date_apply < DateTime.Now)
                    {
                        txtNumOfPatient.Text = row.value_apply.ToString();
                        txtPatientOld.Text = row.value_apply.ToString();
                    }
                    else
                    {
                        txtNumOfPatient.Text = row.value_old.ToString();
                        txtPatientOld.Text = row.value_old.ToString();
                    }
                    txtPatientId.Text = row.id_function.ToString();
                }
            }

            //Quan ly danh sach loai benh
            List<Sickness> listSickness = DataManager.getInstance().getAllSickness();
            sicknessDataGrid.DataContext = listSickness;

            //Quan ly don vi thuoc
            List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();
            unitDataGrid.DataContext = listUnit;

            //Quan ly cach dung
            List<UserMedicine> listUse = DataManager.getInstance().getAllUseMedicine();
            useMedicineDataGrid.DataContext = listUse;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SaveRegulation_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = new User();
            currentUser = (User)Application.Current.Properties["UserInfo"];

            ChangeRegulation updateFee = new ChangeRegulation();
            updateFee.modified = DateTime.Now;
            updateFee.id_function = Convert.ToInt32(txtFeeId.Text);
            updateFee.value_old = Convert.ToInt32(txtFeeOld.Text);
            updateFee.value_apply = Convert.ToInt32(txtFeeExam.Text);
            updateFee.date_apply = Convert.ToDateTime(dpApplyDate.SelectedDate);

            ChangeRegulation updateNumOfPatient = new ChangeRegulation();
            updateNumOfPatient.modified = DateTime.Now;
            updateNumOfPatient.id_function = Convert.ToInt32(txtPatientId.Text);
            updateNumOfPatient.value_old = Convert.ToInt32(txtPatientOld.Text);
            updateNumOfPatient.value_apply = Convert.ToInt32(txtNumOfPatient.Text);
            updateNumOfPatient.date_apply = Convert.ToDateTime(dpApplyDate.SelectedDate);

            try
            {
                int id = DataManager.getInstance().updateRegulation(updateFee, updateNumOfPatient, currentUser.id);
                MessageBox.Show("Cập nhật thành công!");
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnAddSickness_Click(object sender, RoutedEventArgs e)
        {
            AddSickness addSick = new AddSickness(null);
            addSick.ShowDialog();
        }

        private void btnEditSickness_Click(object sender, RoutedEventArgs e)
        {
            Sickness sick = sicknessDataGrid.SelectedItem as Sickness;
            AddSickness editSick = new AddSickness(sick);
            editSick.ShowDialog();
        }

        private void btnDeleteSickness_Click(object sender, RoutedEventArgs e)
        {
            Sickness item = sicknessDataGrid.SelectedItem as Sickness;
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteSickness(item.id, currentUser.id);
                MessageBox.Show("Xóa loại bệnh thành công!");
            }
            catch
            {
                MessageBox.Show("Xóa loại bệnh thất bại!");
            }
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            AddUnitMedicine addUnit = new AddUnitMedicine(null);
            addUnit.ShowDialog();
        }

        private void btnEditUnit_Click(object sender, RoutedEventArgs e)
        {
            UnitMedicine unit = unitDataGrid.SelectedItem as UnitMedicine;
            AddUnitMedicine addUnit = new AddUnitMedicine(unit);
            addUnit.ShowDialog();
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            UnitMedicine item = sicknessDataGrid.SelectedItem as UnitMedicine;
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteUnitMedicine(item.id, currentUser.id);
                MessageBox.Show("Xóa đơn vị thành công!");
            }
            catch
            {
                MessageBox.Show("Xóa đơn vị thất bại!");
            }
        }

        private void btnAddUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddUseMedicine addUse = new AddUseMedicine(null);
            addUse.ShowDialog();
        }

        private void btnEditUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            UserMedicine use = useMedicineDataGrid.SelectedItem as UserMedicine;
            AddUseMedicine addUse = new AddUseMedicine(use);
            addUse.ShowDialog();
        }

        private void btnDeleteUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            UserMedicine item = useMedicineDataGrid.SelectedItem as UserMedicine;
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteUseMedicine(item.id, currentUser.id);
                MessageBox.Show("Xóa cách dùng thành công!");
            }
            catch
            {
                MessageBox.Show("Xóa cách dùng thất bại!");
            }
        }
    }
}
