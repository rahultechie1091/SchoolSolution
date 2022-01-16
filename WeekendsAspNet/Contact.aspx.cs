using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeekendsAspNet
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnName.Value = "sdfsfs";
            ViewState["Stu"] = "Test data";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = "Vijay";
            string str = hdnName.Value;
            string id = "10";
            Session["UserInfo"] = name;
            Application["Test"] = "sfsfsf";
            string st = ViewState["Stu"].ToString();
            HttpCookie stuInfo = new HttpCookie("stuInfo");
            stuInfo["Name"] = "Deepak";
            stuInfo["Email"] = "D@gmail.com";
            stuInfo.Expires.AddDays(1);
            Response.Cookies.Add(stuInfo);
            //?key1=value&key2=value
            Response.Redirect("Default.aspx?SName="+ name + "&SID="+ id);
        }
    }
}