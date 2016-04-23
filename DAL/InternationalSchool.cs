using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InternationalSchool
    {
        private int schoolID;
        private string schoolName;
        private string schoolAddress;
        private string webSite;
        private string schoolLvl;
        private string aboutLink;
        private int countryID;
        private int provinceID;
        private int districtID;
        private string googleMap;
        private string phone;
        private DateTime establish;
        private string hocPhi;
        private string phiKhac;
        private string datCoc;
        private string dieuKienNhapHoc;
        private string hocBong;
        private int images;
        public int SchoolID
        {
            get
            {
                return schoolID;
            }

            set
            {
                schoolID = value;
            }
        }

        public string SchoolName
        {
            get
            {
                return schoolName;
            }

            set
            {
                schoolName = value;
            }
        }

        public string SchoolAddress
        {
            get
            {
                return schoolAddress;
            }

            set
            {
                schoolAddress = value;
            }
        }

        public string WebSite
        {
            get
            {
                return webSite;
            }

            set
            {
                webSite = value;
            }
        }

        public string SchoolLvl
        {
            get
            {
                return schoolLvl;
            }

            set
            {
                schoolLvl = value;
            }
        }

        public string AboutLink
        {
            get
            {
                return aboutLink;
            }

            set
            {
                aboutLink = value;
            }
        }

        public int CountryID
        {
            get
            {
                return countryID;
            }

            set
            {
                countryID = value;
            }
        }
        public int ProvinceID
        {
            get
            {
                return provinceID;
            }

            set
            {
                provinceID = value;
            }
        }

        public int DistrictID
        {
            get
            {
                return districtID;
            }

            set
            {
                districtID = value;
            }
        }
        public string GoogleMap
        {
            get
            {
                return googleMap;
            }

            set
            {
                googleMap = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public DateTime Establish
        {
            get
            {
                return establish;
            }

            set
            {
                establish = value;
            }
        }

        public string HocPhi
        {
            get
            {
                return hocPhi;
            }

            set
            {
                hocPhi = value;
            }
        }

        public string PhiKhac
        {
            get
            {
                return phiKhac;
            }

            set
            {
                phiKhac = value;
            }
        }

        public string DatCoc
        {
            get
            {
                return datCoc;
            }

            set
            {
                datCoc = value;
            }
        }

        public string DieuKienNhapHoc
        {
            get
            {
                return dieuKienNhapHoc;
            }

            set
            {
                dieuKienNhapHoc = value;
            }
        }

        public string HocBong
        {
            get
            {
                return hocBong;
            }

            set
            {
                hocBong = value;
            }
        }

        public int Images
        {
            get
            {
                return images;
            }

            set
            {
                images = value;
            }
        }
    }
}
