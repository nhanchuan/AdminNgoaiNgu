using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ListOfMIMETypes
    {
        private int typesID;
        private string name;
        private string mIMEType;
        private string extension;
        public int TypesID
        {
            get
            {
                return typesID;
            }

            set
            {
                typesID = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string MIMEType
        {
            get
            {
                return mIMEType;
            }

            set
            {
                mIMEType = value;
            }
        }

        public string Extension
        {
            get
            {
                return extension;
            }

            set
            {
                extension = value;
            }
        }
    }
}
