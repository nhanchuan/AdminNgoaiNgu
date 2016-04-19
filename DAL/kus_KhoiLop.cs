using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_KhoiLop
    {
        private int khoiLopID;
        private string tenKhoiLop;
        private string moTaNgan;
        public int KhoiLopID
        {
            get
            {
                return khoiLopID;
            }

            set
            {
                khoiLopID = value;
            }
        }

        public string TenKhoiLop
        {
            get
            {
                return tenKhoiLop;
            }

            set
            {
                tenKhoiLop = value;
            }
        }

        public string MoTaNgan
        {
            get
            {
                return moTaNgan;
            }

            set
            {
                moTaNgan = value;
            }
        }
    }
}
