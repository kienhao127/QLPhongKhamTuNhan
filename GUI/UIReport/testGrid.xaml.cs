using QLPhongKhamTuNhan.GUI.UIReport;
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

namespace QLPhongKhamTuNhan.GUI.UIReport
{
    /// <summary>
    /// Interaction logic for testGrid.xaml
    /// </summary>
    public partial class testGrid : Window
    {
        public testGrid(DataTable dg)
        {
            InitializeComponent();
                        
            dataGrid.ItemsSource = dg.DefaultView;

            dataGrid.Columns.Add(new DataGridTextColumn {
                Header="NGÀY THAY ĐỔI",
                Binding=new Binding("modifled_day")
            });
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            dataGrid.Width = grid.Width;
            dataGrid.Height = grid.Height;
        }
    }
}
