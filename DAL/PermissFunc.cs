using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PermissFunc
    {
        private int permissFuncID;
        private string functionName;
        private string functionCode;
        private int pFGroupID;
        public int PermissFuncID
        {
            get
            {
                return permissFuncID;
            }

            set
            {
                permissFuncID = value;
            }
        }

        public string FunctionName
        {
            get
            {
                return functionName;
            }

            set
            {
                functionName = value;
            }
        }

        public string FunctionCode
        {
            get
            {
                return functionCode;
            }

            set
            {
                functionCode = value;
            }
        }

        public int PFGroupID
        {
            get
            {
                return pFGroupID;
            }

            set
            {
                pFGroupID = value;
            }
        }
    }
}
