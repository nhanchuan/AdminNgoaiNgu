using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class kus_GioThi
    {
        private int gioThiID;
        private string tiet;
        private string gio;
        public int GioThiID
        {
            get
            {
                return gioThiID;
            }

            set
            {
                gioThiID = value;
            }
        }

        public string Tiet
        {
            get
            {
                return tiet;
            }

            set
            {
                tiet = value;
            }
        }

        public string Gio
        {
            get
            {
                return gio;
            }

            set
            {
                gio = value;
            }
        }
    }
}
