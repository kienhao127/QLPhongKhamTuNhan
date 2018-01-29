using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.DataHelper
{
    class Active
    {
        static protected string connectString()
        {
            MySqlConnectionStringBuilder connectString = new MySqlConnectionStringBuilder();
            connectString.Server = "85.10.205.173";
            connectString.UserID = "ad_priclinicmgt";
            connectString.Password = "nmcnpm28";
            connectString.Database = "db_priclinicmgt";
            connectString.CharacterSet = "utf8";
            connectString.Port = 3307;
            // server = 85.10.205.173; user = ad_priclinicmgt; database = db_priclinicmgt; port = 3307; password = nmcnpm28; charset = utf8

            return connectString.ToString();
        }

        static public DataTable select(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        static public int insert(string query)
        {
            int change = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    change = cmd.ExecuteNonQuery();
                }
                return change;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        static public int update(string query)
        {
            int change = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    change = cmd.ExecuteNonQuery();
                }
                return change;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int delete(string query)
        {
            int change = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    change = cmd.ExecuteNonQuery();
                }
                return change;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
