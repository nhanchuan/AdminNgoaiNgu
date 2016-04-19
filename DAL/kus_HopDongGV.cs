using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_HopDongGV
    {
        private int hopDongID;
        private string hopDongCode;
        private int gVID;
        private DateTime ngayHopDong;
        private int thoiHan;
        private int tinhTrangHD;
        public int HopDongID
        {
            get
            {
                return hopDongID;
            }

            set
            {
                hopDongID = value;
            }
        }

        public string HopDongCode
        {
            get
            {
                return hopDongCode;
            }

            set
            {
                hopDongCode = value;
            }
        }

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

        public DateTime NgayHopDong
        {
            get
            {
                return ngayHopDong;
            }

            set
            {
                ngayHopDong = value;
            }
        }

        public int ThoiHan
        {
            get
            {
                return thoiHan;
            }

            set
            {
                thoiHan = value;
            }
        }

        public int TinhTrangHD
        {
            get
            {
                return tinhTrangHD;
            }

            set
            {
                tinhTrangHD = value;
            }
        }
    }
}
