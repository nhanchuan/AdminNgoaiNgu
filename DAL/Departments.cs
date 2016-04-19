using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Departments
    {
        private int departmentsID;
        private string departmentName;
        private int manager;
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

        public string DepartmentName
        {
            get
            {
                return departmentName;
            }

            set
            {
                departmentName = value;
            }
        }

        public int Manager
        {
            get
            {
                return manager;
            }

            set
            {
                manager = value;
            }
        }
    }
}
