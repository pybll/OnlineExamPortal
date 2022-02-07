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
    public partial class sinavhazirla : System.Web.UI.Page
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // ANASAYFA
            Response.Redirect("ogretmenpanel.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            // PROFİL
            Response.Redirect("profilyonetimi.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // ÇIKIŞ YAP
            Session.Abandon();
            Response.Redirect("default.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // @SINAV SINAVINDA @SORU SORUSU VAR / YOK KONTROL
            OleDbCommand kontrol = new OleDbCommand("select * from tblsinavlar where sinav_adi=@sinav and soru_id=@soru", baglanti);
            kontrol.Parameters.AddWithValue("@sinav", TextBox1.Text);
            kontrol.Parameters.AddWithValue("@soru", GridView1.SelectedValue);
            OleDbDataReader oku = kontrol.ExecuteReader();
            // VAR İSE @SORU SORUSUNU TEKRAR EKLEME
            if (oku.Read())
            {
                Label3.Text = "Seçilen soru veritabanında oluşturduğunuz sınav için zaten mevcut.";
            }
            // YOK İSE @SORU SORUSUNU VERİTABANINA @SINAV SINAVI İÇİN KAYDET
            else
            {
                // @SORU ID'Lİ SORUYU KAYDETMEDEN ÖNCE SORUNUN EKLENCEĞİ SINAV VERİTABANINDA MEVCUT MU KONTROL ET
                OleDbCommand kontrol2 = new OleDbCommand("select * from tblsinav_durum where sinav_adi=@sinav", baglanti);
                kontrol2.Parameters.AddWithValue("@sinav", TextBox1.Text);
                OleDbDataReader oku2 = kontrol2.ExecuteReader();
                // MEVCUT İSE İŞLEME DEVAM ET
                if (oku2.Read())
                {
                }
                // MEVCUT DEĞİL İSE İŞLEMİ DURAKLAT VE @SINAV İSİMLİ SINAVI VERİTABANINA KAYDET DAHA SONRA SORU EKLEME İŞLEMİNE DEVAM ET
                else
                {
                    OleDbCommand komut2 = new OleDbCommand("insert into tblsinav_durum(sinav_adi,durum) values(@sinav,@durum)", baglanti);
                    komut2.Parameters.AddWithValue("@sinav", TextBox1.Text);
                    komut2.Parameters.AddWithValue("@durum", "0");
                    komut2.ExecuteNonQuery();
                }
                // @SORU ID'Lİ SORUYU VERİTABANINA @SINAV İSİMLİ SINAV İÇİN KAYDET
                OleDbCommand komut = new OleDbCommand("insert into tblsinavlar(soru_id,sinav_adi) values(@soru_id,@sinav_adi)", baglanti);
                komut.Parameters.AddWithValue("@soru_id", GridView1.SelectedValue);
                komut.Parameters.AddWithValue("@sinav_adi", TextBox1.Text);
                ListBox1.Items.Add(GridView1.SelectedValue.ToString());
                komut.ExecuteNonQuery();
                Label3.Text = GridView1.SelectedValue.ToString() + " numaralı soru sınavınıza eklenmiştir.";
                DropDownList1.Enabled = false;
            }

            baglanti.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // OLUŞTURULMAK İSTENEN SINAV İSMİ VERİTABANINDA DAHA ÖNCEDEN KAYITLI MI KONTROL ET
            OleDbCommand kontrol = new OleDbCommand("select * from tblsinavlar where sinav_adi=@sinav", baglanti);
            kontrol.Parameters.AddWithValue("@sinav", TextBox1.Text);
            OleDbDataReader oku = kontrol.ExecuteReader();
            // KAYITLI İSE
            if (oku.Read())
            {
                Label2.Text = "Bu sınav adı veritabanında mevcut olduğundan seçilemez.";
            }
            // KAYITLI DEĞİL İSE KAYIT İŞLEMLERİ İÇİN GEREKLİ NESNELERİ AKTİF HALE GETİR
            else
            {
                TextBox1.ReadOnly = true;
                DropDownList1.Visible = true;
                GridView1.Visible = true;
                ListBox1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;
                Button4.Visible = true;
                Button1.Enabled = false;
            }
            baglanti.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // SINAV SORU LİSTESİNDE SEÇİLİ OLAN SORUYU LİSTEDEN ÇIKAR
            OleDbCommand komut = new OleDbCommand("delete * from tblsinavlar where soru_id=@soru", baglanti);
            komut.Parameters.AddWithValue("@soru", ListBox1.SelectedValue);
            komut.ExecuteNonQuery();
            ListBox1.Items.Remove(ListBox1.SelectedValue);
            baglanti.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // İŞLEMİ TAMAMLA VE ANASAYFAYA GİT
            Response.Redirect("ogretmenpanel.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            /* İŞLEMİ İPTAL ET*/
            // SINAV-SORU TABLOSUNDAN OLUŞTURULMAKTA OLAN SINAVA AİT TÜM KAYITLARI SİL
            OleDbCommand komut = new OleDbCommand("delete * from tblsinavlar where sinav_adi=@sinav", baglanti);
            komut.Parameters.AddWithValue("@sinav", TextBox1.Text);
            komut.ExecuteNonQuery();
            // SINAV-DURUM TABLOSUNDAN OLUŞTURULMAKTA OLAN SINAVA AİT KAYIDI SİL
            OleDbCommand komut2 = new OleDbCommand("delete * from tblsinav_durum where sinav_adi=@sinav", baglanti);
            komut2.Parameters.AddWithValue("@sinav", TextBox1.Text);
            komut2.ExecuteNonQuery();
            // SAYFAYI YENİLE
            Response.Redirect("sinavhazirla.aspx");
            baglanti.Close();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // ANASAYFA
            Response.Redirect("ogretmenpanel.aspx");
        }
    }
}