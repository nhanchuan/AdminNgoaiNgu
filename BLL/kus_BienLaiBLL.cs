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
    public class kus_BienLaiBLL
    {
        DataServices DB = new DataServices();
        public List<kus_BienLai> getListBienLaiWithCode(string BLcode)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_BienLai where BienLaiCode=@BienLaiCode";
            SqlParameter pBLcode = new SqlParameter("@BienLaiCode", BLcode);
            DataTable tb = DB.DAtable(sql, pBLcode);
            List<kus_BienLai> lst = new List<kus_BienLai>();
            foreach(DataRow r in tb.Rows)
            {
                kus_BienLai bl = new kus_BienLai();
                bl.BienLaiID = (int)r[0];
                bl.BienLaiCode = (string)r[1];
                bl.LyDoThu = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bl.MienGiam = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                bl.SoTien = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                bl.SoTienBangChu = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                bl.DateOfCreate = (DateTime)r[6];
                bl.GhiDanhID = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(bl);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_BienLai> getListBienLaiWithID(int GhiDanhID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_BienLai where GhiDanhID=@GhiDanhID";
            SqlParameter pGhiDanhID = new SqlParameter("@GhiDanhID", GhiDanhID);
            DataTable tb = DB.DAtable(sql, pGhiDanhID);
            List<kus_BienLai> lst = new List<kus_BienLai>();
            foreach (DataRow r in tb.Rows)
            {
                kus_BienLai bl = new kus_BienLai();
                bl.BienLaiID = (int)r[0];
                bl.BienLaiCode = (string)r[1];
                bl.LyDoThu = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                bl.MienGiam = (string.IsNullOrEmpty(r[3].ToString())) ? 0 : (int)r[3];
                bl.SoTien = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
                bl.SoTienBangChu = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                bl.DateOfCreate = (DateTime)r[6];
                bl.GhiDanhID = (string.IsNullOrEmpty(r[7].ToString())) ? 0 : (int)r[7];
                lst.Add(bl);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public DataTable kus_getBienLaiInfor(string BienLaiCode)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_getBienLaiInfor @BienLaiCode";
            SqlParameter pBienLaiCode = new SqlParameter("@BienLaiCode", BienLaiCode);
            DataTable tb = DB.DAtable(sql, pBienLaiCode);
            this.DB.CloseConnection();
            return tb;
        }

        public Boolean CreateBienLai(string LyDoThu, int MienGiam, int SoTien, string SoTienBangChu, int GhiDanhID)
        {
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_TaoBienLai @LyDoThu,@MienGiam,@SoTien,@SoTienBangChu,@GhiDanhID";
            SqlParameter pLyDoThu = (LyDoThu == "") ? new SqlParameter("LyDoThu", DBNull.Value) : new SqlParameter("LyDoThu", LyDoThu);
            SqlParameter pMienGiam = (MienGiam <= 0) ? new SqlParameter("MienGiam", DBNull.Value) : new SqlParameter("MienGiam", MienGiam);
            SqlParameter pSoTien = (SoTien <= 0) ? new SqlParameter("SoTien", DBNull.Value) : new SqlParameter("SoTien", SoTien);
            SqlParameter pSoTienBangChu = (SoTienBangChu == "") ? new SqlParameter("SoTienBangChu", DBNull.Value) : new SqlParameter("SoTienBangChu", SoTienBangChu);
            SqlParameter pGhiDanhID = new SqlParameter("GhiDanhID", GhiDanhID);
            this.DB.Updatedata(sql, pLyDoThu, pMienGiam, pSoTien, pSoTienBangChu, pGhiDanhID);
            this.DB.CloseConnection();
            return true;
        }

    }
}
