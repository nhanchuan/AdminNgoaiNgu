using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerBasicInfo
    {
        private int infoID;
        private string firstName;
        private string lastName;
        private string otherName;
        private DateTime birthday;
        private string birthPlace;
        private int sex;
        private string identityCard;
        private DateTime dateOfIdentityCard;
        private string placeOfIdentityCard;
        private string basicInfoCode;
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

        public string OtherName
        {
            get
            {
                return otherName;
            }

            set
            {
                otherName = value;
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

        public string BirthPlace
        {
            get
            {
                return birthPlace;
            }

            set
            {
                birthPlace = value;
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

        public string IdentityCard
        {
            get
            {
                return identityCard;
            }

            set
            {
                identityCard = value;
            }
        }

        public DateTime DateOfIdentityCard
        {
            get
            {
                return dateOfIdentityCard;
            }

            set
            {
                dateOfIdentityCard = value;
            }
        }

        public string PlaceOfIdentityCard
        {
            get
            {
                return placeOfIdentityCard;
            }

            set
            {
                placeOfIdentityCard = value;
            }
        }

        public string BasicInfoCode
        {
            get
            {
                return basicInfoCode;
            }

            set
            {
                basicInfoCode = value;
            }
        }
    }
}
