using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListOfNationalities
    {
        private int nationalityID;
        private string nationalityName;
        public int NationalityID
        {
            get
            {
                return nationalityID;
            }

            set
            {
                nationalityID = value;
            }
        }

        public string NationalityName
        {
            get
            {
                return nationalityName;
            }

            set
            {
                nationalityName = value;
            }
        }
    }
}
