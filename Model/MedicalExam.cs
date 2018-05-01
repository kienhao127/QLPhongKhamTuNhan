using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class MedicalExam
    {
        private string _code;
        private int _patient_id;
        private int _physician_id;
        private int _sick_id;
        private long _fee_exam;
        private long _fee_medicine;
        private string _prognostic;
        private int _status;
        private DateTime _date_exam;
        private Patient _patient;
        private User _physician;
        private Sickness _sickness;
        private List<Prescription> _prescription;

        public string code { get { return _code; } set { _code = value; } }
        public int patient_id { get { return _patient_id; } set { _patient_id = value; } }
        public int physician_id { get { return _physician_id; } set { _physician_id = value; } }
        public int sick_id { get { return _sick_id; } set { _sick_id = value; } }
        public long fee_exam { get { return _fee_exam; } set { _fee_exam = value; } }
        public long fee_medicine { get { return _fee_medicine; } set { _fee_medicine = value; } }
        public string prognostic { get { return _prognostic; } set { _prognostic = value; } }
        public int status { get { return _status; } set { _status = value; } }
        public DateTime date_exam { get { return _date_exam; } set { _date_exam = value; } }
        internal Patient patient { get { return _patient; } set { _patient = value; } }
        internal User physician { get { return _physician; } set { _physician = value; } }
        internal Sickness sickness { get { return _sickness; } set { _sickness = value; } }
        internal List<Prescription> prescription { get { return _prescription; } set { _prescription = value; } }
    }
}
