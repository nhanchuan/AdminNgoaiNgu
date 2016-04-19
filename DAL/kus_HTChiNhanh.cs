using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_HTChiNhanh
    {
        private int hTChiNhanhID;
        private string tenHTChiNhanh;
        private string ghiChu;
        private int gDChiNHanh;
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

        public string TenHTChiNhanh
        {
            get
            {
                return tenHTChiNhanh;
            }

            set
            {
                tenHTChiNhanh = value;
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

        public int GDChiNHanh
        {
            get
            {
                return gDChiNHanh;
            }

            set
            {
                gDChiNHanh = value;
            }
        }
    }
}
