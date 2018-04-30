using Helper;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    class DataHelper
    {
        public DataHelper()
        {

        }

        public User login(string username, string pw)
        {
            DataTable dt = Active.select("select id from user where user='" + username + "' and pw='" + pw + "'");
            User user = new User();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                user.id = Convert.ToInt32(dt.Rows[0].ItemArray[i]);

            }
            return user;
        }
    }
}
