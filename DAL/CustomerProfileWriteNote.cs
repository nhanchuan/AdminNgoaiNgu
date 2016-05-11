using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerProfileWriteNote
    {
        private int writeNoteID;
        private int userID;
        private int profileID;
        private string noteTitle;
        private string noteContents;
        private DateTime dateOfCreate;
        public int WriteNoteID
        {
            get
            {
                return writeNoteID;
            }

            set
            {
                writeNoteID = value;
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

        public string NoteTitle
        {
            get
            {
                return noteTitle;
            }

            set
            {
                noteTitle = value;
            }
        }

        public string NoteContents
        {
            get
            {
                return noteContents;
            }

            set
            {
                noteContents = value;
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
    }
}
