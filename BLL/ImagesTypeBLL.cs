using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class ImagesTypeBLL
    {
        DataServices DB = new DataServices();
        public List<ImagesType> getallImagesType()
        {
            string sql = "select * from ImagesType";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<ImagesType> lst = new List<ImagesType>();
            foreach (DataRow r in tb.Rows)
            {
                ImagesType it = new ImagesType();
                it.ImagesTypeID = (int)r[0];
                it.ImagesTypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(it);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<ImagesType> getImagesTypeWithID(int ImagesTypeID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from ImagesType where ImagesTypeID=@ImagesTypeID";
            SqlParameter pImagesTypeID = new SqlParameter("@ImagesTypeID", ImagesTypeID);
            DataTable tb = DB.DAtable(sql, pImagesTypeID);
            List<ImagesType> lst = new List<ImagesType>();
            foreach (DataRow r in tb.Rows)
            {
                ImagesType it = new ImagesType();
                it.ImagesTypeID = (int)r[0];
                it.ImagesTypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(it);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getTBListImagesCategory()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select ImagesTypeID, ImagesTypeName, [dbo].[CountImgesWithCT](ImagesTypeID) as NunImages from ImagesType";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //New Category
        public Boolean NewImagesCategory(string ImagesTypeName)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into ImagesType(ImagesTypeName) values(@ImagesTypeName)";
            SqlParameter pImagesTypeName = new SqlParameter("@ImagesTypeName", ImagesTypeName);
            this.DB.Updatedata(sql, pImagesTypeName);
            this.DB.CloseConnection();
            return true;
        }
        //Update Images Category
        public Boolean Update(string ImagesTypeName, int ImagesTypeID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update ImagesType set ImagesTypeName=@ImagesTypeName where ImagesTypeID=@ImagesTypeID";
            SqlParameter pImagesTypeName = new SqlParameter("@ImagesTypeName", ImagesTypeName);
            SqlParameter pImagesTypeID = new SqlParameter("@ImagesTypeID", ImagesTypeID);
            this.DB.Updatedata(sql, pImagesTypeName, pImagesTypeID);
            this.DB.CloseConnection();
            return true;
        }


    }
}
