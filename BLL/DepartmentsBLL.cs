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
    public class DepartmentsBLL
    {
        DataServices DB = new DataServices();
        public List<Departments> getAllDepartment()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Departments";
            DataTable tb = DB.DAtable(sql);
            List<Departments> lst = new List<Departments>();
            foreach (DataRow r in tb.Rows)
            {
                Departments dp = new Departments();
                dp.DepartmentsID = (int)r[0];
                dp.DepartmentName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                dp.Manager = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                lst.Add(dp);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getListDepartment()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec getListDepartment";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //New Department
        public Boolean NewDepartment(string DepartmentName, int Manager)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into Departments(DepartmentName,Manager) values(@DepartmentName,@Manager)";
            SqlParameter pDepartmentName = new SqlParameter("@DepartmentName", DepartmentName);
            SqlParameter pManager = (Manager == 0) ? new SqlParameter("@Manager", DBNull.Value) : new SqlParameter("@Manager", Manager);
            this.DB.Updatedata(sql, pDepartmentName, pManager);
            this.DB.CloseConnection();
            return true;
        }
    }
}
