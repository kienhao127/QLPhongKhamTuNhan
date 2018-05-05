﻿using Helper;
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
    }
}
