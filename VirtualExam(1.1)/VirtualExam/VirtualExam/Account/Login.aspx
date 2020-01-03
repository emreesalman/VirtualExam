<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VirtualExam.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/Login.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Alatsi&display=swap" rel="stylesheet"/> 
    <link href="https://fonts.googleapis.com/css?family=Ubuntu&display=swap" rel="stylesheet"/>
    
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
                       <h3>This is your Virtual Test System!</h3>
                   </div>

                </div>
                 <%-----------------------------------------------------------------------------------------------%>
                <div class="form-box">

                   <div class="form-group">
                     <label>Email</label>
                    <asp:TextBox ID="txtUsername" pattern="[A-Za-z0-9_]{1,15}$" runat="server" placeholder="emin.borandag@cbu.edu.tr" MaxLength="20" MinLength="4"  required title="Kullanıcı adınız [A-Za-z0-9_] biçiminde 4-20 karakter arasında olmalıdır." ></asp:TextBox>
                   </div>

                    <div class="form-group">
                        <label>Password</label>                   
                        <asp:TextBox ID="txtUserPassword"  pattern="[A-Za-z0-9_]{1,15}$"  runat="server" required TextMode="Password" MaxLength="12" MinLength="4"></asp:TextBox>    
                    </div>

                     <div class="form-group">
                        
                         <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
                     </div>
                    <asp:Label ID="lblError" CssClass="lblError" runat="server" ></asp:Label>
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
