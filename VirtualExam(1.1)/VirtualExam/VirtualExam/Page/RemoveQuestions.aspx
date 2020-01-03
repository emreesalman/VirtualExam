<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Teacher.Master" AutoEventWireup="true" CodeBehind="RemoveQuestions.aspx.cs" Inherits="VirtualExam.Page.RemoveQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://fonts.googleapis.com/css?family=Quicksand&display=swap" rel="stylesheet">
    <link href="../Style/Teacher.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="removeQuestions">
        
        <asp:Label ID="lblLesson" CssClass="remove-title" runat="server" Text="Ders Seçiniz:"></asp:Label>  
        <asp:DropDownList CssClass="drpRemove"  ID="drpLesson" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpLesson_SelectedIndexChanged">
           
        </asp:DropDownList>
         <asp:Label ID="lblSubject" Visible="false"  CssClass="remove-title"  runat="server" Text="Konu Seçiniz:"></asp:Label>  
       
        <asp:DropDownList CssClass="drpRemove" Visible="false"   ID="drpSubject" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubject_SelectedIndexChanged">
         
        </asp:DropDownList>
        
       
        
        <asp:Panel ID="pnlQuestions" runat="server" Visible="false">
               <div class="table">

           
                    <div class="thead">
                        <div class="th">Number</div>
                        <div class="th">Subject</div>
                        <div class="th">Question</div>
                        <div class="th">Event</div>
                    </div>
            
               

                    <asp:DataList ID="dtQuestions" Width="100%" runat="server">
                        <ItemTemplate>
                           <div class="tbody">
                    
                                    <div class="td"><%#Eval("questionID") %></div>
                                    <div class="td"><%#Eval("subjectName") %></div>
                                    <div class="td"><%#Eval("questionName") %></div>
                                    <div class="td"><a href="RemoveQuestions.aspx?questionID=<%#Eval("questionID") %>">Delete</a></div>
                         
                          </div>
                         </ItemTemplate>
                    </asp:DataList> 


               </div>
        </asp:Panel>

    </div>






</asp:Content>
