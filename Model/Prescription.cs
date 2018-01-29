using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    class Prescription
    {
        private string _medical_code;
        private int _medicine_id;
        private int _unit_id;
        private int _amount;
        private int _user_id_create;
        private MedicalExam _medical_exam;
        private UnitPriceMedicine _unit_price_medicine;
        private User _user_create;

        public string medical_code { get { return _medical_code; } set { _medical_code = value; } }
        public int medicine_id { get { return _medicine_id; } set { _medicine_id = value; } }
        public int unit_id { get { return _unit_id; } set { _unit_id = value; } }
        public int amount { get { return _amount; } set { _amount = value; } }
        public int user_id_create { get { return _user_id_create; } set { _user_id_create = value; } }
        internal MedicalExam medical_exam { get { return _medical_exam; } set { _medical_exam = value; } }
        internal UnitPriceMedicine unit_price_medicine { get { return _unit_price_medicine; } set { _unit_price_medicine = value; } }
        internal User user_create { get { return _user_create; } set { _user_create = value; } }
    }
}
