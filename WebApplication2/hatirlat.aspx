<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hatirlat.aspx.cs" Inherits="WebApplication2.hatirlat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    
    <link rel="stylesheet" type="text/css" href="style-def.css" />
 

    </head>
<body>
    <form id="form1" runat="server">
        <div id="ust"></div>
        <div id="logo">
            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"  />
            <br />
        </div>
        <div id="menu">
            <a href="#"><div id="iletisim"></div></a><a href="#"><div id="hakkimizda"></div></a><a href="#"><div id="anasayfa"></div></a>
        </div>
        <div id="giris">
            <div id="hatirlat">
                <asp:TextBox ID="TextBox3" runat="server" BackColor="#B03500" BorderColor="#F24800" BorderStyle="Dotted" BorderWidth="2px" ForeColor="#999999" Height="24px" Width="140px" TabIndex="1" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium">Kullanıcı Adı</asp:TextBox>      
                
                <asp:Button ID="Button2" runat="server" Text="Gönder" Width="144px" Height="30px" TabIndex="2" OnClick="Button2_Click"  />      
                
                <br />
                
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
                
                <br />
                <asp:TextBox ID="TextBox5" runat="server" BackColor="#B03500" BorderColor="#F24800" BorderStyle="Dotted" BorderWidth="2px" ForeColor="#999999" Height="24px" Width="460px" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium" ReadOnly="True">Gizli Soru</asp:TextBox>      
                
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White"></asp:Label>
                
                <br />
                <br />
                <asp:TextBox ID="TextBox4" runat="server" BackColor="#B03500" BorderColor="#F24800" BorderStyle="Dotted" BorderWidth="2px" ForeColor="#999999" Height="24px" Width="180px" TabIndex="3" Font-Bold="False" Font-Names="Calibri" Font-Size="Medium">Cevap</asp:TextBox>      
                <asp:Button ID="Button3" runat="server" Text="Cevapla" Width="146px" Height="30px" TabIndex="4" OnClick="Button3_Click" Visible="False"  />      
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Text="Şifreniz: " Visible="False"></asp:Label>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Visible="False"></asp:Label>
                <asp:Button ID="Button4" runat="server" Text="Göster/Gizle" Width="90px" Height="20px" TabIndex="5" OnClick="Button4_Click" Visible="False"  />      
                </div>
            
           
        </div>

        <div id="footer">          
            © Online Sınav Portalı | Tüm Hakları Saklıdır.</div><div></div>
    </form>
</body>
</html>