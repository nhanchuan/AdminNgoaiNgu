using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserAccounts
    {
        private int userID;
        private string userName;
        private string email;
        private string passwords;
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

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Passwords
        {
            get
            {
                return passwords;
            }

            set
            {
                passwords = value;
            }
        }
    }
}
