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
    public class ThongTinPhuHuynhBLL
    {
        DataServices dt = new DataServices();
        DateTime DefaultDate = Convert.ToDateTime("01/01/1900");
        public List<ThongTinPhuHuynh> getAllList()
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from ThongTinPhuHuynh";
            DataTable tb = dt.DAtable(sql);
            List<ThongTinPhuHuynh> lst = new List<ThongTinPhuHuynh>();
            foreach (DataRow r in tb.Rows)
            {
                ThongTinPhuHuynh ph = new ThongTinPhuHuynh();
                ph.ID = (int)r["ID"];
                ph.InfoID = (int)r["InfoID"];
                ph.FirstName_Dad = (string.IsNullOrEmpty(r["FirstName_Dad"].ToString())) ? "" : (string)r["FirstName_Dad"];
                ph.LastName_Dad = (string.IsNullOrEmpty(r["LastName_Dad"].ToString())) ? "" : (string)r["LastName_Dad"];
                ph.NgaySinh_Dad = (string.IsNullOrEmpty(r["NgaySinh_Dad"].ToString())) ? DefaultDate : (DateTime)r["NgaySinh_Dad"];
                ph.NoiSinh_Dad = (string.IsNullOrEmpty(r["NoiSinh_Dad"].ToString())) ? "" : (string)r["NoiSinh_Dad"];
                ph.SoCmnd_Dad = (string.IsNullOrEmpty(r["SoCmnd_Dad"].ToString())) ? "" : (string)r["SoCmnd_Dad"];
                ph.NoiCap_Dad = (string.IsNullOrEmpty(r["NoiCap_Dad"].ToString())) ? "" : (string)r["NoiCap_Dad"];
                ph.NgayCap_Dad = (string.IsNullOrEmpty(r["NgayCap_Dad"].ToString())) ? DefaultDate : (DateTime)r["NgayCap_Dad"];
                ph.SoDienThoai_Dad = (string.IsNullOrEmpty(r["SoDienThoai_Dad"].ToString())) ? "" : (string)r["SoDienThoai_Dad"];
                ph.FirstName_Mom = (string.IsNullOrEmpty(r["FirstName_Mom"].ToString())) ? "" : (string)r["FirstName_Mom"];
                ph.LastName_Mom = (string.IsNullOrEmpty(r["LastName_Mom"].ToString())) ? "" : (string)r["LastName_Mom"];
                ph.NgaySinh_Mom = (string.IsNullOrEmpty(r["NgaySinh_Mom"].ToString())) ? DefaultDate : (DateTime)r["NgaySinh_Mom"];
                ph.NoiSinh_Mom = (string.IsNullOrEmpty(r["NoiSinh_Mom"].ToString())) ? "" : (string)r["NoiSinh_Mom"];
                ph.SoCmnd_Mom = (string.IsNullOrEmpty(r["SoCmnd_Mom"].ToString())) ? "" : (string)r["SoCmnd_Mom"];
                ph.NoiCap_Mom = (string.IsNullOrEmpty(r["NoiCap_Mom"].ToString())) ? "" : (string)r["NoiCap_Mom"];
                ph.NgayCap_Mom = (string.IsNullOrEmpty(r["NgayCap_Mom"].ToString())) ? DefaultDate : (DateTime)r["NgayCap_Mom"];
                ph.SoDienThoai_Mom = (string.IsNullOrEmpty(r["SoDienThoai_Mom"].ToString())) ? "" : (string)r["SoDienThoai_Mom"];
                lst.Add(ph);
            }
            this.dt.CloseConnection();
            return lst;
        }
        public List<ThongTinPhuHuynh> getAllListWithInfoID(int InfoID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from ThongTinPhuHuynh where InfoID=@InfoID";
            SqlParameter pInfoID = new SqlParameter("@InfoID", InfoID);
            DataTable tb = dt.DAtable(sql, pInfoID);
            List<ThongTinPhuHuynh> lst = new List<ThongTinPhuHuynh>();
            foreach (DataRow r in tb.Rows)
            {
                ThongTinPhuHuynh ph = new ThongTinPhuHuynh();
                ph.ID = (int)r["ID"];
                ph.InfoID = (int)r["InfoID"];
                ph.FirstName_Dad = (string.IsNullOrEmpty(r["FirstName_Dad"].ToString())) ? "" : (string)r["FirstName_Dad"];
                ph.LastName_Dad = (string.IsNullOrEmpty(r["LastName_Dad"].ToString())) ? "" : (string)r["LastName_Dad"];
                ph.NgaySinh_Dad = (string.IsNullOrEmpty(r["NgaySinh_Dad"].ToString())) ? DefaultDate : (DateTime)r["NgaySinh_Dad"];
                ph.NoiSinh_Dad = (string.IsNullOrEmpty(r["NoiSinh_Dad"].ToString())) ? "" : (string)r["NoiSinh_Dad"];
                ph.SoCmnd_Dad = (string.IsNullOrEmpty(r["SoCmnd_Dad"].ToString())) ? "" : (string)r["SoCmnd_Dad"];
                ph.NoiCap_Dad = (string.IsNullOrEmpty(r["NoiCap_Dad"].ToString())) ? "" : (string)r["NoiCap_Dad"];
                ph.NgayCap_Dad = (string.IsNullOrEmpty(r["NgayCap_Dad"].ToString())) ? DefaultDate : (DateTime)r["NgayCap_Dad"];
                ph.SoDienThoai_Dad = (string.IsNullOrEmpty(r["SoDienThoai_Dad"].ToString())) ? "" : (string)r["SoDienThoai_Dad"];
                ph.FirstName_Mom = (string.IsNullOrEmpty(r["FirstName_Mom"].ToString())) ? "" : (string)r["FirstName_Mom"];
                ph.LastName_Mom = (string.IsNullOrEmpty(r["LastName_Mom"].ToString())) ? "" : (string)r["LastName_Mom"];
                ph.NgaySinh_Mom = (string.IsNullOrEmpty(r["NgaySinh_Mom"].ToString())) ? DefaultDate : (DateTime)r["NgaySinh_Mom"];
                ph.NoiSinh_Mom = (string.IsNullOrEmpty(r["NoiSinh_Mom"].ToString())) ? "" : (string)r["NoiSinh_Mom"];
                ph.SoCmnd_Mom = (string.IsNullOrEmpty(r["SoCmnd_Mom"].ToString())) ? "" : (string)r["SoCmnd_Mom"];
                ph.NoiCap_Mom = (string.IsNullOrEmpty(r["NoiCap_Mom"].ToString())) ? "" : (string)r["NoiCap_Mom"];
                ph.NgayCap_Mom = (string.IsNullOrEmpty(r["NgayCap_Mom"].ToString())) ? DefaultDate : (DateTime)r["NgayCap_Mom"];
                ph.SoDienThoai_Mom = (string.IsNullOrEmpty(r["SoDienThoai_Mom"].ToString())) ? "" : (string)r["SoDienThoai_Mom"];
                lst.Add(ph);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New
        public Boolean NewThongTinPhuHuynh(int InfoID, string FirstName_Dad, string LastName_Dad, DateTime NgaySinh_Dad, string NoiSinh_Dad, string SoCmnd_Dad, string NoiCap_Dad, DateTime NgayCap_Dad, string SoDienThoai_Dad, string FirstName_Mom, string LastName_Mom, DateTime NgaySinh_Mom, string NoiSinh_Mom, string SoCmnd_Mom, string NoiCap_Mom, DateTime NgayCap_Mom, string SoDienThoai_Mom)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec NewThongTinPhuHuynh @InfoID,@FirstName_Dad,@LastName_Dad,@NgaySinh_Dad,@NoiSinh_Dad,@SoCmnd_Dad,@NoiCap_Dad,@NgayCap_Dad,@SoDienThoai_Dad,@FirstName_Mom,@LastName_Mom,@NgaySinh_Mom,@NoiSinh_Mom,@SoCmnd_Mom,@NoiCap_Mom,@NgayCap_Mom,@SoDienThoai_Mom";
            SqlParameter pInfoID = (InfoID==0) ? new SqlParameter("@InfoID", DBNull.Value) : new SqlParameter("@InfoID", InfoID);

            SqlParameter pFirstName_Dad = (FirstName_Dad=="") ? new SqlParameter("@FirstName_Dad", DBNull.Value) : new SqlParameter("@FirstName_Dad", FirstName_Dad);
            SqlParameter pLastName_Dad = (LastName_Dad=="") ? new SqlParameter("@LastName_Dad", DBNull.Value) : new SqlParameter("@LastName_Dad", LastName_Dad);
            SqlParameter pNgaySinh_Dad = (NgaySinh_Dad.Year<=1900) ? new SqlParameter("@NgaySinh_Dad", DBNull.Value) : new SqlParameter("@NgaySinh_Dad", NgaySinh_Dad);
            SqlParameter pNoiSinh_Dad = (NoiSinh_Dad=="") ? new SqlParameter("@NoiSinh_Dad", DBNull.Value) : new SqlParameter("@NoiSinh_Dad", NoiSinh_Dad);
            SqlParameter pSoCmnd_Dad = (SoCmnd_Dad=="") ? new SqlParameter("@SoCmnd_Dad", DBNull.Value) : new SqlParameter("@SoCmnd_Dad", SoCmnd_Dad);
            SqlParameter pNoiCap_Dad = (NoiCap_Dad=="") ? new SqlParameter("@NoiCap_Dad", DBNull.Value) : new SqlParameter("@NoiCap_Dad", NoiCap_Dad);
            SqlParameter pNgayCap_Dad = (NgayCap_Dad.Year<=1900) ? new SqlParameter("@NgayCap_Dad", DBNull.Value) : new SqlParameter("@NgayCap_Dad", NgayCap_Dad);
            SqlParameter pSoDienThoai_Dad = (SoDienThoai_Dad=="") ? new SqlParameter("@SoDienThoai_Dad", DBNull.Value) : new SqlParameter("@SoDienThoai_Dad", SoDienThoai_Dad);

            SqlParameter pFirstName_Mom = (FirstName_Mom == "") ? new SqlParameter("@FirstName_Mom", DBNull.Value) : new SqlParameter("@FirstName_Mom", FirstName_Mom);
            SqlParameter pLastName_Mom = (LastName_Mom == "") ? new SqlParameter("@LastName_Mom", DBNull.Value) : new SqlParameter("@LastName_Mom", LastName_Mom);
            SqlParameter pNgaySinh_Mom = (NgaySinh_Mom.Year <= 1900) ? new SqlParameter("@NgaySinh_Mom", DBNull.Value) : new SqlParameter("@NgaySinh_Mom", NgaySinh_Mom);
            SqlParameter pNoiSinh_Mom = (NoiSinh_Mom == "") ? new SqlParameter("@NoiSinh_Mom", DBNull.Value) : new SqlParameter("@NoiSinh_Mom", NoiSinh_Mom);
            SqlParameter pSoCmnd_Mom = (SoCmnd_Mom == "") ? new SqlParameter("@SoCmnd_Mom", DBNull.Value) : new SqlParameter("@SoCmnd_Mom", SoCmnd_Mom);
            SqlParameter pNoiCap_Mom = (NoiCap_Mom == "") ? new SqlParameter("@NoiCap_Mom", DBNull.Value) : new SqlParameter("@NoiCap_Mom", NoiCap_Mom);
            SqlParameter pNgayCap_Mom = (NgayCap_Mom.Year <= 1900) ? new SqlParameter("@NgayCap_Mom", DBNull.Value) : new SqlParameter("@NgayCap_Mom", NgayCap_Mom);
            SqlParameter pSoDienThoai_Mom = (SoDienThoai_Mom == "") ? new SqlParameter("@SoDienThoai_Mom", DBNull.Value) : new SqlParameter("@SoDienThoai_Mom", SoDienThoai_Mom);

            this.dt.Updatedata(sql, pInfoID, pFirstName_Dad, pLastName_Dad, pNgaySinh_Dad, pNoiSinh_Dad, pSoCmnd_Dad, pNoiCap_Dad, pNgayCap_Dad, pSoDienThoai_Dad, pFirstName_Mom, pLastName_Mom, pNgaySinh_Mom, pNoiSinh_Mom, pSoCmnd_Mom, pNoiCap_Mom, pNgayCap_Mom, pSoDienThoai_Mom);
            return true;
        }
        //Update
        public Boolean UpdateThongTinPhuHuynh(int InfoID, string FirstName_Dad, string LastName_Dad, DateTime NgaySinh_Dad, string NoiSinh_Dad, string SoCmnd_Dad, string NoiCap_Dad, DateTime NgayCap_Dad, string SoDienThoai_Dad, string FirstName_Mom, string LastName_Mom, DateTime NgaySinh_Mom, string NoiSinh_Mom, string SoCmnd_Mom, string NoiCap_Mom, DateTime NgayCap_Mom, string SoDienThoai_Mom)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "Exec UpdateThongTinPhuHuynh @InfoID,@FirstName_Dad,@LastName_Dad,@NgaySinh_Dad,@NoiSinh_Dad,@SoCmnd_Dad,@NoiCap_Dad,@NgayCap_Dad,@SoDienThoai_Dad,@FirstName_Mom,@LastName_Mom,@NgaySinh_Mom,@NoiSinh_Mom,@SoCmnd_Mom,@NoiCap_Mom,@NgayCap_Mom,@SoDienThoai_Mom";
            SqlParameter pInfoID = (InfoID == 0) ? new SqlParameter("@InfoID", DBNull.Value) : new SqlParameter("@InfoID", InfoID);

            SqlParameter pFirstName_Dad = (FirstName_Dad == "") ? new SqlParameter("@FirstName_Dad", DBNull.Value) : new SqlParameter("@FirstName_Dad", FirstName_Dad);
            SqlParameter pLastName_Dad = (LastName_Dad == "") ? new SqlParameter("@LastName_Dad", DBNull.Value) : new SqlParameter("@LastName_Dad", LastName_Dad);
            SqlParameter pNgaySinh_Dad = (NgaySinh_Dad.Year <= 1900) ? new SqlParameter("@NgaySinh_Dad", DBNull.Value) : new SqlParameter("@NgaySinh_Dad", NgaySinh_Dad);
            SqlParameter pNoiSinh_Dad = (NoiSinh_Dad == "") ? new SqlParameter("@NoiSinh_Dad", DBNull.Value) : new SqlParameter("@NoiSinh_Dad", NoiSinh_Dad);
            SqlParameter pSoCmnd_Dad = (SoCmnd_Dad == "") ? new SqlParameter("@SoCmnd_Dad", DBNull.Value) : new SqlParameter("@SoCmnd_Dad", SoCmnd_Dad);
            SqlParameter pNoiCap_Dad = (NoiCap_Dad == "") ? new SqlParameter("@NoiCap_Dad", DBNull.Value) : new SqlParameter("@NoiCap_Dad", NoiCap_Dad);
            SqlParameter pNgayCap_Dad = (NgayCap_Dad.Year <= 1900) ? new SqlParameter("@NgayCap_Dad", DBNull.Value) : new SqlParameter("@NgayCap_Dad", NgayCap_Dad);
            SqlParameter pSoDienThoai_Dad = (SoDienThoai_Dad == "") ? new SqlParameter("@SoDienThoai_Dad", DBNull.Value) : new SqlParameter("@SoDienThoai_Dad", SoDienThoai_Dad);

            SqlParameter pFirstName_Mom = (FirstName_Mom == "") ? new SqlParameter("@FirstName_Mom", DBNull.Value) : new SqlParameter("@FirstName_Mom", FirstName_Mom);
            SqlParameter pLastName_Mom = (LastName_Mom == "") ? new SqlParameter("@LastName_Mom", DBNull.Value) : new SqlParameter("@LastName_Mom", LastName_Mom);
            SqlParameter pNgaySinh_Mom = (NgaySinh_Mom.Year <= 1900) ? new SqlParameter("@NgaySinh_Mom", DBNull.Value) : new SqlParameter("@NgaySinh_Mom", NgaySinh_Mom);
            SqlParameter pNoiSinh_Mom = (NoiSinh_Mom == "") ? new SqlParameter("@NoiSinh_Mom", DBNull.Value) : new SqlParameter("@NoiSinh_Mom", NoiSinh_Mom);
            SqlParameter pSoCmnd_Mom = (SoCmnd_Mom == "") ? new SqlParameter("@SoCmnd_Mom", DBNull.Value) : new SqlParameter("@SoCmnd_Mom", SoCmnd_Mom);
            SqlParameter pNoiCap_Mom = (NoiCap_Mom == "") ? new SqlParameter("@NoiCap_Mom", DBNull.Value) : new SqlParameter("@NoiCap_Mom", NoiCap_Mom);
            SqlParameter pNgayCap_Mom = (NgayCap_Mom.Year <= 1900) ? new SqlParameter("@NgayCap_Mom", DBNull.Value) : new SqlParameter("@NgayCap_Mom", NgayCap_Mom);
            SqlParameter pSoDienThoai_Mom = (SoDienThoai_Mom == "") ? new SqlParameter("@SoDienThoai_Mom", DBNull.Value) : new SqlParameter("@SoDienThoai_Mom", SoDienThoai_Mom);

            this.dt.Updatedata(sql, pInfoID, pFirstName_Dad, pLastName_Dad, pNgaySinh_Dad, pNoiSinh_Dad, pSoCmnd_Dad, pNoiCap_Dad, pNgayCap_Dad, pSoDienThoai_Dad, pFirstName_Mom, pLastName_Mom, pNgaySinh_Mom, pNoiSinh_Mom, pSoCmnd_Mom, pNoiCap_Mom, pNgayCap_Mom, pSoDienThoai_Mom);
            return true;
        }
    }
}
