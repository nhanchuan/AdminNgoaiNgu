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

public partial class kus_admin_QLPhongHoc : BasePage
{
    private int PageSize = 20;
    kus_HTChiNhanhBLL kus_htchinhanh;
    kus_CoSoBLL kus_coso;
    kus_PhongHocBLL kus_phonghoc;
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
                if (!check_permiss(ac.UserID, FunctionName.QLPhongHoc))
                {
                    Response.Redirect("http://" + Request.Url.Authority + "/Extra/access_denied.aspx");
                }
                else
                {
                    this.load_dlHTChiNhanh();
                    dlHTChiNhanh.Items.Insert(0, new ListItem("------- Chọn Hệ Thống Chi Nhánh -------", "0"));
                    dlQLCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
                    this.Getkus_PhongHocPageWise(1);
                }
                
            }
        }
    }
    private void load_dlHTChiNhanh()
    {
        kus_htchinhanh = new kus_HTChiNhanhBLL();
        dlHTChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
        dlHTChiNhanh.DataTextField = "tenHTChiNhanh";
        dlHTChiNhanh.DataValueField = "hTChiNhanhID";
        dlHTChiNhanh.DataBind();
    }
    private void Getkus_PhongHocPageWise(int pageIndex)
    {
        kus_phonghoc = new kus_PhongHocBLL();
        int recordCount = 0;
        gwListPhongHoc.DataSource = kus_phonghoc.GetGetkus_PhongHocPageWise(pageIndex, PageSize);
        recordCount = kus_phonghoc.CounGetkus_PhongHocPageWise();
        gwListPhongHoc.DataBind();
        this.PopulatePager(recordCount, pageIndex);
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
        this.Getkus_PhongHocPageWise(pageIndex);
    }

    protected void dlHTChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_coso = new kus_CoSoBLL();
        dlQLCoSo.DataSource = kus_coso.getLSTCoSoWithChiNhanhID(Convert.ToInt32(dlHTChiNhanh.SelectedValue));
        dlQLCoSo.DataTextField = "TenCoSo";
        dlQLCoSo.DataValueField = "CoSoID";
        dlQLCoSo.DataBind();
        dlQLCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));
    }
    protected void btnAddPhongHoc_Click(object sender, EventArgs e)
    {
        kus_phonghoc = new kus_PhongHocBLL();
        int cosoid = Convert.ToInt32(dlQLCoSo.SelectedValue.ToString());
        string dayph = txtDayPhongHoc.Text;
        string tangph = txtTangPhongHoc.Text;
        int sophong = Convert.ToInt32(txtSoPhong.Text);
        if (kus_phonghoc.AddNewPhongHoc(dayph, tangph, sophong, cosoid))
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Thêm phòng học false ! Lỗi kết nối db !')</script>");
        }
    }

    protected void gwListPhongHoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        kus_phonghoc = new kus_PhongHocBLL();

        int phonghocID=Convert.ToInt32((gwListPhongHoc.SelectedRow.FindControl("lblPhongHocID") as Label).Text);
        List<kus_PhongHoc> lstPH = kus_phonghoc.getListPhongHocWithID(phonghocID);
        kus_PhongHoc phonghoc = lstPH.FirstOrDefault();

        kus_htchinhanh = new kus_HTChiNhanhBLL();
        dlEditChiNhanh.DataSource = kus_htchinhanh.getAllTBChiNhanh();
        dlEditChiNhanh.DataTextField = "tenHTChiNhanh";
        dlEditChiNhanh.DataValueField = "hTChiNhanhID";
        dlEditChiNhanh.DataBind();
        dlEditChiNhanh.Items.Insert(0, new ListItem("------- Chọn Hệ Thống Chi Nhánh -------", "0"));

        kus_coso = new kus_CoSoBLL();
        dlEditCoSo.DataSource = kus_coso.getAllHTCoSo();
        dlEditCoSo.DataTextField = "TenCoSo";
        dlEditCoSo.DataValueField = "CoSoID";
        dlEditCoSo.DataBind();
        dlEditCoSo.Items.Insert(0, new ListItem("------ Chọn Cơ Sở thuộc Hệ Thống Chi Nhánh -------", "0"));

        txtEditDayPH.Text = phonghoc.DayPhong;
        txtEditTangPH.Text = phonghoc.Tang;
        txtEditSoPhong.Text = phonghoc.SoPhong.ToString();
        dlEditCoSo.Items.FindByValue(string.IsNullOrEmpty(phonghoc.CoSoID.ToString()) ? "0" : phonghoc.CoSoID.ToString()).Selected = true;

        List<kus_CoSo> lstCS = kus_coso.getLSTCoSoWithID(string.IsNullOrEmpty(phonghoc.CoSoID.ToString()) ? 0 : phonghoc.CoSoID);
        kus_CoSo coso = lstCS.FirstOrDefault();
        List<kus_HTChiNhanh> lstHTCN = kus_htchinhanh.getlistHTChiNHanhWithID((coso == null) ? 0 : coso.HTChiNhanhID);
        kus_HTChiNhanh htcn = lstHTCN.FirstOrDefault();
        dlEditChiNhanh.Items.FindByValue((htcn == null) ? "0" : htcn.HTChiNhanhID.ToString()).Selected = true;
    }

    protected void btnUpdatePhongHoc_Click(object sender, EventArgs e)
    {
        kus_phonghoc = new kus_PhongHocBLL();
        int cosoid = Convert.ToInt32(dlEditCoSo.SelectedValue.ToString());
        string dayph = txtEditDayPH.Text;
        string tangph = txtEditTangPH.Text;
        int sophong = Convert.ToInt32(txtEditSoPhong.Text);
        int phonghocID = Convert.ToInt32((gwListPhongHoc.SelectedRow.FindControl("lblPhongHocID") as Label).Text);
        if (kus_phonghoc.UpdatePhongHoc(phonghocID, dayph, tangph, sophong, cosoid))
        {
            txtEditDayPH.Text = "";
            txtEditTangPH.Text = "";
            txtEditSoPhong.Text = "";
            dlQLCoSo.ClearSelection();
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else
        {
            Response.Write("<script>alert('Update phòng học false ! Lỗi kết nối db !')</script>");
        }
    }
}