using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Images
    {
        private int imagesID;
        private string imagesName;
        private string imagesUrl;
        private int imagesTypeID;
        private DateTime dateOfStart;
        private int userUpload;
        public int ImagesID
        {
            get
            {
                return imagesID;
            }

            set
            {
                imagesID = value;
            }
        }

        public string ImagesName
        {
            get
            {
                return imagesName;
            }

            set
            {
                imagesName = value;
            }
        }

        public string ImagesUrl
        {
            get
            {
                return imagesUrl;
            }

            set
            {
                imagesUrl = value;
            }
        }

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

        public DateTime DateOfStart
        {
            get
            {
                return dateOfStart;
            }

            set
            {
                dateOfStart = value;
            }
        }

        public int UserUpload
        {
            get
            {
                return userUpload;
            }

            set
            {
                userUpload = value;
            }
        }
    }
}
