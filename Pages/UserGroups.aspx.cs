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

public partial class Pages_UserGroups : BasePage
{
    DepartmentsBLL departments;
    PermissFuncBLL permissfunction;
    EmployeesBLL employees;
    AuthenticationGroupsBLL authenticationgroup;
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
                if (!check_permiss(ac.UserID, FunctionName.UserGroups))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gwListDepartments();
                    this.load_dlManager();
                    btnAuthentication.Visible = false;
                    this.load_CheckLst();
                }
            }
        }
    }
    private void load_dlManager()
    {
        employees = new EmployeesBLL();
        dlManager.DataSource = employees.GetAllEmployeesDL();
        dlManager.DataTextField = "GVName";
        dlManager.DataValueField = "EmployeesID";
        dlManager.DataBind();
        dlManager.Items.Insert(0, new ListItem("-- Chọn thành viên --", "0"));
    }
    private void load_gwListDepartments()
    {
        departments = new DepartmentsBLL();
        gwListDepartments.DataSource = departments.getListDepartment();
        gwListDepartments.DataBind();
    }
    
    protected void gwListDepartments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwListDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Response.Write("<script>alert('This function is in the process of building!')</script>");
    }

    protected void btnAddGroup_Click(object sender, EventArgs e)
    {
        departments = new DepartmentsBLL();
        if(departments.NewDepartment(txtDepGroup.Text,Convert.ToInt32(dlManager.SelectedValue)))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Nhóm thất bại. Lỗi kết nối CSDL !')</script>");
        }
    }
    
    protected void gwListDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAuthentication.Visible = true;
        this.ClearSelection();
        int depID = Convert.ToInt32((gwListDepartments.SelectedRow.FindControl("lblDepartmentsID") as Label).Text);
        this.load_checkedCHK(chlSystem, depID);
        this.load_checkedCHK(chlUsermanager, depID);
        this.load_checkedCHK(chlFileManager, depID);
        this.load_checkedCHK(chlmedia, depID);
        this.load_checkedCHK(chlFile, depID);
        this.load_checkedCHK(chlCenter, depID);
        this.load_checkedCHK(chlAdv, depID);
        this.load_checkedCHK(chlWeb, depID);

        this.checkSelectedAll(chlSystemall, chlSystem, depID);
        this.checkSelectedAll(chlUsermanagerall, chlUsermanager, depID);
        this.checkSelectedAll(chlFileManagerall, chlFileManager, depID);
        this.checkSelectedAll(chlmediaall, chlmedia, depID);
        this.checkSelectedAll(chlFileall, chlFile, depID);
        this.checkSelectedAll(chlCenterall, chlCenter, depID);
        this.checkSelectedAll(chlAdvall, chlAdv, depID);
        this.checkSelectedAll(chlWeball, chlWeb, depID);
    }

    #region CheckBoxList
    private void ClearSelection()
    {
        chlSystemall.Checked = false;
        chlSystem.ClearSelection();
        chlUsermanagerall.Checked = false;
        chlUsermanager.ClearSelection();
        chlFileManagerall.Checked = false;
        chlFileManager.ClearSelection();
        chlmediaall.Checked = false;
        chlmedia.ClearSelection();
        chlFileall.Checked = false;
        chlFile.ClearSelection();
        chlCenterall.Checked = false;
        chlCenter.ClearSelection();
        chlAdvall.Checked = false;
        chlAdv.ClearSelection();
        chlWeball.Checked = false;
        chlWeb.ClearSelection();
    }
    private void load_chlSystem(int FGroupID, CheckBoxList chkl)
    {
        permissfunction = new PermissFuncBLL();
        chkl.DataSource = permissfunction.getListFGPermissFunc(FGroupID);
        chkl.DataTextField = "FunctionName";
        chkl.DataValueField = "PermissFuncID";
        chkl.DataBind();
    }
    private void load_CheckLst()
    {
        this.load_chlSystem(1, chlSystem);
        this.load_chlSystem(2, chlUsermanager);
        this.load_chlSystem(3, chlFileManager);
        this.load_chlSystem(4, chlmedia);
        this.load_chlSystem(5, chlFile);
        this.load_chlSystem(6, chlCenter);
        this.load_chlSystem(7, chlAdv);
        this.load_chlSystem(8, chlWeb);
    }
    protected void chlSystemall_CheckedChanged(object sender, EventArgs e)
    {
        if (chlSystemall.Checked)
        {
            foreach (ListItem l in chlSystem.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlSystem.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlchlSystem()
    {
        foreach (ListItem l in chlSystem.Items)
        {
            if (l.Selected == false)
            {
                chlSystemall.Checked = false;
                return;
            }
        }
    }
    protected void chlUsermanagerall_CheckedChanged(object sender, EventArgs e)
    {
        if(chlUsermanagerall.Checked)
        {
            foreach(ListItem l in chlUsermanager.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlUsermanager.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlUsermanager()
    {
        foreach (ListItem l in chlUsermanager.Items)
        {
           if(l.Selected==false)
            {
                chlUsermanagerall.Checked = false;
                return;
            }
        }
    }
    protected void chlFileManagerall_CheckedChanged(object sender, EventArgs e)
    {
        if (chlFileManagerall.Checked)
        {
            foreach (ListItem l in chlFileManager.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlFileManager.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlFileManager()
    {
        foreach (ListItem l in chlFileManager.Items)
        {
            if (l.Selected == false)
            {
                chlFileManagerall.Checked = false;
                return;
            }
        }
    }
    protected void chlmediaall_CheckedChanged(object sender, EventArgs e)
    {
        if (chlmediaall.Checked)
        {
            foreach (ListItem l in chlmedia.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlmedia.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlmedia()
    {
        foreach (ListItem l in chlmedia.Items)
        {
            if (l.Selected == false)
            {
                chlmediaall.Checked = false;
                return;
            }
        }
    }
    protected void chlFileall_CheckedChanged(object sender, EventArgs e)
    {
        if (chlFileall.Checked)
        {
            foreach (ListItem l in chlFile.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlFile.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlFile()
    {
        foreach (ListItem l in chlFile.Items)
        {
            if (l.Selected == false)
            {
                chlFileall.Checked = false;
                return;
            }
        }
    }
    protected void chlCenterall_CheckedChanged(object sender, EventArgs e)
    {
        if (chlCenterall.Checked)
        {
            foreach (ListItem l in chlCenter.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlCenter.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlCenter()
    {
        foreach (ListItem l in chlCenter.Items)
        {
            if (l.Selected == false)
            {
                chlCenterall.Checked = false;
                return;
            }
        }
    }
    protected void chlAdvall_CheckedChanged(object sender, EventArgs e)
    {
        if (chlAdvall.Checked)
        {
            foreach (ListItem l in chlAdv.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlAdv.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlAdv()
    {
        foreach (ListItem l in chlAdv.Items)
        {
            if (l.Selected == false)
            {
                chlAdvall.Checked = false;
                return;
            }
        }
    }
    protected void chlWeball_CheckedChanged(object sender, EventArgs e)
    {
        if (chlWeball.Checked)
        {
            foreach (ListItem l in chlWeb.Items)
            {
                l.Selected = true;
            }
        }
        else
        {
            foreach (ListItem l in chlWeb.Items)
            {
                l.Selected = false;
            }
        }
    }
    private void checkchlWeb()
    {
        foreach (ListItem l in chlWeb.Items)
        {
            if (l.Selected == false)
            {
                chlWeball.Checked = false;
                return;
            }
        }
    }
    protected void chlUsermanager_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlUsermanager();
    }
    protected void chlSystem_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlchlSystem();
    }
    protected void chlFileManager_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlFileManager();
    }
    protected void chlmedia_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlmedia();
    }
    protected void chlFile_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlFile();
    }
    protected void chlCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlCenter();
    }
    protected void chlAdv_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlAdv();
    }
    protected void chlWeb_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.checkchlWeb();
    }
    protected void btnSaveFuntion_Click(object sender, EventArgs e)
    {
        authenticationgroup = new AuthenticationGroupsBLL();
        int depID = Convert.ToInt32((gwListDepartments.SelectedRow.FindControl("lblDepartmentsID") as Label).Text);
        bool delAuthGroup = authenticationgroup.DeleteWithDepartmentsID(depID);
        if(delAuthGroup)
        {
            this.NewAuthenGroup(chlSystem, depID);
            this.NewAuthenGroup(chlUsermanager, depID);
            this.NewAuthenGroup(chlFileManager, depID);
            this.NewAuthenGroup(chlmedia, depID);
            this.NewAuthenGroup(chlFile, depID);
            this.NewAuthenGroup(chlCenter, depID);
            this.NewAuthenGroup(chlAdv, depID);
            this.NewAuthenGroup(chlWeb, depID);
        }
        else
        {
            Response.Write("<script>Thêm thất bại, lỗi kết nối CSDL !</script>");
        }
    }
    private void NewAuthenGroup(CheckBoxList chkl, int depid)
    {
        authenticationgroup = new AuthenticationGroupsBLL();
       
        foreach(ListItem itm in chkl.Items)
        {
            if(itm.Selected==true)
            {
                
                this.authenticationgroup.NewAuthenticationGroups(depid, Convert.ToInt32(itm.Value));
                
            }
        }
    }
    private Boolean hasChecked(int perID, int DepID)
    {
        authenticationgroup = new AuthenticationGroupsBLL();
        List<AuthenticationGroups> lst = authenticationgroup.getListpIDanddepID(perID, DepID);
        AuthenticationGroups auth = lst.FirstOrDefault();
        if(auth==null)
        {
            return false;
        }
        return true;
    }
    //check vào select all nếu 
    private void load_checkedCHK(CheckBoxList chkl, int depid)
    {
        authenticationgroup = new AuthenticationGroupsBLL();
        foreach (ListItem itm in chkl.Items)
        {
            
            if(hasChecked(Convert.ToInt32(itm.Value),depid))
            {
                itm.Selected = true;
            }
        }
    }
    //Đếm số checkbox is checked
    private int num_checkedCHK(CheckBoxList chkl, int depid)
    {
        int n1 = 0;
        authenticationgroup = new AuthenticationGroupsBLL();
        foreach (ListItem itm in chkl.Items)
        {

            if (hasChecked(Convert.ToInt32(itm.Value), depid))
            {
                n1++;
            }
        }
        return n1;
    }
    //Sum Item in checkbosList
    private int SumItem_checkboxList(CheckBoxList chl)
    {
        int n2 = 0;
        for (int i = 0; i < chl.Items.Count; i++)
        {
            n2++;
        }
        return n2;
    }
    //Check select all
    private void checkSelectedAll(CheckBox chb, CheckBoxList chl, int depID)
    {
        if(num_checkedCHK(chl,depID)==SumItem_checkboxList(chl))
        {
            chb.Checked = true;
        }
    }

    #endregion CheckBoxList
}