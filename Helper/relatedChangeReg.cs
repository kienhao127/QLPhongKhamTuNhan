using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Helper
{
    class relatedChangeReg
    {
        static public DataTable tableChangeReg(string name, string pass)
        {
            return Active.select("SELECT modifled_day, id_function, name_function, value_old, DATE_FORMAT(date_apply, \"%d/%m/%Y\") date_apply, value_new, user_change FROM change_reg");
        }

        static public int feeExam()
        {
            return Convert.ToInt16(Active.select("SELECT IF(date_apply>=DATE_ADD(CURRENT_TIMESTAMP , INTERVAL 6 hour), value_old, value_new) FROM change_reg WHERE id_function=1").Rows[0][0].ToString());
        }
    }
}
