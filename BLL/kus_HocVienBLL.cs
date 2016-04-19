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
    public class kus_HocVienBLL
    {
        DataServices DB = new DataServices();
        public DataTable getTBAllHocVien()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HocVien";
            DataTable tb = DB.DAtable(sql);
            this.DB.CloseConnection();
            return tb;
        }
        public List<kus_HocVien> getAllHocVien()
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HocVien";
            DataTable tb = DB.DAtable(sql);
            List<kus_HocVien> lst = new List<kus_HocVien>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HocVien hv = new kus_HocVien();
                hv.HocVienID = (int)r[0];
                hv.HocVienCode = (string)r[1];
                hv.InfoID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                hv.DCThuongTru = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                hv.DCTamTru = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                hv.Email = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                hv.DienThoai = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
                hv.HoTenPH = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                hv.NgheNghiep = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                hv.PhonePhuHuynh = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                hv.HocVienStatus = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                hv.DateOfCreate = (DateTime)r[11];
                hv.RandomCode = (string)r[12];
                hv.ImgID = (string.IsNullOrEmpty(r[13].ToString())) ? 0 : (int)r[13];
                lst.Add(hv);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_HocVien> getHocVienWithID(int HocVienID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HocVien where HocVienID=@HocVienID";
            SqlParameter pHocVienID = new SqlParameter("HocVienID", HocVienID);
            DataTable tb = DB.DAtable(sql, pHocVienID);
            List<kus_HocVien> lst = new List<kus_HocVien>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HocVien hv = new kus_HocVien();
                hv.HocVienID = (int)r[0];
                hv.HocVienCode = (string)r[1];
                hv.InfoID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                hv.DCThuongTru = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                hv.DCTamTru = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                hv.Email = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                hv.DienThoai = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
                hv.HoTenPH = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                hv.NgheNghiep = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                hv.PhonePhuHuynh = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                hv.HocVienStatus = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                hv.DateOfCreate = (DateTime)r[11];
                hv.RandomCode = (string)r[12];
                hv.ImgID = (string.IsNullOrEmpty(r[13].ToString())) ? 0 : (int)r[13];
                lst.Add(hv);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_HocVien> getHocVienWithMaHV(string HocVienCode)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HocVien where HocVienCode=@HocVienCode";
            SqlParameter pHocVienCode = new SqlParameter("HocVienCode", HocVienCode);
            DataTable tb = DB.DAtable(sql, pHocVienCode);
            List<kus_HocVien> lst = new List<kus_HocVien>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HocVien hv = new kus_HocVien();
                hv.HocVienID = (int)r[0];
                hv.HocVienCode = (string)r[1];
                hv.InfoID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                hv.DCThuongTru = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                hv.DCTamTru = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                hv.Email = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                hv.DienThoai = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
                hv.HoTenPH = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                hv.NgheNghiep = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                hv.PhonePhuHuynh = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                hv.HocVienStatus = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                hv.DateOfCreate = (DateTime)r[11];
                hv.RandomCode = (string)r[12];
                hv.ImgID = (string.IsNullOrEmpty(r[13].ToString())) ? 0 : (int)r[13];
                lst.Add(hv);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_HocVien> getAllHocVienAutoComplete(string pretext)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HocVien where HocVienCode like @pretext+'%'";
            SqlParameter ppretext = new SqlParameter("@pretext", pretext);
            DataTable tb = DB.DAtable(sql);
            List<kus_HocVien> lst = new List<kus_HocVien>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HocVien hv = new kus_HocVien();
                hv.HocVienID = (int)r[0];
                hv.HocVienCode = (string)r[1];
                hv.InfoID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                hv.DCThuongTru = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                hv.DCTamTru = (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                hv.Email = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                hv.DienThoai = (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
                hv.HoTenPH = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                hv.NgheNghiep = (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                hv.PhonePhuHuynh = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                hv.HocVienStatus = (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                hv.DateOfCreate = (DateTime)r[11];
                hv.RandomCode = (string)r[12];
                hv.ImgID = (string.IsNullOrEmpty(r[13].ToString())) ? 0 : (int)r[13];
                lst.Add(hv);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<kus_HocVien> getHVWithCode(string code)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "select * from kus_HocVien where RandomCode=@code";
            SqlParameter pcode = new SqlParameter("@code", code);
            DataTable tb = DB.DAtable(sql, pcode);
            List<kus_HocVien> lst = new List<kus_HocVien>();
            foreach (DataRow r in tb.Rows)
            {
                kus_HocVien hv = new kus_HocVien();
                hv.HocVienID = (int)r[0];
                hv.HocVienCode = (string)r[1];
                hv.InfoID = (string.IsNullOrEmpty(r[2].ToString())) ? 0 : (int)r[2];
                hv.DCThuongTru = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                hv.DCTamTru= (string.IsNullOrEmpty(r[4].ToString())) ? "" : (string)r[4];
                hv.Email= (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                hv.DienThoai= (string.IsNullOrEmpty(r[6].ToString())) ? "" : (string)r[6];
                hv.HoTenPH= (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                hv.NgheNghiep= (string.IsNullOrEmpty(r[8].ToString())) ? "" : (string)r[8];
                hv.PhonePhuHuynh= (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                hv.HocVienStatus= (string.IsNullOrEmpty(r[10].ToString())) ? 0 : (int)r[10];
                hv.DateOfCreate = (DateTime)r[11];
                hv.RandomCode = (string)r[12];
                hv.ImgID = (string.IsNullOrEmpty(r[13].ToString())) ? 0 : (int)r[13];
                lst.Add(hv);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean CreateCodeHocVien(string code)
        {
            string sql = "insert into kus_HocVien(RandomCode) values(@code)";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pCode = new SqlParameter("code", code);
            this.DB.Updatedata(sql, pCode);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean kus_UpdateHocVen(int HocVienID, int InfoID, string DCThuongTru, string DCTamTru, string Email, string DienThoai, string HoTenPH, string NgheNghiep, string PhonePhuHuynh, int HocVienStatus)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "Exec kus_UpdateHocVen @HocVienID, @InfoID,@DCThuongTru,@DCTamTru,@Email,@DienThoai,@HoTenPH,@NgheNghiep,@PhonePhuHuynh,@HocVienStatus";
            SqlParameter pHocVienID = new SqlParameter("HocVienID", HocVienID);
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter pDCThuongTru = new SqlParameter("DCThuongTru", DCThuongTru);
            SqlParameter pDCTamTru = new SqlParameter("DCTamTru", DCTamTru);
            SqlParameter pEmail = new SqlParameter("Email", Email);
            SqlParameter pDienThoai = new SqlParameter("DienThoai", DienThoai);
            SqlParameter pHoTenPH = new SqlParameter("HoTenPH", HoTenPH);
            SqlParameter pNgheNghiep = new SqlParameter("NgheNghiep", NgheNghiep);
            SqlParameter pPhonePhuHuynh = new SqlParameter("PhonePhuHuynh", PhonePhuHuynh);
            SqlParameter pHocVienStatus = new SqlParameter("HocVienStatus", HocVienStatus);
            this.DB.Updatedata(sql, pHocVienID, pInfoID, pDCThuongTru, pDCTamTru, pEmail, pDienThoai, pHoTenPH, pNgheNghiep, pPhonePhuHuynh, pHocVienStatus);
            this.DB.CloseConnection();
            return true;
        }
        //========APDATE HOC VIEN IMAGES======================================================================================================
        public Boolean UpdateHocVienImage(int HocVienID, int ImgID)
        {
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            string sql = "update kus_HocVien set ImgID=@ImgID where HocVienID=@HocVienID";
            SqlParameter pImgID = new SqlParameter("@ImgID", ImgID);
            SqlParameter pHocVienID = new SqlParameter("@HocVienID", HocVienID);
            this.DB.Updatedata(sql, pImgID, pHocVienID);
            this.DB.CloseConnection();
            return true;
        }
        //=============GET HOC VIEN TO EXPROT to Excel=======================================================================================================================
        public DataTable ExprotHVtoExcel(int LopHocID)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec ExprotHVtoExcel @LopHocID";
            SqlParameter pLopHocID = new SqlParameter("@LopHocID", LopHocID);
            DataTable tb = DB.DAtable(sql, pLopHocID);
            this.DB.CloseConnection();
            return tb;
        }
        //============kus_HocVienInfor========================================================================================================================================
        public DataTable kus_HocVienInfor(string HocVienCode)
        {
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            string sql = "Exec kus_HocVienInfor @HocVienCode";
            SqlParameter pHocVienCode = new SqlParameter("@HocVienCode", HocVienCode);
            DataTable tb = DB.DAtable(sql, pHocVienCode);
            this.DB.CloseConnection();
            return tb;
        }
    }
}
