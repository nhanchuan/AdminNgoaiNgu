using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Post_Category_relationships
    {
        private int postID;
        private int categoryID;
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
    }
}
