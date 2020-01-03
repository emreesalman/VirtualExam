using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualExam.Page
{
    public partial class TeacherIndex : System.Web.UI.Page
    {
        conn con = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"]== null)

            {
                Response.Redirect("~/Account/Login.aspx");

            }

           
            DataTable dtstudentInfo = con.GetDataTable("select u.userID,ui.Name,ui.Surname,ui.Phone from userGroup ug  inner join [user] u on ug.userGroupID=u.userGroupID inner join userInfo ui on u.userID=ui.userID where ug.userGroupID=3");

            dtStudent.DataSource = dtstudentInfo;
           
            dtStudent.DataBind();


        }
    }
}