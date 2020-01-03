using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace VirtualExam.Page
{
    public partial class StudentIndex : System.Web.UI.Page
    {
  
        conn con = new conn();
        int questionsID;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            Application["questionCount"] = 1;
            Application.UnLock();

            if (Session["userID"] == null)

            {
                Response.Redirect("~/Account/Login.aspx");

            }
            if (Page.IsPostBack == false)
            {
           
                lesson();
                drpLesson.Items.Insert(0, new ListItem("Seçiniz", "0"));
            }
           

        }

     

    
     

        protected void rbA_CheckedChanged(object sender, EventArgs e)
        {
            lblReplyID.Text ="1";
        }
        protected void rbB_CheckedChanged(object sender, EventArgs e)
        {
            lblReplyID.Text = "2";
        }
        protected void rbC_CheckedChanged(object sender, EventArgs e)
        {
            lblReplyID.Text = "3";

        }
        protected void rbD_CheckedChanged(object sender, EventArgs e)
        {
            lblReplyID.Text = "4";
        }
        protected void rbNull_CheckedChanged(object sender, EventArgs e)
        {
            lblReplyID.Text = "5";
        }



        [Obsolete]
        protected void btnNext_Click(object sender, EventArgs e)
        {
           
           
            if (Convert.ToInt32(lblQuestionCount.Text) <10)       
            {
                lblQuestionCount.Text =(Convert.ToInt32(lblQuestionCount.Text) + 1).ToString();
                start();
                replyInsert();

            }
            else
            {
                Response.Redirect("StudentStats.aspx");
            }
            Application.UnLock();
        }


        [Obsolete]
        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (drpLesson.SelectedItem.Value != "0")
            {
                pnlSubject.Visible = false;
                pnlQuestions.Visible = true;
                lblQuestionCount.Text = "1";
                start();
                testInsert();
                maxTestID();
                lblError.Visible = false;
            }
            else
            {
                lblError.Text = "Lütfen Ders Seçiniz";
            }
        }

        void start()
        {
            SqlConnection connect = con.baglan();
            SqlCommand cmdQuestion = new SqlCommand("SELECT  TOP 1  l.lessonID,s.subjectID,q.questionID,r.replyID, l.lessonName, s.subjectName, q.questionName, q.isText, r.a, r.b, r.c, r.d from lesson l inner join [subject] s on l.lessonID = s.lessonID inner join question q on s.subjectID = q.subjectID inner join reply r on q.questionID = r.questionID where l.lessonID = "+drpLesson.SelectedItem.Value+" ORDER BY NEWID() ", connect);

            SqlDataReader read = cmdQuestion.ExecuteReader();
            while (read.Read())
            {
                if (Convert.ToInt32(read["isText"]) == 0)
                {
                    imgA.Visible = false;
                    imgB.Visible = false;
                    imgC.Visible = false;
                    imgD.Visible = false;
                    imgQuestion.Visible = false;

                    rbA.Visible = true;
                    rbB.Visible = true;
                    rbC.Visible = true;
                    rbD.Visible = true;
                    lblQuestion.Visible = true;
                   
                    lblQuestion.Text = read["questionName"].ToString();

                    rbA.Text=read["a"].ToString();
                    rbB.Text =read["b"].ToString();
                    rbC.Text =read["c"].ToString();
                    rbD.Text =read["d"].ToString();
                    questionsID = Convert.ToInt32(read["questionID"]);
                }
                else
                {
                    rbA.Visible = true;
                    rbA.Text = "";
                    rbB.Visible = true;
                    rbB.Text = "";
                    rbC.Visible = true;
                    rbC.Text = "";
                    rbD.Visible = true;
                    rbD.Text = "";
                    lblQuestion.Visible = false;

                    imgA.Visible = true;
                    imgB.Visible = true;
                    imgC.Visible = true;
                    imgD.Visible = true;
                    imgQuestion.Visible = true;


                    imgQuestion.ImageUrl = "../upload/" + read["questionName"].ToString();

                    imgA.ImageUrl = "../upload/" + read["a"].ToString();
                    imgB.ImageUrl = "../upload/" + read["b"].ToString();
                    imgC.ImageUrl = "../upload/" + read["c"].ToString();
                    imgD.ImageUrl = "../upload/" + read["d"].ToString();
                    questionsID = Convert.ToInt32(read["questionID"]);

                }
            }


          


        }

        [Obsolete]
        void testInsert()
        {


            DateTime dt = DateTime.Today;
            int yil = dt.Year;
            int ay = dt.Month;
            int gun = dt.Day;
            SqlConnection connect = con.baglan();
            SqlCommand cmd = new SqlCommand("insert into test (userID,date) values (@USERID,@DATE)", connect);
            cmd.Parameters.Add("@USERID", Session["userID"]);
            cmd.Parameters.Add("@DATE", (gun+"."+ay+"."+ yil));
            cmd.ExecuteNonQuery();
            connect.Close();
            connect.Dispose();
        }

        void maxTestID()
        {

            SqlConnection connect = con.baglan();
            SqlCommand cmdQuestion = new SqlCommand("select max(t.testID) as testID ,t.userID  from test t where t.userID=" + Session["UserID"] + " GROUP BY userID ", connect);
            SqlDataReader read = cmdQuestion.ExecuteReader();
            while (read.Read())
            {
                lblTestID.Text = read["testID"].ToString();
              
            }

            connect.Close();
            connect.Dispose();  
        }

        [Obsolete]
        void replyInsert()
        {

            if (lblReplyID.Text=="")
            { 
                lblError.Text = "Lütfen Soru Şıkkı Seçiniz.";
            }
            else
            {

                SqlConnection connect = con.baglan();
                SqlCommand cmd = new SqlCommand("insert into userReply (testID,questionID,trueReplyID)values (@TESTID,@QUESTIONID,@REPLY)", connect);
                cmd.Parameters.Add("@TESTID",Convert.ToInt32(lblTestID.Text));
                cmd.Parameters.Add("@QUESTIONID",questionsID);
                cmd.Parameters.Add("@REPLY", Convert.ToInt32(lblReplyID.Text));
                cmd.ExecuteNonQuery();
                connect.Close();
                connect.Dispose();

            }



            

        }

        protected void lesson()
        {

            DataTable dtLesson = con.GetDataTable("select * from lesson order by lessonName");
            drpLesson.DataSource = dtLesson;
            drpLesson.DataTextField = "lessonName";
            drpLesson.DataValueField = "lessonID";
            drpLesson.DataBind();

        }
    }
}