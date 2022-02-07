<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logo-y.aspx.cs" Inherits="WebApplication2.logo_y" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style-admin.css" />
    <style type="text/css">
        .auto-style1
        {
            width: 217px;
        }
        .auto-style2 {
            width: 242px;
        }
        .auto-style3 {
            width: 160px;
        }
        .auto-style4 {
            width: 477px;
        }
    </style>
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
                    <div id="logina-hosgeldiniz">SAYIN <asp:Label ID="Label1" Class="isimsoyisim" runat="server" Text="İSİM SOYİSİM" /> &nbsp;HOŞGELDİNİZ<br />
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton2_Click" >ANASAYFA</asp:LinkButton>
                    &nbsp;|
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton2_Click" >PROFİL YÖNETİMİ</asp:LinkButton>
                    &nbsp;| <asp:LinkButton ID="LinkButton1" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton1_Click" >ÇIKIŞ YAP</asp:LinkButton>
                    </div>
                </div> 
            </div>
        <div id="cizgi"></div>
        <div id="yy">

           <table>
               <tr>
                   <td class="auto-style2">
                       <asp:Label ID="Label3" runat="server" Text="Yeni Logo" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
                   </td>
                   <td class="auto-style3">

                       <asp:Label ID="Label4" runat="server" Text="Mevcut Logolar" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>

                   </td>
                   <td class="auto-style4">
                    
                       <asp:Label ID="Label5" runat="server" Text="Önizleme" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Visible="False"></asp:Label>

                   </td>
               </tr>
               <tr>
                   <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" Width="208px" Font-Names="Calibri">Logo Adı</asp:TextBox>
                   </td>
                   <td rowspan="3" valign="top" class="auto-style3">
                       <asp:ListBox ID="ListBox1" runat="server" Width="125px" Height="100px" Font-Names="Calibri" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" DataSourceID="AccessDataSource1" DataTextField="isim" DataValueField="isim"></asp:ListBox>
                   </td>
                   <td rowspan="2" valign="top" class="auto-style4">
                       <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server" Height="45px" TextMode="MultiLine" Width="207px" Font-Names="Calibri">Logo Açıklama</asp:TextBox>
                   </td>
                  
               </tr>
               <tr>
                   <td class="auto-style2">
                        <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="Calibri" />
                   </td>
                   <td valign="top" class="auto-style4" rowspan="3">
                       
                       <asp:Label ID="Label7" runat="server" ForeColor="White"></asp:Label>
                       
                   </td>         
               </tr>
               <tr>
                   <td class="auto-style2">
                        <asp:Button ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click" height="25px" width="125px" Font-Names="Calibri" />
                   </td>
                       <td class="auto-style3">
                       <asp:Button ID="Button2" runat="server" Text="Yükle" Width="63px" Height="25px" Font-Names="Calibri" OnClick="Button2_Click" />
                           <asp:Button ID="Button3" runat="server" Font-Names="Calibri" Height="25px" OnClick="Button3_Click" Text="Sil" Width="63px" />
                   </td>    
                     
               </tr>
               <tr>
                   <td class="auto-style1" colspan="2">
                       <asp:Label ID="Label8" runat="server" Text="*Resim türü 'png' olmalıdır." Font-Bold="True" ForeColor="#FF6600"></asp:Label><br />
                       <asp:Label ID="Label2" runat="server" Font-Names="Calibri" ForeColor="White" Font-Size="Small">Tavsiye edilen boyutlar: <br /> Width=&#39;400&#39; - &#39;640&#39; Heigth=&#39;60&#39; - &#39;100&#39;</asp:Label>
                       <br />
                   </td>

               </tr>
           </table>
            <br />
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/eegitim.accdb" SelectCommand="SELECT [isim] FROM [tbllogo]"></asp:AccessDataSource>
        </div>
    </form>
</body>
</html>
