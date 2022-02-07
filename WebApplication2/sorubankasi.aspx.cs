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
    public partial class sorubankasi : System.Web.UI.Page
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
            Response.Redirect("ogretmenpanel.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("profilyonetimi.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
            baglanti.Open();
            // DOĞRU CEVAP SEÇİMİ YAPILDIYSA GİRİLEN BİLGİLERE GÖRE VERİTABANINA YENİ SORU EKLE
            if (RadioButtonList1.SelectedValue != "")
            {
                OleDbCommand komut = new OleDbCommand("insert into tblsorular(ders_adi,konu,soru,cevap,secenek_a,secenek_b,secenek_c,secenek_d) values(@ders,@konu,@soru,@cevap,@a,@b,@c,@d)", baglanti);
                komut.Parameters.AddWithValue("@ders", DropDownList1.SelectedValue);
                komut.Parameters.AddWithValue("@konu", DropDownList2.SelectedValue);
                komut.Parameters.AddWithValue("@soru", TextBox1.Text);
                komut.Parameters.AddWithValue("@cevap", RadioButtonList1.SelectedValue);
                komut.Parameters.AddWithValue("@a", TextBox2.Text);
                komut.Parameters.AddWithValue("@b", TextBox3.Text);
                komut.Parameters.AddWithValue("@c", TextBox4.Text);
                komut.Parameters.AddWithValue("@d", TextBox5.Text);
                komut.ExecuteNonQuery();
                Response.Redirect("sorubankasi.aspx");
            }
            baglanti.Close();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ogretmenpanel.aspx");
        }
    }
}