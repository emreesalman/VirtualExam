<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Teacher.Master" AutoEventWireup="true" CodeBehind="AddQuestions.aspx.cs" Inherits="VirtualExam.Page.AddQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Quicksand&display=swap" rel="stylesheet">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="addQuestions">
     
        <asp:Label ID="lblDers" CssClass="title"   runat="server" Text="Ders Seçiniz:"></asp:Label>
       
        <asp:DropDownList CssClass="drp"  ID="drpLesson" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpLesson_SelectedIndexChanged">
           
        </asp:DropDownList>
        <asp:Label ID="lblKonu" CssClass="title" Visible="false"  runat="server" Text="Konu Seçiniz:"></asp:Label>
        
        <asp:DropDownList CssClass="drp" visible="false"  ID="drpSubject" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSubject_SelectedIndexChanged">
           
        </asp:DropDownList>
        <asp:Panel ID="pnlDrp" runat="server" Visible="false" class="title" >

            <asp:RadioButton ID="rbText" Checked="true" runat="server" GroupName="questions" />&nbsp;&nbsp;Yazılı Soru Ekle
            <br />
            <asp:RadioButton ID="rbImages" runat="server" GroupName="questions" />&nbsp;&nbsp;Resimli Soru Ekle
      
        </asp:Panel>
        <asp:Panel ID="pnlText" runat="server" Visible="false">
            <asp:Label ID="lblError1" runat="server" Text="Label"></asp:Label>
            <div id="text"    >
                 <p class="title">Yazılı Soru Ekleme:</p>
                 <asp:TextBox Width="100%" Height="80px" MaxLength="500" ID="txtAddQuestion" min="5"  runat="server" OnTextChanged="txtAddQuestion_TextChanged" ></asp:TextBox>
         
                <br /><br />
                 <div  ><p class="title">Reply A:</p> <asp:TextBox ID="A" MinLength="1"  MaxLength="500" Width="100%" Height="30px" runat="server" ></asp:TextBox></div>
                    <br />
                 <div ><p class="title">Reply B:</p> <asp:TextBox ID="B" MinLength="1" MaxLength="500"  Width="100%" Height="30px" runat="server" ></asp:TextBox></div>
                <br />
                 <div ><p class="title">Reply C:</p> <asp:TextBox ID="C"  MinLength="1" Width="100%" Height="30px" runat="server" ></asp:TextBox></div>
                <br />
                 <div ><p class="title">Reply D:</p> <asp:TextBox ID="D"  MinLength="1"  Width="100%" Height="30px" runat="server" ></asp:TextBox></div>
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlImages" runat="server" Visible="false">
             <div id="images" >
                 <p class="title">Resimli Soru Ekleme:</p><br /><br />
             
                <asp:FileUpload ID="fuQuestion" runat="server" />
                 <br /><br /><br />
                 <div ><p class="title">Reply A:</p><br /> <asp:FileUpload ID="fuA" runat="server" /></div>
                 <br />
                 <div ><p class="title">Reply B:</p><br /> <asp:FileUpload ID="fuB" runat="server" /></div>
                 <br />
                 <div ><p class="title">Reply C:</p><br /><asp:FileUpload ID="fuC" runat="server" /></div>
                 <br />
                 <div ><p class="title">Reply D:</p> <br /><asp:FileUpload ID="fuD" runat="server" /></div>
                 <br />
                 <asp:Label ID="lblError" Visible="false" CssClass="lblError" runat="server" Text="Lütfen Boş Geçmeyiniz."></asp:Label>
            </div>
        </asp:Panel>
        <br /><br />
        <asp:Panel ID="pnlReply" Visible="false" runat="server">
            <p class="title">Reply A:&nbsp;</p> <asp:RadioButton ID="rbA" Checked="true" runat="server" GroupName="reply" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <p class="title">Reply B:&nbsp;</p><asp:RadioButton ID="rbB" runat="server" GroupName="reply" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <p class="title">Reply C:&nbsp;</p><asp:RadioButton ID="rbC" runat="server" GroupName="reply" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <p class="title">Reply D:&nbsp;</p><asp:RadioButton ID="rbD" runat="server" GroupName="reply" />&nbsp;&nbsp;&nbsp;
        </asp:Panel>

        <br /><br />
        <asp:Button ID="btnNext" CssClass="btn" runat="server" Text="Next" Visible="false" OnClick="btnNext_Click" />
        <asp:Button ID="btnInsert" CssClass="btn" runat="server" Text="Add" OnClick="btnInsert_Click" Visible="false" />
       

    </div>


</asp:Content>
