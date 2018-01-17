using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class User
    {
        int id { get; set; }
        string name { get; set; }
        string full_name { get; set; }
        string password { get; set; }
        string email { get; set; }
        int role_id { get; set; }
        Role role { get; set; }
    }
}
