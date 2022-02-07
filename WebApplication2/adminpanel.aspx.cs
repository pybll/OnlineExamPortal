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
    public partial class adminpanel : System.Web.UI.Page
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // ÇIKIŞ YAP
            Session.Abandon();
            Response.Redirect("default.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }
    }
}