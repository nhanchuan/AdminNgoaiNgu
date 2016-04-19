using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class nc_LoaiHinhDaoTao
    {
        private int iD;
        private string maLoaiHinh;
        private string tenLoaiHinh;
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

        public string MaLoaiHinh
        {
            get
            {
                return maLoaiHinh;
            }

            set
            {
                maLoaiHinh = value;
            }
        }

        public string TenLoaiHinh
        {
            get
            {
                return tenLoaiHinh;
            }

            set
            {
                tenLoaiHinh = value;
            }
        }
    }
}
