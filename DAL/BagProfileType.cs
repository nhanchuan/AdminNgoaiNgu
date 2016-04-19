using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BagProfileType
    {
        private int bagProfileTypeID;
        private string typeName;
        public int BagProfileTypeID
        {
            get
            {
                return bagProfileTypeID;
            }

            set
            {
                bagProfileTypeID = value;
            }
        }

        public string TypeName
        {
            get
            {
                return typeName;
            }

            set
            {
                typeName = value;
            }
        }
    }
}
