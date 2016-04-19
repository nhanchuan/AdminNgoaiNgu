using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_Books
    {
        private int bookID;
        private string bookCode;
        private string bookName;
        private string author;
        private string publisher;
        private DateTime ngayXB;
        private int soTrang;
        private string hinhThuc;
        private string languages;
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

        public string BookCode
        {
            get
            {
                return bookCode;
            }

            set
            {
                bookCode = value;
            }
        }

        public string BookName
        {
            get
            {
                return bookName;
            }

            set
            {
                bookName = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public string Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                publisher = value;
            }
        }

        public DateTime NgayXB
        {
            get
            {
                return ngayXB;
            }

            set
            {
                ngayXB = value;
            }
        }

        public int SoTrang
        {
            get
            {
                return soTrang;
            }

            set
            {
                soTrang = value;
            }
        }

        public string HinhThuc
        {
            get
            {
                return hinhThuc;
            }

            set
            {
                hinhThuc = value;
            }
        }

        public string Languages
        {
            get
            {
                return languages;
            }

            set
            {
                languages = value;
            }
        }
    }
}
