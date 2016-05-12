using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProfileProcessType
    {
        private int processID;
        private string processCode;
        private string processName;
        public int ProcessID
        {
            get
            {
                return processID;
            }

            set
            {
                processID = value;
            }
        }

        public string ProcessCode
        {
            get
            {
                return processCode;
            }

            set
            {
                processCode = value;
            }
        }

        public string ProcessName
        {
            get
            {
                return processName;
            }

            set
            {
                processName = value;
            }
        }
    }
}
