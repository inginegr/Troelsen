using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = (DataTable)Cache["AppDataTable"];
            GridView1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        AutoLotConnectedLayer.InventoryDAL dal = new AutoLotConnectedLayer.InventoryDAL();
        dal.OpenConnection(@"Data Source=DIMA-PC\MSSQLSERVER2014;Initial Catalog=master;Integrated Security=True");
        dal.InsertAuto(int.Parse(TextBox1.Text), TextBox2.Text, TextBox3.Text, TextBox4.Text);
        dal.CloseConnection();
        RefreshData();
    }

    void RefreshData()
    {
        AutoLotConnectedLayer.InventoryDAL dal = new AutoLotConnectedLayer.InventoryDAL();
        dal.OpenConnection(@"Data Source=DIMA-PC\MSSQLSERVER2014;Initial Catalog=master;Integrated Security=True");
        DataTable thc = dal.GetAllInventoryAsDataTable();
        GridView1.DataSource = thc;
        GridView1.DataBind();
    }
}