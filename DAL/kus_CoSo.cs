using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_CoSo
    {
        private int coSoID;
        private string tenCoSo;
        private string diaChi;
        private string fax;
        private string phone;
        private string email;
        private DateTime ngayThanhLap;
        private string ghiChu;
        private int hTChiNhanhID;
        private int qLCoSo;
        public int CoSoID
        {
            get
            {
                return coSoID;
            }

            set
            {
                coSoID = value;
            }
        }

        public string TenCoSo
        {
            get
            {
                return tenCoSo;
            }

            set
            {
                tenCoSo = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
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

        public DateTime NgayThanhLap
        {
            get
            {
                return ngayThanhLap;
            }

            set
            {
                ngayThanhLap = value;
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

        public int HTChiNhanhID
        {
            get
            {
                return hTChiNhanhID;
            }

            set
            {
                hTChiNhanhID = value;
            }
        }

        public int QLCoSo
        {
            get
            {
                return qLCoSo;
            }

            set
            {
                qLCoSo = value;
            }
        }
    }
}
