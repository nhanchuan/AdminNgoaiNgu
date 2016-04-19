using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Country
    {
        private int countryID;
        private string countryName;
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
