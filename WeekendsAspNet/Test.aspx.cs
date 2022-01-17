using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace WeekendsAspNet
{
    public partial class Test : System.Web.UI.Page
    {
        private int attempts;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int attempts;
            var ds = new DataSet();
            var ds1 = new DataSet();
            using (var con = new SqlConnection(@"Data Source=PCDEVELOPER\MYSQL;Integrated Security=true;Initial Catalog=Tested"))
            {
                con.Open();
                var cmd = new SqlCommand("select userid,attemptcount from tblLock where username=@username", con);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPwd.Text);
                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds is object)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        attempts = Convert.ToInt32(ds.Tables[0].Rows[0]["attemptcount"]);
                        if (attempts == 3)
                        {
                            lblMsg.Text = "Your Account Already Locked";
                            lblMsg.ForeColor = Color.Red;
                        }
                        else
                        {
                            cmd = new SqlCommand("select userid,attemptcount from tblLock where username=@username and password=@password", con);
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@password", txtPwd.Text);
                            da = new SqlDataAdapter(cmd);
                            da.Fill(ds1);
                            if (ds1 is object)
                            {
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    attempts = Conversions.ToInteger(ds1.Tables[0].Rows[0]["attemptcount"]);
                                    if (attempts != 3)
                                    {
                                        cmd = new SqlCommand("update tblLock set attemptcount=0 where username=@username and password=@password", con);
                                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                                        cmd.Parameters.AddWithValue("@password", txtPwd.Text);
                                        cmd.ExecuteNonQuery();
                                        lblMsg.Text = "Logged in Successfully.";
                                        lblMsg.ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Your Account Already Locked.";
                                        lblMsg.ForeColor = Color.Red;
                                    }
                                }
                                else
                                {
                                    string strquery = string.Empty;
                                    if (attempts > 2)
                                    {
                                        strquery = "update tblLock set islocked=1, attemptcount=@attempts where username=@username and password=@password";
                                        lblMsg.Text = "Your account has been locked";
                                    }
                                    else
                                    {
                                        attempts = attempts + 1;
                                        strquery = "update tblLock set attemptcount=@attempts where username=@username";
                                        if (attempts == 3)
                                        {
                                            lblMsg.Text = "Your Account Locked";
                                        }
                                        else
                                        {
                                            lblMsg.Text = "Your Password Wrong you have only " + (3 - attempts) + " attempts";
                                        }
                                    }

                                    cmd = new SqlCommand(strquery, con);
                                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                                    cmd.Parameters.AddWithValue("@password", txtPwd.Text);
                                    cmd.Parameters.AddWithValue("@attempts", attempts);
                                    cmd.ExecuteNonQuery();
                                    lblMsg.ForeColor = Color.Red;
                                }
                            }
                        }
                    }
                    else
                    {
                        lblMsg.Text = "UserName Not Exists";
                        lblMsg.ForeColor = Color.Red;
                    }
                }

                con.Close();
            }
        }
    }
}