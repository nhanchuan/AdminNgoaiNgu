using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_LopHoc
    {
        private int lopHocID;
        private string lopHocCode;
        private string tenLopHoc;
        private DateTime ngayKhaiGiang;
        private int thoiLuong;
        private DateTime ngayKetThuc;
        private int siSoToiDa;
        private DateTime dateOfCreate;
        private int capDoID;
        private int mucHocPhi;
        private int trangThai;
        private int coSoID;
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

        public DateTime NgayKhaiGiang
        {
            get
            {
                return ngayKhaiGiang;
            }

            set
            {
                ngayKhaiGiang = value;
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

        public DateTime NgayKetThuc
        {
            get
            {
                return ngayKetThuc;
            }

            set
            {
                ngayKetThuc = value;
            }
        }

        public int SiSoToiDa
        {
            get
            {
                return siSoToiDa;
            }

            set
            {
                siSoToiDa = value;
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

        public int CapDoID
        {
            get
            {
                return capDoID;
            }

            set
            {
                capDoID = value;
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

        public int TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }

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
    }
}
