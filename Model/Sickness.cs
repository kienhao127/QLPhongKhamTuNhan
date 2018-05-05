using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    public class Sickness
    {
        private int _id;
        private string _name;
        private string _noted;
        private bool _is_delete;
        private int _user_id_change;
        private User _user_change;

        public int id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string noted { get { return _noted; } set { _noted = value; } }
        public bool is_delete { get { return _is_delete; } set { _is_delete = value; } }
        public int user_id_change { get { return _user_id_change; } set { _user_id_change = value; } }
        internal User user_change { get { return _user_change; } set { _user_change = value; } }
    }
}