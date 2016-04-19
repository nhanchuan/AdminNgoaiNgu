using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VideoType
    {
        private int videotypeID;
        private string typeName;
        private string shortDesciption;
        public int VideotypeID
        {
            get
            {
                return videotypeID;
            }

            set
            {
                videotypeID = value;
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

        public string ShortDesciption
        {
            get
            {
                return shortDesciption;
            }

            set
            {
                shortDesciption = value;
            }
        }
    }
}
