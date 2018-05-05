using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Utils
{
    public class helper
    {
        static public string getDateTimeNow()
        {
            return String.Format("{0:dd-MM-yyyy}", DateTime.Now);
        }

        static public string createExamCode()
        {
            return String.Format("{0:BNddMMyy}", DateTime.Now);
        }
    }
}
