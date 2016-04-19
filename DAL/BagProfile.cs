using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BagProfile
    {
        private int bagProfileID;
        private int infoID;
        private string docName;
        private string docNote;
        private DateTime dateOfCreate;
        private int docStatucs;
        public int BagProfileID
        {
            get
            {
                return bagProfileID;
            }

            set
            {
                bagProfileID = value;
            }
        }

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

        public string DocName
        {
            get
            {
                return docName;
            }

            set
            {
                docName = value;
            }
        }

        public string DocNote
        {
            get
            {
                return docNote;
            }

            set
            {
                docNote = value;
            }
        }

        public DateTime DateOfCreate
        {
            get
            {
                return dateOfCreate;
            }

            set
            {
                dateOfCreate = value;
            }
        }

        public int DocStatucs
        {
            get
            {
                return docStatucs;
            }

            set
            {
                docStatucs = value;
            }
        }
    }
}
