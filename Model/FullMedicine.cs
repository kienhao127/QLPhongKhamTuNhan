using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongKhamTuNhan.Model
{
    public class FullMedicine
    {
        private int _id;
        private string _name;
        private string _another_name;
        private int _unit_id;
        private string _unit_name;
        private long _unit_price;
        private int _num_smallest_unit;
        private bool _is_delete;
        private int _user_change;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string another_name
        {
            get
            {
                return _another_name;
            }

            set
            {
                _another_name = value;
            }
        }

        public int unit_id
        {
            get
            {
                return _unit_id;
            }

            set
            {
                _unit_id = value;
            }
        }

        public string unit_name
        {
            get
            {
                return _unit_name;
            }

            set
            {
                _unit_name = value;
            }
        }

        public long unit_price
        {
            get
            {
                return _unit_price;
            }

            set
            {
                _unit_price = value;
            }
        }

        public int num_smallest_unit
        {
            get
            {
                return _num_smallest_unit;
            }

            set
            {
                _num_smallest_unit = value;
            }
        }

        public bool is_delete
        {
            get
            {
                return _is_delete;
            }

            set
            {
                _is_delete = value;
            }
        }

        public int user_change
        {
            get
            {
                return _user_change;
            }

            set
            {
                _user_change = value;
            }
        }
    }
}
