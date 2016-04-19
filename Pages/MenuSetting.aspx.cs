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

public partial class Pages_MenuSetting : BasePage
{
    MainMenuBLL mainmenu;
    Menu_CategoryBLL menu_categry;
    CategoryBLL category;
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
                if (!check_permiss(ac.UserID, FunctionName.MenuSetting))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_gwMenuItems();
                    btnSubmit.Enabled = false;
                }
            }
        }
    }

    protected void btnAddMenuItem_Click(object sender, EventArgs e)
    {
        mainmenu = new MainMenuBLL();
        if (mainmenu.NewMainMenu(txtItemname.Text, txtPermalink.Text, mainmenu.MaxItemindex() + 1))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm Menu thất bại. Lỗi kết nối CSDL !')</srcipt>");
            return;
        }
    }
    private void load_gwMenuItems()
    {
        mainmenu = new MainMenuBLL();
        gwMenuItems.DataSource = mainmenu.ListMenuItems();
        gwMenuItems.DataBind();
    }
    [Serializable]
    class Number
    {
        int num;
        public Number(int num) // ham khoi tao
        {
            this.num = num;
        }
        public int getNum()     // ham tra ve gia tri num
        {
            return num;
        }
        public void setNum(int num) // ham set gia tri num
        {
            this.num = num;
        }
    }
    private void swap(Number a, Number b) // ham hoan vi
    {
        int temp = a.getNum();                  // gan num cua a cho temp
        a.setNum(b.getNum());                   // gan num cua b cho a
        b.setNum(temp);                         // gan temp cho num cua b
    }
    
    protected void lkbtnUp_Click(object sender, EventArgs e)
    {
        mainmenu = new MainMenuBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int menuid = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<MainMenu> lstMN = mainmenu.ListMenuItemsWithMenuID(menuid); //index A
        MainMenu menu = lstMN.FirstOrDefault();

        List<MainMenu> lstMUP = mainmenu.ListMenuItemsWithIndex(mainmenu.MaxItemindexLK(menu.ItemIndex)); //index B
        MainMenu menuUp = lstMUP.FirstOrDefault();
        
        if (menuUp==null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(menu.MenuID);
            B = new Number(menuUp.MenuID);
            a = new Number(menu.ItemIndex);
            b = new Number(menuUp.ItemIndex);
            this.swap(a, b);
            this.mainmenu.UpdateItemIndex(a.getNum(),A.getNum());
            this.mainmenu.UpdateItemIndex(b.getNum(),B.getNum());
            this.load_gwMenuItems();
            gwMenuItems.SelectedIndex = -1;
        }
    }
    protected void lkbtnDown_Click(object sender, EventArgs e)
    {
        mainmenu = new MainMenuBLL();
        LinkButton lkbutton = (sender as LinkButton);
        //Get the command argument
        string commandArgument = lkbutton.CommandArgument;
        int menuid = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<MainMenu> lstMN = mainmenu.ListMenuItemsWithMenuID(menuid);
        MainMenu menu = lstMN.FirstOrDefault();
        List<MainMenu> lstMDown = mainmenu.ListMenuItemsWithIndex(mainmenu.MinItemindexLK(menu.ItemIndex)); //index B
        MainMenu menuDown = lstMDown.FirstOrDefault();
        if(menuDown==null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(menu.MenuID);
            B = new Number(menuDown.MenuID);
            a = new Number(menu.ItemIndex);
            b = new Number(menuDown.ItemIndex);
            this.swap(a, b);
            this.mainmenu.UpdateItemIndex(a.getNum(), A.getNum());
            this.mainmenu.UpdateItemIndex(b.getNum(), B.getNum());
            this.load_gwMenuItems();
            gwMenuItems.SelectedIndex = -1;
        }
    }
    protected void gwMenuItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        mainmenu = new MainMenuBLL();
        string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
        List<MainMenu> lstMN = mainmenu.ListMenuItemsWithMenuID(Convert.ToInt32(strMenuID));
        MainMenu menu = lstMN.FirstOrDefault();

        txtEditItemname.Text = menu.ItemName;
        txtEPermalink.Text = menu.Permalink;
        lblEIndex.Text = menu.ItemIndex.ToString();
        btnSubmit.Enabled = false;
        this.load_dlSelectCategory();
        this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
    }
    protected void txtEPermalink_TextChanged(object sender, EventArgs e)
    {
        btnSubmit.Enabled = true;
    }
    protected void txtEditItemname_TextChanged(object sender, EventArgs e)
    {
        btnSubmit.Enabled = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        mainmenu = new MainMenuBLL();
        if (gwMenuItems.SelectedRow==null)
        {
            lblWaringEdit.Text = "Chưa chọn menu Item !";
        }
        else
        {
            string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
            if(this.mainmenu.UpdateMainMenu(Convert.ToInt32(strMenuID), txtEditItemname.Text, txtEPermalink.Text))
            {
                this.load_gwMenuItems();
                btnSubmit.Enabled = false;
            }
            else
            {
                lblWaringEdit.Text = "Update thất bại. Lỗi kết nối CSDL !";
            }
        }
    }
    protected void gwMenuItems_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gwMenuItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        menu_categry = new Menu_CategoryBLL();
        mainmenu = new MainMenuBLL();
        int menuid = Convert.ToInt32((gwMenuItems.Rows[e.RowIndex].FindControl("lblMenuID") as Label).Text);

        if (this.menu_categry.DeleteMenu_CategoryMenuID(menuid) && this.mainmenu.DeleteMainMenuyMenuID(menuid))
        {
            this.load_gwMenuItems();
        }
        else
        {
            Response.Write("<script>alert('Xóa Menu Item thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
    private void load_dlSelectCategory()
    {
        category = new CategoryBLL();
        dlSelectCategory.DataSource = category.getAllCategory();
        dlSelectCategory.DataValueField = "CategoryID";
        dlSelectCategory.DataTextField = "CategoryName";
        dlSelectCategory.DataBind();
        dlSelectCategory.Items.Insert(0, new ListItem("-- Selected Category --", "0"));
    }
    private void load_gwSubMenuItem(int menuId)
    {
        menu_categry = new Menu_CategoryBLL();
        gwSubMenuItem.DataSource = menu_categry.ListSubMenuItem(menuId);
        gwSubMenuItem.DataBind();
    }
    protected void btnInsertItemtoMenu_ServerClick(object sender, EventArgs e)
    {
        menu_categry = new Menu_CategoryBLL();
        if(gwMenuItems.SelectedRow==null)
        {
            lblAddSubItemWaring.Text = "Chưa chọn Menu !";
        }
        else
        {
            string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
            List<Menu_Category> lstMC = menu_categry.ListItemWithMenuAndCT(Convert.ToInt32(strMenuID), Convert.ToInt32(dlSelectCategory.SelectedValue));
            Menu_Category menuItem = lstMC.FirstOrDefault();
            if (menuItem!=null)
            {
                lblAddSubItemWaring.Text = "Danh mục đã có. Vui lòng chọn danh mục khác !";
            }
            else
            {
                //lblAddSubItemWaring.Text = menu_categry.CounkItemWithMenuID(Convert.ToInt32(strMenuID)).ToString();
                lblAddSubItemWaring.Text = "";
                if (menu_categry.AddNewMenu_Category(Convert.ToInt32(strMenuID), Convert.ToInt32(dlSelectCategory.SelectedValue), menu_categry.MaxItemindexWithMenuID(Convert.ToInt32(strMenuID))+1))
                {
                    this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
                }
                else
                {
                    lblAddSubItemWaring.Text = "Thêm thất bại. Lỗi kết nối CSDL !";
                }
            }
        }
    }
    protected void lkbtnSubUp_Click(object sender, EventArgs e)
    {
        menu_categry = new Menu_CategoryBLL();
        string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
        LinkButton lkbutton = (sender as LinkButton);
        string commandArgument = lkbutton.CommandArgument;
        int c_menuid = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<Menu_Category> lstCMN = menu_categry.ListItemWithCID(c_menuid);
        Menu_Category c_menu = lstCMN.FirstOrDefault();
        List<Menu_Category> lstCMUP = menu_categry.ListItemWithIndex(menu_categry.MaxItemindexLK(c_menu.ItemIndex, Convert.ToInt32(strMenuID)), Convert.ToInt32(strMenuID));
        Menu_Category menuUp = lstCMUP.FirstOrDefault();
        
        if (menuUp == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(c_menu.CMenuID);
            B = new Number(menuUp.CMenuID);
            a = new Number(c_menu.ItemIndex);
            b = new Number(menuUp.ItemIndex);
            this.swap(a, b);
            this.menu_categry.UpdateIndexItem(a.getNum(), A.getNum());
            this.menu_categry.UpdateIndexItem(b.getNum(), B.getNum());
            this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
            gwSubMenuItem.SelectedIndex = -1;
        }
    }
    protected void lkbtnSubDown_Click(object sender, EventArgs e)
    {
        menu_categry = new Menu_CategoryBLL();
        string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
        LinkButton lkbutton = (sender as LinkButton);
        string commandArgument = lkbutton.CommandArgument;
        int c_menuid = int.Parse(commandArgument);
        Number a, b;
        Number A, B;
        List<Menu_Category> lstCMN = menu_categry.ListItemWithCID(c_menuid);
        Menu_Category c_menu = lstCMN.FirstOrDefault();
        List<Menu_Category> lstCMUP = menu_categry.ListItemWithIndex(menu_categry.MinItemindexLK(c_menu.ItemIndex, Convert.ToInt32(strMenuID)), Convert.ToInt32(strMenuID));
        Menu_Category menuUp = lstCMUP.FirstOrDefault();

        if (menuUp == null)
        {
            a = new Number(0);
            b = new Number(0);
            return;
        }
        else
        {
            A = new Number(c_menu.CMenuID);
            B = new Number(menuUp.CMenuID);
            a = new Number(c_menu.ItemIndex);
            b = new Number(menuUp.ItemIndex);
            this.swap(a, b);
            this.menu_categry.UpdateIndexItem(a.getNum(), A.getNum());
            this.menu_categry.UpdateIndexItem(b.getNum(), B.getNum());
            this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
            gwSubMenuItem.SelectedIndex = -1;
        }
    }
    protected void gwSubMenuItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDelSubItem") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Bạn chắc chắn muốn xóa ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwSubMenuItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        menu_categry = new Menu_CategoryBLL();
        string strMenuID = (gwMenuItems.SelectedRow.FindControl("lblMenuID") as Label).Text;
        int c_menuid = Convert.ToInt32((gwSubMenuItem.Rows[e.RowIndex].FindControl("lblCMenuID") as Label).Text);

        if (this.menu_categry.DeleteMenu_CategoryCMenuID(c_menuid))
        {
            this.load_gwSubMenuItem(Convert.ToInt32(strMenuID));
        }
        else
        {
            Response.Write("<script>alert('Xóa Menu Item thất bại. Lỗi kết nối csdl !')</script>");
        }
    }
}