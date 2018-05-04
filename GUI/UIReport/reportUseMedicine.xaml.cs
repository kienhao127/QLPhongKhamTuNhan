using Helper;
using Microsoft.Reporting.WinForms;
using QLPhongKhamTuNhan.Manager;
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

namespace QLPhongKhamTuNhan.GUI.UIReport
{
    /// <summary>
    /// Interaction logic for reportUseMedicine.xaml
    /// </summary>
    public partial class reportUseMedicine : Window
    {
        public reportUseMedicine()
        {
            InitializeComponent();
            SizeChanged += ReportUseMedicine_SizeChanged;
        }

        private void ReportUseMedicine_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            wfh.Width = Width - 16;
            wfh.Height = Height - 39 - 47;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
                cbxMonth.Items.Add(i.ToString());
            cbxMonth.SelectedValue = DateTime.Now.Month.ToString();

            for (int i = DateTime.Now.Year; i >= 1996; i--)
                cbxYear.Items.Add(i.ToString());
            cbxYear.SelectedValue = DateTime.Now.Year.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            report.Reset();


            ReportDataSource ds = new ReportDataSource("dataset", DataReport.UseMedicine(cbxMonth.SelectedValue.ToString(),cbxYear.SelectedValue.ToString()));

            report.LocalReport.DataSources.Add(ds);

            report.LocalReport.ReportEmbeddedResource = "QLPhongKhamTuNhan.GUI.UIReport.reportUseMedicine.rdlc";

            ReportParameter rp = new ReportParameter("txtMonth", "Tháng: " + cbxMonth.SelectedValue + " năm " + cbxYear.SelectedValue);
            report.LocalReport.SetParameters(new ReportParameter[] { rp });

            report.RefreshReport();
        }
    }
}
