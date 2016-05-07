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
                ph.FirstName = (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : (string)r["FirstName"];
                ph.LastName = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
                ph.NgaySinh = (string.IsNullOrEmpty(r["NgaySinh"].ToString())) ? DefaultDate : (DateTime)r["NgaySinh"];
                ph.NoiSinh = (string.IsNullOrEmpty(r["NoiSinh"].ToString())) ? "" : (string)r["NoiSinh"];
                ph.SoCmnd = (string.IsNullOrEmpty(r["SoCmnd"].ToString())) ? "" : (string)r["SoCmnd"];
                ph.NoiCap = (string.IsNullOrEmpty(r["NoiCap"].ToString())) ? "" : (string)r["NoiCap"];
                ph.NgayCap = (string.IsNullOrEmpty(r["NgayCap"].ToString())) ? DefaultDate : (DateTime)r["NgayCap"];
                ph.SoDienThoai= (string.IsNullOrEmpty(r["SoDienThoai"].ToString())) ? "" : (string)r["SoDienThoai"];
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
                ph.FirstName = (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : (string)r["FirstName"];
                ph.LastName = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
                ph.NgaySinh = (string.IsNullOrEmpty(r["NgaySinh"].ToString())) ? DefaultDate : (DateTime)r["NgaySinh"];
                ph.NoiSinh = (string.IsNullOrEmpty(r["NoiSinh"].ToString())) ? "" : (string)r["NoiSinh"];
                ph.SoCmnd = (string.IsNullOrEmpty(r["SoCmnd"].ToString())) ? "" : (string)r["SoCmnd"];
                ph.NoiCap = (string.IsNullOrEmpty(r["NoiCap"].ToString())) ? "" : (string)r["NoiCap"];
                ph.NgayCap = (string.IsNullOrEmpty(r["NgayCap"].ToString())) ? DefaultDate : (DateTime)r["NgayCap"];
                ph.SoDienThoai = (string.IsNullOrEmpty(r["SoDienThoai"].ToString())) ? "" : (string)r["SoDienThoai"];
                lst.Add(ph);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New
        public Boolean NewThongTinPhuHuynh(int InfoID, string FirstName, string LastName, DateTime NgaySinh, string NoiSinh, string SoCmnd, string NoiCap, DateTime NgayCap, string SoDienThoai)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into ThongTinPhuHuynh(InfoID,FirstName,LastName,NgaySinh,NoiSinh,SoCmnd,NoiCap,NgayCap,SoDienThoai) values(@InfoID,@FirstName,@LastName,@NgaySinh,@NoiSinh,@SoCmnd,@NoiCap,@NgayCap,@SoDienThoai)";
            SqlParameter pInfoID = (InfoID==0) ? new SqlParameter("@InfoID", DBNull.Value) : new SqlParameter("@InfoID", InfoID);
            SqlParameter pFirstName = (FirstName=="") ? new SqlParameter("@FirstName", DBNull.Value) : new SqlParameter("@FirstName", FirstName);
            SqlParameter pLastName = (LastName=="") ? new SqlParameter("@LastName", DBNull.Value) : new SqlParameter("@LastName", LastName);
            SqlParameter pNgaySinh = (NgaySinh.Year<=1900) ? new SqlParameter("@NgaySinh", DBNull.Value) : new SqlParameter("@NgaySinh", NgaySinh);
            SqlParameter pNoiSinh = (NoiSinh=="") ? new SqlParameter("@NoiSinh", DBNull.Value) : new SqlParameter("@NoiSinh", NoiSinh);
            SqlParameter pSoCmnd = (SoCmnd=="") ? new SqlParameter("@SoCmnd", DBNull.Value) : new SqlParameter("@SoCmnd", SoCmnd);
            SqlParameter pNoiCap = (NoiCap=="") ? new SqlParameter("@NoiCap", DBNull.Value) : new SqlParameter("@NoiCap", NoiCap);
            SqlParameter pNgayCap = (NgayCap.Year<=1900) ? new SqlParameter("@NgayCap", DBNull.Value) : new SqlParameter("@NgayCap", NgayCap);
            SqlParameter pSoDienThoai = (SoDienThoai=="") ? new SqlParameter("@SoDienThoai", DBNull.Value) : new SqlParameter("@SoDienThoai", SoDienThoai);
            this.dt.Updatedata(sql, pInfoID, pFirstName, pLastName, pNgaySinh, pNoiSinh, pSoCmnd, pNoiCap, pNgayCap, pSoDienThoai);
            return true;
        }
        //Update
        public Boolean UpdateThongTinPhuHuynh(int InfoID, string FirstName, string LastName, DateTime NgaySinh, string NoiSinh, string SoCmnd, string NoiCap, DateTime NgayCap, string SoDienThoai)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update ThongTinPhuHuynh set FirstName=@FirstName,LastName=@LastName,NgaySinh=@NgaySinh,NoiSinh=@NoiSinh,SoCmnd=@SoCmnd,NoiCap=@NoiCap,NgayCap=@NgayCap,SoDienThoai=@SoDienThoai where InfoID=@InfoID";
            SqlParameter pInfoID = (InfoID == 0) ? new SqlParameter("@InfoID", DBNull.Value) : new SqlParameter("@InfoID", InfoID);
            SqlParameter pFirstName = (FirstName == "") ? new SqlParameter("@FirstName", DBNull.Value) : new SqlParameter("@FirstName", FirstName);
            SqlParameter pLastName = (LastName == "") ? new SqlParameter("@LastName", DBNull.Value) : new SqlParameter("@LastName", LastName);
            SqlParameter pNgaySinh = (NgaySinh.Year <= 1900) ? new SqlParameter("@NgaySinh", DBNull.Value) : new SqlParameter("@NgaySinh", NgaySinh);
            SqlParameter pNoiSinh = (NoiSinh == "") ? new SqlParameter("@NoiSinh", DBNull.Value) : new SqlParameter("@NoiSinh", NoiSinh);
            SqlParameter pSoCmnd = (SoCmnd == "") ? new SqlParameter("@SoCmnd", DBNull.Value) : new SqlParameter("@SoCmnd", SoCmnd);
            SqlParameter pNoiCap = (NoiCap == "") ? new SqlParameter("@NoiCap", DBNull.Value) : new SqlParameter("@NoiCap", NoiCap);
            SqlParameter pNgayCap = (NgayCap.Year <= 1900) ? new SqlParameter("@NgayCap", DBNull.Value) : new SqlParameter("@NgayCap", NgayCap);
            SqlParameter pSoDienThoai = (SoDienThoai == "") ? new SqlParameter("@SoDienThoai", DBNull.Value) : new SqlParameter("@SoDienThoai", SoDienThoai);
            this.dt.Updatedata(sql, pInfoID, pFirstName, pLastName, pNgaySinh, pNoiSinh, pSoCmnd, pNoiCap, pNgayCap, pSoDienThoai);
            return true;
        }
    }
}
