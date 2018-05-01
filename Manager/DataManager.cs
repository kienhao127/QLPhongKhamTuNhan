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
            DataHelper dataHelper = new DataHelper();
            return dataHelper.login(username, pw);
        }

        public List<int> getRoleFunction(int roleId)
        {
            DataHelper dataHelper = new DataHelper();
            return dataHelper.getRoleFunction(roleId);
        }
    }
}
