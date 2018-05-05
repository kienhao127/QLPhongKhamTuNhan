using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    public class Patient
    {
        private int _id;
        private string _full_name;
        private string _sex;
        private int _year_of_birth;
        private string _address;
        private bool _is_delete;

        public int id { get { return _id; } set { _id = value; } }
        public string full_name { get { return _full_name; } set { _full_name = value; } }
        public string sex { get { return _sex; } set { _sex = value; } }
        public int year_of_birth { get { return _year_of_birth; } set { _year_of_birth = value; } }
        public string address { get { return _address; } set { _address = value; } }
        public bool is_delete { get { return _is_delete; } set { _is_delete = value; } }
    }
}
