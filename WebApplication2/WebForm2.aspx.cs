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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Arkaplan
             * Öğretmen, Öğrenci, Yönetici
             * Duyuru
             * Not Bilgisi
             * Rehber
             */

            Random sayi = new Random();
            int sira = sayi.Next(1, 26);

            string bg = "Images/anasayfa_h.png";
            string deneme = "#a4f5e2";
            Response.Write("<style>body{background-image:url('"+bg+"'); background-color:"+deneme+"}</style>");

            /*OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\vt.accdb"));
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select ad from tablo where ", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            Response.Write(oku["ad"].ToString());
            baglanti.Close();*/
            Label1.Text = Session["dsayisi"].ToString();
        }
    }
}