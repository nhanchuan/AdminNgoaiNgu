using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Registration_Type
    {
        private int typeID;
        private string typeName;
        public int TypeID
        {
            get
            {
                return typeID;
            }

            set
            {
                typeID = value;
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
