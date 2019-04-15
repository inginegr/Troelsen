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
        string st = string.Empty;
        foreach (string s in Request.Cookies)
            st += $"{s}__________{Request.Cookies[s].Value}<br/>";
        lbl.Text = st;
    }

    protected void btnWriteToCookie_Click(object sender, EventArgs e)
    {
        HttpCookie cke = new HttpCookie(CkName.Text, CkValue.Text);
        Response.Cookies.Add(cke);
    }

    protected void btnReadFromCookie_Click(object sender, EventArgs e)
    {
        HttpCookie cke = new HttpCookie(CkName.Text, CkValue.Text);
        cke.Expires = DateTime.Now.AddHours(2);
        Response.Cookies.Add(cke);
    }
}