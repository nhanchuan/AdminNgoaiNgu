using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Province
    {
        private int provinceID;
        private string provinceName;
        private int countryID;
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

        public string ProvinceName
        {
            get
            {
                return provinceName;
            }

            set
            {
                provinceName = value;
            }
        }

        public int CountryID
        {
            get
            {
                return countryID;
            }

            set
            {
                countryID = value;
            }
        }
    }
}
