using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BagAttachments
    {
        private int attachmentID;
        private string attachmentName;
        private string attachmentURL;
        private int bagProfileID;
        private int userUpload;
        private DateTime dateOfCreate;
        public int AttachmentID
        {
            get
            {
                return attachmentID;
            }

            set
            {
                attachmentID = value;
            }
        }

        public string AttachmentName
        {
            get
            {
                return attachmentName;
            }

            set
            {
                attachmentName = value;
            }
        }

        public string AttachmentURL
        {
            get
            {
                return attachmentURL;
            }

            set
            {
                attachmentURL = value;
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
