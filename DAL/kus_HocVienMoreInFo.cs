using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_HocVienMoreInFo
    {
        private int moreInFoID;
        private int hocVienID;
        private string hVGioiThieu;
        private string trinhDoHocVan;
        private string tenTruong;
        private string cCTiengAnh;
        private string bietThongTin;
        public int MoreInFoID
        {
            get
            {
                return moreInFoID;
            }

            set
            {
                moreInFoID = value;
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
    }
}
