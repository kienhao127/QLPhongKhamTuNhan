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
                user.id = Convert.ToInt32(dt.Rows[i]["id"]);
                user.role_id = Convert.ToInt32(dt.Rows[i]["role_id"]);
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
                listFunc.Add(Convert.ToInt32(dt.Rows[i]["function"]));
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
                p.sex = Convert.ToInt32(dt.Rows[i]["sex"]) == 1 ? "Nam" : "Nữ";
                p.year_of_birth = Convert.ToInt32(dt.Rows[i]["yob"]);
                p.address = dt.Rows[i]["address"].ToString();
                listPatient.Add(p);
            }
            return listPatient;
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

        static public List<Sickness> getAllSickness()
        {
            DataTable dt = Active.select("select * from sickness where is_delete = " + 0);
            List<Sickness> listSickness = new List<Sickness>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sickness sick = new Sickness();
                sick.id = Convert.ToInt32(dt.Rows[i]["id"]);
                sick.name = dt.Rows[i]["name"].ToString();
                sick.noted = dt.Rows[i]["noted"].ToString();
                listSickness.Add(sick);
            }
            return listSickness;
        }

        static public int getMedicineID(string medicineName)
        {
            DataTable dt = Active.select("SELECT id from medicine where name = '" + medicineName + "'");
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            int id = Convert.ToInt32(dt.Rows[0]["id"]);
            return id;

        }

        static public int getUseID(string useName)
        {
            DataTable dt = Active.select("SELECT id from use_medicine where name = '" + useName + "'");
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            int id = Convert.ToInt32(dt.Rows[0]["id"]);
            return id;

        }

        static public List<string> getListUseName()
        {
            List<string> listUseName = new List<string>();
            DataTable dt = Active.select("select name from use_medicine where is_delete = " + 0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = "";
                s = dt.Rows[i]["name"].ToString();
                listUseName.Add(s);
            }
            return listUseName;
        }

        static public List<string> getListUnitName()
        {
            List<string> listUnitName = new List<string>();
            DataTable dt = Active.select("select name from unit_medicine where is_delete = " + 0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = "";
                s = dt.Rows[i]["name"].ToString();
                listUnitName.Add(s);
            }
            return listUnitName;
        }

        static public int getUnitID(string unitName)
        {
            DataTable dt = Active.select("SELECT id from unit_medicine where name = '" + unitName + "'");
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            int id = Convert.ToInt32(dt.Rows[0]["id"]);
            return id;

        }

        static public int insertSickness(Sickness sick, int user_update)
        {
            int id = Active.insert("INSERT INTO sickness(name, noted, user_change) VALUES (N'" + sick.name + "',N'" + sick.noted + "','" + user_update + "')");
            return id;
        }

        static public int updateSickness(Sickness sick, int user_change)
        {
            int id = Active.update("UPDATE sickness SET name = N'" + sick.name + "', noted = N'" + sick.noted + "', user_change = '" + user_change + "' where id = " + sick.id + "");
            return id;
        }

        static public int deleteSickness(int sick_id, int user_change)
        {
            int id = Active.update("UPDATE sickness SET is_delete = N'" + 1 + "', user_change = N'" + user_change + "' where id = " + sick_id + "");
            return id;
        }

        static public int getSicknessID(string sicknessName)
        {
            DataTable dt = Active.select("SELECT id from sickness where name = '" + sicknessName + "'");
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            int id = Convert.ToInt32(dt.Rows[0]["id"]);
            return id;
        }

        static public int insertPrescription(Prescription p, string code)
        {
            int num = Active.insert("INSERT INTO prescription(code, medicine_id, unit_id, amount, use_id) VALUES ('" + code + "', " + p.medicine_id + ", " + p.unit_id + ", " + p.amount + ", " + p.use_id + ")");
            return num;
        }

        static public int insertMedicalExam(string code, int patientID, int doctorID)
        {
            int num = Active.insert("INSERT INTO medical_exam(code, patient_id, physician_id, date_exam) VALUES ('" + code + "', " + patientID + ", " + doctorID + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
            return num;
        }

        static public int countMedicalExam()
        {
            DataTable dt = Active.select("SELECT COUNT(code) totalCode from medical_exam where date_exam = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            if (dt.Rows[0]["totalCode"] == null)
            {
                return -1;
            }
            int id = Convert.ToInt32(dt.Rows[0]["totalCode"]);
            return id;
        }

        static public int updateMedicalExam(string code, int sickID, string prognostic, int status)
        {
            int num = Active.update("UPDATE medical_exam SET sick_id = " + sickID + ", prognostic = N'" + prognostic + "', status = " + status + " where code = '" + code + "'");
            return num;
        }

        static public List<UnitMedicine> getAllUnit()
        {
            DataTable dt = Active.select("select * from unit_medicine where is_delete = " + 0);
            List<UnitMedicine> listUnit = new List<UnitMedicine>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UnitMedicine unit = new UnitMedicine();
                unit.id = Convert.ToInt32(dt.Rows[i]["id"]);
                unit.name = dt.Rows[i]["name"].ToString();
                listUnit.Add(unit);
            }
            return listUnit;
        }

        static public int insertUnitMedicine(UnitMedicine unit, int user_update)
        {
            int id = Active.insert("INSERT INTO unit_medicine(name, user_change) VALUES (N'" + unit.name + "','" + user_update + "')");
            return id;
        }

        static public int updateUnitMedicine(UnitMedicine unit, int user_change)
        {
            int id = Active.update("UPDATE unit_medicine SET name = N'" + unit.name + "', user_change = '" + user_change + "' where id = " + unit.id + "");
            return id;
        }

        static public int deleteUnitMedicine(int unit_id, int user_change)
        {
            int id = Active.update("UPDATE unit_medicine SET is_delete = N'" + 1 + "', user_change = N'" + user_change + "' where id = " + unit_id + "");
            return id;
        }
    }
}
