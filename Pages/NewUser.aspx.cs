using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BLL;

public partial class Pages_NewUser : BasePage
{
    UserAccountsBLL useraccount;
    UserProfileBLL userprofile;
    EmployeesBLL employees;
    DepartmentsBLL departments;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            UserAccounts ac = Session.GetCurrentUser();
            if (ac == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Login.aspx");
            }
            else
            {
                if (!check_permiss(ac.UserID, FunctionName.NewUser))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlDepartments();
                }
            }
        }
    }

    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {
        useraccount = new UserAccountsBLL();
        List<UserAccounts> lst = useraccount.getAllUserAccountUsername(txtUsername.Text);
        UserAccounts uc = lst.FirstOrDefault();
        if (uc != null)
        {
            lblcheckusername.Text = "Tên đăng nhập đã được sử dụng !";
        }
        else
        {
            lblcheckusername.Text = "";
        }
    }
    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        useraccount = new UserAccountsBLL();
        List<UserAccounts> lst = useraccount.getAllUserAccountEmail(txtEmail.Text);
        UserAccounts uc = lst.FirstOrDefault();
        if (uc != null)
        {
            lblCheckEmail.Text = "Email đã được sử dụng !";
        }
        else
        {
            lblCheckEmail.Text = "";
        }
    }
    private void load_dlDepartments()
    {
        departments = new DepartmentsBLL();
        dlDepartments.DataSource = departments.getAllDepartment();
        dlDepartments.DataTextField = "DepartmentName";
        dlDepartments.DataValueField = "DepartmentsID";
        dlDepartments.DataBind();
        dlDepartments.Items.Insert(0, new ListItem("-- Chọn Phòng Ban --", "0"));
    }
    public static string CreateSHAHash(string Password, string Salt)
    {
        System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
        Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Password, Salt));
        Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
        HashTool.Clear();
        return Convert.ToBase64String(EncryptedBytes);
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        try
        {
            bool result = HasPermission(Session.GetCurrentUser().UserID, FunctionName.NewUser, TypeAudit.AddNew);
            if (result == false)
            {
                lblPageValid.Text = "Bạn không có quyền thực hiện chức năng này !";
            }
            else
            {
                useraccount = new UserAccountsBLL();
                userprofile = new UserProfileBLL();
                employees = new EmployeesBLL();
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string Fname = txtFirstname.Text;
                string Lname = txtLastname.Text;
                int Dep = Convert.ToInt32(dlDepartments.SelectedValue);
                string passwords = txtPrePassword.Text;

                bool bol1 = this.useraccount.NewAccount(username, email, CreateSHAHash(passwords, SaltPassword()));
                bool bol2 = this.userprofile.CreateUserProfile(useraccount.GetUIDWithName(username), Fname, Lname, 1);
                bool bol3 = this.employees.createEmployee(userprofile.getProfileID(useraccount.GetUIDWithName(username)), Dep);

                if (bol1 || bol2 || bol3)
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Pages/Users.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Thêm người dùng thất bại. Lỗi kết nối CSDL !')</script>");
                }
            }
        }
        catch(Exception ex)
        {
            lblPageValid.Text = ex.ToString();
        }
    }
}