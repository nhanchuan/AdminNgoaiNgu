using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class nc_KhoaHoc
    {
        private int iD;
        private string maKhoaHoc;
        private string tenKhoaHoc;
        private int soLuong;
        private DateTime ngayKhaiGiang;
        private int thoiLuong;
        private DateTime ngayKetThuc;
        private int loaiChuongTrinh;
        private int chuongTrinh;
        private int lopHoc;
        private int coSoID;
        private DateTime dateOfCreate;
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

        public string MaKhoaHoc
        {
            get
            {
                return maKhoaHoc;
            }

            set
            {
                maKhoaHoc = value;
            }
        }

        public string TenKhoaHoc
        {
            get
            {
                return tenKhoaHoc;
            }

            set
            {
                tenKhoaHoc = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
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

        public int LopHoc
        {
            get
            {
                return lopHoc;
            }

            set
            {
                lopHoc = value;
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
