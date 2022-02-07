using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;


namespace WebApplication2
{
    public partial class logo_y : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // HOŞGELDİNİZ MESAJI VE tatata YÜKLE
            OleDbCommand komut = new OleDbCommand("select * from tblkullanici where kadi=@kadi", baglanti);
            komut.Parameters.AddWithValue("@kadi", Session["kadi"].ToString());
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            Label1.Text = oku["ad"].ToString().ToUpper() + " " + oku["soyad"].ToString().ToUpper();
            Image1.ImageUrl = oku["tatata"].ToString();

            // VERİTABANINDAKİ SEÇİLİ LOGOYU YÜKLE
            OleDbCommand komut3 = new OleDbCommand("select dizin from secilenlogo", baglanti);
            OleDbDataReader oku3 = komut3.ExecuteReader();
            oku3.Read();
            ImageButton1.ImageUrl = oku3["dizin"].ToString();
            baglanti.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();

            //YENİ LOGO EKLE
            OleDbCommand komut = new OleDbCommand("insert into tbllogo(isim,aciklama,dizin) values(@isim,@aciklama,@dizin)", baglanti);
            if (FileUpload1.HasFile)
            {
                string isim = TextBox1.Text;
                string dizin = "Images/"+isim+".png";
                komut.Parameters.AddWithValue("@isim", isim);
                komut.Parameters.AddWithValue("@aciklama", TextBox2.Text);
                komut.Parameters.AddWithValue("@dizin", dizin);
                FileUpload1.SaveAs(Server.MapPath("Images/") + isim+".png");
                komut.ExecuteNonQuery();
                Label2.Text = "Logo Başarıyla Kaydedildi.";
            }
            else
                Label1.Text="Logo Yüklenemedi";
            baglanti.Close();
            Response.Redirect("logo-y.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // ÇIKIŞ YAP
            Session.Abandon();
            Response.Redirect("default.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            // ANASAYFA
            Response.Redirect("adminpanel.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // VERİTABANINDA BULUNAN SEÇİLEN LOGO TABLOSUNU SEÇİLEN LOGO İLE GÜNCELLE
            OleDbCommand komut = new OleDbCommand("select * from tbllogo where isim=@isim",baglanti);
            komut.Parameters.AddWithValue("@isim",ListBox1.SelectedValue);
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            OleDbCommand komut2 = new OleDbCommand("update secilenlogo set logo_isim=@isim, dizin=@dizin", baglanti);
            komut2.Parameters.AddWithValue("@isim", oku["isim"].ToString());
            komut2.Parameters.AddWithValue("@dizin", oku["dizin"].ToString());
            komut2.ExecuteNonQuery();
            baglanti.Close();

            Response.Redirect("logo-y.aspx");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            if (ListBox1.SelectedValue == "Standart")
            {
                Response.Write("<script>alert(\"Standart Logo Silinemez\")</script>");
            }
                // SEÇİLEN LOGO STANDART LOGO DEĞİL İSE SİL
            else
            {
                OleDbCommand komut3 = new OleDbCommand("select * from secilenlogo", baglanti);
                OleDbDataReader oku3 = komut3.ExecuteReader();
                oku3.Read();
                // SİLİNEN LOGO KULLANILMAKTA OLAN LOGO İSE SİLDİKTEN SONRA YERİNE STANDART LOGOYU ATA
                if (oku3["logo_isim"].ToString() == ListBox1.SelectedValue)
                {
                    OleDbCommand komut2 = new OleDbCommand("update secilenlogo set logo_isim=\"Standart\",dizin=\"Images/logo.png\" ", baglanti);
                    komut2.ExecuteNonQuery();
                }
                OleDbCommand komut = new OleDbCommand("delete from tbllogo where isim=@isim", baglanti);
                komut.Parameters.AddWithValue("@isim", ListBox1.SelectedValue);
                komut.ExecuteNonQuery();
                
                
                
            }
            baglanti.Close();
            Response.Redirect("logo-y.aspx");
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // SEÇİLEN LOGOYU ÖNİZLE VE BİLGİLERİNİ YAZDIR.
            OleDbCommand komut = new OleDbCommand("select * from tbllogo where isim=@isim", baglanti);
            komut.Parameters.AddWithValue("@isim", ListBox1.SelectedValue);
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            Label5.Visible = true;
            Label6.Text = "<img src=" + oku["dizin"].ToString() + " height=\"30px\" />";
            Label7.Text = oku["aciklama"].ToString();

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // ANASAYFA
            Response.Redirect("adminpanel.aspx");
        }
    }
}
