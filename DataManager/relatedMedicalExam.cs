using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.DataHelper
{
    class relatedMedicalExam
    {
        static string createCode()
        {
            string code = "BN" + String.Format("{0:yyMMdd}", DateTime.Now);

            int count_exam_in_today = int.Parse(Active.select("select count * from medical_exam where date_exam='" + String.Format("{0:yyyy-MM-dd}", DateTime.Now) + "'").Rows[0][0].ToString()) + 1;

            return code + String.Format("{0:000}", count_exam_in_today);
        }

        static public short addMedicalExam(int patient_id)
        {
            return Active.insert("insert into medical_exam('code','patient','status','date_exam') values ('" + createCode() + "','" + patient_id + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
        }
    }
}
