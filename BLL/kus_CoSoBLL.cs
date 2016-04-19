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
    public class kus_CoSoBLL
    {
        DataServices DB = new DataServices();
        DateTime defaultdate = Convert.ToDateTime("12/12/1900");
        public List<kus_CoSo> getLSTCoSoWithChiNhanhID(int chinhanhID)
        {
            string sql = "select * from kus_CoSo where HTChiNhanhID=@chinhanhID";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pchinhanhID = new SqlParameter("chinhanhID", chinhanhID);
            DataTable tb = DB.DAtable(sql, pchinhanhID);
            List<kus_CoSo> lst = new List<kus_CoSo>();
            foreach(DataRow r in tb.Rows)
            {
                kus_CoSo cs = new kus_CoSo();
                cs.CoSoID = (int)r[0];
                cs.TenCoSo = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cs.DiaChi = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                cs.Fax = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                cs.Phone = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                cs.Email = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                cs.NgayThanhLap = (string.IsNullOrEmpty(r[6].ToString())) ? defaultdate : (DateTime)r[6];
                cs.GhiChu = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                cs.HTChiNhanhID = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                cs.QLCoSo = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                lst.Add(cs);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_CoSo> getLSTCoSoWithID(int cosoID)
        {
            string sql = "select * from kus_CoSo where CoSoID=@cosoID";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pcosoID = new SqlParameter("cosoID", cosoID);
            DataTable tb = DB.DAtable(sql, pcosoID);
            List<kus_CoSo> lst = new List<kus_CoSo>();
            foreach (DataRow r in tb.Rows)
            {
                kus_CoSo cs = new kus_CoSo();
                cs.CoSoID = (int)r[0];
                cs.TenCoSo = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                cs.DiaChi = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                cs.Fax = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                cs.Phone = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                cs.Email = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                cs.NgayThanhLap = (string.IsNullOrEmpty(r[6].ToString())) ? defaultdate : (DateTime)r[6];
                cs.GhiChu = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                cs.HTChiNhanhID = (string.IsNullOrEmpty(r[8].ToString())) ? 0 : (int)r[8];
                cs.CoSoID = (string.IsNullOrEmpty(r[9].ToString())) ? 0 : (int)r[9];
                lst.Add(cs);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable getAllHTCoSo()
        {
            string sql = "Exec kus_getAllHTCoSo";
            if(!this.DB.OpenConnection())
            {
                return null;
            }
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        //Create
        public Boolean AddNew_CoSo(string coso, string diachi, string fax, string phone, string email, DateTime ngaythanhlap, string ghichu, int chinhanh_id, int qlcoso_id)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int year = ngaythanhlap.Year;
            string query = "insert into kus_CoSo(TenCoSo,DiaChi,Fax,Phone,Email,NgayThanhLap,GhiChu,HTChiNhanhID,QLCoSo) values(@coso, @diachi, @fax, @phone, @email, @ngaythanhlap, @ghichu, @chinhanh_id, @qlcoso_id)";
            SqlParameter pcoso = new SqlParameter("@coso", coso);
            SqlParameter pdiachi = new SqlParameter("@diachi", diachi);
            SqlParameter pfax = new SqlParameter("@fax", fax);
            SqlParameter pphone = new SqlParameter("@phone", phone);
            SqlParameter pemail = new SqlParameter("@email", email);
            SqlParameter pngaythanhlap = (year <= 1900) ? new SqlParameter("@ngaythanhlap", DBNull.Value) : new SqlParameter("@ngaythanhlap", ngaythanhlap);
            SqlParameter pghichu = new SqlParameter("@ghichu", ghichu);
            SqlParameter pchinhanh_id = (chinhanh_id == 0) ? new SqlParameter("@chinhanh_id", DBNull.Value) : new SqlParameter("@chinhanh_id", chinhanh_id);
            SqlParameter pqlcoso_id = (qlcoso_id == 0) ? new SqlParameter("@qlcoso_id", DBNull.Value) : new SqlParameter("@qlcoso_id", qlcoso_id);
            this.DB.Updatedata(query, pcoso, pdiachi, pfax, pphone, pemail, pngaythanhlap, pghichu, pchinhanh_id, pqlcoso_id);
            this.DB.CloseConnection();
            return true;
        }
        //Update
        public Boolean Update_CoSo(int id, string coso, string diachi, string fax, string phone, string email, DateTime ngaythanhlap, string ghichu, int chinhanh_id, int qlcoso_id)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int year = ngaythanhlap.Year;
            string query = "update kus_CoSo set TenCoSo=@coso, DiaChi=@diachi, Fax=@fax, Phone=@phone, Email=@email, NgayThanhLap=@ngaythanhlap, GhiChu=@ghichu, HTChiNhanhID=@chinhanh_id, QLCoSo=@qlcoso_id where CoSoID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            SqlParameter pcoso = new SqlParameter("@coso", coso);
            SqlParameter pdiachi = new SqlParameter("@diachi", diachi);
            SqlParameter pfax = new SqlParameter("@fax", fax);
            SqlParameter pphone = new SqlParameter("@phone", phone);
            SqlParameter pemail = new SqlParameter("@email", email);
            SqlParameter pngaythanhlap = (year <= 1900) ? new SqlParameter("@ngaythanhlap", DBNull.Value) : new SqlParameter("@ngaythanhlap", ngaythanhlap);
            SqlParameter pghichu = new SqlParameter("@ghichu", ghichu);
            SqlParameter pchinhanh_id = (chinhanh_id == 0) ? new SqlParameter("@chinhanh_id", DBNull.Value) : new SqlParameter("@chinhanh_id", chinhanh_id);
            SqlParameter pqlcoso_id = (qlcoso_id == 0) ? new SqlParameter("@qlcoso_id", DBNull.Value) : new SqlParameter("@qlcoso_id", qlcoso_id);
            this.DB.Updatedata(query,pid, pcoso, pdiachi, pfax, pphone, pemail, pngaythanhlap, pghichu, pchinhanh_id, pqlcoso_id);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean Delete_CoSo(int id)
        {
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            string query = "delete from kus_CoSo where CoSoID=@id";
            SqlParameter pid = new SqlParameter("@id", id);
            this.DB.Updatedata(query, pid);
            this.DB.CloseConnection();
            return true;
        }
    }
}
