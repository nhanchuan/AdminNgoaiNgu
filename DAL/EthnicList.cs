using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EthnicList
    {
        private int ethnicID;
        private string ethnicName;
        private string ethnicOtherName;
        private int nationalityID;
        public int EthnicID
        {
            get
            {
                return ethnicID;
            }

            set
            {
                ethnicID = value;
            }
        }

        public string EthnicName
        {
            get
            {
                return ethnicName;
            }

            set
            {
                ethnicName = value;
            }
        }

        public string EthnicOtherName
        {
            get
            {
                return ethnicOtherName;
            }

            set
            {
                ethnicOtherName = value;
            }
        }

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
    }
}
