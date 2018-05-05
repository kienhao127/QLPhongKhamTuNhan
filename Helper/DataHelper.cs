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
        static public User login(string username, string pw)
        {
            DataTable dt = Active.select("select id, role_id from user where user='" + username + "' and pw='" + pw + "'");
            User user = new User();
            for (int i = 0; i < dt.Rows.Count && dt != null; i++)
            {
                user.id = Convert.ToInt32(dt.Rows[i].ItemArray[0]);
                user.role_id = Convert.ToInt32(dt.Rows[i].ItemArray[1]);
            }
            return user;
        }

        //Phân quyền người dùng
        static public List<int> getRoleFunction(int roleid)
        {
            DataTable dt = Active.select("select function from role_function where role=" + roleid + " and is_delete = " + 0);
            List<int> listFunc = new List<int>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listFunc.Add(Convert.ToInt32(dt.Rows[i].ItemArray[0]));
            }
            return listFunc;
        }

        static public int countAllUser()
        {
            DataTable dt = Active.select("SELECT * FROM user");
            return dt.Rows.Count;
        }

        static public int countAllPatient()
        {
            DataTable dt = Active.select("SELECT COUNT(DISTINCT p.id) totalPatient FROM patient p, medical_exam me WHERE p.id = me.patient_id and MONTH(me.`date_exam`) = MONTH(CURRENT_DATE()) ");
            return Convert.ToInt32(dt.Rows[0]["totalPatient"]);
        }

        static public int getTurnover()
        {
            DataTable dt = Active.select("SELECT SUM(me.fee_exam) + SUM(me.fee_medicine) as turnover FROM medical_exam as me WHERE MONTH(me.`date_exam`) = MONTH(CURRENT_DATE()) ");
            int result = 0;
            if (dt.Rows[0]["turnover"].ToString() != "")
            {
                result = Convert.ToInt32(dt.Rows[0]["turnover"]);
            }
            return result;
        }

        static public int insertUser(User u)
        {
            int id = Active.insert("INSERT INTO user(user, name, pw, email, role_id) VALUES ('" + u.name + "',N'" + u.full_name + "','" + u.password + "','" + u.email + "','" + u.role_id + "')");
            return id;
        }

        static public List<User> getAllUser()
        {
            DataTable dt = Active.select("select * from user where is_delete = " + 0);
            List<User> listUser = new List<User>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                User u = new User();
                u.id = Convert.ToInt32(dt.Rows[i]["id"]);
                u.name = dt.Rows[i]["user"].ToString();
                u.full_name = dt.Rows[i]["name"].ToString();
                u.password = dt.Rows[i]["pw"].ToString();
                u.email = dt.Rows[i]["email"].ToString();
                u.role_id = Convert.ToInt32(dt.Rows[i]["role_id"]);
                listUser.Add(u);
            }
            return listUser;
        }

        static public int updateUser(User u)
        {
            int id = Active.update("UPDATE user SET user = '" + u.name + "', name = N'" + u.full_name + "', pw = '" + u.password + "', email = '" + u.email + "', role_id = '" + u.role_id + "' where id = " + u.id + "");
            return id;
        }

        static public int deleteUser(int userid, int is_delete)
        {
            int id = Active.update("UPDATE user SET is_delete = '" + is_delete + "' where id = '" + userid + "'");
            return id;
        }

        static public List<ChangeRegulation> getAllRegulation()
        {
            DataTable dt = Active.select(" select * from change_reg ");
            List<ChangeRegulation> listRegulation = new List<ChangeRegulation>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ChangeRegulation reg = new ChangeRegulation();
                reg.id_function = Convert.ToInt32(dt.Rows[i]["id_function"]);
                reg.name_function = dt.Rows[i]["name_function"].ToString();
                reg.value_old = Convert.ToInt32(dt.Rows[i]["value_old"]);
                reg.date_apply = Convert.ToDateTime(dt.Rows[i]["date_apply"]);
                reg.value_apply = Convert.ToInt32(dt.Rows[i]["value_new"]);
                listRegulation.Add(reg);
            }
            return listRegulation;
        }

        static public int updateRegulation(ChangeRegulation updateFee, ChangeRegulation updatePatient, int user_update)
        {
            int id = Active.update("UPDATE change_reg SET modifled_day = '" + updateFee.modified.ToString("yyyy-MM-dd HH:mm:ss") + "', value_old = '" + updateFee.value_old + "', value_new = '" + updateFee.value_apply + "', user_change = '" + user_update + "', date_apply = '" + updateFee.date_apply.ToString("yyyy-MM-dd HH:mm:ss") + "' where id_function = " + updateFee.id_function + "");
            id = Active.update("UPDATE change_reg SET modifled_day = '" + updatePatient.modified.ToString("yyyy-MM-dd HH:mm:ss") + "', value_old = '" + updatePatient.value_old + "', value_new = '" + updatePatient.value_apply + "', user_change = '" + user_update + "', date_apply = '" + updatePatient.date_apply.ToString("yyyy-MM-dd HH:mm:ss") + "' where id_function = " + updatePatient.id_function + "");
            return id;
        }
    }
}
