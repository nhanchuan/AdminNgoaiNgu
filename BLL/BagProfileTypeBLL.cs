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
    public class BagProfileTypeBLL
    {
        DataServices DB = new DataServices();
        public List<BagProfileType> getAllBagProfileType()
        {
            string sql = "select * from BagProfileType";
            if(!DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            List<BagProfileType> lst = new List<BagProfileType>();
            foreach (DataRow r in tb.Rows)
            {
                BagProfileType bt = new BagProfileType();
                bt.BagProfileTypeID = (int)r[0];
                bt.TypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<BagProfileType> getBagProfileTypeWithId(int bpId)
        {
            string sql = "select * from BagProfileType where BagProfileTypeID=@bpId";
            if (!DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pbpId = new SqlParameter("bpId", bpId);
            DataTable tb = DB.DAtable(sql,pbpId);
            List<BagProfileType> lst = new List<BagProfileType>();
            foreach (DataRow r in tb.Rows)
            {
                BagProfileType bt = new BagProfileType();
                bt.BagProfileTypeID = (int)r[0];
                bt.TypeName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                lst.Add(bt);
            }
            this.DB.CloseConnection();
            return lst;
        }
    }
}
