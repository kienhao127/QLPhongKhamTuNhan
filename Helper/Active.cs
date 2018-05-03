using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Helper
{
    public static class Active
    {
        static string connectString()
        {
            MySqlConnectionStringBuilder connectString = new MySqlConnectionStringBuilder();
            connectString.Server = "localhost";
            connectString.UserID = "root";
            connectString.Password = "";
            connectString.Database = "db_priclinicmgt";
            connectString.CharacterSet = "utf8";
            connectString.Port = 3306;
            /*connectString.Server = "85.10.205.173";
            connectString.UserID = "ad_priclinicmgt";
            connectString.Password = "nmcnpm28";
            connectString.Database = "db_priclinicmgt";
            connectString.CharacterSet = "utf8";
            connectString.Port = 3307;*/

            return connectString.ToString();
        }

        public static DataTable select(string query)
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public static short insert(string query)
        {
            short change = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    change = Convert.ToInt16(cmd.ExecuteNonQuery());
                    connection.Close();
                }
                return change;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        }

        public static short update(string query)
        {
            short change = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    change = Convert.ToInt16(cmd.ExecuteNonQuery());
                }
                return change;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        }

        public static short delete(string query)
        {
            short change = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectString()))
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    change = Convert.ToInt16(cmd.ExecuteNonQuery());
                }
                return change;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return -1;
            }
        }
    }
}
