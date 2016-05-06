using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongTinPhuHuynh
    {
        private int iD;
        private int infoID;
        private string firstName;
        private string lastName;
        private DateTime ngaySinh;
        private string noiSinh;
        private string soCmnd;
        private string noiCap;
        private DateTime ngayCap;
        private string soDienThoai;
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public int InfoID
        {
            get
            {
                return infoID;
            }

            set
            {
                infoID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }
        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public string NoiSinh
        {
            get
            {
                return noiSinh;
            }

            set
            {
                noiSinh = value;
            }
        }

        public string SoCmnd
        {
            get
            {
                return soCmnd;
            }

            set
            {
                soCmnd = value;
            }
        }

        public string NoiCap
        {
            get
            {
                return noiCap;
            }

            set
            {
                noiCap = value;
            }
        }

        public DateTime NgayCap
        {
            get
            {
                return ngayCap;
            }

            set
            {
                ngayCap = value;
            }
        }

        public string SoDienThoai
        {
            get
            {
                return soDienThoai;
            }

            set
            {
                soDienThoai = value;
            }
        }

        
    }
}
