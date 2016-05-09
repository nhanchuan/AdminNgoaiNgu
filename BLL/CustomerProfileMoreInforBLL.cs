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
    public class CustomerProfileMoreInforBLL
    {
        DataServices dt = new DataServices();
        public List<CustomerProfileMoreInfor> GetListWithInfoID(int InfoID)
        {
            if (!this.dt.OpenConnection())
            {
                return null;
            }
            string sql = "select * from CustomerProfileMoreInfor where InfoID=@InfoID";
            SqlParameter pInfoID = new SqlParameter("@InfoID", InfoID);
            DataTable tb = dt.DAtable(sql, pInfoID);
            List<CustomerProfileMoreInfor> lst = new List<CustomerProfileMoreInfor>();
            foreach(DataRow r in tb.Rows)
            {
                CustomerProfileMoreInfor cm = new CustomerProfileMoreInfor();
                cm.MoreInforID = (int)r["MoreInforID"];
                cm.InfoID = (int)r["InfoID"];
                cm.HVGioiThieu = (string.IsNullOrEmpty(r["HVGioiThieu"].ToString())) ? "" : (string)r["HVGioiThieu"];
                cm.TrinhDoHocVan = (string.IsNullOrEmpty(r["TrinhDoHocVan"].ToString())) ? "" : (string)r["TrinhDoHocVan"];
                cm.TenTruong= (string.IsNullOrEmpty(r["TenTruong"].ToString())) ? "" : (string)r["TenTruong"];
                cm.CCTiengAnh= (string.IsNullOrEmpty(r["CCTiengAnh"].ToString())) ? "" : (string)r["CCTiengAnh"];
                cm.BietThongTin= (string.IsNullOrEmpty(r["BietThongTin"].ToString())) ? "" : (string)r["BietThongTin"];
                cm.GhiChu= (string.IsNullOrEmpty(r["GhiChu"].ToString())) ? "" : (string)r["GhiChu"];
                lst.Add(cm);
            }
            this.dt.CloseConnection();
            return lst;
        }
        //New CustomerProfileMoreInfor
        public Boolean NewCustomerProfileMoreInfor(int InfoID, string HVGioiThieu, string TrinhDoHocVan, string TenTruong, string CCTiengAnh, string BietThongTin, string GhiChu)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "insert into CustomerProfileMoreInfor(InfoID,HVGioiThieu,TrinhDoHocVan,TenTruong,CCTiengAnh,BietThongTin,GhiChu)";
            sql += " ";
            sql += "values (@InfoID,@HVGioiThieu,@TrinhDoHocVan,@TenTruong,@CCTiengAnh,@BietThongTin,@GhiChu)";
            SqlParameter pInfoID = new SqlParameter("@InfoID", InfoID);
            SqlParameter pHVGioiThieu = (HVGioiThieu == "") ? new SqlParameter("@HVGioiThieu", DBNull.Value) : new SqlParameter("@HVGioiThieu", HVGioiThieu);
            SqlParameter pTrinhDoHocVan = (TrinhDoHocVan == "") ? new SqlParameter("@TrinhDoHocVan", DBNull.Value) : new SqlParameter("@TrinhDoHocVan", TrinhDoHocVan);
            SqlParameter pTenTruong = (TenTruong == "") ? new SqlParameter("@TenTruong", DBNull.Value) : new SqlParameter("@TenTruong", TenTruong);
            SqlParameter pCCTiengAnh = (CCTiengAnh == "") ? new SqlParameter("@CCTiengAnh", DBNull.Value) : new SqlParameter("@CCTiengAnh", CCTiengAnh);
            SqlParameter pBietThongTin = (BietThongTin == "") ? new SqlParameter("@BietThongTin", DBNull.Value) : new SqlParameter("@BietThongTin", BietThongTin);
            SqlParameter pGhiChu = (GhiChu == "") ? new SqlParameter("@GhiChu", DBNull.Value) : new SqlParameter("@GhiChu", GhiChu);
            this.dt.Updatedata(sql, pInfoID, pHVGioiThieu, pTrinhDoHocVan, pTenTruong, pCCTiengAnh, pBietThongTin, pGhiChu);
            this.dt.CloseConnection();
            return true;
        }
        //Update 
        public Boolean UpdateCustomerProfileMoreInfor(int InfoID, string HVGioiThieu, string TrinhDoHocVan, string TenTruong, string CCTiengAnh, string BietThongTin, string GhiChu)
        {
            if (!this.dt.OpenConnection())
            {
                return false;
            }
            string sql = "update CustomerProfileMoreInfor set HVGioiThieu=@HVGioiThieu,TrinhDoHocVan=@TrinhDoHocVan,TenTruong=@TenTruong,CCTiengAnh=@CCTiengAnh,BietThongTin=@BietThongTin,GhiChu=@GhiChu where InfoID=@InfoID";
            SqlParameter pInfoID = new SqlParameter("@InfoID", InfoID);
            SqlParameter pHVGioiThieu = (HVGioiThieu == "") ? new SqlParameter("@HVGioiThieu", DBNull.Value) : new SqlParameter("@HVGioiThieu", HVGioiThieu);
            SqlParameter pTrinhDoHocVan = (TrinhDoHocVan == "") ? new SqlParameter("@TrinhDoHocVan", DBNull.Value) : new SqlParameter("@TrinhDoHocVan", TrinhDoHocVan);
            SqlParameter pTenTruong = (TenTruong == "") ? new SqlParameter("@TenTruong", DBNull.Value) : new SqlParameter("@TenTruong", TenTruong);
            SqlParameter pCCTiengAnh = (CCTiengAnh == "") ? new SqlParameter("@CCTiengAnh", DBNull.Value) : new SqlParameter("@CCTiengAnh", CCTiengAnh);
            SqlParameter pBietThongTin = (BietThongTin == "") ? new SqlParameter("@BietThongTin", DBNull.Value) : new SqlParameter("@BietThongTin", BietThongTin);
            SqlParameter pGhiChu = (GhiChu == "") ? new SqlParameter("@GhiChu", DBNull.Value) : new SqlParameter("@GhiChu", GhiChu);
            this.dt.Updatedata(sql, pInfoID, pHVGioiThieu, pTrinhDoHocVan, pTenTruong, pCCTiengAnh, pBietThongTin, pGhiChu);
            this.dt.CloseConnection();
            return true;
        }

    }
}
