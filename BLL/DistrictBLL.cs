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
    public class DistrictBLL
    {
        DataServices DB = new DataServices();
        public List<District> getallDistrict()
        {
            string sql = "select * from District";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<District> lst = new List<District>();
            foreach (DataRow r in tb.Rows)
            {
                District d = new District();
                d.DistrictID = (int)r[0];
                d.DistrictName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                d.ProvinceID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(d);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<District> getDistrictwithProid(int proid)
        {
            string sql = "select * from District where ProvinceID=@proid";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter paramproid = new SqlParameter("proid", proid);
            DataTable tb = DB.DAtable(sql, paramproid);
            List<District> lst = new List<District>();
            foreach (DataRow r in tb.Rows)
            {
                District d = new District();
                d.DistrictID = (int)r[0];
                d.DistrictName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                d.ProvinceID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(d);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<District> getDistrictwithDisId(int disId)
        {
            string sql = "select * from District where DistrictID=@disId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pdisId = new SqlParameter("disId", disId);
            DataTable tb = DB.DAtable(sql, pdisId);
            List<District> lst = new List<District>();
            foreach (DataRow r in tb.Rows)
            {
                District d = new District();
                d.DistrictID = (int)r[0];
                d.DistrictName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                d.ProvinceID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(d);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
