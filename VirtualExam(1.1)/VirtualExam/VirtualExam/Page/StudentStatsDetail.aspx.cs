using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualExam.Page
{
    public partial class StudentStatsDetail : System.Web.UI.Page
    {

        int testID;
        conn con = new conn();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userID"] == null)

            {
                Response.Redirect("~/Account/Login.aspx");

            }

            try
            {
                testID = Convert.ToInt32(Request.QueryString["testID"]);
            }
            catch (Exception ex )
            {

                
            }
            
            grafik();
            score();
            testReply();
            trueReply();
            subjectReply();


        }


        void testReply()
        {
            DataTable dtTest = con.GetDataTable("select t.userID,t.testID,ur.userReplyID,ur.questionID,ur.trueReplyID,tr.trueReplyName from test t inner join userReply ur  on t.testID = ur.testID inner join   trueReply tr on ur.trueReplyID = tr.trueReplyID where t.testID ="+ testID +" ");

            dataTrueReply.DataSource = dtTest;
            dataTrueReply.DataBind();
        }


        void trueReply()
        {
            DataTable dtTest = con.GetDataTable("select q.subjectID,q.userID,q.questionID,q.questionName,r.trueReplyID,tr.trueReplyName from question q  inner join reply r on q.questionID = r.questionID inner join trueReply tr on r.trueReplyID = tr.trueReplyID  where q.questionID IN(select ur.questionID  from test t inner  join userReply ur on t.testID = ur.testID where t.testID ="+testID+" )");

            dataUserReply.DataSource = dtTest;
            dataUserReply.DataBind();
        }


        void subjectReply()
        {
            DataTable dtSubject = con.GetDataTable("select count(s.subjectName) as count ,s.subjectName from test t	 inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID where t.testID ="+ testID+" group by s.subjectName");

            dataSubject.DataSource = dtSubject;
            dataSubject.DataBind();

        }
        void grafik()
        {
            SqlConnection connect = con.baglan();
            SqlCommand cmdSubject = new SqlCommand("select count(s.subjectName) as count ,s.subjectName from test t	 inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID where t.testID = " + testID + " group by s.subjectName", connect);

            SqlDataReader read = cmdSubject.ExecuteReader();
            while (read.Read())
            {
                Chart1.Series["Konu"].Points.AddXY(read["subjectName"].ToString(), read["count"].ToString());

     
            }

            read.Close();
            SqlCommand cmdSubjectTrue = new SqlCommand("select count(s.subjectName) as count ,s.subjectName from test t inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID inner join reply r on q.questionID = r.questionID where t.testID =" +testID+"and  r.trueReplyID IN(ur.trueReplyID) group by s.subjectName", connect);

            SqlDataReader readFalse = cmdSubjectTrue.ExecuteReader();
            while (readFalse.Read())
            {
              

                Chart2.Series["Doğru"].Points.AddXY(readFalse["subjectName"].ToString(), readFalse["count"].ToString());

            }
            readFalse.Close();


            SqlCommand cmdSubjectFalse = new SqlCommand("select count(s.subjectName) as count ,s.subjectName from test t inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID inner join reply r on q.questionID = r.questionID where t.testID =" + testID + "and  r.trueReplyID NOT IN (ur.trueReplyID) group by s.subjectName", connect);

            SqlDataReader readTrue = cmdSubjectFalse.ExecuteReader();
            while (readTrue.Read())
            {


                Chart3.Series["Yanlış"].Points.AddXY(readTrue["subjectName"].ToString(), readTrue["count"].ToString());

            }



        }

        void score()
        {
            DataRow drScore = con.GetDataRow("select count(s.subjectName)*2 as count  from test t inner join userReply ur on t.testID = ur.testID inner join question q on ur.questionID = q.questionID inner join[subject] s on q.subjectID = s.subjectID inner join reply r on q.questionID = r.questionID where t.testID ="+testID+" and  r.trueReplyID IN(ur.trueReplyID)");
            lblScore.Text = drScore["count"].ToString();
        }
    }
}