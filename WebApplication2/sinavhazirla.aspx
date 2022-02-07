<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sinavhazirla.aspx.cs" Inherits="WebApplication2.sinavhazirla" %>

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
            Sınav Adı:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button1" runat="server" Text="Oluştur" OnClick="Button1_Click" ValidationGroup="1" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Boş geçilemez." ValidationGroup="1"></asp:RequiredFieldValidator>
            <br />
            Ders seçiniz:            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="dersaktar" DataTextField="ders_adi" DataValueField="ders_adi" Visible="False"></asp:DropDownList>
            <asp:AccessDataSource ID="dersaktar" runat="server" DataFile="~/App_Data/eegitim.accdb" SelectCommand="SELECT [ders_adi] FROM [tbldersler] ORDER BY [ders_adi]"></asp:AccessDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="soru_id" DataSourceID="sorular" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="False">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="soru_id" HeaderText="soru_id" InsertVisible="False" ReadOnly="True" SortExpression="soru_id" />
                    <asp:BoundField DataField="soru" HeaderText="soru" SortExpression="soru" />
                    <asp:BoundField DataField="konu" HeaderText="konu" SortExpression="konu" />
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
            <asp:AccessDataSource ID="sorular" runat="server" ConflictDetection="CompareAllValues" DataFile="~/App_Data/eegitim.accdb" DeleteCommand="DELETE FROM [tblsorular] WHERE [soru_id] = ? AND (([konu] = ?) OR ([konu] IS NULL AND ? IS NULL)) AND (([soru] = ?) OR ([soru] IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO [tblsorular] ([soru_id], [konu], [soru]) VALUES (?, ?, ?)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [soru_id], [konu], [soru] FROM [tblsorular] WHERE ([ders_adi] = ?)" UpdateCommand="UPDATE [tblsorular] SET [konu] = ?, [soru] = ? WHERE [soru_id] = ? AND (([konu] = ?) OR ([konu] IS NULL AND ? IS NULL)) AND (([soru] = ?) OR ([soru] IS NULL AND ? IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_soru_id" Type="Int32" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_soru" Type="String" />
                    <asp:Parameter Name="original_soru" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="soru_id" Type="Int32" />
                    <asp:Parameter Name="konu" Type="String" />
                    <asp:Parameter Name="soru" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="ders_adi" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="konu" Type="String" />
                    <asp:Parameter Name="soru" Type="String" />
                    <asp:Parameter Name="original_soru_id" Type="Int32" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_soru" Type="String" />
                    <asp:Parameter Name="original_soru" Type="String" />
                </UpdateParameters>
            </asp:AccessDataSource>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Visible="False" Width="140px"></asp:ListBox>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Kaldır" Visible="False" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Tamam" Visible="False" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="İptal" Visible="False" OnClick="Button4_Click" />
        </div>
    </form>
</body>
</html>