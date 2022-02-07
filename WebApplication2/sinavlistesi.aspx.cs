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
    public partial class sinavlistesi : System.Web.UI.Page
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
            
            // SAYFA AÇILIŞINDA DROPDOWNLIST1 NESNESİNDE SEÇİLİ GELEN SINAVIN DURUM BİLGİLERİNİ YAZDIRMAK İÇİN [ DROPDOWNLIST1_SELECTEDINDEXCHANGED OLAYI ÇALIŞMADIĞI İÇİN BU YÖNTEM KULLANILMIŞTIR ]
            if (DropDownList1.SelectedValue == "")
            {
                OleDbCommand komut2 = new OleDbCommand("select * from tblsinav_durum", baglanti);
                OleDbDataReader oku2 = komut2.ExecuteReader();
                oku2.Read();
                if (oku2["durum"].ToString() == "0")
                {
                    Label3.Text = "Kapalı";
                    Label5.Text = "--/--/--";
                    Label7.Text = "--:--";
                }
                else if (oku2["durum"].ToString() == "1")
                {
                    Label3.Text = "Aktif";
                    Label5.Text = oku2["tarih"].ToString();
                    Label7.Text = oku2["saat"].ToString();
                }
                else
                {
                    Label3.Text = "???";
                    Label5.Text = "???";
                    Label7.Text = "???";
                }
            }
            baglanti.Close();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // ANASAYFA
            Response.Redirect("ogrencipanel.aspx");
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // ANASAYFA
            Response.Redirect("ogrencipanel.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // SINAV LİSTESİNDEN SEÇİLEN SINAVIN BİLGİLERİNİ GETİR
            OleDbCommand komut = new OleDbCommand("select * from tblsinav_durum where sinav_adi=@ad", baglanti);
            komut.Parameters.AddWithValue("@ad", DropDownList1.SelectedValue);
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            // DURUM: KAPALI
            if (oku["durum"].ToString() == "0")
            {
                Label3.Text = "Kapalı";
                Label5.Text = "--/--/--";
                Label7.Text = "--:--";
            }
            // DURUM: AKTİF
            else if (oku["durum"].ToString() == "1")
            {
                Label3.Text = "Aktif";
                Label5.Text = oku["tarih"].ToString();
                Label7.Text = oku["saat"].ToString();
            }
            else
            {
                Label3.Text = "???";
                Label5.Text = "???";
                Label7.Text = "???";
            }
            baglanti.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Label3.Text=="Aktif")
            {
                
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsinavlar where sinav_adi=@ad", baglanti);
                komut.Parameters.AddWithValue("@ad", DropDownList1.SelectedValue);
                OleDbDataReader oku = komut.ExecuteReader();
                int soruno = 0;
                while (oku.Read())
                {
                    soruno++;
                    Session["soru" + soruno] = int.Parse(oku["soru_id"].ToString());
                }
                Session["dsayisi"] = 0;
                Response.Redirect("sinavol.aspx");
            }
       
        }




    }
}