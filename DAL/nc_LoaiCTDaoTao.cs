using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class nc_LoaiCTDaoTao
    {
        private int iD;
        private string maChuongTrinh;
        private string tenChuongTrinh;
        private int lHDT;
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

        public string MaChuongTrinh
        {
            get
            {
                return maChuongTrinh;
            }

            set
            {
                maChuongTrinh = value;
            }
        }

        public string TenChuongTrinh
        {
            get
            {
                return tenChuongTrinh;
            }

            set
            {
                tenChuongTrinh = value;
            }
        }

        public int LHDT
        {
            get
            {
                return lHDT;
            }

            set
            {
                lHDT = value;
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
