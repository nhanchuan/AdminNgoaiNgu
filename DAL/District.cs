using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class District
    {
        private int districtID;
        private string districtName;
        private int provinceID;
        public int DistrictID
        {
            get
            {
                return districtID;
            }

            set
            {
                districtID = value;
            }
        }

        public string DistrictName
        {
            get
            {
                return districtName;
            }

            set
            {
                districtName = value;
            }
        }

        public int ProvinceID
        {
            get
            {
                return provinceID;
            }

            set
            {
                provinceID = value;
            }
        }
    }
}
