<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sinavlar.aspx.cs" Inherits="WebApplication2.sinavlar" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" DataSourceID="sinavaktar" DataTextField="sinav_adi" DataValueField="sinav_adi" Font-Names="Calibri" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"></asp:RadioButtonList>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Names="Calibri" ForeColor="White" Text="Durum:"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" EnableTheming="True" Font-Names="Calibri">
                <asp:ListItem Value="0">Kapalı</asp:ListItem>
                <asp:ListItem Value="1">Aktif</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Label ID="Label2" runat="server" Font-Names="Calibri" ForeColor="White" Text="Sınav Tarihi (Gün/Ay/Yıl):" Visible="False"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="200px" Visible="False">0G/0A/YY</asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Width="80px" Visible="False">00:00</asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Kaydet" />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Tam bir tarih seçimi yapmak zorundasınız." ForeColor="White"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Tam bir saat seçimi yapmak zorundasınız." ForeColor="White"></asp:RequiredFieldValidator>
            &nbsp;<asp:AccessDataSource ID="sinavaktar" runat="server" DataFile="~/App_Data/eegitim.accdb" SelectCommand="SELECT [sinav_adi] FROM [tblsinav_durum]"></asp:AccessDataSource>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <br />
        </div>
    </form>
</body>
</html>