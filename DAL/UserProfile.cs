using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserProfile
    {
        private int profileID;
        private int userID;
        private string firstName;
        private string lastName;
        private int sex;
        private DateTime birthday;
        private int countryID;
        private int provinceID;
        private int districtID;
        private string address_ui;
        private string mobileNumber;
        private string interests;
        private string occupation;
        private string about;
        private string websiteUrl;
        private int img_id;
        private DateTime dateOfStart;
        private int userStatus;
        public int ProfileID
        {
            get
            {
                return profileID;
            }

            set
            {
                profileID = value;
            }
        }

        public int UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public int Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
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
        public string Address_ui
        {
            get
            {
                return address_ui;
            }

            set
            {
                address_ui = value;
            }
        }

        public string MobileNumber
        {
            get
            {
                return mobileNumber;
            }

            set
            {
                mobileNumber = value;
            }
        }

        public string Interests
        {
            get
            {
                return interests;
            }

            set
            {
                interests = value;
            }
        }

        public string Occupation
        {
            get
            {
                return occupation;
            }

            set
            {
                occupation = value;
            }
        }

        public string About
        {
            get
            {
                return about;
            }

            set
            {
                about = value;
            }
        }

        public string WebsiteUrl
        {
            get
            {
                return websiteUrl;
            }

            set
            {
                websiteUrl = value;
            }
        }

        public int Img_id
        {
            get
            {
                return img_id;
            }

            set
            {
                img_id = value;
            }
        }

        public DateTime DateOfStart
        {
            get
            {
                return dateOfStart;
            }

            set
            {
                dateOfStart = value;
            }
        }

        public int UserStatus
        {
            get
            {
                return userStatus;
            }

            set
            {
                userStatus = value;
            }
        }

       
    }
}
