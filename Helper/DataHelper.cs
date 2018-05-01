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

        //Người dùng
        public User login(string username, string pw)
        {
            DataTable dt = Active.select("select id, role_id from user where user='" + username + "' and pw='" + pw + "'");
            User user = new User();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                user.id = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                user.role_id = Convert.ToInt32(dt.Rows[i].ItemArray[1]);
            }
            return user;
        }

        //Phân quyền người dùng
        public List<int> getRoleFunction(int roleid)
        {
            DataTable dt = Active.select("select function from role_function where role=" + roleid + " and is_delete = " + 0);
            List<int> listFunc = new List<int>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listFunc.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0]));
            }
            return listFunc;
        }
    }
}
