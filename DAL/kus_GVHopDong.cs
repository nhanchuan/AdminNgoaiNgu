using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_GVHopDong
    {
        private int gVID;
        private string firstName;
        private string lastName;
        private DateTime birthday;
        private int sex;
        private string cMND;
        private string gVAddress;
        private string email;
        private string phone;
        private string ghiChu;
        private string moTaGV;
        public int GVID
        {
            get
            {
                return gVID;
            }

            set
            {
                gVID = value;
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

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }
        public int Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }
        public string CMND
        {
            get
            {
                return cMND;
            }

            set
            {
                cMND = value;
            }
        }
        public string GVAddress
        {
            get
            {
                return gVAddress;
            }

            set
            {
                gVAddress = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return ghiChu;
            }

            set
            {
                ghiChu = value;
            }
        }

        public string MoTaGV
        {
            get
            {
                return moTaGV;
            }

            set
            {
                moTaGV = value;
            }
        }
    }
}
