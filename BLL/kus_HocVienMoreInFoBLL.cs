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
    public class kus_HocVienMoreInFoBLL
    {
        DataServices DB = new DataServices();
        public Boolean kus_NewHocVienMoreInFo(int HocVienID, string HVGioiThieu, string TrinhDoHocVan, string TenTruong, string CCTiengAnh, string BietThongTin)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_NewHocVienMoreInFo @HocVienID,@HVGioiThieu,@TrinhDoHocVan,@TenTruong,@CCTiengAnh,@BietThongTin";
            SqlParameter pHocVienID = new SqlParameter("HocVienID", HocVienID);
            SqlParameter pHVGioiThieu = new SqlParameter("HVGioiThieu", HVGioiThieu);
            SqlParameter pTrinhDoHocVan = new SqlParameter("TrinhDoHocVan", TrinhDoHocVan);
            SqlParameter pTenTruong = new SqlParameter("TenTruong", TenTruong);
            SqlParameter pCCTiengAnh = new SqlParameter("CCTiengAnh", CCTiengAnh);
            SqlParameter pBietThongTin = new SqlParameter("BietThongTin", BietThongTin);
            this.DB.Updatedata(sql, pHocVienID, pHVGioiThieu, pTrinhDoHocVan, pTenTruong, pCCTiengAnh, pBietThongTin);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean kus_UpdateNewHocVienMoreInFo(int HocVienID, string HVGioiThieu, string TrinhDoHocVan, string TenTruong, string CCTiengAnh, string BietThongTin)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_UpdateNewHocVienMoreInFo @HocVienID,@HVGioiThieu,@TrinhDoHocVan,@TenTruong,@CCTiengAnh,@BietThongTin";
            SqlParameter pHocVienID = new SqlParameter("HocVienID", HocVienID);
            SqlParameter pHVGioiThieu = new SqlParameter("HVGioiThieu", HVGioiThieu);
            SqlParameter pTrinhDoHocVan = new SqlParameter("TrinhDoHocVan", TrinhDoHocVan);
            SqlParameter pTenTruong = new SqlParameter("TenTruong", TenTruong);
            SqlParameter pCCTiengAnh = new SqlParameter("CCTiengAnh", CCTiengAnh);
            SqlParameter pBietThongTin = new SqlParameter("BietThongTin", BietThongTin);
            this.DB.Updatedata(sql, pHocVienID, pHVGioiThieu, pTrinhDoHocVan, pTenTruong, pCCTiengAnh, pBietThongTin);
            this.DB.CloseConnection();
            return true;
        }
    }
}
