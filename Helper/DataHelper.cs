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
            DataTable dt = Active.select("select p.* from patient p, medical_exam m where p.is_delete = " + 0 + " and m.patient_id = p.id and m.fee_exam = 0 and m.date_exam = '" + DateTime.Now.ToString("yyyy-MM-dd") +"'");

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
            int num = Active.insert("INSERT INTO medical_exam(code, patient_id, physician_id, date_exam, status, fee_exam, fee_medicine) VALUES ('" + code + "', " + patientID + ", " + doctorID + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "', 1, 0, 0)");
            return num;
        }

        static public int updateMedicalExamStatus(string code, int status)
        {
            int num = Active.update("UPDATE medical_exam SET status = " + status + " WHERE code = '" + code + "'");
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

        static public int updateMedicalExam(string code, long feeExam, int feeMedicine)
        {
            int num = Active.update("UPDATE medical_exam SET fee_exam = " + feeExam + ", fee_medicine = " + feeMedicine + " where code = '" + code + "'");
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

        //Quan ly cach dung
        static public List<UserMedicine> getAllUseMedicine()
        {
            DataTable dt = Active.select("select * from use_medicine where is_delete = " + 0);
            List<UserMedicine> listUseMedicine = new List<UserMedicine>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserMedicine use = new UserMedicine();
                use.id = Convert.ToInt32(dt.Rows[i]["id"]);
                use.name = dt.Rows[i]["name"].ToString();
                use.detail = dt.Rows[i]["detail"].ToString();
                listUseMedicine.Add(use);
            }
            return listUseMedicine;
        }

        static public int insertUseMedicine(UserMedicine use, int user_update)
        {
            int id = Active.insert("INSERT INTO use_medicine(name, detail, user_change) VALUES (N'" + use.name + "',N'" + use.detail + "','"  + user_update + "')");
            return id;
        }

        static public int updateUseMedicine(UserMedicine use, int user_change)
        {
            int id = Active.update("UPDATE use_medicine SET name = N'" + use.name + "', detail = '" + use.detail + "', user_change = '" + user_change + "' where id = " + use.id + "");
            return id;
        }

        static public int deleteUseMedicine(int use_id, int user_change)
        {
            int id = Active.update("UPDATE use_medicine SET is_delete = N'" + 1 + "', user_change = N'" + user_change + "' where id = " + use_id + "");
            return id;
        }

        //Quan ly thuoc
        static public List<FullMedicine> getAllMedicine()
        {
            DataTable dt = Active.select("select medicine.id, medicine.`name`, medicine.another_name, unit_price_medicine.unit_id, unit_medicine.`name` as unit, unit_price_medicine.unit_price, unit_price_medicine.num_smallest_unit from medicine, unit_price_medicine, unit_medicine where medicine.id = unit_price_medicine.medicine_id and unit_price_medicine.unit_id = unit_medicine.id and medicine.is_delete = " + 0);
            List<FullMedicine> listFullMedicine = new List<FullMedicine>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FullMedicine medicine = new FullMedicine();
                medicine.id = Convert.ToInt32(dt.Rows[i]["id"]);
                medicine.name = dt.Rows[i]["name"].ToString();
                medicine.another_name = dt.Rows[i]["another_name"].ToString();
                medicine.unit_id = Convert.ToInt32(dt.Rows[i]["unit_id"]);
                medicine.unit_name = dt.Rows[i]["unit"].ToString();
                medicine.unit_price = Convert.ToInt64(dt.Rows[i]["unit_price"]);
                medicine.num_smallest_unit = Convert.ToInt32(dt.Rows[i]["num_smallest_unit"]);
                listFullMedicine.Add(medicine);
            }
            return listFullMedicine;
        }

        static public int insertMedicine(FullMedicine medicine, int user_update)
        {
            int id = Active.insert("INSERT INTO medicine(name, another_name, user_change) VALUES (N'" + medicine.name + "',N'" + medicine.another_name + "','" + user_update + "')");
            if(id > 0)
            {
                int id_unit_price = Active.insert("INSERT INTO unit_price_medicine(medicine_id, unit_id, unit_price, num_smallest_unit, user_change) VALUES ('" + id + "','" + medicine.unit_id + "','" + medicine.unit_price + "','" + medicine.num_smallest_unit + "','" + user_update + "')");
                return id;
            }
            return 0;
        }

        static public int updateMedicine(FullMedicine medicine, int user_change)
        {
            int id = Active.update("UPDATE medicine SET name = N'" + medicine.name + "', another_name = N'" + medicine.another_name + "', user_change = '" + user_change + "' where id = " + medicine.id + "");
            id = Active.update("UPDATE unit_price_medicine SET unit_id = '" + medicine.unit_id + "', unit_price = '" + medicine.unit_price + "', num_smallest_unit = '" + medicine.num_smallest_unit + "', user_change = '" + user_change + "' where medicine_id = " + medicine.id + "");
            return id;
        }

        static public int deleteMedicine(int medicine_id, int user_change)
        {
            int id = Active.update("UPDATE medicine SET is_delete = N'" + 1 + "', user_change = N'" + user_change + "' where id = " + medicine_id + "");
            id = Active.update("UPDATE unit_price_medicine SET is_delete = N'" + 1 + "', user_change = N'" + user_change + "' where medicine_id = " + medicine_id + "");
            return id;
        }

        static public int insertPatient(Patient p)
        {
            int sex = p.sex == "Nam" ? 1 : 0;
            int id = Active.insert("INSERT INTO patient(name, sex, yob, address, is_delete) VALUES (N'" + p.full_name + "', " + sex + ", " + p.year_of_birth +", N'" + p.address + "', 0)");
            return id;
        }

        static public List<int> getPatientIdInExam()
        {
            List<int> listID = new List<int>();
            DataTable dt = Active.select("SELECT patient_id FROM medical_exam WHERE date_exam = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and status = 1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = Convert.ToInt32(dt.Rows[i]["patient_id"]);
                listID.Add(id);
            }
            return listID;
        }
        
        static public Patient getPatientWithID(int id)
        {
            Patient p = new Patient();
            DataTable dt = Active.select("SELECT * FROM patient WHERE id = " + id + " and is_delete = " + 0);
            if (dt.Rows.Count != 0)
            {
                p.id = id;
                p.full_name = dt.Rows[0]["name"].ToString();
                p.sex = Convert.ToInt32(dt.Rows[0]["sex"]) == 1 ? "Nam" : "Nữ";
                p.address = dt.Rows[0]["address"].ToString();
                p.year_of_birth = Convert.ToInt32(dt.Rows[0]["yob"]);
                return p;
            }
            p.id = -1;
            return p;
        }

        static public string getExamCode(int patientID)
        {
            DataTable dt = Active.select("SELECT code FROM medical_exam WHERE patient_id = " + patientID + " and date_exam = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'"); 
            string code = dt.Rows[0]["code"].ToString();
            return code;
        }

        static public int updatePatient(Patient p)
        {
            int sex = p.sex == "Nam" ? 1 : 0;
            int id = Active.update("UPDATE patient SET name = N'" + p.full_name + "', sex = " + sex + ", yob = " + p.year_of_birth + ", address = N'" + p.address + "' where id = " + p.id);
            return id;
        }

        static public int deletePatient(int pid)
        {
            int id = Active.update("UPDATE patient SET is_delete = " + 1 + " where id = " + pid);
            return id;
        }

        static public int getLastPatientID()
        {
            DataTable dt = Active.select("select MAX(id) id from patient where is_delete = 0");
            return Convert.ToInt32(dt.Rows[0]["id"]);
        }

        static public int getMedicalExamStatus(int patientID)
        {
            DataTable dt = Active.select("select status from medical_exam where patient_id = " + patientID + " and date_exam = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'");
            return Convert.ToInt32(dt.Rows[0]["status"]);
        }

        static public int getFeeMedicine(string code)
        {
            DataTable dt = Active.select("SELECT medicine_id, unit_id, amount FROM prescription WHERE code = '" + code + "'");
            int n = dt.Rows.Count;
            int price = 0;
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    int medicineID = Convert.ToInt32(dt.Rows[i]["medicine_id"]);
                    int unitID = Convert.ToInt32(dt.Rows[i]["unit_id"]);
                    int amount = Convert.ToInt32(dt.Rows[i]["amount"]);
                    int unitPrice = 0;

                    DataTable dt2 = Active.select("SELECT unit_price FROM unit_price_medicine WHERE medicine_id = " + medicineID + " and unit_id = " + unitID);
                    int m = dt.Rows.Count;
                    if (m > 0)
                    {
                        unitPrice = Convert.ToInt32(dt2.Rows[0]["unit_price"]);
                    }
                    price += amount * unitPrice;
                }
            }
            return price;
        }

        //dem so don thuoc theo ma thuoc
        static public int countPrescriptionByID(int id)
        {
            int quantity = 0;
            DataTable dt = Active.select("select * from prescription where medicine_id = " + id);
            quantity = dt.Rows.Count;
            return quantity;
        }

        //dem so don thuoc theo ma cach dung
        static public int countPrescriptionByUseID(int id)
        {
            int quantity = 0;
            DataTable dt = Active.select("select * from prescription where use_id = " + id);
            quantity = dt.Rows.Count;
            return quantity;
        }

        //dem don gia thuoc theo ma don vi thuoc
        static public int countUnitPriceMedicineByUnitID(int id)
        {
            int quantity = 0;
            DataTable dt = Active.select("select * from unit_price_medicine where unit_id = " + id + " and is_delete = " + 0);
            quantity = dt.Rows.Count;
            return quantity;
        }

        //dem phieu kham benh theo ma loai benh
        static public int countMedicalExamBySickID(int id)
        {
            int quantity = 0;
            DataTable dt = Active.select("select * from medical_exam where sick_id = " + id);
            quantity = dt.Rows.Count;
            return quantity;
        }

        //update user (khong thay doi password)
        static public int updateUserNoPass(User u)
        {
            int id = Active.update("UPDATE user SET user = '" + u.name + "', name = N'" + u.full_name + "', email = '" + u.email + "', role_id = '" + u.role_id + "' where id = " + u.id + "");
            return id;
        }
    }
}
