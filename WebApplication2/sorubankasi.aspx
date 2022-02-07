<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sorubankasi.aspx.cs" Inherits="WebApplication2.sorubankasi" %>

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
            Ders seçiniz:            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="dersaktar" DataTextField="ders_adi" DataValueField="ders_adi"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Ders seçimi yapmak zorunludur."></asp:RequiredFieldValidator>
            <asp:AccessDataSource ID="dersaktar" runat="server" DataFile="~/App_Data/eegitim.accdb" SelectCommand="SELECT [ders_adi] FROM [tbldersler] ORDER BY [ders_adi]"></asp:AccessDataSource>
            <br />
            Konu seçiniz:<asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="konuaktar" DataTextField="konu" DataValueField="konu"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownList2" ErrorMessage="Konu seçimi yapmak zorunludur."></asp:RequiredFieldValidator>
            <asp:AccessDataSource ID="konuaktar" runat="server" DataFile="~/App_Data/eegitim.accdb" SelectCommand="SELECT [konu] FROM [tblkonular] WHERE ([ders_adi] = ?) ORDER BY [konu]">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="ders_adi" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:AccessDataSource>
            <br />
            Soru:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Bu alan boş geçilemez."></asp:RequiredFieldValidator>
            <br />
            A Seçeneği:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox2" ErrorMessage="Bu alan boş geçilemez."></asp:RequiredFieldValidator>
            <br />
            B Seçeneği:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox3" ErrorMessage="Bu alan boş geçilemez."></asp:RequiredFieldValidator>
            <br />
            C Seçeneği:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox4" ErrorMessage="Bu alan boş geçilemez."></asp:RequiredFieldValidator>
            <br />
            D Seçeneği:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox5" ErrorMessage="Bu alan boş geçilemez."></asp:RequiredFieldValidator>
            <br />
            Doğru Seçenek:<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
                <asp:ListItem>D</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Doğru cevap seçimi zorunludur."></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Ekle" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="soru_id" DataSourceID="soruyukle" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="soru_id" HeaderText="soru_id" InsertVisible="False" ReadOnly="True" SortExpression="soru_id" />
                    <asp:BoundField DataField="ders_adi" HeaderText="ders_adi" ReadOnly="True" SortExpression="ders_adi" />
                    <asp:BoundField DataField="konu" HeaderText="konu" ReadOnly="True" SortExpression="konu" />
                    <asp:BoundField DataField="cevap" HeaderText="cevap" ReadOnly="True" SortExpression="cevap" />
                    <asp:BoundField DataField="soru" HeaderText="soru" SortExpression="soru" />
                    <asp:BoundField DataField="secenek_a" HeaderText="secenek_a" SortExpression="secenek_a" />
                    <asp:BoundField DataField="secenek_b" HeaderText="secenek_b" SortExpression="secenek_b" />
                    <asp:BoundField DataField="secenek_c" HeaderText="secenek_c" SortExpression="secenek_c" />
                    <asp:BoundField DataField="secenek_d" HeaderText="secenek_d" SortExpression="secenek_d" />
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
            <asp:AccessDataSource ID="soruyukle" runat="server" ConflictDetection="CompareAllValues" DataFile="~/App_Data/eegitim.accdb" DeleteCommand="DELETE FROM [tblsorular] WHERE [soru_id] = ? AND (([soru] = ?) OR ([soru] IS NULL AND ? IS NULL)) AND (([ders_adi] = ?) OR ([ders_adi] IS NULL AND ? IS NULL)) AND (([konu] = ?) OR ([konu] IS NULL AND ? IS NULL)) AND (([cevap] = ?) OR ([cevap] IS NULL AND ? IS NULL)) AND (([secenek_a] = ?) OR ([secenek_a] IS NULL AND ? IS NULL)) AND (([secenek_b] = ?) OR ([secenek_b] IS NULL AND ? IS NULL)) AND (([secenek_c] = ?) OR ([secenek_c] IS NULL AND ? IS NULL)) AND (([secenek_d] = ?) OR ([secenek_d] IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO [tblsorular] ([soru_id], [soru], [ders_adi], [konu], [cevap], [secenek_a], [secenek_b], [secenek_c], [secenek_d]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [soru_id], [soru], [ders_adi], [konu], [cevap], [secenek_a], [secenek_b], [secenek_c], [secenek_d] FROM [tblsorular] ORDER BY [soru_id], [ders_adi], [konu]" UpdateCommand="UPDATE [tblsorular] SET [soru] = ?, [ders_adi] = ?, [konu] = ?, [cevap] = ?, [secenek_a] = ?, [secenek_b] = ?, [secenek_c] = ?, [secenek_d] = ? WHERE [soru_id] = ? AND (([soru] = ?) OR ([soru] IS NULL AND ? IS NULL)) AND (([ders_adi] = ?) OR ([ders_adi] IS NULL AND ? IS NULL)) AND (([konu] = ?) OR ([konu] IS NULL AND ? IS NULL)) AND (([cevap] = ?) OR ([cevap] IS NULL AND ? IS NULL)) AND (([secenek_a] = ?) OR ([secenek_a] IS NULL AND ? IS NULL)) AND (([secenek_b] = ?) OR ([secenek_b] IS NULL AND ? IS NULL)) AND (([secenek_c] = ?) OR ([secenek_c] IS NULL AND ? IS NULL)) AND (([secenek_d] = ?) OR ([secenek_d] IS NULL AND ? IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_soru_id" Type="Int32" />
                    <asp:Parameter Name="original_soru" Type="String" />
                    <asp:Parameter Name="original_soru" Type="String" />
                    <asp:Parameter Name="original_ders_adi" Type="String" />
                    <asp:Parameter Name="original_ders_adi" Type="String" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_cevap" Type="String" />
                    <asp:Parameter Name="original_cevap" Type="String" />
                    <asp:Parameter Name="original_secenek_a" Type="String" />
                    <asp:Parameter Name="original_secenek_a" Type="String" />
                    <asp:Parameter Name="original_secenek_b" Type="String" />
                    <asp:Parameter Name="original_secenek_b" Type="String" />
                    <asp:Parameter Name="original_secenek_c" Type="String" />
                    <asp:Parameter Name="original_secenek_c" Type="String" />
                    <asp:Parameter Name="original_secenek_d" Type="String" />
                    <asp:Parameter Name="original_secenek_d" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="soru_id" Type="Int32" />
                    <asp:Parameter Name="soru" Type="String" />
                    <asp:Parameter Name="ders_adi" Type="String" />
                    <asp:Parameter Name="konu" Type="String" />
                    <asp:Parameter Name="cevap" Type="String" />
                    <asp:Parameter Name="secenek_a" Type="String" />
                    <asp:Parameter Name="secenek_b" Type="String" />
                    <asp:Parameter Name="secenek_c" Type="String" />
                    <asp:Parameter Name="secenek_d" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="soru" Type="String" />
                    <asp:Parameter Name="ders_adi" Type="String" />
                    <asp:Parameter Name="konu" Type="String" />
                    <asp:Parameter Name="cevap" Type="String" />
                    <asp:Parameter Name="secenek_a" Type="String" />
                    <asp:Parameter Name="secenek_b" Type="String" />
                    <asp:Parameter Name="secenek_c" Type="String" />
                    <asp:Parameter Name="secenek_d" Type="String" />
                    <asp:Parameter Name="original_soru_id" Type="Int32" />
                    <asp:Parameter Name="original_soru" Type="String" />
                    <asp:Parameter Name="original_soru" Type="String" />
                    <asp:Parameter Name="original_ders_adi" Type="String" />
                    <asp:Parameter Name="original_ders_adi" Type="String" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_konu" Type="String" />
                    <asp:Parameter Name="original_cevap" Type="String" />
                    <asp:Parameter Name="original_cevap" Type="String" />
                    <asp:Parameter Name="original_secenek_a" Type="String" />
                    <asp:Parameter Name="original_secenek_a" Type="String" />
                    <asp:Parameter Name="original_secenek_b" Type="String" />
                    <asp:Parameter Name="original_secenek_b" Type="String" />
                    <asp:Parameter Name="original_secenek_c" Type="String" />
                    <asp:Parameter Name="original_secenek_c" Type="String" />
                    <asp:Parameter Name="original_secenek_d" Type="String" />
                    <asp:Parameter Name="original_secenek_d" Type="String" />
                </UpdateParameters>
            </asp:AccessDataSource>
        </div>
    </form>
</body>
</html>