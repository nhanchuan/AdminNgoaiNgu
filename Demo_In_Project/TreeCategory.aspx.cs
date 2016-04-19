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

public partial class Demo_In_Project_TreeCategory : System.Web.UI.Page
{
    CategoryBLL category;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.PopulateRootLevel();
        }
    }
    private void PopulateRootLevel()
    {
        category = new CategoryBLL();
        DataTable tbnodeRoot = category.getCategoryWithParentNull();
        PopulateNodes(tbnodeRoot, treeboxCategory.Nodes);
    }
    private void PopulateNodes(DataTable tb, TreeNodeCollection node)
    {
        foreach (DataRow r in tb.Rows)
        {
            //int parentId = (string.IsNullOrEmpty(r[4].ToString())) ? 0 : (int)r[4];
            TreeNode child = new TreeNode
            {
                Text = r["CategoryName"].ToString(),
                Value = r["CategoryID"].ToString()
            };
            int dec = (string.IsNullOrEmpty(r["childnodecount"].ToString())) ? 0 : (int)r["childnodecount"];
            child.PopulateOnDemand = (dec > 0);
            node.Add(child);
        }
    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        category = new CategoryBLL();
        DataTable dtChild = category.getCategoryWithParent(parentid);
        PopulateNodes(dtChild, parentNode.ChildNodes);
    }
    protected void treeboxCategory_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(int.Parse(e.Node.Value), e.Node);
    }
}