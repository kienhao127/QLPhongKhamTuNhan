using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class UnitPriceMedicine
    {
        int medicine_id { get; set; }
        int unit_id { get; set; }
        long unit_price { get; set; }
        bool is_delete { get; set; }
        int user_id_change { get; set; }
        Medicine medicine { get; set; }
        UnitMedicine unit_medicine { get; set; }
        User user_change { get; set; }
    }
}
