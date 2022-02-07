<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminpanel.aspx.cs" Inherits="WebApplication2.adminpanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style-admin.css" />
</head>
<body>
    <form id="form1" runat="server">
            <div id="logina-ust">
                <div id="logina-tatata">
                    <asp:Image ID="Image1" runat="server" Height="160px" Width="146px" />
                </div>
                <div id="logina-logo">
                    <asp:ImageButton ID="ImageButton1" runat="server" />
                    <br />
                    <div id="logina-hosgeldiniz">SAYIN <asp:Label ID="Label1" Class="isimsoyisim" runat="server" Text="İSİM SOYİSİM"/> &nbsp;HOŞGELDİNİZ<br />
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton3_Click" >ANASAYFA</asp:LinkButton>
                    &nbsp;|
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="hosgeldinizlink" >PROFİL YÖNETİMİ</asp:LinkButton>
                    &nbsp;| <asp:LinkButton ID="LinkButton1" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton1_Click" >ÇIKIŞ YAP</asp:LinkButton>
                    </div>
                </div> 
            </div>
        <div id="cizgi"></div>
        <div id="tasarim-yonetimi"><img src="Images/tasarimyonetimi.png" height="34"/><br />
            <img src="Images/kat-cizgi.png" height="5" width="850"/><br /><br />
            <a href="logo-y.aspx"><img src="Images/logodegis.png" border="0" height="64"/></a>
            <a href="#"><img src="Images/aprenk.png" border="0" height="64"/></a>
            <a href="#"><img src="Images/apresim.png" border="0" height="64"/></a>
        </div>
        <div id="eklekaldirdegistir"><img src="Images/eklekaldirdegistir.png" height="40"/><br />
            <img src="Images/kat-cizgi.png" height="5" width="850" /><br /><br />
            <a href="ogretmen-y.aspx"><img src="Images/ogretmen-y.png" border="0" height="64" /></a>
            <a href="ogrenci-y.aspx"><img src="Images/ogrenci-y.png" border="0" height="64" /></a>
            <a href="#"><img src="Images/duyuru-y.png" border="0" height="64"/></a>
            <a href="yonetici-y.aspx"><img src="Images/yonetici-y.png" border="0" height="64"/></a>
        </div>
        <div>

        </div>
    </form>
</body>
</html>