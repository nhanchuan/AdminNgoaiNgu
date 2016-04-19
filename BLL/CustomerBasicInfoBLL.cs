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
    public class CustomerBasicInfoBLL
    {
        DataServices DB = new DataServices();
        DateTime DefaultBirthday = Convert.ToDateTime("12/12/1900");
        public List<CustomerBasicInfo> GetCusBasicInfoWithCode(string code)
        {
            string sql = "select * from CustomerBasicInfo where BasicInfoCode=@code";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pCode = new SqlParameter("code", code);
            DataTable tb = DB.DAtable(sql, pCode);
            List<CustomerBasicInfo> lst = new List<CustomerBasicInfo>();
            foreach(DataRow r in tb.Rows)
            {
                CustomerBasicInfo c = new CustomerBasicInfo();
                c.InfoID = (int)r[0];
                c.FirstName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                c.LastName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                c.OtherName = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                c.Birthday = (string.IsNullOrEmpty(r[4].ToString())) ? DefaultBirthday : (DateTime)r[4];
                c.BirthPlace = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                c.Sex = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                c.IdentityCard = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                c.DateOfIdentityCard= (string.IsNullOrEmpty(r[8].ToString())) ? DefaultBirthday : (DateTime)r[8];
                c.PlaceOfIdentityCard= (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                c.BasicInfoCode= (string)r[10];
                lst.Add(c);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public List<CustomerBasicInfo> GetCusBasicInfoWithInfoId(int inforId)
        {
            string sql = "select * from CustomerBasicInfo where InfoID=@inforId";
            if (!this.DB.OpenConnection())
            {
                return null;
            }
            SqlParameter pinforId = new SqlParameter("inforId", inforId);
            DataTable tb = DB.DAtable(sql, pinforId);
            List<CustomerBasicInfo> lst = new List<CustomerBasicInfo>();
            foreach (DataRow r in tb.Rows)
            {
                CustomerBasicInfo c = new CustomerBasicInfo();
                c.InfoID = (int)r[0];
                c.FirstName = (string.IsNullOrEmpty(r[1].ToString())) ? "" : (string)r[1];
                c.LastName = (string.IsNullOrEmpty(r[2].ToString())) ? "" : (string)r[2];
                c.OtherName = (string.IsNullOrEmpty(r[3].ToString())) ? "" : (string)r[3];
                c.Birthday = (string.IsNullOrEmpty(r[4].ToString())) ? DefaultBirthday : (DateTime)r[4];
                c.BirthPlace = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                c.Sex = (string.IsNullOrEmpty(r[6].ToString())) ? 0 : (int)r[6];
                c.IdentityCard = (string.IsNullOrEmpty(r[7].ToString())) ? "" : (string)r[7];
                c.DateOfIdentityCard = (string.IsNullOrEmpty(r[8].ToString())) ? DefaultBirthday : (DateTime)r[8];
                c.PlaceOfIdentityCard = (string.IsNullOrEmpty(r[9].ToString())) ? "" : (string)r[9];
                c.BasicInfoCode = (string)r[10];
                lst.Add(c);
            }
            this.DB.CloseConnection();
            return lst;
        }
        public Boolean CreateBasicCodeInfo(string code)
        {
            string sql = "insert into CustomerBasicInfo(BasicInfoCode) values(@code)";
            if(!this.DB.OpenConnection())
            {
                return false;
            }
            SqlParameter pCode = new SqlParameter("code", code);
            this.DB.Updatedata(sql, pCode);
            this.DB.CloseConnection();
            return true;
        }
        public Boolean UpdateCustomerBasicInfo(int InfoID, string FirstName, string LastName, string OtherName, DateTime Birthday, string BirthPlace, int sex, string IdentityCard, DateTime DateOfIdentityCard, string PlaceOfIdentityCard)
        {
            string sql = "Exec UpdateCustomerBasicInfo @InfoID,@FirstName,@LastName,@OtherName,@Birthday,@BirthPlace,@sex,@IdentityCard,@DateOfIdentityCard,@PlaceOfIdentityCard";
            if (!this.DB.OpenConnection())
            {
                return false;
            }
            int Birthyear = Birthday.Year;
            int DOCyear = DateOfIdentityCard.Year;
            SqlParameter pInfoID = new SqlParameter("InfoID", InfoID);
            SqlParameter pFirstName = new SqlParameter("FirstName", FirstName);
            SqlParameter pLastName = new SqlParameter("LastName", LastName);
            SqlParameter pOtherName = new SqlParameter("OtherName", OtherName);
            SqlParameter pBirthday = (Birthyear <= 1900) ? new SqlParameter("Birthday", DBNull.Value) : new SqlParameter("Birthday", Birthday);
            SqlParameter pBirthPlace = new SqlParameter("BirthPlace", BirthPlace);
            SqlParameter psex =(sex==0)? new SqlParameter("sex", DBNull.Value): new SqlParameter("sex", sex);
            SqlParameter pIdentityCard = new SqlParameter("IdentityCard", IdentityCard);
            SqlParameter pDateOfIdentityCard = (DOCyear <= 1900) ? new SqlParameter("DateOfIdentityCard", DBNull.Value) : new SqlParameter("DateOfIdentityCard", DateOfIdentityCard);
            SqlParameter pPlaceOfIdentityCard = new SqlParameter("PlaceOfIdentityCard", PlaceOfIdentityCard);
            this.DB.Updatedata(sql, pInfoID, pFirstName, pLastName, pOtherName, pBirthday, pBirthPlace, psex, pIdentityCard, pDateOfIdentityCard, pPlaceOfIdentityCard);
            return true;
        }
    }
}
