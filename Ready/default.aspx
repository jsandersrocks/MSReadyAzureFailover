<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ready._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
     <meta charset=utf-8>
    <meta http-equiv=X-UA-Compatible content="IE=edge,chrome=1">
    <title>MSReady Sample using Sticky Footer &mdash; Solved by Flexbox &mdash; Cleaner, hack-free CSS</title>
    <meta name=HandheldFriendly content=True>
    <meta name=MobileOptimized content=320>
    <meta name=viewport content="width=device-width,minimum-scale=1,maximum-scale=1">
    <meta name=google-site-verification content=q5KncOje-dNdD5uxqSOG1znSAo5Wsz5MlBcAmteQAJA>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600" rel=stylesheet>
    <link href=https://netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.min.css rel=stylesheet>
    <link href=/css/main.css rel=stylesheet type=text/css> 
        </head> <body class=Site>

            <header class=Site-header>
            <div class="Header Header--cozy" role=banner>
                <div class=Header-titles>
                    <asp:Label class=Header-title ID="headertitle" runat="server" Text=""></asp:Label>
                    </br>
                    <asp:Label class=Header-subTitle  ID="headersubtitle" runat ="server" Text=""></asp:Label>
                </div>
        </header>
        <main class=Site-content>
            <div class=Container>
                <h1>List of things</h1>
                <div class="Demo Demo--spaced">
                    <asp:Label ID="description" runat="server" Text=""></asp:Label>
                    
                </div>
                <form id="form1" runat="server">
            <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" /><br />
            <asp:ListBox runat="server" ID ="ListBox1" > </asp:ListBox><br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Refesh" />
                </br>
            <label>Hitting Web Server: </label><asp:Label ID="WebSiteName" runat="server" Text="WebSiteName"></asp:Label>
        </div>

        <asp:Label  ID="message" runat="server"></asp:Label>
    </form>
            </div>
        </main>
        <footer class=Site-footer>
            <div class=Footer>
                <div class=Footer-credits><span class=Footer-credit>See my Blog <a
                            href="http://jsandersblog.azurewebsites.net" target="_blank">Jeff Sanders</a>. </span> </div>
            </div>
        </footer>
        <script>!function () { var e = document.body.style; if (!("flexBasis" in e || "msFlexAlign" in e || "webkitBoxDirection" in e)) { var o = document.createElement("div"); o.className = "Error", o.innerHTML = "Your browser does not support Flexbox.  Parts of this site may not appear as expected.", document.body.insertBefore(o, document.body.firstChild) } }()</script>
      
    
</body>
</html>
