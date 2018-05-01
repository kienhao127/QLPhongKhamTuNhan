using Manager;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            int totalUser = DataManager.getInstance().countAllUser();
            tblTotalUser.Text = totalUser.ToString();
            int totalPatient = DataManager.getInstance().countAllPatient();
            tblTotalPatient.Text = totalPatient.ToString();
            int turnover = DataManager.getInstance().getTurnover();
            tblTotalTurnover.Text = turnover.ToString();
        }
    }
}
