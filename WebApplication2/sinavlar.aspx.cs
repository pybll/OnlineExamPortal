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
    public partial class sinavlar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // HOŞGELDİNİZ MESAJI VE tatata YÜKLE
            /*OleDbCommand komut = new OleDbCommand("select * from tblkullanici where kadi=@kadi", baglanti);
            komut.Parameters.AddWithValue("@kadi", Session["kadi"].ToString());
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            Label1.Text = oku["ad"].ToString().ToUpper() + " " + oku["soyad"].ToString().ToUpper();
            Image1.ImageUrl = oku["tatata"].ToString();*/

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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            // ANASAYFA
            Response.Redirect("ogretmenpanel.aspx");
        }



        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SEÇİLEN DURUM KAPALI İSE TARİH VE SAAT TEXTBOXLARINI GİZLE, AKTİF İSE GÖRÜNÜR HALE GETİR
            if (DropDownList1.SelectedValue == "0")
            {
                Label2.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
            }
            else
            {
                Label2.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // RADİOBUTTONLİST1'DE SEÇİM YAPILMIŞ İSE SEÇİLEN SINAVA AİT BİLGİLERİ TERCİH EDİLEN BİLGİLERLE GÜNCELLEŞTİR
            if (RadioButtonList1.SelectedValue != "")
            {
                    // DURUM: KAPALI
                if (DropDownList1.SelectedValue == "0")
                {
                    OleDbCommand komut = new OleDbCommand("update tblsinav_durum set durum=\"0\" where sinav_adi=@ad", baglanti);
                    komut.Parameters.AddWithValue("@ad", RadioButtonList1.SelectedValue);
                    komut.ExecuteNonQuery();
                }
                    // DURUM: AKTİF
                else
                {
                    OleDbCommand komut = new OleDbCommand("update tblsinav_durum set durum=\"1\" , tarih=\""+TextBox2.Text+"\" , saat=\""+ TextBox3.Text+"\" where sinav_adi=@ad", baglanti);
                    komut.Parameters.AddWithValue("@ad", RadioButtonList1.SelectedValue);
                    komut.ExecuteNonQuery();
                }
            }
            baglanti.Close();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // SINAV LİSTESİNDEN SEÇİLEN SINAVIN BİLGİLERİNİ GETİR
            OleDbCommand komut = new OleDbCommand("select * from tblsinav_durum where sinav_adi=@ad", baglanti);
            komut.Parameters.AddWithValue("@ad", RadioButtonList1.SelectedValue);
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            // DURUM: KAPALI
            if (oku["durum"].ToString() == "0")
            {
                DropDownList1.ClearSelection();
                DropDownList1.SelectedIndex = 0;
                Label2.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                TextBox2.Text = "0G.0A.YY";
                TextBox3.Text = "00:00";
            }
            // DURUM: AKTİF
            else
            {
                DropDownList1.ClearSelection();
                DropDownList1.SelectedIndex = 1;
                Label2.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox2.Text = oku["tarih"].ToString();
                TextBox3.Text = oku["saat"].ToString();
            }
            baglanti.Close();
        }

        

    }
}