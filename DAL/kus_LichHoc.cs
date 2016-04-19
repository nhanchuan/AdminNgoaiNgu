using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_LichHoc
    {
        private int lichHocID;
        private int lopHocID;
        private int dayID;
        private int gioHocID;
        private int phongHocID;
        private int soTiet;
        private int gVTT;
        private int gVHD;
        public int LichHocID
        {
            get
            {
                return lichHocID;
            }

            set
            {
                lichHocID = value;
            }
        }

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

        public int DayID
        {
            get
            {
                return dayID;
            }

            set
            {
                dayID = value;
            }
        }

        public int GioHocID
        {
            get
            {
                return gioHocID;
            }

            set
            {
                gioHocID = value;
            }
        }

        public int PhongHocID
        {
            get
            {
                return phongHocID;
            }

            set
            {
                phongHocID = value;
            }
        }

        public int SoTiet
        {
            get
            {
                return soTiet;
            }

            set
            {
                soTiet = value;
            }
        }

        public int GVTT
        {
            get
            {
                return gVTT;
            }

            set
            {
                gVTT = value;
            }
        }

        public int GVHD
        {
            get
            {
                return gVHD;
            }

            set
            {
                gVHD = value;
            }
        }
    }
}
