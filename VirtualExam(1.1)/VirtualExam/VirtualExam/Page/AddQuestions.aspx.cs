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
    public partial class AddQuestions : System.Web.UI.Page
    {
        conn con = new conn();
        int reply=0;
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
           

        }
        protected void drpLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            subject();
            drpSubject.Items.Insert(0, new ListItem("Seçiniz", "0"));
            drpSubject.Visible = true;
            lblKonu.Visible = true;
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

        [Obsolete]
       
        protected void btnNext_Click(object sender, EventArgs e)
        {
            if(rbText.Checked)
            {
                
                pnlText.Visible = true;
                pnlImages.Visible = false;
            }
            else if(rbImages.Checked)
            {
                
                pnlImages.Visible = true;
                pnlText.Visible = false;
            }
            btnNext.Visible = false;
            btnInsert.Visible = true;
            pnlDrp.Visible = false;

            lblKonu.Visible = false;
            lblDers.Visible = false;
            drpSubject.Visible = false;
            drpLesson.Visible = false;
            pnlReply.Visible = true;


        }

        [Obsolete]
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtAddQuestion.Text.Length<5 )
            {
               
                lblError1.Text = "Lütfen İçerik Doldurunuz.";
            }
            else
            {

            }

            if (rbA.Checked)
            {
                reply = 1;
            }
            else if (rbB.Checked)
            {
                reply = 2;
            }
            else if (rbC.Checked)
            {
                reply = 3;
            }
            else if (rbD.Checked)
            {
                reply = 4;
            }
            if (reply!=0)
            {
               
                if (rbText.Checked)
                {
                    SqlConnection connect = con.baglan();
                    SqlCommand cmd = new SqlCommand("insert into question (userID,subjectID,questionName,isText) values (@USERID,@SUBJECTID,@QUESTIONSNAME,@ISTEXT)", connect);
                    cmd.Parameters.Add("@USERID", Session["userID"]);
                    cmd.Parameters.Add("@SUBJECTID", drpSubject.SelectedItem.Value);
                    cmd.Parameters.Add("@QUESTIONSNAME", txtAddQuestion.Text);
                    cmd.Parameters.Add("@ISTEXT", "0");


                    if (cmd.ExecuteNonQuery() == 0)

                    {
                        connect.Close();
                        connect.Dispose();
                    }
                    else
                    {
                        DataRow drQuestions = con.GetDataRow("select * from [question]  where CONVERT(NVARCHAR(MAX), questionName)='" + txtAddQuestion.Text + "'");
                        if (drQuestions["questionID"] != null)
                        {
                            SqlCommand replyCmd = new SqlCommand("insert into reply (questionID,a,b,c,d,trueReplyID) values(@QUESTIONSID,@A,@B,@C,@D,@TRUEREPLY)", connect);
                            replyCmd.Parameters.Add("@QUESTIONSID", drQuestions["questionID"]);
                            replyCmd.Parameters.Add("@A", A.Text);
                            replyCmd.Parameters.Add("@B", B.Text);
                            replyCmd.Parameters.Add("@C", C.Text);
                            replyCmd.Parameters.Add("@D", D.Text);

                            replyCmd.Parameters.Add("@TRUEREPLY", reply);
                            replyCmd.ExecuteNonQuery();
                            Response.Redirect("RemoveQuestions.aspx");
                        }
                        else
                        {
                            connect.Close();
                            connect.Dispose();
                        }
                    }

                }
                else if (rbImages.Checked)
                {
                    if (fuA.PostedFile.ContentType == "image/png" && fuB.PostedFile.ContentType == "image/png" && fuC.PostedFile.ContentType == "image/png" && fuD.PostedFile.ContentType == "image/png")
                    {
                        if (fuA.PostedFile.ContentLength < 5000000 && fuD.PostedFile.ContentLength < 5000000 && fuC.PostedFile.ContentLength < 5000000 && fuD.PostedFile.ContentLength < 5000000)
                        {
                            if (fuA.HasFile && fuB.HasFile && fuC.HasFile && fuD.HasFile && fuQuestion.HasFile)
                            {
                                SqlConnection connect = con.baglan();

                                Random rnd = new Random();


                                fuQuestion.PostedFile.SaveAs(Server.MapPath("~/upload/") + Session["userID"].ToString() + fuQuestion.FileName.ToString());

                                SqlCommand cmd = new SqlCommand("insert into question (userID,subjectID,questionName,isText) values (@USERID,@SUBJECTID,@QUESTIONSNAME,@ISTEXT)", connect);
                                cmd.Parameters.Add("@USERID", Session["userID"]);
                                cmd.Parameters.Add("@SUBJECTID", drpSubject.SelectedItem.Value);
                                cmd.Parameters.Add("@QUESTIONSNAME", Session["userID"].ToString() + fuQuestion.FileName.ToString());
                                cmd.Parameters.Add("@ISTEXT", "1");
                                if (cmd.ExecuteNonQuery() == 0)

                                {
                                    connect.Close();
                                    connect.Dispose();
                                }
                                else
                                {
                                    DataRow drQuestions = con.GetDataRow("select * from [question]  where CONVERT(NVARCHAR(MAX), questionName)='" + Session["userID"].ToString() + fuQuestion.FileName.ToString() + "'");
                                    if (drQuestions["questionID"] != null)
                                    {

                                        fuA.PostedFile.SaveAs(Server.MapPath("~/upload/") + drQuestions["questionID"].ToString() + fuA.FileName.ToString());
                                        fuB.PostedFile.SaveAs(Server.MapPath("~/upload/") + drQuestions["questionID"].ToString() + fuB.FileName.ToString());
                                        fuC.PostedFile.SaveAs(Server.MapPath("~/upload/") + drQuestions["questionID"].ToString() + fuC.FileName.ToString());
                                        fuD.PostedFile.SaveAs(Server.MapPath("~/upload/") + drQuestions["questionID"].ToString() + fuD.FileName.ToString());

                                        SqlCommand replyCmd = new SqlCommand("insert into reply (questionID,a,b,c,d,trueReply) values(@QUESTIONSID,@A,@B,@C,@D,@TRUEREPLY)", connect);
                                        replyCmd.Parameters.Add("@QUESTIONSID", drQuestions["questionID"]);
                                        replyCmd.Parameters.Add("@A", drQuestions["questionID"].ToString() + fuA.FileName.ToString());
                                        replyCmd.Parameters.Add("@B", drQuestions["questionID"].ToString() + fuB.FileName.ToString());
                                        replyCmd.Parameters.Add("@C", drQuestions["questionID"].ToString() + fuC.FileName.ToString());
                                        replyCmd.Parameters.Add("@D", drQuestions["questionID"].ToString() + fuD.FileName.ToString());
                                        replyCmd.Parameters.Add("@TRUEREPLY", reply);
                                        replyCmd.ExecuteNonQuery();

                                        Response.Redirect("RemoveQuestions.aspx");


                                    }
                                    else
                                    {
                                        connect.Close();
                                        connect.Dispose();
                                    }
                                }
                            }
                            else
                            {
                                lblError.Visible = true;
                                lblError.Text = "Dosya Yüklenemedi.";
                            }
                        }
                        else
                        {
                            lblError.Visible = true;
                            lblError.Text = "Dosya boyutu uygun değil.";
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Dosya uzantısı uygun değil.";
                    }


                }

            }
            else
            {
                lblError1.Visible = true;
                lblError1.Text = "Hatalı İşlem";
            }
}

        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnNext.Visible = true;
            
            pnlDrp.Visible = true;
        }

        protected void txtAddQuestion_TextChanged(object sender, EventArgs e)
        {
            int uzunluk = txtAddQuestion.Text.Count();
            if (uzunluk<5)
            {
               
            }
          
        }
    }
}