using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualExam.Page
{
    public partial class Statistics : System.Web.UI.Page
    {
        conn con = new conn();
        string date1;
        string date2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)

            {
                Response.Redirect("~/Account/Login.aspx");

            }
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            date1=Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            date2= Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            
            grafic();
            Panel1.Visible = false;
            Panel2.Visible = true;
        }


        void grafic()
        {

            SqlConnection connect = con.baglan();
            SqlCommand cmdSubject = new SqlCommand("select count(s.subjectName) as count, s.subjectName from test t inner join userReply ur on t.testID = ur.testID  inner join question q on ur.questionID = q.questionID  inner join[subject] s on q.subjectID = s.subjectID where CONVERT(date, [date], 4) > CONVERT(nvarchar, '"+ date1 +"', 4) and CONVERT(nvarchar, [date], 4) < CONVERT(nvarchar, '"+ date2 + "', 4) and t.userID = "+Session["UserID"]+"   group by s.subjectName", connect);

            SqlDataReader read = cmdSubject.ExecuteReader();
            while (read.Read())
            {
                
                Chart1.Series["Konu"].Points.AddXY(read["subjectName"].ToString(), read["count"].ToString());


            }

            read.Close();
            SqlCommand cmdSubjectTrue = new SqlCommand("select count(s.subjectName) as count ,s.subjectName from test t  inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID inner join reply r on q.questionID = r.questionID   where CONVERT(date, [date], 4) > CONVERT(nvarchar, '" + date1 + "', 4) and CONVERT(nvarchar, [date], 4) < CONVERT(nvarchar, '" + date2 + "', 4) and t.userID =" + Session["UserID"] + " and  r.trueReplyID IN(ur.trueReplyID) group by s.subjectName ", connect);

            SqlDataReader readFalse = cmdSubjectTrue.ExecuteReader();
            while (readFalse.Read())
            {


                Chart2.Series["Doğru"].Points.AddXY(readFalse["subjectName"].ToString(), readFalse["count"].ToString());

            }
            readFalse.Close();


            SqlCommand cmdSubjectFalse = new SqlCommand("select count(s.subjectName) as count ,s.subjectName from test t  inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID inner join reply r on q.questionID = r.questionID   where CONVERT(date, [date], 4) > CONVERT(nvarchar, '" + date1 + "', 4) and CONVERT(nvarchar, [date], 4) < CONVERT(nvarchar, '" + date2 + "', 4) and t.userID =" + Session["UserID"] + " and  r.trueReplyID NOT IN(ur.trueReplyID) group by s.subjectName ", connect);

            SqlDataReader readTrue = cmdSubjectFalse.ExecuteReader();
            while (readTrue.Read())
            {


                Chart3.Series["Yanlış"].Points.AddXY(readTrue["subjectName"].ToString(), readTrue["count"].ToString());

            }

        }
    }
}