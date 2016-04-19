using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category
    {
        private int categoryID;
        private string categoryName;
        private string descriptions;
        private string permalink;
        private int parent;
        private int cateogryImage;
        private int itemIndex;
        public int CategoryID
        {
            get
            {
                return categoryID;
            }

            set
            {
                categoryID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }

            set
            {
                categoryName = value;
            }
        }

        public string Descriptions
        {
            get
            {
                return descriptions;
            }

            set
            {
                descriptions = value;
            }
        }

        public string Permalink
        {
            get
            {
                return permalink;
            }

            set
            {
                permalink = value;
            }
        }

        public int Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        public int CateogryImage
        {
            get
            {
                return cateogryImage;
            }

            set
            {
                cateogryImage = value;
            }
        }

        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            set
            {
                itemIndex = value;
            }
        }
    }
}
