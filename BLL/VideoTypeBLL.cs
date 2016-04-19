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
    public class VideoTypeBLL
    {
        DataServices DB = new DataServices();
        public List<VideoType> getallVideoType()
        {
            string sql = "select * from VideoType";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<VideoType> lst = new List<VideoType>();
            foreach (DataRow r in tb.Rows)
            {
                VideoType vt = new VideoType();
                vt.VideotypeID =(int)r[0];
                vt.TypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                vt.ShortDesciption = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lst.Add(vt);
            }

            this.DB.CloseConnection();
            return lst;
        }
        public List<VideoType> getVideoTypeWithTypeID(int typeId)
        {
            string sql = "select * from VideoType where VideotypeID=@typeId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter ptypeId = new SqlParameter("typeId", typeId);
            DataTable tb = DB.DAtable(sql, ptypeId);
            List<VideoType> lst = new List<VideoType>();
            foreach (DataRow r in tb.Rows)
            {
                VideoType vt = new VideoType();
                vt.VideotypeID = (int)r[0];
                vt.TypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                vt.ShortDesciption = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                lst.Add(vt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean NewVideoType(string name, string shortDc)
        {
            string sql = "insert into VideoType(TypeName,ShortDesciption) values(@name,@shortDc)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pname = new SqlParameter("name", name);
            SqlParameter pshortDc = new SqlParameter("shortDc", shortDc);
            this.DB.Updatedata(sql, pname, pshortDc);
            return true;
        }
        public Boolean UpdateVideoType(int typeId, string name, string shortDc)
        {
            string sql = "update VideoType set TypeName=@name, ShortDesciption=@shortDc where VideotypeID=@typeId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptypeId = new SqlParameter("typeId", typeId);
            SqlParameter pname = new SqlParameter("name", name);
            SqlParameter pshortDc = new SqlParameter("shortDc", shortDc);
            this.DB.Updatedata(sql, ptypeId, pname, pshortDc);
            return true;
        }
        public Boolean DeleteVideoType(int typeId)
        {
            string sql = "delete from VideoType where VideotypeID=@typeId";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter ptypeId = new SqlParameter("typeId", typeId);
            this.DB.Updatedata(sql, ptypeId);
            return true;
        }
    }
}
