using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerProfileMoreInfor
    {
        private int moreInforID;
        private int infoID;
        private string hVGioiThieu;
        private string trinhDoHocVan;
        private string tenTruong;
        private string cCTiengAnh;
        private string bietThongTin;
        private string ghiChu;
        public int MoreInforID
        {
            get
            {
                return moreInforID;
            }

            set
            {
                moreInforID = value;
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

        public string HVGioiThieu
        {
            get
            {
                return hVGioiThieu;
            }

            set
            {
                hVGioiThieu = value;
            }
        }

        public string TrinhDoHocVan
        {
            get
            {
                return trinhDoHocVan;
            }

            set
            {
                trinhDoHocVan = value;
            }
        }

        public string TenTruong
        {
            get
            {
                return tenTruong;
            }

            set
            {
                tenTruong = value;
            }
        }

        public string CCTiengAnh
        {
            get
            {
                return cCTiengAnh;
            }

            set
            {
                cCTiengAnh = value;
            }
        }

        public string BietThongTin
        {
            get
            {
                return bietThongTin;
            }

            set
            {
                bietThongTin = value;
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
    }
}
