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
    public class EmployeesBLL
    {
        DataServices DB = new DataServices();
        public DataTable GetEmployeesWithDepartments(int DpID)
        {
            string sql = "Exec GetEmployeesWithDepartments @DpID";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDpID = new SqlParameter("DpID", DpID);
            DataTable tb = DB.DAtable(sql, pDpID);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetEmployeesWithDepartmentsDL(int DpID)
        {
            string sql = "Exec GetEmployeesWithDepartmentsDL @DpID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDpID = new SqlParameter("DpID", DpID);
            DataTable tb = DB.DAtable(sql, pDpID);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable GetAllEmployeesDL()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec GetAllEmployeesDL";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable SearchEmployeesWithDepartments(int DpID, string keysearch)
        {
            string sql = "Exec SearchEmployeesWithDepartments @DpID,@keysearch";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDpID = new SqlParameter("DpID", DpID);
            SqlParameter pkeysearch = new SqlParameter("keysearch", keysearch);
            DataTable tb = DB.DAtable(sql, pDpID, pkeysearch);
            this.DB.CloseConnection();
            return tb;
        }
        public DataTable DropdownEmployeesWithDepartments(int DpID)
        {
            string sql = "Exec DropdownEmployeesWithDepartments @DpID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pDpID = new SqlParameter("DpID", DpID);
            DataTable tb = DB.DAtable(sql, pDpID);
            this.DB.CloseConnection();
            return tb;
        }
        public List<Employees> getEmpWithProfileId(int proID)
        {
            string sql = "select * from Employees where ProfileID=@proID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pproID = new SqlParameter("proID", proID);
            DataTable tb = DB.DAtable(sql, pproID);
            List<Employees> lst = new List<Employees>();
            foreach(DataRow r in tb.Rows)
            {
                Employees em = new Employees();
                em.EmployeesID = (int)r[0];
                em.EmployeesCode = (string)r[1];
                em.ProfileID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                em.EduLevel = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                em.IdentityCard_Old = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                em.IdentityCard_New = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                em.IdentityCard_Old_Date= (string.IsNullOrEmpty(r[6].ToString())) ? DateTime.Now : (DateTime)r[6];
                em.IdentityCard_New_Date= (string.IsNullOrEmpty(r[7].ToString())) ? DateTime.Now : (DateTime)r[7];
                em.IdentityCard_Place = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                em.DateOfStart = (string.IsNullOrEmpty(r[9].ToString())) ? DateTime.Now : (DateTime)r[9];
                em.Regency = (string.IsNullOrEmpty(r[10].ToString())) ? "" : (string)r[10];
                em.DepartmentsID = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                lst.Add(em);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Employees> getAllEmp()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from Employees";
            DataTable tb = DB.DAtable(sql);
            List<Employees> lst = new List<Employees>();
            foreach (DataRow r in tb.Rows)
            {
                Employees em = new Employees();
                em.EmployeesID = (int)r[0];
                em.EmployeesCode = (string)r[1];
                em.ProfileID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                em.EduLevel = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                em.IdentityCard_Old = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                em.IdentityCard_New = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                em.IdentityCard_Old_Date = (string.IsNullOrEmpty(r[6].ToString())) ? DateTime.Now : (DateTime)r[6];
                em.IdentityCard_New_Date = (string.IsNullOrEmpty(r[7].ToString())) ? DateTime.Now : (DateTime)r[7];
                em.IdentityCard_Place = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                em.DateOfStart = (string.IsNullOrEmpty(r[9].ToString())) ? DateTime.Now : (DateTime)r[9];
                em.Regency = (string.IsNullOrEmpty(r[10].ToString())) ? "" : (string)r[10];
                em.DepartmentsID = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                lst.Add(em);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<Employees> getEmpWithId(int EmpID)
        {
            string sql = "select * from Employees where EmployeesID=@EmpID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pEmpID = new SqlParameter("EmpID", EmpID);
            DataTable tb = DB.DAtable(sql, pEmpID);
            List<Employees> lst = new List<Employees>();
            foreach (DataRow r in tb.Rows)
            {
                Employees em = new Employees();
                em.EmployeesID = (int)r[0];
                em.EmployeesCode = (string)r[1];
                em.ProfileID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                em.EduLevel = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                em.IdentityCard_Old = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                em.IdentityCard_New = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                em.IdentityCard_Old_Date = (string.IsNullOrEmpty(r[6].ToString())) ? DateTime.Now : (DateTime)r[6];
                em.IdentityCard_New_Date = (string.IsNullOrEmpty(r[7].ToString())) ? DateTime.Now : (DateTime)r[7];
                em.IdentityCard_Place = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                em.DateOfStart = (string.IsNullOrEmpty(r[9].ToString())) ? DateTime.Now : (DateTime)r[9];
                em.Regency = (string.IsNullOrEmpty(r[10].ToString())) ? "" : (string)r[10];
                em.DepartmentsID = (string.IsNullOrEmpty(r[11].ToString())) ? 0 : (int)r[11];
                lst.Add(em);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable GetEmpNameCode(string code)
        {
            string sql = "Exec GetEmpNameCode @code";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcode = new SqlParameter("code", code);
            DataTable tb = DB.DAtable(sql, pcode);
            this.DB.CloseConnection();
            return tb;
        }
        //============= DANH SACH GIAO VIEN TAI TRUNG TAM====================================================================================================================================================================
        public DataTable kus_ListGiaoVienTTPageWise(int PageIndex, int PageSize, int depID)
        {
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_ListGiaoVienTTPageWise @PageIndex,@PageSize,@depID";
            SqlParameter pPageIndex = new SqlParameter("@PageIndex", PageIndex);
            SqlParameter pPageSize = new SqlParameter("@PageSize", PageSize);
            SqlParameter pdepID = new SqlParameter("@depID", depID);
            DataTable tb = DB.DAtable(sql, pPageIndex, pPageSize, pdepID);
            this.DB.CloseConnection();
            return tb;
        }
        public int Countkus_ListGiaoVienTT(int depID)
        {
            int dem = 0;
            if (!this.DB.OpenConnection())
            {
                return 0;
            }
            string sql = "select COUNT(*) from Employees where DepartmentsID=@depID";
            SqlParameter pdepID = new SqlParameter("@depID", depID);
            dem = DB.GetValues(sql, pdepID);
            this.DB.CloseConnection();
            return dem;
        }
        //===========================================
        public DataTable getTenGiaoVien(int EmployeesID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select emp.EmployeesCode, pro.LastName, pro.FirstName from Employees emp full outer join UserProfile pro on emp.ProfileID=pro.ProfileID where emp.EmployeesID=@EmployeesID";
            SqlParameter pEmployeesID = new SqlParameter("@EmployeesID", EmployeesID);
            DataTable tb = DB.DAtable(sql, pEmployeesID);
            this.DB.CloseConnection();
            return tb;
        }
        //==create Employee
        public Boolean createEmployee(int ProfileID, int DepartmentsID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into Employees(ProfileID,DepartmentsID) values(@ProfileID,@DepartmentsID)";
            SqlParameter pProfileID = new SqlParameter("@ProfileID", ProfileID);
            SqlParameter pDepartmentsID = (DepartmentsID == 0) ? new SqlParameter("@DepartmentsID", DBNull.Value) : new SqlParameter("@DepartmentsID", DepartmentsID);
            this.DB.Updatedata(sql, pProfileID, pDepartmentsID);
            this.DB.CloseConnection();
            return true;
        }

    }
}
