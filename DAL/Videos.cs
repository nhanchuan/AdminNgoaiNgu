using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Videos
    {
        private int videoID;
        private string videoName;
        private string videoUrl;
        private string contentType;
        private int videotypeID;
        private string shortDecsription;
        private DateTime dateOfCreate;
        private int userUpload;
        public int VideoID
        {
            get
            {
                return videoID;
            }

            set
            {
                videoID = value;
            }
        }

        public string VideoName
        {
            get
            {
                return videoName;
            }

            set
            {
                videoName = value;
            }
        }

        public string VideoUrl
        {
            get
            {
                return videoUrl;
            }

            set
            {
                videoUrl = value;
            }
        }

        public string ContentType
        {
            get
            {
                return contentType;
            }

            set
            {
                contentType = value;
            }
        }

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

        public string ShortDecsription
        {
            get
            {
                return shortDecsription;
            }

            set
            {
                shortDecsription = value;
            }
        }

        public DateTime DateOfCreate
        {
            get
            {
                return dateOfCreate;
            }

            set
            {
                dateOfCreate = value;
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
