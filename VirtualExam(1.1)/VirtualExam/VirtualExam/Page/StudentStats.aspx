<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Student.Master" AutoEventWireup="true" CodeBehind="StudentStats.aspx.cs" Inherits="VirtualExam.Page.StudentStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/Student.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="student-stats">

       
        <div class="detailTitle">
            <div class="detailNumber" >
                <p>Question Reply</p>
            </div>
            <div class="detailName" >
                  <p>Lesson Stats</p>
            </div>
            <div class="detailLink">
                  <p>Link</p>
            </div>
              
        </div>

        <div class="detailContent">

             <asp:DataList ID="dataTest" Width="100%" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
               <ItemTemplate>
                     <div class="testID">
                            <%# Eval("testID")%>
                       </div>
                        <div class="userName">
                          <%# Eval("userName")%>
                       </div>
                        <div class="detail">
                           <a href="StudentStatsDetail.aspx?testID=<%# Eval("testID")%>">Detail</a>
                     </div>
                         
               </ItemTemplate>
            </asp:DataList> 
          
           

        </div>
         
    </div>



</asp:Content>
