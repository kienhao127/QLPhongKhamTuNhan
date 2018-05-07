using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongKhamTuNhan.Manager
{
    class DataReport
    {
        static public DataTable MonthlyRevenue(string month,string year)
        {            
            return Active.select("SELECT DATE(m0.date_exam) date_exam, " +
                                 "COUNT(*) num_patient, " +
                                 "SUM(m0.fee_exam + m0.fee_medicine) day_revenue " +
                                 "FROM medical_exam m0 " +
                                 "WHERE MONTH(m0.date_exam) = " + month +
                                 "        and YEAR(m0.date_exam) = " + year +
                                 " GROUP by DATE(m0.date_exam);");
        }

        static public DataTable UseMedicine(string month, string year)
        {
            return Active.select("SELECT medicine.name medicine_name, " +
                                 "unit_medicine.name unit, " +
                                 "SUM(prescription.amount) amount, " +
                                 "COUNT(prescription.code) number_times " +
                                 "FROM medicine, unit_medicine, prescription " +
                                 "WHERE medicine.id = prescription.medicine_id " +
                                 "  AND prescription.unit_id = unit_medicine.id " +
                                 "  AND prescription.code in ( " +
                                 "          SELECT medical_exam.code " +
                                 "          FROM medical_exam " +
                                 "          WHERE MONTH(medical_exam.date_exam) = " + month +
                                 "              AND YEAR(medical_exam.date_exam) = " + year +
                                 "              AND fee_medicine > 0 " +
                                 "      ) " +
                                 "GROUP BY medicine.name, unit_medicine.name");
        }
    }
}
