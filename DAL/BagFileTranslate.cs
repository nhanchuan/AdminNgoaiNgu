using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BagFileTranslate
    {
        private int fileTranslateID;
        private string fileTranslateName;
        private string fileTranslateURL;
        private int bagProfileID;
        private int userUpload;
        private DateTime dateOfCreate;
        public int FileTranslateID
        {
            get
            {
                return fileTranslateID;
            }

            set
            {
                fileTranslateID = value;
            }
        }

        public string FileTranslateName
        {
            get
            {
                return fileTranslateName;
            }

            set
            {
                fileTranslateName = value;
            }
        }

        public string FileTranslateURL
        {
            get
            {
                return fileTranslateURL;
            }

            set
            {
                fileTranslateURL = value;
            }
        }

        public int BagProfileID
        {
            get
            {
                return bagProfileID;
            }

            set
            {
                bagProfileID = value;
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
    }
}
