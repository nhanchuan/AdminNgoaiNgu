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
    public class kus_HopDongGVBLL
    {
        DataServices DB = new DataServices();
        public DateTime defaultdate = Convert.ToDateTime("01/01/1900");
        public List<kus_HopDongGV> getHDGVWithGiaoVienID(int GVID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HopDongGV where GVID=@GVID";
            SqlParameter pGVID = new SqlParameter("@GVID", GVID);
            DataTable tb = DB.DAtable(sql, pGVID);
            List<kus_HopDongGV> lst = new List<kus_HopDongGV>();
            foreach(DataRow r in tb.Rows)
            {
                kus_HopDongGV hd = new kus_HopDongGV();
                hd.HopDongID = (int)r[0];
                hd.HopDongCode = (string)r[1];
                hd.GVID = (int)r[2];
                hd.NgayHopDong = (string.IsNullOrEmpty(r[3].ToString())) ? defaultdate : (DateTime)r[3];
                hd.ThoiHan = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                hd.TinhTrangHD = (int)r[5];
                lst.Add(hd);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean newHopDong(int GVID, DateTime NgayHopDong, int ThoiHan, int TinhTrangHD)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "insert into kus_HopDongGV(GVID,NgayHopDong,ThoiHan,TinhTrangHD) values(@GVID,@NgayHopDong,@ThoiHan,@TinhTrangHD)";
            SqlParameter pGVID = new SqlParameter("@GVID", GVID);
            SqlParameter pNgayHopDong = new SqlParameter("@NgayHopDong", NgayHopDong);
            SqlParameter pThoiHan = new SqlParameter("@ThoiHan", ThoiHan);
            SqlParameter pTinhTrangHD = new SqlParameter("@TinhTrangHD", TinhTrangHD);
            this.DB.Updatedata(sql, pGVID, pNgayHopDong, pThoiHan, pTinhTrangHD);
            this.DB.CloseConnection();
            return true;
        }
        //Delete
        public Boolean Delete_kus_GVHopDong(int GVID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "delete from kus_HopDongGV where GVID=@GVID";
            SqlParameter pGVID = new SqlParameter("@GVID", GVID);
            this.DB.Updatedata(sql, pGVID);
            this.DB.CloseConnection();
            return true;
        }
    }
}
