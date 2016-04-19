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

public partial class Pages_Users : BasePage
{
    UserAccountsBLL useraccount;
    DepartmentsBLL departments;
    PermissFuncBLL permissfunction;
    UserPermissBLL userpermiss;
    AuthenticationGroupsBLL authenticationgroup;
    public int PageSize = 5;
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
                if (!check_permiss(ac.UserID, FunctionName.AllUser))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.Getkus_listAllUserPageWise(1);
                    this.load_dlDepartments();
                    this.load_CheckLst();
                    btnChangeFunction.Visible = false;
                    btnViewDetail.Visible = false;
                }
            }
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://" + Request.Url.Authority + "/Pages/NewUser.aspx");
    }
    private void Getkus_listAllUserPageWise(int pageIndex)
    {
        useraccount = new UserAccountsBLL();
        int recordCount = 0;
        gwListUsers.DataSource = useraccount.kus_listAllUser(pageIndex, PageSize);
        recordCount = useraccount.CountListAllUser();
        gwListUsers.DataBind();
        this.PopulatePager(recordCount, pageIndex);
        //lbltotalRecord.Text = recordCount.ToString();
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;
        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.Getkus_listAllUserPageWise(pageIndex);
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

    protected void gwListUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnChangeFunction.Visible = true;
        btnViewDetail.Visible = true;

        this.ClearSelection();
        int UserID = Convert.ToInt32((gwListUsers.SelectedRow.FindControl("lblUserID") as Label).Text);
        this.load_checkedUserCHK(chlSystem, UserID);
        this.load_checkedUserCHK(chlUsermanager, UserID);
        this.load_checkedUserCHK(chlFileManager, UserID);
        this.load_checkedUserCHK(chlmedia, UserID);
        this.load_checkedUserCHK(chlFile, UserID);
        this.load_checkedUserCHK(chlCenter, UserID);
        this.load_checkedUserCHK(chlAdv, UserID);
        this.load_checkedUserCHK(chlWeb, UserID);

        this.checkUserSelectedAll(chlSystemall, chlSystem, UserID);
        this.checkUserSelectedAll(chlUsermanagerall, chlUsermanager, UserID);
        this.checkUserSelectedAll(chlFileManagerall, chlFileManager, UserID);
        this.checkUserSelectedAll(chlmediaall, chlmedia, UserID);
        this.checkUserSelectedAll(chlFileall, chlFile, UserID);
        this.checkUserSelectedAll(chlCenterall, chlCenter, UserID);
        this.checkUserSelectedAll(chlAdvall, chlAdv, UserID);
        this.checkUserSelectedAll(chlWeball, chlWeb, UserID);

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
        if (chlUsermanagerall.Checked)
        {
            foreach (ListItem l in chlUsermanager.Items)
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
            if (l.Selected == false)
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
    
    private Boolean hasChecked(int perID, int DepID)
    {
        authenticationgroup = new AuthenticationGroupsBLL();
        List<AuthenticationGroups> lst = authenticationgroup.getListpIDanddepID(perID, DepID);
        AuthenticationGroups auth = lst.FirstOrDefault();
        if (auth == null)
        {
            return false;
        }
        return true;
    }
    //check vào select all nếu 
    private void load_checkedCHK(CheckBoxList chkl, int depid)
    {
        
        foreach (ListItem itm in chkl.Items)
        {

            if (hasChecked(Convert.ToInt32(itm.Value), depid))
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
        if (num_checkedCHK(chl, depID) == SumItem_checkboxList(chl))
        {
            chb.Checked = true;
        }
    }

    #endregion CheckBoxList

    protected void dlDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btnAuthentication.Visible = true;
        this.ClearSelection();
        int depID = Convert.ToInt32(dlDepartments.SelectedValue);
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





    private Boolean has_checkedListBox(int perID, int UID)
    {
        userpermiss = new UserPermissBLL();
        List<UserPermiss> lst = userpermiss.lstPermiss(UID, perID);
        UserPermiss pm = lst.FirstOrDefault();
        if (pm == null)
        {
            return false;
        }
        return true;
    }

    private void load_checkedUserCHK(CheckBoxList chkl, int useid)
    {
        
        foreach (ListItem itm in chkl.Items)
        {

            if (has_checkedListBox(Convert.ToInt32(itm.Value), useid))
            {
                itm.Selected = true;
            }
        }
    }
    private int num_checkedUserCHK(CheckBoxList chkl, int userID)
    {
        int n1 = 0;
        authenticationgroup = new AuthenticationGroupsBLL();
        foreach (ListItem itm in chkl.Items)
        {

            if (has_checkedListBox(Convert.ToInt32(itm.Value), userID))
            {
                n1++;
            }
        }
        return n1;
    }
    private void checkUserSelectedAll(CheckBox chb, CheckBoxList chl, int userid)
    {
        if (num_checkedUserCHK(chl, userid) == SumItem_checkboxList(chl))
        {
            chb.Checked = true;
        }
    }
    private void NewUserPermiss(CheckBoxList chkl, int userID)
    {
        userpermiss = new UserPermissBLL();
        foreach (ListItem itm in chkl.Items)
        {
            if (itm.Selected == true)
            {
                this.userpermiss.NewUserPermiss(userID, Convert.ToInt32(itm.Value));
            }
        }
    }

    protected void btnSaveFuntion_Click(object sender, EventArgs e)
    {
        userpermiss = new UserPermissBLL();
        int Userid = Convert.ToInt32((gwListUsers.SelectedRow.FindControl("lblUserID") as Label).Text);
        bool delAuthGroup = userpermiss.DeleteWithUserID(Userid);
        if (delAuthGroup)
        {
            this.NewUserPermiss(chlSystem, Userid);
            this.NewUserPermiss(chlUsermanager, Userid);
            this.NewUserPermiss(chlFileManager, Userid);
            this.NewUserPermiss(chlmedia, Userid);
            this.NewUserPermiss(chlFile, Userid);
            this.NewUserPermiss(chlCenter, Userid);
            this.NewUserPermiss(chlAdv, Userid);
            this.NewUserPermiss(chlWeb, Userid);
        }
        else
        {
            Response.Write("<script>Thêm thất bại, lỗi kết nối CSDL !</script>");
        }
    }
}