<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Teacher.Master" AutoEventWireup="true" CodeBehind="TeacherIndex.aspx.cs" Inherits="VirtualExam.Page.TeacherIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="student-list">

        
        <div class="table">

           
                <div class="thead">
                    <div class="th">Number</div>
                    <div class="th">Name</div>
                    <div class="th">Surname</div>
                    <div class="th">Statistic</div>
                </div>
            
           
                <asp:DataList ID="dtStudent" Width="100%" runat="server">
                    <ItemTemplate>
                       <div class="tbody">
                    
                                <div class="td"><%#Eval("userID") %></div>
                                <div class="td"><%#Eval("name") %></div>
                                <div class="td"><%#Eval("surname") %></div>
                                <div class="td"><%#Eval("phone") %></div>
                         
                      </div>
                     </ItemTemplate>
                </asp:DataList> 


        </div>
                     


    </div>


</asp:Content>
