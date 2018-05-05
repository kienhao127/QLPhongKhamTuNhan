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
            DataTable dt = Active.select("select id, role_id from user where user='" + username + "' and pw='" + pw + "' and is_delete = " + 0);
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

        static public List<string> getListSicknessName()
        {
            List<string> listSickName = new List<string>();
            DataTable dt = Active.select("select name from sickness where is_delete = " + 0);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = "";
                s = dt.Rows[i]["name"].ToString();
                listSickName.Add(s);
            }
            return listSickName;
        }

        static public List<string> getListMedicineName()
        {
            List<string> listMedicineName = new List<string>();
            DataTable dt = Active.select("select name from medicine where is_delete = " + 0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = "";
                s = dt.Rows[i]["name"].ToString();
                listMedicineName.Add(s);
            }
            return listMedicineName;
        }

        static public List<Patient> getListPatient()
        {
            List<Patient> listPatient = new List<Patient>();
            DataTable dt = Active.select("select * from patient where is_delete = " + 0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Patient p = new Patient();
                p.id = Convert.ToInt32(dt.Rows[i]["id"]);
                p.full_name = dt.Rows[i]["name"].ToString();
                p.sex = Convert.ToInt32(dt.Rows[i]["sex"]) == 1 ? "Nam" : "Nữ" ;
                p.year_of_birth = Convert.ToInt32(dt.Rows[i]["yob"]);
                p.address = dt.Rows[i]["address"].ToString();
                listPatient.Add(p);
            }
            return listPatient;

        }
    }
}
