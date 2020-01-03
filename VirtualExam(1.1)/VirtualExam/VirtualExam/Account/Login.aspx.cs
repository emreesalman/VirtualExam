using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualExam.Account
{
    public partial class Login : System.Web.UI.Page
    {
        conn con = new conn();
        string userName;
        string userPassword;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["state"] == "off")
            {
                Session.Abandon();

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            userName = txtUsername.Text.ToString();
            userPassword = txtUserPassword.Text.ToString();

            DataRow drGiris = con.GetDataRow("select ug.userGroupID,ug.userGroupName,u.userID,u.userName,p.userPasword from [userGroup] ug inner join [user] u on ug.userGroupID=u.userGroupID inner join [password] p on u.userID=p.userID where u.userName='"+userName+"' and p.userPasword='"+userPassword+"'");
            if(drGiris != null)
            {

                if (drGiris["userGroupID"].ToString() == "2")
                {
                    Session["userID"] = drGiris["userID"].ToString();
                    Response.Redirect("~/page/TeacherIndex.aspx");

                }
                else if (drGiris["userGroupID"].ToString() == "3")
                {
                    Session["userID"] = drGiris["userID"].ToString();
                    Response.Redirect("~/page/StudentIndex.aspx");
                }
               

            }
            else
            {
                lblError.Text = "Hatalı Kullanıcı Adı veya Şifre";   
            }

        }
    }
}