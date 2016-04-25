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
    public class CountryBLL
    {
        DataServices DB = new DataServices();
        public List<Country> getAllCountry()
        {
            string sql = "select * from Country";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<Country> lst = new List<Country>();
            foreach (DataRow r in tb.Rows)
            {
                Country ct = new Country();
                ct.CountryID = (int)r["CountryID"];
                ct.CountryName = (string.IsNullOrEmpty(r["CountryName"].ToString())) ? "" : (string)r["CountryName"];
                lst.Add(ct);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Country> getCountryWithId(int countryId)
        {
            string sql = "select * from Country where CountryID=@countryId";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcountryId = new SqlParameter("countryId", countryId);
            DataTable tb = DB.DAtable(sql, pcountryId);
            List<Country> lst = new List<Country>();
            foreach(DataRow r in tb.Rows)
            {
                Country ct = new Country();
                ct.CountryID = (int)r["CountryID"];
                ct.CountryName = (string.IsNullOrEmpty(r["CountryName"].ToString())) ? "" : (string)r["CountryName"];
                lst.Add(ct);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
