using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_BienLai
    {
        private int bienLaiID;
        private string bienLaiCode;
        private string lyDoThu;
        private int mienGiam;
        private int soTien;
        private string soTienBangChu;
        private DateTime dateOfCreate;
        private int ghiDanhID;
        public int BienLaiID
        {
            get
            {
                return bienLaiID;
            }

            set
            {
                bienLaiID = value;
            }
        }

        public string BienLaiCode
        {
            get
            {
                return bienLaiCode;
            }

            set
            {
                bienLaiCode = value;
            }
        }

        public string LyDoThu
        {
            get
            {
                return lyDoThu;
            }

            set
            {
                lyDoThu = value;
            }
        }

        public int MienGiam
        {
            get
            {
                return mienGiam;
            }

            set
            {
                mienGiam = value;
            }
        }

        public int SoTien
        {
            get
            {
                return soTien;
            }

            set
            {
                soTien = value;
            }
        }

        public string SoTienBangChu
        {
            get
            {
                return soTienBangChu;
            }

            set
            {
                soTienBangChu = value;
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

        public int GhiDanhID
        {
            get
            {
                return ghiDanhID;
            }

            set
            {
                ghiDanhID = value;
            }
        }
    }
}
