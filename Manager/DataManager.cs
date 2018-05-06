using Helper;
using QLPhongKhamTuNhan.Model;
using System.Collections.Generic;

namespace Manager
{
    class DataManager
    {
        private static DataManager instance;
        
        private DataManager()
        {

        }

        public static DataManager getInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }
            return instance;
        }

        public User login(string username, string pw)
        {
            return DataHelper.login(username, pw);
        }

        public List<int> getRoleFunction(int roleId)
        {
            return DataHelper.getRoleFunction(roleId);
        }

        public int countAllUser()
        {
            return DataHelper.countAllUser();
        }

        public int countAllPatient()
        {
            return DataHelper.countAllPatient();
        }

        public int getTurnover()
        {
            return DataHelper.getTurnover();
        }

        public int insertUser(User u)
        {
            return DataHelper.insertUser(u);
        }

        public List<User> getAllUser()
        {
            return DataHelper.getAllUser();
        }
        
        public List<string> getListSicknessName()
        {
            return DataHelper.getListSicknessName();
        }

        public List<string> getListMedicineName()
        {
            return DataHelper.getListMedicineName();
        }

        public List<Patient> getListPatient()
        {
            return DataHelper.getListPatient();
        }

        public int updateUser(User u)
        {
            return DataHelper.updateUser(u);
        }

        public int deleteUser(int userid, int is_delete)
        {
            return DataHelper.deleteUser(userid, is_delete);
        }

        public List<ChangeRegulation> getAllRegulation()
        {
            return DataHelper.getAllRegulation();
        }

        public int updateRegulation(ChangeRegulation updateFee, ChangeRegulation updatePatient, int user_change)
        {
            return DataHelper.updateRegulation(updateFee, updatePatient, user_change);
        }

        public List<Sickness> getAllSickness()
        {
            return DataHelper.getAllSickness();
        }



        public int getMedicineID(string medicineName)
        {
            return DataHelper.getMedicineID(medicineName);
        }

        public int getUseID(string useName)
        {
            return DataHelper.getUseID(useName);
        }

        public List<string> getListUseName()
        {
            return DataHelper.getListUseName();
        }

        public List<string> getListUnitName()
        {
            return DataHelper.getListUnitName();
        }

        public int getUnitID(string unitName)
        {
            return DataHelper.getUnitID(unitName);
        }

        public int insertSickness(Sickness sick, int user_update)
        {
            return DataHelper.insertSickness(sick, user_update);
        }

        public int updateSickness(Sickness sick, int user_change)
        {
            return DataHelper.updateSickness(sick, user_change);
        }

        public int deleteSickness(int sick_id, int user_change)
        {
            return DataHelper.deleteSickness(sick_id, user_change);
        }

        public int getSicknessID(string sicknessName)
        {
            return DataHelper.getSicknessID(sicknessName);
        }

        public int insertMedicalExam(string code, int patientID, int doctorID)
        {
            return DataHelper.insertMedicalExam(code, patientID, doctorID);
        }

        public int countMedicalExam()
        {
            return DataHelper.countMedicalExam();
        }

        public int updateMedicalExam(string code, int sickID, string prognostic, int status)
        {
            return DataHelper.updateMedicalExam(code, sickID, prognostic, status);
        }

        public int insertPrescription(List<Prescription> listPrescription, string code)
        {
            foreach (Prescription p in listPrescription)
            {
                DataHelper.insertPrescription(p, code);
            }
            return 1;
        }
        
        //Quan ly don vi thuoc
        public List<UnitMedicine> getAllUnit()
        {
            return DataHelper.getAllUnit();
        }

        public int insertUnitMedicine(UnitMedicine unit, int user_update)
        {
            return DataHelper.insertUnitMedicine(unit, user_update);
        }

        public int updateUnitMedicine(UnitMedicine unit, int user_change)
        {
            return DataHelper.updateUnitMedicine(unit, user_change);
        }

        public int deleteUnitMedicine(int unit_id, int user_change)
        {
            return DataHelper.deleteUnitMedicine(unit_id, user_change);
        }

        //Quan ly cach dung
        public List<UserMedicine> getAllUseMedicine()
        {
            return DataHelper.getAllUseMedicine();
        }

        public int insertUseMedicine(UserMedicine use, int user_update)
        {
            return DataHelper.insertUseMedicine(use, user_update);
        }

        public int updateUseMedicine(UserMedicine use, int user_change)
        {
            return DataHelper.updateUseMedicine(use, user_change);
        }

        public int deleteUseMedicine(int use_id, int user_change)
        {
            return DataHelper.deleteUseMedicine(use_id, user_change);
        }

        //Quan ly thuoc
        public List<FullMedicine> getAllMedicine()
        {
            return DataHelper.getAllMedicine();
        }

        public int insertMedicine(FullMedicine medicine, int user_update)
        {
            return DataHelper.insertMedicine(medicine, user_update);
        }

        public int updateMedicine(FullMedicine medicine, int user_change)
        {
            return DataHelper.updateMedicine(medicine, user_change);
        }

        public int deleteMedicine(int medicine_id, int user_change)
        {
            return DataHelper.deleteMedicine(medicine_id, user_change);
        }

        public int insertPatient(Patient p)
        {
            return DataHelper.insertPatient(p);
        }

        public List<Patient> getListPatientForDoctor()
        {
            List<int> listID = DataHelper.getPatientIdInExam();
            List<Patient> listPatient = new List<Patient>();
            foreach (int id in listID)
            {
                Patient p = new Patient();
                p = DataHelper.getPatientWithID(id);
                if (p.id != -1) {
                    listPatient.Add(p);
                }
            }
            return listPatient;
        }

        public string getExamCode(int patientID)
        {
            return DataHelper.getExamCode(patientID);
        }

        public int updatePatient(Patient p)
        {
            return DataHelper.updatePatient(p);
        }

        public int deletePatient(int pid)
        {
            return DataHelper.deletePatient(pid);
        }

        public int getLastPatientID()
        {
            return DataHelper.getLastPatientID();
        }

        public int updateMedicalExamStatus(string code, int status)
        {
            return DataHelper.updateMedicalExamStatus(code, status);
        }

        public int getMedicalExamStatus(int patientid)
        {
            return DataHelper.getMedicalExamStatus(patientid);
        }

        public int getFeeExam()
        {
            return 40000;
        }

        public int getFeeMedicine(string code)
        {
            return DataHelper.getFeeMedicine(code);
        }

        public int updateMedicineExam(string code, int feeExam, int feeMedicine)
        {
            return DataHelper.updateMedicalExam(code, feeExam, feeMedicine);
        }

        public int countPrescriptionByID(int id)
        {
            return DataHelper.countPrescriptionByID(id);
        }

        public int countPrescriptionByUseID(int id)
        {
            return DataHelper.countPrescriptionByUseID(id);
        }

        public int countUnitPriceMedicineByUnitID(int id)
        {
            return DataHelper.countUnitPriceMedicineByUnitID(id);
        }
    }
}
