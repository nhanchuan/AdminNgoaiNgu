using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employees
    {
        private int employeesID;
        private string employeesCode;
        private int profileID;
        private int eduLevel;
        private string identityCard_Old;
        private string identityCard_New;
        private DateTime identityCard_Old_Date;
        private DateTime identityCard_New_Date;
        private string identityCard_Place;
        private DateTime dateOfStart;
        private string regency;
        private int departmentsID;
        public int EmployeesID
        {
            get
            {
                return employeesID;
            }

            set
            {
                employeesID = value;
            }
        }

        public string EmployeesCode
        {
            get
            {
                return employeesCode;
            }

            set
            {
                employeesCode = value;
            }
        }

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

        public int EduLevel
        {
            get
            {
                return eduLevel;
            }

            set
            {
                eduLevel = value;
            }
        }

        public string IdentityCard_Old
        {
            get
            {
                return identityCard_Old;
            }

            set
            {
                identityCard_Old = value;
            }
        }

        public string IdentityCard_New
        {
            get
            {
                return identityCard_New;
            }

            set
            {
                identityCard_New = value;
            }
        }

        public DateTime IdentityCard_Old_Date
        {
            get
            {
                return identityCard_Old_Date;
            }

            set
            {
                identityCard_Old_Date = value;
            }
        }

        public DateTime IdentityCard_New_Date
        {
            get
            {
                return identityCard_New_Date;
            }

            set
            {
                identityCard_New_Date = value;
            }
        }

        public string IdentityCard_Place
        {
            get
            {
                return identityCard_Place;
            }

            set
            {
                identityCard_Place = value;
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

        public string Regency
        {
            get
            {
                return regency;
            }

            set
            {
                regency = value;
            }
        }

        public int DepartmentsID
        {
            get
            {
                return departmentsID;
            }

            set
            {
                departmentsID = value;
            }
        }
    }
}
