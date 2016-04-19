using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_LopHoc_Books
    {
        private int lopHocID;
        private int bookID;
        private DateTime dateOfCreate;
        public int LopHocID
        {
            get
            {
                return lopHocID;
            }

            set
            {
                lopHocID = value;
            }
        }

        public int BookID
        {
            get
            {
                return bookID;
            }

            set
            {
                bookID = value;
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
