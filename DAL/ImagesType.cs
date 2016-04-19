using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ImagesType
    {
        private int imagesTypeID;
        private string imagesTypeName;
        public int ImagesTypeID
        {
            get
            {
                return imagesTypeID;
            }

            set
            {
                imagesTypeID = value;
            }
        }

        public string ImagesTypeName
        {
            get
            {
                return imagesTypeName;
            }

            set
            {
                imagesTypeName = value;
            }
        }
    }
}
