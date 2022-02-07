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
    public partial class Site1 : System.Web.UI.MasterPage
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

            // VERİTABANINDAKİ TÜM KULLANICILARI OKU VE YETKİ TÜRÜNE GÖRE GRUPLAYARAK SAY
            OleDbCommand komut = new OleDbCommand("select * from tblkullanici", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            int ogr=0,ogt=0,yon=0;
            while (oku.Read())
            {
                if (oku["yetki"].ToString() == "0")
                {
                    ogr++;
                }
                if (oku["yetki"].ToString() == "1")
                {
                    ogt++;
                }
                if (oku["yetki"].ToString() == "2")
                {
                    yon++;
                }
            }

            // GRUPLANAN ÖĞRENCİ, ÖĞRETMEN VE YÖNETİCİ SAYISINI YERLERİNE YAZ
            Label2.Text = ogr.ToString();
            Label3.Text = ogt.ToString();
            Label4.Text = yon.ToString();

            baglanti.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            /* GİRİŞ YAP */
            // KULLANICI ADI @KADI VE ŞİFRESİ @SIFRE OLAN KULLANICI BİLGİLERİNİ OKU
            OleDbCommand komut = new OleDbCommand("select * from tblkullanici where kadi=@kadi and sifre=@sifre", baglanti);
            komut.Parameters.AddWithValue("@kadi", TextBox1.Text);
            komut.Parameters.AddWithValue("@sifre", TextBox2.Text);
            OleDbDataReader oku = komut.ExecuteReader();

            // BİLGİ DÖNÜŞÜ VAR İSE PENCERE KAPANANA KADAR DEĞİŞKEN YERİNİ TUTACAK SESSIONLARI BİLGİ TÜRLERİNE GÖRE ATA
            // KULLANICIYI GERİ YETKİ TÜRÜNE GÖRE ADMİN, ÖĞRETMEN VEYA ÖĞRENCİ SAYFASINA YÖNLENDİR
            if (oku.Read())
            {
                Session["kadi"] = oku["kadi"].ToString();
                Session["ad"] = oku["ad"].ToString();
                Session["soyad"] = oku["soyad"].ToString();
                Session["yetki"] = oku["yetki"].ToString();
                if (oku["yetki"].ToString() == "2")
                {
                    Label1.Text = "Giriş başarılı, yönlendiriliyorsunuz...";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("adminpanel.aspx");
                }
                else if (oku["yetki"].ToString() == "1")
                {
                    Label1.Text = "Giriş başarılı, yönlendiriliyorsunuz...";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("ogretmenpanel.aspx");
                }
                else if (oku["yetki"].ToString() == "0")
                {
                    Label1.Text = "Giriş başarılı, yönlendiriliyorsunuz...";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("ogrencipanel.aspx");
                }
            }
            // BİLGİ DÖNÜŞÜ YOK İSE HATA MESAJI VER
            else
            {
                Label1.Text = "Giriş başarısız";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            baglanti.Close();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // ŞİFREMİ UNUTTUM
            Response.Redirect("hatirlat.aspx");
        }


    }
}