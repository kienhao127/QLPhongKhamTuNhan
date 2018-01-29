using MySql.Data.MySqlClient;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLPhongKhamTuNhan.DataHelper
{
    class relatedUser
    {
        /*
         * ham dang nhap
         * dau vao: user - ten dang nhap, pass - mat khau
         * tra ve:  -1 - khong ket noi duoc database
         *          0 - nhap sai ten dang nhap va mat khau
         *          1 - nhap sai ten dang nhap
         *          2 - nhap sai mat khau
         *          3 - dang nhap thanh cong
        */
        static public int logIn(string user,string pass)
        {
            DataTable dt = Active.select("select user,pw form user");

            if (dt == null) return -1;

            if (dt.Rows.Count == 0) return 0;

            if (dt.Rows[0][0].ToString() != user) return 1;

            if (dt.Rows[0][1].ToString() != user) return 2;

            return 3;
        }

        static public int addUser(User u)
        {
            return 1;
        }
    }
}
