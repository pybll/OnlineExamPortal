<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ogretmenpanel.aspx.cs" Inherits="WebApplication2.ogretmenpanel" %>

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
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton2_Click" >PROFİL YÖNETİMİ</asp:LinkButton>
                    &nbsp;| <asp:LinkButton ID="LinkButton1" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton1_Click" >ÇIKIŞ YAP</asp:LinkButton>
                    </div>
                </div> 
            </div>
        <div id="cizgi"></div>
        <div>
            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" ForeColor="White">Soru bankası</asp:LinkButton> 
            &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" ForeColor="White">Sınav Hazırla</asp:LinkButton> 
            &nbsp;<asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" ForeColor="White">Sınav Durumları</asp:LinkButton>
        </div>
    </form>
</body>
</html>