using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualExam.Page
{
    public partial class StudentStats : System.Web.UI.Page
    {
        conn con = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] == null)

            {
                Response.Redirect("~/Account/Login.aspx");

            }

            test();

        }
        
        void test()
        {
            DataTable dtTest = con.GetDataTable("select t.testID,u.userID,u.userName from test t inner join [user] u on t.userID=u.userID where u.userID="+ Session["userID"]);

            dataTest.DataSource = dtTest;
            dataTest.DataBind();
        }
     
        
       
        
    }
}