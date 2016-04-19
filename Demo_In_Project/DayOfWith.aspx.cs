using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo_In_Project_DayOfWith : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public bool IsNumber(string pText)
    {
        Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
        return regex.IsMatch(pText);
    }
    private string getday(string str)
    {
        string day = "";
        if (!IsNumber(str.Substring(0, 2)))
        {
            return "";
        }
        else
        {
            day = str.Substring(0, 2);
        }
        return day;
    }
    private string getmonth(string str)
    {
        string month = "";
        if (!IsNumber(str.Substring(3, 2)))
        {
            return "";
        }
        else
        {
            month = str.Substring(3, 2);
        }
        return month;
    }
    private string getyear(string str)
    {
        string year = "";
        if (str.Length!=10)
        {
            return "";
        }
        else
        {
            if(!IsNumber(str.Substring(6, 4)))
            {
                return "";
            }
            else
            {
                year = str.Substring(6, 4);
            }
        }
        return year;
    }
    protected void btnpick_Click(object sender, EventArgs e)
    {
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

        DateTime dateValue;
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" };
        if (txtNgayKT.Text == "" || string.IsNullOrWhiteSpace(txtNgayKT.Text) || DateTime.TryParseExact(txtNgayKT.Text, formats, new CultureInfo("vi-VN"), DateTimeStyles.None, out dateValue) || getday(txtNgayKT.Text) =="" || getmonth(txtNgayKT.Text)==""|| getyear(txtNgayKT.Text)=="")
        {
            dateValue = Convert.ToDateTime("01/01/1900");
        }
        else
        {
            dateValue = DateTime.ParseExact(getday(txtNgayKT.Text) + "/" + getmonth(txtNgayKT.Text) + "/" + getyear(txtNgayKT.Text), "dd/MM/yyyy", null);
        }
        // Display the DayOfWeek string representation
        //Console.WriteLine(dateValue.DayOfWeek.ToString());
        lblweekday.Text = dateValue.DayOfWeek.ToString();

        //lblweekday.Text = dateValue.ToString();

        // Restore original current culture
        Thread.CurrentThread.CurrentCulture = originalCulture;

        //DateTime dtStart = new DateTime(2016, 1, 1);
        //DateTime dtEnd = new DateTime(2016, 3, 1);
        //while (dtStart < dtEnd)
        //{

        //    //Console.WriteLine(dtStart.ToString("dd/MM/yyyy"));
        //    //dtStart = dtStart.AddMonths(1);
        //    //lblweekday.Text += dtStart.DayOfWeek.ToString();
        //    if(dtStart.DayOfWeek.ToString()== "Monday")
        //    {
        //        lblweekday.Text += dtStart.ToShortDateString()+"  -> ";
        //    }
        //    dtStart = dtStart.AddDays(1);
        //}

    }
}