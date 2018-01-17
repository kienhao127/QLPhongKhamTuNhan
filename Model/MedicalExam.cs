using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class MedicalExam
    {
        string code { get; set; }
        int patient_id { get; set; }
        int physician_id { get; set; }
        int sick_id { get; set; }
        long fee_exam { get; set; }
        long fee_medicine { get; set; }
        string prognostic { get; set; }
        int status { get; set; }
        DateTime date_exam { get; set; }
        Patient patient { get; set; }
        User physician { get; set; }
        Sickness sickness { get; set; }
        List<Prescription> prescription { get; set; }
    }
}
