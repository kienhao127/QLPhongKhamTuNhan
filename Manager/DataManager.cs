using Helper;
using QLPhongKhamTuNhan.Model;

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
    }
}
