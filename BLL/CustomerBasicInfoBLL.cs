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
                c.InfoID = (int)r["InfoID"];
                c.FirstName = (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : (string)r["FirstName"];
                c.LastName = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
                c.OtherName = (string.IsNullOrEmpty(r["OtherName"].ToString())) ? "" : (string)r["OtherName"];
                c.Birthday = (string.IsNullOrEmpty(r["Birthday"].ToString())) ? DefaultBirthday : (DateTime)r["Birthday"];
                c.BirthPlace = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                c.Sex = (string.IsNullOrEmpty(r["BirthPlace"].ToString())) ? 0 : (int)r["BirthPlace"];
                c.IdentityCard = (string.IsNullOrEmpty(r["IdentityCard"].ToString())) ? "" : (string)r["IdentityCard"];
                c.DateOfIdentityCard= (string.IsNullOrEmpty(r["DateOfIdentityCard"].ToString())) ? DefaultBirthday : (DateTime)r["DateOfIdentityCard"];
                c.PlaceOfIdentityCard= (string.IsNullOrEmpty(r["PlaceOfIdentityCard"].ToString())) ? "" : (string)r["PlaceOfIdentityCard"];
                c.BasicInfoCode= (string)r["BasicInfoCode"];
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
                c.InfoID = (int)r["InfoID"];
                c.FirstName = (string.IsNullOrEmpty(r["FirstName"].ToString())) ? "" : (string)r["FirstName"];
                c.LastName = (string.IsNullOrEmpty(r["LastName"].ToString())) ? "" : (string)r["LastName"];
                c.OtherName = (string.IsNullOrEmpty(r["OtherName"].ToString())) ? "" : (string)r["OtherName"];
                c.Birthday = (string.IsNullOrEmpty(r["Birthday"].ToString())) ? DefaultBirthday : (DateTime)r["Birthday"];
                c.BirthPlace = (string.IsNullOrEmpty(r[5].ToString())) ? "" : (string)r[5];
                c.Sex = (string.IsNullOrEmpty(r["BirthPlace"].ToString())) ? 0 : (int)r["BirthPlace"];
                c.IdentityCard = (string.IsNullOrEmpty(r["IdentityCard"].ToString())) ? "" : (string)r["IdentityCard"];
                c.DateOfIdentityCard = (string.IsNullOrEmpty(r["DateOfIdentityCard"].ToString())) ? DefaultBirthday : (DateTime)r["DateOfIdentityCard"];
                c.PlaceOfIdentityCard = (string.IsNullOrEmpty(r["PlaceOfIdentityCard"].ToString())) ? "" : (string)r["PlaceOfIdentityCard"];
                c.BasicInfoCode = (string)r["BasicInfoCode"];
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
