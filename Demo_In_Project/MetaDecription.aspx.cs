﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo_In_Project_MetaDecription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            tagsMetaDescription.Content = "jksdfkashdbvhdgvkhsbdvgkiiwuabushdbvkuhsbdvkasbrhgvsukahybvgksdhubvgkjbgfkaushbgfr";
        }
    }
}