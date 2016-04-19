using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BloodGroup
    {
        private int bloodID;
        private string bloodName;
        public int BloodID
        {
            get
            {
                return bloodID;
            }

            set
            {
                bloodID = value;
            }
        }

        public string BloodName
        {
            get
            {
                return bloodName;
            }

            set
            {
                bloodName = value;
            }
        }
    }
}
