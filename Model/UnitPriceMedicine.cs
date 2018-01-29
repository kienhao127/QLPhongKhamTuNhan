using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class UnitPriceMedicine
    {
        private int _medicine_id;
        private int _unit_id;
        private long _unit_price;
        private bool _is_delete;
        private int _user_id_change;
        private Medicine _medicine;
        private UnitMedicine _unit_medicine;
        private User _user_change;

        public int medicine_id { get { return _medicine_id; } set { _medicine_id = value; } }
        public int unit_id { get { return _unit_id; } set { _unit_id = value; } }
        public long unit_price { get { return _unit_price; } set { _unit_price = value; } }
        public bool is_delete { get { return _is_delete; } set { _is_delete = value; } }
        public int user_id_change { get { return _user_id_change; } set { _user_id_change = value; } }
        internal Medicine medicine { get { return _medicine; } set { _medicine = value; } }
        internal UnitMedicine unit_medicine { get { return _unit_medicine; } set { _unit_medicine = value; } }
        internal User user_change { get { return _user_change; } set { _user_change = value; } }
    }
}
