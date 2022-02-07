using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace WebApplication2
{
    public partial class hatirlat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();

            // VERİTABANINDAKİ SEÇİLİ LOGOYU YÜKLE
            OleDbCommand komut3 = new OleDbCommand("select dizin from secilenlogo", baglanti);
            OleDbDataReader oku3 = komut3.ExecuteReader();
            oku3.Read();
            ImageButton1.ImageUrl = oku3["dizin"].ToString();
            baglanti.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // GİRİLEN KULLANICI ADI SİSTEMDE MEVCUT MU KONTROL ET
            OleDbCommand komut = new OleDbCommand("select * from tblkullanici where kadi=@kadi", baglanti);
            komut.Parameters.AddWithValue("@kadi", TextBox3.Text);
            OleDbDataReader oku = komut.ExecuteReader();
            // VAR İSE KULLANICI ADI GİRİŞİNİ ENGELLE VE GİZLİ SORUYU YAZDIR
            if (oku.Read())
            {
                Label3.Text = "";
                TextBox5.Text = oku["gizlisoru"].ToString();
                Button3.Visible = true;
                TextBox3.ReadOnly = true;

            }
            // YOK İSE HATA MESAJI VER
            else
            {
                Label3.Text = "Veritabanında belirtilen kullanıcı adı bulunamadı. <br>";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from tblkullanici where kadi=@kadi", baglanti);
            komut.Parameters.AddWithValue("@kadi", TextBox3.Text);
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            // GİRİLEN KULLANICIYA AİT GİZLİ SORUNUN CEVABI VERİLEN CEVABA EŞİT İSE ŞİFREYİ YAZDIR
            if (TextBox4.Text == oku["cevap"].ToString())
            {
                Label4.Text = "";
                Label2.Text = oku["sifre"].ToString();
                Label1.Visible = true;
                Button4.Visible = true;
            }
            // GİRİLEN KULLANICIYA AİT GİZLİ SORUNUN CEVABI VERİLEN CEVABA EŞİT DEĞİL İSE HATA MESAJI VER
            else
            {
                Label4.Text = "Yanlış Cevap";
                Label4.ForeColor = System.Drawing.Color.DarkRed;
            }
            baglanti.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //ŞİFREYİ GÖSTER/GİZLE
            if (Label2.Visible == true)
            {
                Label2.Visible = false;
            }
            else
            {
                Label2.Visible = true;
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // ANASAYFA
            Response.Redirect("default.aspx");
        }
    }
}