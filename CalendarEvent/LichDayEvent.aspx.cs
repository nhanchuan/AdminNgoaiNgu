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

public partial class CalendarEvent_LichDayEvent : System.Web.UI.Page
{
    EmployeesBLL employees;
    kus_GVHopDongBLL kus_gvhopdong;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            load_GVName();
        }
    }
    private void load_GVName()
    {
        employees = new EmployeesBLL();
        kus_gvhopdong = new kus_GVHopDongBLL();

        List<Employees> lstEmp = employees.getEmpWithId(Convert.ToInt32(Session.GetCurrentGVTT()));
        Employees emp = lstEmp.FirstOrDefault();
        List<kus_GVHopDong> lstGV = kus_gvhopdong.getGVHopDongWithID(Convert.ToInt32(Session.GetCurrentGvHD()));
        kus_GVHopDong giaovien = lstGV.FirstOrDefault();
        if (emp != null)
        {
            //lblGiaoVien.Text=
            DataTable tbemp = employees.getTenGiaoVien(Convert.ToInt32(Session.GetCurrentGVTT()));
            foreach (DataRow r in tbemp.Rows)
            {
                lblGiaoVien.Text = (string)r[0] + " - " + (string.IsNullOrEmpty(r[1].ToString()) ? "" : (string)r[1]) + " " + (string.IsNullOrEmpty(r[2].ToString()) ? "" : (string)r[2]);
            }
        }
        else
        {
            lblGiaoVien.Text = "Gv." + giaovien.LastName + " " + giaovien.FirstName;
        }
    }
}