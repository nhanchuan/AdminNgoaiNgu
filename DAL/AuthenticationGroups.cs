using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthenticationGroups
    {
        private int authenticationGroupsID;
        private int departmentsID;
        private int permissFuncID;
        public int AuthenticationGroupsID
        {
            get
            {
                return authenticationGroupsID;
            }

            set
            {
                authenticationGroupsID = value;
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

        public int PermissFuncID
        {
            get
            {
                return permissFuncID;
            }

            set
            {
                permissFuncID = value;
            }
        }
    }
}
