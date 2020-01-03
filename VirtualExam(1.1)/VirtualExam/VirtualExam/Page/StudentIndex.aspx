<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Student.Master" AutoEventWireup="true" CodeBehind="StudentIndex.aspx.cs" Inherits="VirtualExam.Page.StudentIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Student.css" rel="stylesheet" />
    <script type="text/javascript">

      
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:Panel ID="pnlSubject" runat="server">
            <div class="drpSubject title">
                <p class="title">Ders Seçiniz :</p> 
                <asp:DropDownList CssClass="drp" ID="drpLesson" runat="server" AutoPostBack="True"></asp:DropDownList>
            <br /><br />
                
                <br />
                <br />
            </div>
      
        <div class="drpStart">
            <asp:Button ID="btnStart" CssClass="btn" runat="server" Text="Start" OnClick="btnStart_Click" />
        
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlQuestions" Visible="false" runat="server">
        <div class="questions-box" > 
           <div class="left-arrow">
           </div>
            
            <div class="questions">
                             <div class="questions-text">
                                  <p>
                                      <asp:Label ID="lblQuestionCount" runat="server" ></asp:Label>
                                      <asp:Image ID="imgQuestion" Visible="false" runat="server" />
                                      <asp:Label ID="lblQuestion" Visible="false" runat="server" ></asp:Label>
                                   
                                 </p>
                            </div>

                            <div class="questions-stylish">
                                <div class="a">
                                    <span><b>A : </b></span>    
                                    <span class="text">
                                         
                                        <asp:RadioButton ID="rbA" Checked="true" runat="server" AutoPostBack="true" GroupName="reply" OnCheckedChanged="rbA_CheckedChanged" Visible="false"/>
                                        <asp:Image ID="imgA" Visible="false" runat="server" />
                                       
                                    </span>
                                </div>

                                <div class="b">
                                    <span><b>B : </b></span>
                                    <span class="text">
                                         <asp:RadioButton ID="rbB" runat="server" AutoPostBack="true" GroupName="reply" OnCheckedChanged="rbB_CheckedChanged" Visible="false" />
                                        <asp:Image ID="imgB" Visible="false" runat="server" />
                                         
                                      
                                     </span>
                                </div>

                                <div class="c">
                                    <span><b>C : </b></span>
                                    <span class="text">
                                      
                                          <asp:RadioButton ID="rbC" runat="server" AutoPostBack="true" GroupName="reply" OnCheckedChanged="rbC_CheckedChanged" Visible="false"/>
                                          <asp:Image ID="imgC" Visible="false" runat="server" />
                                        
                                     </span>
                                </div>

                                <div class="d">
                                    <span><b>D : </b></span>
                                    <span class="text">
                                       
                                        <asp:RadioButton ID="rbD" runat="server" AutoPostBack="true" GroupName="reply" OnCheckedChanged="rbD_CheckedChanged" Visible="false" />
                                         <asp:Image ID="imgD" Visible="false" runat="server" />
                                         
                                     </span>
                                </div>

                                <div class="d">
                                    <span><b>Boş Geç : </b></span>
                                    <span class="text">
                                       
                                        <asp:RadioButton ID="rbNull" runat="server" AutoPostBack="true" GroupName="reply" OnCheckedChanged="rbNull_CheckedChanged"  />
                                       
                                         
                                     </span>
                                </div>

                            </div>


               
                
            </div>

                    
            <div class="right-arrow">
                <asp:Button ID="btnNext" CssClass="btnNext" runat="server"  OnClick="btnNext_Click"    />
                
            </div>
            <asp:Label ID="lblTestID" Visible="false" runat="server" ></asp:Label>
            <asp:Label ID="lblReplyID" Visible="false" runat="server" ></asp:Label>

           
           

            
        </div>
    </asp:Panel>
   <asp:Label ID="lblError" runat="server" ></asp:Label>
</asp:Content>
