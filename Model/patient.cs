using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class Patient
    {
        int id { get; set; }
        string full_name { get; set; }
        string sex { get; set; }
        int year_of_birth { get; set; }
        string address { get; set; }
        bool is_delete { get; set; }
    }
}
