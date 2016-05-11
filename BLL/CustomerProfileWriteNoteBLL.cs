﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class CustomerProfileWriteNoteBLL
    {
        DataServices dt = new DataServices();
        DateTime DefaultDate = Convert.ToDateTime("01/01/1900");
        public List<CustomerProfileWriteNote> getListWithProfileID(int ProfileID)
        {
            if(!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from CustomerProfileWriteNote where ProfileID=@ProfileID";
            SqlParameter pProfileID = new SqlParameter("@ProfileID", ProfileID);
            DataTable tb = dt.DAtable(sql, pProfileID); ;
            List<CustomerProfileWriteNote> lst = new List<CustomerProfileWriteNote>();
            foreach(DataRow r in tb.Rows)
            {
                CustomerProfileWriteNote wn = new CustomerProfileWriteNote();
                wn.WriteNoteID = (int)r["WriteNoteID"];
                wn.UserID = (string.IsNullOrEmpty(r["UserID"].ToString())) ? 0 : (int)r["UserID"];
                wn.ProfileID = (string.IsNullOrEmpty(r["ProfileID"].ToString())) ? 0 : (int)r["ProfileID"];
                wn.NoteTitle = (string.IsNullOrEmpty(r["NoteTitle"].ToString())) ? "" : (string)r["NoteTitle"];
                wn.NoteContents = (string.IsNullOrEmpty(r["NoteContents"].ToString())) ? "" : (string)r["NoteContents"];
                wn.DateOfCreate= (string.IsNullOrEmpty(r["DateOfCreate"].ToString())) ? DefaultDate : (DateTime)r["DateOfCreate"];
                lst.Add(wn);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New
        public Boolean NewCPWriteNote(int UserID, int ProfileID, string NoteTitle, string NoteContents)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec NewCPWriteNote @UserID,@ProfileID,@NoteTitle,@NoteContents";
            SqlParameter pUserID =(UserID==0)? new SqlParameter("@UserID", DBNull.Value):new SqlParameter("@UserID", UserID);
            SqlParameter pProfileID =(ProfileID==0)? new SqlParameter("@ProfileID", DBNull.Value):new SqlParameter("@ProfileID", ProfileID);
            SqlParameter pNoteTitle =(NoteTitle=="")? new SqlParameter("@NoteTitle", DBNull.Value):new SqlParameter("@NoteTitle", NoteTitle);
            SqlParameter pNoteContents = (NoteContents == "") ? new SqlParameter("@NoteContents", DBNull.Value) : new SqlParameter("@NoteContents", NoteContents);
            this.dt.Updatedata(sql, pUserID, pProfileID, pNoteTitle, pNoteContents);
            this.dt.CloseConnection();
            return true;
        }
    }
}
