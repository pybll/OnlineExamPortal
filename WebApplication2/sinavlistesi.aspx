<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sinavlistesi.aspx.cs" Inherits="WebApplication2.sinavlistesi" %>

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
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" />
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
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="sinavaktar" DataTextField="sinav_adi" DataValueField="sinav_adi" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:AccessDataSource ID="sinavaktar" runat="server" DataFile="~/App_Data/eegitim.accdb" SelectCommand="SELECT * FROM [tblsinav_durum] ORDER BY [sinav_adi]"></asp:AccessDataSource>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Durum:" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
            <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Tarih:" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
            <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Saat:" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
            <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sınavı Başlat" />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Medium" ForeColor="#FFCC00"></asp:Label>
            
            
            <br />
        </div>
    </form>
</body>
</html>