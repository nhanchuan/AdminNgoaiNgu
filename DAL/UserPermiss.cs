using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserPermiss
    {
        private int userID;
        private int permissFuncID;
        private int permisstionNumber;

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

        public int PermisstionNumber
        {
            get
            {
                return permisstionNumber;
            }

            set
            {
                permisstionNumber = value;
            }
        }
    }
}
