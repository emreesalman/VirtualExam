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
    public partial class RemoveQuestions : System.Web.UI.Page
    {
        conn con = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userID"] == null)

            {
               Response.Redirect("~/Account/Login.aspx");

            }
            if (Page.IsPostBack == false)
            {
                lesson();
                drpLesson.Items.Insert(0, new ListItem("Seçiniz", "0"));
                drpSubject.Items.Insert(0, new ListItem("Seçiniz", "0"));
            }


            if (Request.QueryString["questionID"] != null)
            {
                string questionID = Request.QueryString["questionID"];
                SqlConnection connect = con.baglan();
                SqlCommand cmdReply = new SqlCommand("delete FROM reply WHERE questionID="+questionID, connect);
                if (cmdReply.ExecuteNonQuery() == 0)

                {
                    connect.Close();
                    connect.Dispose();
                }
                else
                {
                    SqlCommand cmdQuestion = new SqlCommand("delete FROM question WHERE questionID=" + questionID, connect);
                    if(cmdQuestion.ExecuteNonQuery()==0)
                    {
                        connect.Close();
                        connect.Dispose();
                    }
                    else
                    {
                        Response.Redirect("RemoveQuestions.aspx");
                    }
                }

            }

        }
        protected void lesson()
        {

            DataTable lesson = con.GetDataTable("select * from lesson order by lessonName");
            drpLesson.DataSource = lesson;
            drpLesson.DataTextField = "lessonName";
            drpLesson.DataValueField = "lessonID";
            drpLesson.DataBind();
        }
        protected void subject()
        {

            DataTable subject = con.GetDataTable("select * from [subject] where  lessonID='" + drpLesson.SelectedValue + "'");
            drpSubject.DataSource = subject;
            drpSubject.DataTextField = "subjectName";
            drpSubject.DataValueField = "subjectID";
            drpSubject.DataBind();
        }

        protected void drpLesson_SelectedIndexChanged(object sender, EventArgs e)
        {

            subject();
            drpSubject.Items.Insert(0, new ListItem("Seçiniz", "0"));
            lblSubject.Visible = true;
            drpSubject.Visible = true;
        }

        

        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlQuestions.Visible = true;

            DataTable dtQuestionsInfo = con.GetDataTable("select qs.questionID,qs.userID,sj.subjectID,sj.subjectName,qs.questionName from question qs inner join [subject] sj on qs.subjectID=sj.subjectID where sj.subjectID='" + drpSubject.SelectedItem.Value + "' and qs.userID='" + Session["userID"] + "'");

            dtQuestions.DataSource = dtQuestionsInfo;

            dtQuestions.DataBind();


          
        }
    }
}