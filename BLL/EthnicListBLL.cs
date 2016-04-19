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
    public class EthnicListBLL
    {
        DataServices DB = new DataServices();
        public List<EthnicList> GetallEthnicList()
        {
            string sql = "select * from EthnicList";
            if (!DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<EthnicList> lst = new List<EthnicList>();
            foreach (DataRow r in tb.Rows)
            {
                EthnicList el = new EthnicList();
                el.EthnicID = (int)r[0];
                el.EthnicName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                el.EthnicOtherName= (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                el.NationalityID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(el);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<EthnicList> GetallEthnicListWithNationID(int NaID)
        {
            string sql = "select * from EthnicList where NationalityID=@NaID";
            if (!DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pNaID = new SqlParameter("NaID", NaID);
            DataTable tb = DB.DAtable(sql, pNaID);
            List<EthnicList> lst = new List<EthnicList>();
            foreach (DataRow r in tb.Rows)
            {
                EthnicList el = new EthnicList();
                el.EthnicID = (int)r[0];
                el.EthnicName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                el.EthnicOtherName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                el.NationalityID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(el);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<EthnicList> GetallEthnicListWithoutNationID(int NaID)
        {
            string sql = "select * from EthnicList where NationalityID<>@NaID";
            if (!DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pNaID = new SqlParameter("NaID", NaID);
            DataTable tb = DB.DAtable(sql, pNaID);
            List<EthnicList> lst = new List<EthnicList>();
            foreach (DataRow r in tb.Rows)
            {
                EthnicList el = new EthnicList();
                el.EthnicID = (int)r[0];
                el.EthnicName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                el.EthnicOtherName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                el.NationalityID = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                lst.Add(el);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
