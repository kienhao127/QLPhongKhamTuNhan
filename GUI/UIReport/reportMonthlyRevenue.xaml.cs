using Helper;
using Microsoft.Reporting.WinForms;
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
    /// Interaction logic for reportDoanhThuThang.xaml
    /// </summary>
    public partial class reportDoanhThuThang : Window
    {
        public reportDoanhThuThang()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            report.Reset();            
            
            
            ReportDataSource ds = new ReportDataSource("dataset", Active.select("SELECT m0.date_exam, "+
                                                                                "COUNT(*) num_patient, " +
                                                                                "SUM(m0.fee_exam + m0.fee_medicine) day_revenue," +
                                                                                "sum(m0.fee_exam + m0.fee_medicine) / totals.total radio" +
                                                                                "FROM medical_exam m0, (" +
                                                                                "    select m1.date_exam," +
                                                                                "    SUM(m1.fee_exam + m1.fee_medicine) total" +
                                                                                "    from medical_exam m1" +
                                                                                "    WHERE MONTH(m1.date_exam) = "+cbxMonth.SelectedValue +
                                                                                "        and YEAR(m1.date_exam) = " + cbxYear.SelectedValue +
                                                                                "    GROUP BY m1.date_exam" +
                                                                                ") as totals" +
                                                                                "WHERE MONTH(m0.date_exam) = " + cbxMonth.SelectedValue +
                                                                                "        and YEAR(m0.date_exam) = " + cbxYear.SelectedValue +
                                                                                "        and totals.date_exam = m0.date_exam" +
                                                                                "GROUP by date_exam"));

            report.LocalReport.DataSources.Add(ds);

            report.LocalReport.ReportEmbeddedResource = "QLPhongKhamTuNhan.GUI.UIReport.reportMonthlyRevenue.rdlc";

            ReportParameter rp = new ReportParameter("txtMonth", "Tháng: " + cbxMonth.SelectedValue + "/" + cbxYear.SelectedValue);
            report.LocalReport.SetParameters(new ReportParameter[] { rp });

            report.RefreshReport();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
                cbxMonth.Items.Add(i.ToString());
            cbxMonth.SelectedValue = DateTime.Now.Month.ToString();

            for (int i = DateTime.Now.Year; i >= 1996; i--)
            {
                cbxYear.Items.Add(i.ToString());
            }
            cbxYear.SelectedValue = DateTime.Now.Year.ToString();
        }
    }
}
