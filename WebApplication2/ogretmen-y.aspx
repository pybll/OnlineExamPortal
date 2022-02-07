<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ogretmen-y.aspx.cs" Inherits="WebApplication2.ogretmen_y" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style-admin.css" />
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        .auto-style2 {
            font-size: small;
            font-family: Calibri;
            color: #fff;
            width: 104px;
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
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton3_Click" >ANASAYFA</asp:LinkButton>
                    &nbsp;|
                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton2_Click" >PROFİL YÖNETİMİ</asp:LinkButton>
                    &nbsp;| <asp:LinkButton ID="LinkButton1" runat="server" CssClass="hosgeldinizlink" OnClick="LinkButton1_Click" >ÇIKIŞ YAP</asp:LinkButton>
                    </div>
                </div> 
            </div>
        <div id="cizgi"></div>
        <div id="yy">
            <asp:GridView  ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="kadi" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" PageSize="5" Font-Bold="False" Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Strikeout="False" Width="753px">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CancelText="İptal" DeleteText="Sil" EditText="Değiştir" InsertText="Ekle" NewText="Yeni" ShowInsertButton="True" UpdateText="Güncelle" />
                    <asp:BoundField DataField="kadi" HeaderText="K.Adı" ReadOnly="True" SortExpression="kadi" />
                    <asp:BoundField DataField="sifre" HeaderText="Şifre" SortExpression="sifre" />
                    <asp:BoundField DataField="ad" HeaderText="Ad" SortExpression="ad" />
                    <asp:BoundField DataField="soyad" HeaderText="Soyad" SortExpression="soyad" />
                    <asp:BoundField DataField="yetki" HeaderText="Yetki" SortExpression="yetki" />
                    <asp:BoundField DataField="mail" HeaderText="E-Mail" SortExpression="mail" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ogretmen %>" DeleteCommand="DELETE FROM [tblkullanici] WHERE (([kadi] = ?) OR ([kadi] IS NULL AND ? IS NULL)) AND (([sifre] = ?) OR ([sifre] IS NULL AND ? IS NULL)) AND (([ad] = ?) OR ([ad] IS NULL AND ? IS NULL)) AND (([soyad] = ?) OR ([soyad] IS NULL AND ? IS NULL)) AND (([mail] = ?) OR ([mail] IS NULL AND ? IS NULL)) AND (([yetki] = ?) OR ([yetki] IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO [tblkullanici] ([kadi], [sifre], [ad], [soyad], [mail], [yetki]) VALUES (?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:ogretmen.ProviderName %>" SelectCommand="SELECT [kadi], [sifre], [ad], [soyad], [mail], [yetki] FROM [tblkullanici] WHERE ([yetki] = ?)" UpdateCommand="UPDATE [tblkullanici] SET [sifre] = ?, [ad] = ?, [soyad] = ?, [mail] = ?, [yetki] = ? WHERE (([kadi] = ?) OR ([kadi] IS NULL AND ? IS NULL)) AND (([sifre] = ?) OR ([sifre] IS NULL AND ? IS NULL)) AND (([ad] = ?) OR ([ad] IS NULL AND ? IS NULL)) AND (([soyad] = ?) OR ([soyad] IS NULL AND ? IS NULL)) AND (([mail] = ?) OR ([mail] IS NULL AND ? IS NULL)) AND (([yetki] = ?) OR ([yetki] IS NULL AND ? IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_kadi" Type="String" />
                    <asp:Parameter Name="original_sifre" Type="String" />
                    <asp:Parameter Name="original_sifre" Type="String" />
                    <asp:Parameter Name="original_ad" Type="String" />
                    <asp:Parameter Name="original_ad" Type="String" />
                    <asp:Parameter Name="original_soyad" Type="String" />
                    <asp:Parameter Name="original_soyad" Type="String" />
                    <asp:Parameter Name="original_mail" Type="String" />
                    <asp:Parameter Name="original_mail" Type="String" />
                    <asp:Parameter Name="original_yetki" Type="String" />
                    <asp:Parameter Name="original_yetki" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="kadi" Type="String" />
                    <asp:Parameter Name="sifre" Type="String" />
                    <asp:Parameter Name="ad" Type="String" />
                    <asp:Parameter Name="soyad" Type="String" />
                    <asp:Parameter Name="mail" Type="String" />
                    <asp:Parameter Name="yetki" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="yetki" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="sifre" Type="String" />
                    <asp:Parameter Name="ad" Type="String" />
                    <asp:Parameter Name="soyad" Type="String" />
                    <asp:Parameter Name="mail" Type="String" />
                    <asp:Parameter Name="yetki" Type="String" />
                    <asp:Parameter Name="original_kadi" Type="String" />
                    <asp:Parameter Name="original_sifre" Type="String" />
                    <asp:Parameter Name="original_sifre" Type="String" />
                    <asp:Parameter Name="original_ad" Type="String" />
                    <asp:Parameter Name="original_ad" Type="String" />
                    <asp:Parameter Name="original_soyad" Type="String" />
                    <asp:Parameter Name="original_soyad" Type="String" />
                    <asp:Parameter Name="original_mail" Type="String" />
                    <asp:Parameter Name="original_mail" Type="String" />
                    <asp:Parameter Name="original_yetki" Type="String" />
                    <asp:Parameter Name="original_yetki" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br /><br />
            <table>
                <tr>
                    <td class="auto-style1"></td><td>
                       <asp:Label ID="Label3" runat="server" Text="Yeni Öğretmen Ekle" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Kullanıcı Adı:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Bu Alan Boş Geçilemez!" Font-Bold="True" Font-Names="Calibri" Font-Size="Smaller" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Şifre:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Bu Alan Boş Geçilemez!" Font-Bold="True" Font-Names="Calibri" Font-Size="Smaller" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                </tr>                <tr>
                    <td class="auto-style2">
                        Ad:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Bu Alan Boş Geçilemez!" Font-Bold="True" Font-Names="Calibri" Font-Size="Smaller" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                </tr>                <tr>
                    <td class="auto-style2">
                        Soyad:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Bu Alan Boş Geçilemez!" Font-Bold="True" Font-Names="Calibri" Font-Size="Smaller" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                </tr>                <tr>
                    <td class="auto-style2">
                        Mail:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Bu Alan Boş Geçilemez!" Font-Bold="True" Font-Names="Calibri" Font-Size="Smaller" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </td>
                </tr>                
                <tr>
                    <td class="auto-style2">
                        Telefon:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Gizli Soru:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Cevap:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Tatata:
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click" ValidationGroup="A" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
