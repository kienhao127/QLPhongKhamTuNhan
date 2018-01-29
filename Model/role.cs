using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class Role
    {
        private int _id;
        private int _function;
        private bool _is_delete;

        public int id { get { return _id; } set { _id = value; } }
        public int function { get { return _function; } set { _function = value; } }
        public bool is_delete { get { return _is_delete; } set { _is_delete = value; } }
    }
}
