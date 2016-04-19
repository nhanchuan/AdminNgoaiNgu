using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class nc_LopHoc
    {
        private int iD;
        private string lopHocCode;
        private string tenLopHoc;
        private int thoiLuong;
        private string bangCap;
        private int mucHocPhi;
        private int loaiChuongTrinh;
        private int chuongTrinh;
        private string moTa;
        private int sapXep;
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

        public string LopHocCode
        {
            get
            {
                return lopHocCode;
            }

            set
            {
                lopHocCode = value;
            }
        }

        public string TenLopHoc
        {
            get
            {
                return tenLopHoc;
            }

            set
            {
                tenLopHoc = value;
            }
        }

        public int ThoiLuong
        {
            get
            {
                return thoiLuong;
            }

            set
            {
                thoiLuong = value;
            }
        }

        public string BangCap
        {
            get
            {
                return bangCap;
            }

            set
            {
                bangCap = value;
            }
        }

        public int MucHocPhi
        {
            get
            {
                return mucHocPhi;
            }

            set
            {
                mucHocPhi = value;
            }
        }
        public int LoaiChuongTrinh
        {
            get
            {
                return loaiChuongTrinh;
            }

            set
            {
                loaiChuongTrinh = value;
            }
        }
        public int ChuongTrinh
        {
            get
            {
                return chuongTrinh;
            }

            set
            {
                chuongTrinh = value;
            }
        }

        public string MoTa
        {
            get
            {
                return moTa;
            }

            set
            {
                moTa = value;
            }
        }

        public int SapXep
        {
            get
            {
                return sapXep;
            }

            set
            {
                sapXep = value;
            }
        }

        
    }
}
