using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class Prescription
    {
        string medical_code { get; set; }
        int medicine_id { get; set; }
        int unit_id { get; set; }
        int amount { get; set; }
        int user_id_create { get; set; }
        MedicalExam medical_exam { get; set; }
        UnitPriceMedicine unit_price_medicine { get; set; }
        User user_create { get; set; }
    }
}
