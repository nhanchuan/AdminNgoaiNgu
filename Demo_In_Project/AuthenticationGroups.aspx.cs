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

public partial class Pages_AuthenticationGroups : BasePage
{
    PermissFuncBLL permissfunction;
    DepartmentsBLL department;
    AuthenticationGroupsBLL authenticationGroups;
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

                    this.load_gwAuthenticationGroups();
                    string selectIndex = Request.QueryString["selectedID"];
                    if(string.IsNullOrEmpty(selectIndex))
                    {
                        gwAuthenticationGroups.SelectedIndex = -1;
                    }
                    else
                    {
                        gwAuthenticationGroups.SelectedIndex = Convert.ToInt32(selectIndex);
                    }
                }
            }
        }
        this.BindGrid();
    }

    private void load_gwAuthenticationGroups()
    {

        department = new DepartmentsBLL();
        authenticationGroups = new AuthenticationGroupsBLL();
        List<Departments> lstdep = department.getAllDepartment();
        BoundField bfield = new BoundField();
        bfield.HeaderText = "Chức năng";
        bfield.DataField = "FunctionName";
        gwAuthenticationGroups.Columns.Add(bfield);

        TemplateField tfield = new TemplateField();
        tfield.HeaderText = "Country";
        gwAuthenticationGroups.Columns.Add(tfield);

        //TemplateField tf;
        //foreach (Departments itm in lstdep)
        //{
        //    tf = new TemplateField();
        //    tf.HeaderText = itm.DepartmentName;
        //    //int FuID = Convert.ToInt32((gwAuthenticationGroups.Rows[e.RowIndex].FindControl("lblCategoryID") as Label).Text);
        //    List<AuthenticationGroups> lst = authenticationGroups.getListpIDanddepID(0, itm.DepartmentsID);
        //    tf.ItemTemplate = new AddTemplateToGridView(ListItemType.Item, itm.DepartmentsID.ToString());
        //    gwAuthenticationGroups.Columns.Add(tf);

        //}
        CommandField cf = new CommandField();
        cf.ButtonType = ButtonType.Link;
        cf.SelectText = "Select";
        cf.ShowSelectButton = true;
        gwAuthenticationGroups.Columns.Add(cf);

        
    }

    private void load_dataInGrid()
    {
        department = new DepartmentsBLL();
        List<Departments> lstdep = department.getAllDepartment();
        TemplateField tfield=new TemplateField();
            foreach (Departments itm in lstdep)
            {
                tfield = new TemplateField();
                tfield.HeaderText = itm.DepartmentName;
                List<AuthenticationGroups> lst = authenticationGroups.getListpIDanddepID(string.IsNullOrEmpty(Request.QueryString["FID"]) ? 0 : Convert.ToInt32(Request.QueryString["FID"]), itm.DepartmentsID);
                AuthenticationGroups auth = lst.FirstOrDefault();
                tfield.ItemTemplate = new AddTemplateToGridView(ListItemType.Item, (auth == null) ? "NO" : "YES");
                gwAuthenticationGroups.Columns.Add(tfield);
            }

        BindGrid();

    }
    private void add_selectbtn()
    {
        
        CommandField cf = new CommandField();
        cf.ButtonType = ButtonType.Link;
        cf.SelectText = "Select";
        cf.ShowSelectButton = true;
        gwAuthenticationGroups.Columns.Add(cf);
        
        this.BindGrid();
    }
    private void BindGrid()
    {
        
        permissfunction = new PermissFuncBLL();
        gwAuthenticationGroups.DataSource = permissfunction.getTBListPermissFunc();
        gwAuthenticationGroups.DataBind();
    }
    public class AddTemplateToGridView : ITemplate
    {
        ListItemType _type;
        string _text;
        public AddTemplateToGridView(ListItemType type, string text)
        {
            _type = type;
            _text = text;
        }
        void ITemplate.InstantiateIn(System.Web.UI.Control container)
        {

            switch (_type)
            {
                case ListItemType.Item:

                    Label lbl = new Label();
                    lbl.Text = _text;
                    lbl.ID = "lblDepID";
                    //lbl.CssClass = "display-none";
                    container.Controls.Add(lbl);
                    break;
            }
        }
    }

    protected void gwAuthenticationGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pid = (gwAuthenticationGroups.SelectedRow.FindControl("lblPermissFuncID") as Label).Text;
        string indexSelected = gwAuthenticationGroups.SelectedIndex.ToString();
        Response.Redirect("http://" + Request.Url.Authority + "/Pages/AuthenticationGroups.aspx?selectedID="+ indexSelected+"&FID="+ pid);
    }

    protected void gwAuthenticationGroups_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = e.Row.FindControl("lblPermissFuncID") as Label;
                TextBox txtCountry = new TextBox();
                txtCountry.ID = "txtCountry";
                //txtCountry.Text = (e.Row.DataItem as DataRowView).Row["FunctionName"].ToString();
                txtCountry.Text = lbl.Text;
                e.Row.Cells[3].Controls.Add(txtCountry);

                
            }
        }
        catch (Exception)
        {

        }
    }
    
}