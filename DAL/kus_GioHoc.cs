using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_GioHoc
    {
        private int gioHocID;
        private int tietHoc;
        private DateTime startTime;
        private DateTime endTime;
        private int buoiHocID;
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

        public int TietHoc
        {
            get
            {
                return tietHoc;
            }

            set
            {
                tietHoc = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }

        public int BuoiHocID
        {
            get
            {
                return buoiHocID;
            }

            set
            {
                buoiHocID = value;
            }
        }
    }
}
