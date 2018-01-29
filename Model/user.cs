using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class User
    {
        private int _id;
        private string _name;
        private string _full_name;
        private string _password;
        private string _email;
        private int _role_id;
        private List<Role> _role;

        public int id { get { return _id; } set { _id = value; } }
        public string name { get { return _name; } set { _name = value; } }
        public string full_name { get { return _full_name; } set { _full_name = value; } }
        public string password { get { return _password; } set { _password = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public int role_id { get { return _role_id; } set { _role_id = value; } }
        internal List<Role> role { get { return _role; } set { _role = value; } }
    }
}
