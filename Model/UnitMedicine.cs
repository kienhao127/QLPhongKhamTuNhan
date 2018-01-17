using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class UnitMedicine
    {
        int id { get; set; }
        string name { get; set; }
        bool is_delete { get; set; }
        int user_id_change { get; set; }
        User user_change { get; set; }
    }
}
