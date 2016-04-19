using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_GhiDanh
    {
        private int ghiDanhID;
        private int hocVienID;
        private int khoaHoc;
        private int nVGhiDanh;
        private string ghiChu;
        private DateTime ngayDangKy;
        private int datCoc;
        private string ghiDanhCode;
        public int GhiDanhID
        {
            get
            {
                return ghiDanhID;
            }

            set
            {
                ghiDanhID = value;
            }
        }

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
        public int NVGhiDanh
        {
            get
            {
                return nVGhiDanh;
            }

            set
            {
                nVGhiDanh = value;
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

        public DateTime NgayDangKy
        {
            get
            {
                return ngayDangKy;
            }

            set
            {
                ngayDangKy = value;
            }
        }

        public int DatCoc
        {
            get
            {
                return datCoc;
            }

            set
            {
                datCoc = value;
            }
        }

        public string GhiDanhCode
        {
            get
            {
                return ghiDanhCode;
            }

            set
            {
                ghiDanhCode = value;
            }
        }
        
    }
}
