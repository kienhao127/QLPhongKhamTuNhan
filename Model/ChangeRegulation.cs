using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class ChangeRegulation
    {
        DateTime modified { get; set; }
        int id_function { get; set; }
        string name_function { get; set; }
        long value_old { get; set; }
        DateTime date_apply { get; set; }
        long value_apply { get; set; }
    }
}
