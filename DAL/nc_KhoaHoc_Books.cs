using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class nc_KhoaHoc_Books
    {
        private int khoaHoc;
        private int bookID;
        private DateTime dateOfCreate;
        public int KhoaHoc
        {
            get
            {
                return khoaHoc;
            }

            set
            {
                khoaHoc = value;
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
