using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class POST
    {
        private int postID;
        private string postTitle;
        private string metaKeywords;
        private string metaDescription;
        private string postContentVN;
        private string postContentEN;
        private DateTime postModified;
        private DateTime dateOfCreate;
        private int postAuthor;
        private int postStatus;
        private int viewCount;
        private int postImage;
        private string postCode;
        public int PostID
        {
            get
            {
                return postID;
            }

            set
            {
                postID = value;
            }
        }
        public string PostTitle
        {
            get
            {
                return postTitle;
            }

            set
            {
                postTitle = value;
            }
        }
        public string MetaKeywords
        {
            get
            {
                return metaKeywords;
            }

            set
            {
                metaKeywords = value;
            }
        }
        public string MetaDescription
        {
            get
            {
                return metaDescription;
            }

            set
            {
                metaDescription = value;
            }
        }
        public string PostContentVN
        {
            get
            {
                return postContentVN;
            }

            set
            {
                postContentVN = value;
            }
        }
        public string PostContentEN
        {
            get
            {
                return postContentEN;
            }

            set
            {
                postContentEN = value;
            }
        }
        public DateTime PostModified
        {
            get
            {
                return postModified;
            }

            set
            {
                postModified = value;
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
        public int PostAuthor
        {
            get
            {
                return postAuthor;
            }

            set
            {
                postAuthor = value;
            }
        }
        public int PostStatus
        {
            get
            {
                return postStatus;
            }

            set
            {
                postStatus = value;
            }
        }
        public int ViewCount
        {
            get
            {
                return viewCount;
            }

            set
            {
                viewCount = value;
            }
        }
        public int PostImage
        {
            get
            {
                return postImage;
            }

            set
            {
                postImage = value;
            }
        }
        public string PostCode
        {
            get
            {
                return postCode;
            }

            set
            {
                postCode = value;
            }
        }
    }
}
