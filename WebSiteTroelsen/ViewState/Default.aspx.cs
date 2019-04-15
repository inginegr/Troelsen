using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lstb.Items.Add("Item One");
            lstb.Items.Add("Item Two");
            lstb.Items.Add("Item Three");
            lstb.Items.Add("Item Four");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = $"{Application["Description"]}";
    }
}