using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
            
            return @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                    @"Data Source=db_priclinicmgt.mdb";
        }

        public static DataTable select(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                using (OleDbConnection connection = new OleDbConnection(connectString()))
                using (OleDbCommand command = new OleDbCommand())
                {
                    connection.Open();
                    command.CommandText = query;
                    command.Connection = connection;
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
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
                using (OleDbConnection connection = new OleDbConnection(connectString()))
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
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
                using (OleDbConnection connection = new OleDbConnection(connectString()))
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
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
                using (OleDbConnection connection = new OleDbConnection(connectString()))
                using (OleDbCommand cmd = new OleDbCommand(query, connection))
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
