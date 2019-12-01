<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VirtualExam.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Alatsi&display=swap" rel="stylesheet"/> 
    <link href="https://fonts.googleapis.com/css?family=Ubuntu&display=swap" rel="stylesheet"/>
     <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.13/css/all.css" integrity="sha384-DNOHZ68U8hZfKXOrtjWvjxusGo9WQnrNx2sqG0tfsghAvtVlRW3tvkXWZh58N9jp"  crossorigin="anonymous"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-box">

            <div class="content-box">
            <%-----------------------------------------------------------------------------------------------%>
                <div class="logo-box">
                 
                    <div class="welcome">  
                        <h1 >Welcome</h1>
                    </div>
                 
                    <div class="login-text">
                       <h3>This your Virtual Test System!</h3>
                   </div>

                </div>
                 <%-----------------------------------------------------------------------------------------------%>
                <div class="form-box">

                   <div class="form-group">
                     <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                   </div>

                    <div class="form-group">
                        <label>Password</label>                   
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>               
                    </div>

                     <div class="form-group">
                        
                         <asp:Button ID="btnLogin" runat="server" Text="LOGIN" />
                     </div>
                    </div>
                 <%-----------------------------------------------------------------------------------------------%>
                  <div class="footer-box">
                     <p>© Uğur ÇİFTÇİ - Emre ŞİMŞEK 2019 - Tüm Hakları Saklıdır.</p>


                </div>
                 <%-----------------------------------------------------------------------------------------------%>
            </div>
           
        </div>
    </form>
</body>
</html>
