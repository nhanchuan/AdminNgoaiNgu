using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo_In_Project_CheckAll_Uncheck : System.Web.UI.Page
{
    List<Employee> listEmp = new List<Employee>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Employee emp = new Employee();
            listEmp = emp.GetEmployees();
            this.GridView1.DataSource = listEmp;
            this.GridView1.DataBind();
        }
    }

    protected void btnRetrieveCheck_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("chkSel");
            if (cb != null && cb.Checked)
            {
                Response.Write("Employee Id: " +
                    GridView1.DataKeys[row.RowIndex].Value
                    + " Name: " + row.Cells[2].Text + "<br/>");
            }
        }
    }
}

public class Employee
{

    public int ID { get; set; }

    public string FName { get; set; }

    public int Age { get; set; }

    public char Sex { get; set; }

    public List<Employee> GetEmployees()
    {
        List<Employee> eList = new List<Employee>();

        eList.Add(new Employee() { ID = 1, FName = "John", Age = 23, Sex = 'M' });

        eList.Add(new Employee() { ID = 2, FName = "Mary", Age = 25, Sex = 'F' });

        eList.Add(new Employee() { ID = 3, FName = "Amber", Age = 23, Sex = 'M' });

        eList.Add(new Employee() { ID = 4, FName = "Kathy", Age = 25, Sex = 'M' });

        eList.Add(new Employee() { ID = 5, FName = "Lena", Age = 27, Sex = 'F' });

        eList.Add(new Employee() { ID = 6, FName = "John", Age = 28, Sex = 'M' });

        eList.Add(new Employee() { ID = 7, FName = "Kathy", Age = 27, Sex = 'F' });

        eList.Add(new Employee() { ID = 8, FName = "John", Age = 28, Sex = 'M' });

        return eList;
    }
}