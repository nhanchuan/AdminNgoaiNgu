using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_CapDo
    {
        private int capDoID;
        private string tenCapDo;
        private int khoiLopID;
        private string moTaNgan;
        public int CapDoID
        {
            get
            {
                return capDoID;
            }

            set
            {
                capDoID = value;
            }
        }

        public string TenCapDo
        {
            get
            {
                return tenCapDo;
            }

            set
            {
                tenCapDo = value;
            }
        }

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
