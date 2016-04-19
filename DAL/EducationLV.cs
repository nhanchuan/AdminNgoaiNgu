using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EducationLV
    {
        private int iD;
        private string nAME;
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string NAME
        {
            get
            {
                return nAME;
            }

            set
            {
                nAME = value;
            }
        }
    }
}
