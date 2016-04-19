using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CountryAdvisory
    {
        private int countryAdvisoryID;
        private string countryName;
        public int CountryAdvisoryID
        {
            get
            {
                return countryAdvisoryID;
            }

            set
            {
                countryAdvisoryID = value;
            }
        }

        public string CountryName
        {
            get
            {
                return countryName;
            }

            set
            {
                countryName = value;
            }
        }
    }
}
