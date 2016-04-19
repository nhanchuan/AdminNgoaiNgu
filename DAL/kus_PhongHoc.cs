using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_PhongHoc
    {
        private int phongHocID;
        private string dayPhong;
        private string tang;
        private int soPhong;
        private int coSoID;
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

        public string DayPhong
        {
            get
            {
                return dayPhong;
            }

            set
            {
                dayPhong = value;
            }
        }

        public string Tang
        {
            get
            {
                return tang;
            }

            set
            {
                tang = value;
            }
        }

        public int SoPhong
        {
            get
            {
                return soPhong;
            }

            set
            {
                soPhong = value;
            }
        }

        public int CoSoID
        {
            get
            {
                return coSoID;
            }

            set
            {
                coSoID = value;
            }
        }
    }
}
