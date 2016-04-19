using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Tags_relationships
    {
        private int postID;
        private int tagsID;
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

        public int TagsID
        {
            get
            {
                return tagsID;
            }

            set
            {
                tagsID = value;
            }
        }
    }
}
