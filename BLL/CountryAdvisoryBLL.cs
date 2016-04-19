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
    public class CountryAdvisoryBLL
    {
        DataServices DB = new DataServices();
        public List<CountryAdvisory> getallCountryAdvisory()
        {
            string sql = "select * from CountryAdvisory";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<CountryAdvisory> lst = new List<CountryAdvisory>();
            foreach (DataRow r in tb.Rows)
            {
                CountryAdvisory ca = new CountryAdvisory();
                ca.CountryAdvisoryID = (int)r[0];
                ca.CountryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(ca);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<CountryAdvisory> getallCountryAdvisoryWithId(int CadvId)
        {
            string sql = "select * from CountryAdvisory where CountryAdvisoryID=@CadvId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pCadvId = new SqlParameter("CadvId", CadvId);
            DataTable tb = DB.DAtable(sql, pCadvId);
            List<CountryAdvisory> lst = new List<CountryAdvisory>();
            foreach (DataRow r in tb.Rows)
            {
                CountryAdvisory ca = new CountryAdvisory();
                ca.CountryAdvisoryID = (int)r[0];
                ca.CountryName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(ca);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
