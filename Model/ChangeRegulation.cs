using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class ChangeRegulation
    {
        private DateTime _modified;
        private int _id_function;
        private string _name_function;
        private long _value_old;
        private DateTime _date_apply;
        private long _value_apply;

        public DateTime odified { get { return _modified; } set { _modified = value; } }
        public int id_function { get { return _id_function; } set { _id_function = value; } }
        public string name_function { get { return _name_function; } set { _name_function = value; } }
        public long value_old { get { return _value_old; } set { _value_old = value; } }
        public DateTime date_apply { get { return _date_apply; } set { _date_apply = value; } }
        public long value_apply { get { return _value_apply; } set { _value_apply = value; } }
    }
}
