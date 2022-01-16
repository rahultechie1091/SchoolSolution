using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeekendsAspNet
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string name =   Request.QueryString["SName"]?.ToString();
           string na =  Session["UserInfo"].ToString();
            string te = Application["Test"].ToString();
        }
    }
}