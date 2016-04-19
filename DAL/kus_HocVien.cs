using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_HocVien
    {
        private int hocVienID;
        private string hocVienCode;
        private int infoID;
        private string dCThuongTru;
        private string dCTamTru;
        private string email;
        private string dienThoai;
        private string hoTenPH;
        private string ngheNghiep;
        private string phonePhuHuynh;
        private int hocVienStatus;
        private DateTime dateOfCreate;
        private string randomCode;
        private int imgID;
        public int HocVienID
        {
            get
            {
                return hocVienID;
            }

            set
            {
                hocVienID = value;
            }
        }

        public string HocVienCode
        {
            get
            {
                return hocVienCode;
            }

            set
            {
                hocVienCode = value;
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

        public string DCThuongTru
        {
            get
            {
                return dCThuongTru;
            }

            set
            {
                dCThuongTru = value;
            }
        }

        public string DCTamTru
        {
            get
            {
                return dCTamTru;
            }

            set
            {
                dCTamTru = value;
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

        public string DienThoai
        {
            get
            {
                return dienThoai;
            }

            set
            {
                dienThoai = value;
            }
        }

        public string HoTenPH
        {
            get
            {
                return hoTenPH;
            }

            set
            {
                hoTenPH = value;
            }
        }

        public string NgheNghiep
        {
            get
            {
                return ngheNghiep;
            }

            set
            {
                ngheNghiep = value;
            }
        }

        public string PhonePhuHuynh
        {
            get
            {
                return phonePhuHuynh;
            }

            set
            {
                phonePhuHuynh = value;
            }
        }
        public int HocVienStatus
        {
            get
            {
                return HocVienStatus1;
            }

            set
            {
                HocVienStatus1 = value;
            }
        }

        public int HocVienStatus1
        {
            get
            {
                return hocVienStatus;
            }

            set
            {
                hocVienStatus = value;
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

        public string RandomCode
        {
            get
            {
                return randomCode;
            }

            set
            {
                randomCode = value;
            }
        }

        public int ImgID
        {
            get
            {
                return imgID;
            }

            set
            {
                imgID = value;
            }
        }
    }
}
