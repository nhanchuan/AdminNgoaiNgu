using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

public partial class Controls_AdvisoryTicker : System.Web.UI.UserControl
{
    REGISTRATION_FORM_ADVISORY_BLL registrationForm;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
    //    registrationForm = new REGISTRATION_FORM_ADVISORY_BLL();
    //    lblcountNewAdvisory.Text = registrationForm.CountNew().ToString();
    //}
}