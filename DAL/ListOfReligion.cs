using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListOfReligion
    {
        private int religionID;
        private string religionName;
        public int ReligionID
        {
            get
            {
                return religionID;
            }

            set
            {
                religionID = value;
            }
        }

        public string ReligionName
        {
            get
            {
                return religionName;
            }

            set
            {
                religionName = value;
            }
        }
    }
}
