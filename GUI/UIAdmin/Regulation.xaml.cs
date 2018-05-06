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
            LoadRegulation();

            try
            {
                //Quan ly danh sach loai benh
                List<Sickness> listSickness = DataManager.getInstance().getAllSickness();
                sicknessDataGrid.DataContext = listSickness;

                //Quan ly don vi thuoc
                List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();
                unitDataGrid.DataContext = listUnit;

                //Quan ly cach dung
                List<UserMedicine> listUse = DataManager.getInstance().getAllUseMedicine();
                useMedicineDataGrid.DataContext = listUse;

                //Quan ly thuoc
                List<FullMedicine> listMedicine = DataManager.getInstance().getAllMedicine();
                medicineDataGrid.DataContext = listMedicine;
            }
            catch
            {
                MessageBox.Show("Error!");
            }
            
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
                LoadRegulation();
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        public void LoadRegulation()
        {
            dpApplyDate.SelectedDate = DateTime.Today;
            try
            {
                List<ChangeRegulation> listReg = DataManager.getInstance().getAllRegulation();
                foreach (var row in listReg)
                {
                    if (row.name_function == "fee")
                    {
                        if (row.date_apply < DateTime.Now)
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
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        //Quan ly loai benh
        private void btnAddSickness_Click(object sender, RoutedEventArgs e)
        {
            AddSickness addSick = new AddSickness(null);
            addSick.ShowDialog();
            List<Sickness> listSickness = DataManager.getInstance().getAllSickness();
            sicknessDataGrid.DataContext = listSickness;
        }

        private void btnEditSickness_Click(object sender, RoutedEventArgs e)
        {
            Sickness sick = sicknessDataGrid.SelectedItem as Sickness;
            AddSickness editSick = new AddSickness(sick);
            editSick.ShowDialog();
            List<Sickness> listSickness = DataManager.getInstance().getAllSickness();
            sicknessDataGrid.DataContext = listSickness;
        }

        private void btnDeleteSickness_Click(object sender, RoutedEventArgs e)
        {
            Sickness item = sicknessDataGrid.SelectedItem as Sickness;
            int countMedicalExam = DataManager.getInstance().countMedicalExamBySickID(item.id);
            if (countMedicalExam > 0)
            {
                MessageBox.Show("Có phiếu khám bệnh đang sử dụng loại bệnh này. Không thể xóa được!");
                return;
            }
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteSickness(item.id, currentUser.id);
                MessageBox.Show("Xóa loại bệnh thành công!");
                List<Sickness> listSickness = DataManager.getInstance().getAllSickness();
                sicknessDataGrid.DataContext = listSickness;
            }
            catch
            {
                MessageBox.Show("Xóa loại bệnh thất bại!");
            }
        }

        //Quan ly don vi thuoc
        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            AddUnitMedicine addUnit = new AddUnitMedicine(null);
            addUnit.ShowDialog();
            List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();
            unitDataGrid.DataContext = listUnit;
        }

        private void btnEditUnit_Click(object sender, RoutedEventArgs e)
        {
            UnitMedicine unit = unitDataGrid.SelectedItem as UnitMedicine;
            AddUnitMedicine addUnit = new AddUnitMedicine(unit);
            addUnit.ShowDialog();
            List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();
            unitDataGrid.DataContext = listUnit;
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            UnitMedicine item = unitDataGrid.SelectedItem as UnitMedicine;
            int countUnitPrice = DataManager.getInstance().countUnitPriceMedicineByUnitID(item.id);
            if (countUnitPrice > 0)
            {
                MessageBox.Show("Có thuốc đang sử dụng đơn vị này. Không thể xóa được!");
                return;
            }
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteUnitMedicine(item.id, currentUser.id);
                MessageBox.Show("Xóa đơn vị thành công!");
                List<UnitMedicine> listUnit = DataManager.getInstance().getAllUnit();
                unitDataGrid.DataContext = listUnit;
            }
            catch
            {
                MessageBox.Show(e.ToString());
            }
        }

        //Quan ly cach dung
        private void btnAddUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddUseMedicine addUse = new AddUseMedicine(null);
            addUse.ShowDialog();
            List<UserMedicine> listUse = DataManager.getInstance().getAllUseMedicine();
            useMedicineDataGrid.DataContext = listUse;
        }

        private void btnEditUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            UserMedicine use = useMedicineDataGrid.SelectedItem as UserMedicine;
            AddUseMedicine addUse = new AddUseMedicine(use);
            addUse.ShowDialog();
            List<UserMedicine> listUse = DataManager.getInstance().getAllUseMedicine();
            useMedicineDataGrid.DataContext = listUse;
        }

        private void btnDeleteUseMedicine_Click(object sender, RoutedEventArgs e)
        {
            UserMedicine item = useMedicineDataGrid.SelectedItem as UserMedicine;
            int countPrescription = DataManager.getInstance().countPrescriptionByUseID(item.id);
            if (countPrescription > 0)
            {
                MessageBox.Show("Có đơn thuốc đang sử dụng cách dùng này. Không thể xóa được!");
                return;
            }
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteUseMedicine(item.id, currentUser.id);
                MessageBox.Show("Xóa cách dùng thành công!");
                List<UserMedicine> listUse = DataManager.getInstance().getAllUseMedicine();
                useMedicineDataGrid.DataContext = listUse;
            }
            catch
            {
                MessageBox.Show("Xóa cách dùng thất bại!");
            }
        }

        //Quan ly thuoc
        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddMedicine addMedicine = new AddMedicine(null);
            addMedicine.ShowDialog();
            List<FullMedicine> listMedicine = DataManager.getInstance().getAllMedicine();
            medicineDataGrid.DataContext = listMedicine;
        }

        private void btnEditMedicine_Click(object sender, RoutedEventArgs e)
        {
            FullMedicine medicine = medicineDataGrid.SelectedItem as FullMedicine;
            AddMedicine addMedicine = new AddMedicine(medicine);
            addMedicine.ShowDialog();
            List<FullMedicine> listMedicine = DataManager.getInstance().getAllMedicine();
            medicineDataGrid.DataContext = listMedicine;
        }

        private void btnDeleteMedicine_Click(object sender, RoutedEventArgs e)
        {
            FullMedicine item = medicineDataGrid.SelectedItem as FullMedicine;
            int countPrescription = DataManager.getInstance().countPrescriptionByID(item.id);
            if(countPrescription > 0)
            {
                MessageBox.Show("Có đơn thuốc đang sử dụng loại thuốc này. Không thể xóa được!");
                return;
            }
            try
            {
                User currentUser = new User();
                currentUser = (User)Application.Current.Properties["UserInfo"];
                int id = DataManager.getInstance().deleteMedicine(item.id, currentUser.id);
                MessageBox.Show("Xóa thuốc thành công!");
                List<FullMedicine> listMedicine = DataManager.getInstance().getAllMedicine();
                medicineDataGrid.DataContext = listMedicine;
            }
            catch
            {
                MessageBox.Show("Xóa thuốc thất bại!");
            }
        }
    }
}
