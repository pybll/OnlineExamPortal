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
    public partial class sinav : System.Web.UI.Page
    {


        OleDbConnection baglanti;
        protected void Page_Load(object sender, EventArgs e)
        {            
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
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
            

            OleDbCommand komutsoru = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komutsoru.Parameters.AddWithValue("@id", int.Parse(Session["soru1"].ToString()));
                OleDbDataReader okusoru = komutsoru.ExecuteReader();
                okusoru.Read();
            Label deneme = new Label();
            this.Controls.Add(deneme);
            deneme.CssClass = "deneme";
            deneme.Text = okusoru["soru"].ToString();

            /*RadioButtonList radyo = new RadioButtonList();
            this.Controls.Add(radyo);
            radyo.CssClass = "deneme";
            radyo.Items.Add(okusoru["cevap"].ToString());*/
            
        }
        /*
        protected void Label2_Load(object sender, EventArgs e)
        {
            try
            {
                 baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru1"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label2.Text ="1."+oku["soru"].ToString();
                Label2.ForeColor = System.Drawing.Color.Wheat;
                RadioButtonList1.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList1.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList1.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList1.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList1.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label2.Visible = false;
                RadioButtonList1.Visible = false;
            }
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

        protected void Label3_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru2"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label3.Text = "2." + oku["soru"].ToString();
                Label3.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList2.Items.Clear();
                RadioButtonList2.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList2.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList2.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList2.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList2.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label3.Visible = false;
                RadioButtonList2.Visible = false;
            }
        }

        protected void Label4_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru3"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label4.Text = "3." + oku["soru"].ToString();
                Label4.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList3.Items.Clear();
                RadioButtonList3.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList3.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList3.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList3.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList3.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label4.Visible = false;
                RadioButtonList3.Visible = false;
            }
        }

        protected void Label5_Load(object sender, EventArgs e)
        {
            try
            {
                // OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                //baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru4"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label5.Text = "4." + oku["soru"].ToString();
                Label5.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList4.Items.Clear();
                RadioButtonList4.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList4.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList4.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList4.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList4.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label5.Visible = false;
                RadioButtonList4.Visible = false;
            }
        }

        protected void Label6_Load(object sender, EventArgs e)
        {
            try
            {
               // OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru5"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label6.Text = "5." + oku["soru"].ToString();
                Label6.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList5.Items.Clear();
                RadioButtonList5.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList5.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList5.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList5.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList5.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label6.Visible = false;
                RadioButtonList5.Visible = false;
            }
        }

        protected void Label7_Load(object sender, EventArgs e)
        {
            try
            {
               // OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru6"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label7.Text = "6." + oku["soru"].ToString();
                Label7.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList6.Items.Clear();
                RadioButtonList6.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList6.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList6.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList6.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList6.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label7.Visible = false;
                RadioButtonList6.Visible = false;
            }
        }

        protected void Label8_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru7"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label8.Text = "7." + oku["soru"].ToString();
                Label8.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList7.Items.Clear();
                RadioButtonList7.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList7.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList7.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList7.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList7.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label8.Visible = false;
                RadioButtonList7.Visible = false;
            }
        }

        protected void Label9_Load(object sender, EventArgs e)
        {
            try
            {
               // OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru8"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label9.Text = "8." + oku["soru"].ToString();
                Label9.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList8.Items.Clear();
                RadioButtonList8.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList8.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList8.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList8.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList8.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label9.Visible = false;
                RadioButtonList8.Visible = false;
            }
        }

        protected void Label10_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru9"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label10.Text = "9." + oku["soru"].ToString();
                Label10.ForeColor = System.Drawing.Color.Wheat;
                //RadioButtonList9.Items.Clear();
                RadioButtonList9.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList9.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList9.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList9.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList9.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label10.Visible = false;
                RadioButtonList9.Visible = false;
            }
        }

        protected void Label11_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru10"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label11.Text = "10." + oku["soru"].ToString();
                Label11.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList10.Items.Clear();
                RadioButtonList10.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList10.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList10.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList10.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList10.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label11.Visible = false;
                RadioButtonList10.Visible = false;
            }
        }

        protected void Label12_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru11"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label12.Text = "11." + oku["soru"].ToString();
                Label12.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList11.Items.Clear();
                RadioButtonList11.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList11.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList11.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList11.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList11.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label12.Visible = false;
                RadioButtonList11.Visible = false;
            }
        }

        protected void Label13_Load(object sender, EventArgs e)
        {
            try
            {
             //   OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru12"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label13.Text = "12." + oku["soru"].ToString();
                Label13.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList12.Items.Clear();
                RadioButtonList12.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList12.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList12.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList12.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList12.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label13.Visible = false;
                RadioButtonList12.Visible = false;
            }
        }

        protected void Label14_Load(object sender, EventArgs e)
        {
            try
            {
             //   OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru13"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label14.Text = "13." + oku["soru"].ToString();
                Label14.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList13.Items.Clear();
                RadioButtonList13.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList13.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList13.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList13.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList13.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label14.Visible = false;
                RadioButtonList13.Visible = false;
            }
        }

        protected void Label15_Load(object sender, EventArgs e)
        {
            try
            {
             //   OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru14"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label15.Text = "14." + oku["soru"].ToString();
                Label15.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList14.Items.Clear();
                RadioButtonList14.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList14.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList14.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList14.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList14.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label15.Visible = false;
                RadioButtonList14.Visible = false;
            }
        }

        protected void Label16_Load(object sender, EventArgs e)
        {
            try
            {
             //   OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru15"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label16.Text = "15." + oku["soru"].ToString();
                Label16.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList15.Items.Clear();
                RadioButtonList15.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList15.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList15.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList15.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList15.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label16.Visible = false;
                RadioButtonList15.Visible = false;
            }
        }

        protected void Label17_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru16"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label17.Text = "16." + oku["soru"].ToString();
                Label17.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList16.Items.Clear();
                RadioButtonList16.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList16.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList16.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList16.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList16.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label17.Visible = false;
                RadioButtonList16.Visible = false;
            }
        }

        protected void Label18_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru17"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label18.Text = "17." + oku["soru"].ToString();
                Label18.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList17.Items.Clear();
                RadioButtonList17.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList17.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList17.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList17.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList17.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label18.Visible = false;
                RadioButtonList17.Visible = false;
            }
        }

        protected void Label19_Load(object sender, EventArgs e)
        {
            try
            {
             //   OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru18"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label19.Text = "18." + oku["soru"].ToString();
                Label19.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList18.Items.Clear();
                RadioButtonList18.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList18.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList18.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList18.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList18.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label19.Visible = false;
                RadioButtonList18.Visible = false;
            }
        }

        protected void Label20_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru19"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label20.Text = "19." + oku["soru"].ToString();
                Label20.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList19.Items.Clear();
                RadioButtonList19.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList19.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList19.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList19.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList19.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label20.Visible = false;
                RadioButtonList19.Visible = false;
            }
        }

        protected void Label21_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru20"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label21.Text = "20." + oku["soru"].ToString();
                Label21.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList20.Items.Clear();
                RadioButtonList20.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList20.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList20.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList20.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList20.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label21.Visible = false;
                RadioButtonList20.Visible = false;
            }
        }

        protected void Label22_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru21"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label22.Text = "21." + oku["soru"].ToString();
                Label22.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList21.Items.Clear();
                RadioButtonList21.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList21.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList21.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList20.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList21.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label22.Visible = false;
                RadioButtonList21.Visible = false;
            }
        }

        protected void Label23_Load(object sender, EventArgs e)
        {
            try
            {
               // OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru22"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label23.Text = "22." + oku["soru"].ToString();
                Label23.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList22.Items.Clear();
                RadioButtonList22.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList22.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList22.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList22.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList22.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label23.Visible = false;
                RadioButtonList22.Visible = false;
            }
        }

        protected void Label24_Load(object sender, EventArgs e)
        {
            try
            {
             //   OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru23"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label24.Text = "23." + oku["soru"].ToString();
                Label24.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList23.Items.Clear();
                RadioButtonList23.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList23.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList23.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList23.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList23.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label24.Visible = false;
                RadioButtonList23.Visible = false;
            }
        }

        protected void Label25_Load(object sender, EventArgs e)
        {
            try
            {
           //     OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru24"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label25.Text = "24." + oku["soru"].ToString();
                Label25.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList24.Items.Clear();
                RadioButtonList24.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList24.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList24.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList24.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList24.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label25.Visible = false;
                RadioButtonList24.Visible = false;
            }
        }

        protected void Label26_Load(object sender, EventArgs e)
        {
            try
            {
           //     OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru25"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label26.Text = "25." + oku["soru"].ToString();
                Label26.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList25.Items.Clear();
                RadioButtonList25.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList25.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList25.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList25.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList25.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label26.Visible = false;
                RadioButtonList25.Visible = false;
            }
        }

        protected void Label27_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru26"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label27.Text = "26." + oku["soru"].ToString();
                Label27.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList26.Items.Clear();
                RadioButtonList26.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList26.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList26.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList26.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList26.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label27.Visible = false;
                RadioButtonList26.Visible = false;
            }
        }

        protected void Label28_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru27"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label28.Text = "27." + oku["soru"].ToString();
                Label28.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList27.Items.Clear();
                RadioButtonList27.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList27.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList27.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList27.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList27.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label28.Visible = false;
                RadioButtonList27.Visible = false;
            }
        }

        protected void Label29_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru28"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label29.Text = "28." + oku["soru"].ToString();
                Label29.ForeColor = System.Drawing.Color.Wheat;
           //     RadioButtonList28.Items.Clear();
                RadioButtonList28.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList28.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList28.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList28.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList28.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label29.Visible = false;
                RadioButtonList28.Visible = false;
            }
        }

        protected void Label30_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru29"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label30.Text = "29." + oku["soru"].ToString();
                Label30.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList29.Items.Clear();
                RadioButtonList29.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList29.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList29.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList29.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList29.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label30.Visible = false;
                RadioButtonList29.Visible = false;
            }
        }

        protected void Label31_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru30"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label31.Text = "30." + oku["soru"].ToString();
                Label31.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList30.Items.Clear();
                RadioButtonList30.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList30.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList30.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList30.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList30.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label31.Visible = false;
                RadioButtonList30.Visible = false;
            }
        }

        protected void Label32_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru31"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label32.Text = "31." + oku["soru"].ToString();
                Label32.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList31.Items.Clear();
                RadioButtonList31.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList31.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList31.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList31.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList31.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label32.Visible = false;
                RadioButtonList31.Visible = false;
            }
        }

        protected void Label33_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru32"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label33.Text = "32." + oku["soru"].ToString();
                Label33.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList32.Items.Clear();
                RadioButtonList32.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList32.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList32.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList32.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList32.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label33.Visible = false;
                RadioButtonList32.Visible = false;
            }
        }

        protected void Label34_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru33"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label34.Text = "33." + oku["soru"].ToString();
                Label34.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList33.Items.Clear();
                RadioButtonList33.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList33.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList33.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList33.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList33.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label34.Visible = false;
                RadioButtonList33.Visible = false;
            }
        }

        protected void Label35_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru34"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label35.Text = "34." + oku["soru"].ToString();
                Label35.ForeColor = System.Drawing.Color.Wheat;
             //   RadioButtonList34.Items.Clear();
                RadioButtonList34.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList34.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList34.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList34.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList34.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label35.Visible = false;
                RadioButtonList34.Visible = false;
            }
        }

        protected void Label36_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru35"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label36.Text = "35." + oku["soru"].ToString();
                Label36.ForeColor = System.Drawing.Color.Wheat;
            //    RadioButtonList35.Items.Clear();
                RadioButtonList35.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList35.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList35.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList35.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList35.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label36.Visible = false;
                RadioButtonList35.Visible = false;
            }
        }

        protected void Label37_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru36"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label37.Text = "36." + oku["soru"].ToString();
                Label37.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList36.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList36.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList36.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList36.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList36.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label37.Visible = false;
                RadioButtonList36.Visible = false;
            }
        }

        protected void Label38_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru37"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label38.Text = "37." + oku["soru"].ToString();
                Label38.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList37.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList37.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList37.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList37.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList37.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label38.Visible = false;
                RadioButtonList37.Visible = false;
            }
        }

        protected void Label39_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru38"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label39.Text = "38." + oku["soru"].ToString();
                Label39.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList38.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList38.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList38.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList38.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList38.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label39.Visible = false;
                RadioButtonList38.Visible = false;
            }
        }

        protected void Label40_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru39"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label40.Text = "39." + oku["soru"].ToString();
                Label40.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList39.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList39.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList39.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList39.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList39.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label40.Visible = false;
                RadioButtonList39.Visible = false;
            }
        }

        protected void Label41_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru40"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label41.Text = "40." + oku["soru"].ToString();
                Label41.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList40.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList40.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList40.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList40.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList40.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label41.Visible = false;
                RadioButtonList40.Visible = false;
            }
        }

        protected void Label42_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru41"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label42.Text = "41." + oku["soru"].ToString();
                Label42.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList41.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList41.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList41.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList41.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList41.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label42.Visible = false;
                RadioButtonList41.Visible = false;
            }
        }

        protected void Label43_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru42"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label43.Text = "42." + oku["soru"].ToString();
                Label43.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList42.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList42.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList42.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList42.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList42.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label43.Visible = false;
                RadioButtonList42.Visible = false;
            }

        }

        protected void Label44_Load(object sender, EventArgs e)
        {
            try
            {
            //    OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru43"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label44.Text = "43." + oku["soru"].ToString();
                Label44.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList43.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList43.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList43.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList43.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList43.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label44.Visible = false;
                RadioButtonList43.Visible = false;
            }

        }

        protected void Label45_Load(object sender, EventArgs e)
        {
            try
            {
           //     OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru44"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label45.Text = "44." + oku["soru"].ToString();
                Label45.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList44.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList44.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList44.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList44.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList44.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label45.Visible = false;
                RadioButtonList44.Visible = false;
            }

        }

        protected void Label46_Load(object sender, EventArgs e)
        {
            try
            {
           //     OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru45"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label46.Text = "45." + oku["soru"].ToString();
                Label46.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList45.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList45.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList45.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList45.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList45.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label46.Visible = false;
                RadioButtonList45.Visible = false;
            }
        }

        protected void Label47_Load(object sender, EventArgs e)
        {
            try
            {
           //     OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru46"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label47.Text = "46." + oku["soru"].ToString();
                Label47.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList46.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList46.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList46.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList46.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList46.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label47.Visible = false;
                RadioButtonList46.Visible = false;
            }
        }

        protected void Label48_Load(object sender, EventArgs e)
        {
            try
            {
              //  OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru47"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label48.Text = "47." + oku["soru"].ToString();
                Label48.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList47.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList47.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList47.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList47.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList47.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label48.Visible = false;
                RadioButtonList47.Visible = false;
            }
        }

        protected void Label49_Load(object sender, EventArgs e)
        {
            try
            {
          //      OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru48"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label49.Text = "48." + oku["soru"].ToString();
                Label49.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList48.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList48.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList48.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList48.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList48.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label49.Visible = false;
                RadioButtonList48.Visible = false;
            }
        }

        protected void Label50_Load(object sender, EventArgs e)
        {
            try
            {
        //        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru49"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label50.Text = "49." + oku["soru"].ToString();
                Label50.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList49.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList49.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList49.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList49.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList49.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label50.Visible = false;
                RadioButtonList49.Visible = false;
            }
        }

        protected void Label51_Load(object sender, EventArgs e)
        {
            try
            {
        //        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("App_Data\\eegitim.accdb"));
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru50"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                Label51.Text = "50." + oku["soru"].ToString();
                Label51.ForeColor = System.Drawing.Color.Wheat;
                //    RadioButtonList35.Items.Clear();
                RadioButtonList50.Items.Add(oku["secenek_a"].ToString());
                RadioButtonList50.Items.Add(oku["secenek_b"].ToString());
                RadioButtonList50.Items.Add(oku["secenek_c"].ToString());
                RadioButtonList50.Items.Add(oku["secenek_d"].ToString());
                RadioButtonList50.ForeColor = System.Drawing.Color.White;
                baglanti.Close();
            }
            catch (Exception)
            {
                Label51.Visible = false;
                RadioButtonList50.Visible = false;
            }
        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cevap = "";
                //baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru1"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                if (RadioButtonList1.SelectedIndex == 0)
                {
                    cevap = "A";
                }
                else if (RadioButtonList1.SelectedIndex == 1)
                {
                    cevap = "B";
                }
                else if (RadioButtonList1.SelectedIndex == 2)
                {
                    cevap = "C";
                }
                else if (RadioButtonList1.SelectedIndex == 3)
                {
                    cevap = "D";
                }
                if (cevap == oku["cevap"].ToString())
                {
                    Session["dsayisi"] = int.Parse(Session["dsayisi"].ToString()) + 1;
                }
                baglanti.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cevap = "";
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", int.Parse(Session["soru2"].ToString()));
                OleDbDataReader oku = komut.ExecuteReader();
                oku.Read();
                if (RadioButtonList2.SelectedIndex == 0)
                {
                    cevap = "A";
                }
                else if (RadioButtonList2.SelectedIndex == 1)
                {
                    cevap = "B";
                }
                else if (RadioButtonList2.SelectedIndex == 2)
                {
                    cevap = "C";
                }
                else if (RadioButtonList2.SelectedIndex == 3)
                {
                    cevap = "D";
                }
                if (cevap == oku["cevap"].ToString())
                {
                    Session["dsayisi"] = int.Parse(Session["dsayisi"].ToString()) + 1;
                }
                baglanti.Close();
            }
            catch (Exception)
            {
                
                
            }
            
        }

        protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cevap = "";
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from tblsorular where soru_id=@id", baglanti);
            komut.Parameters.AddWithValue("@id", int.Parse(Session["soru3"].ToString()));
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            if (RadioButtonList3.SelectedIndex == 0)
            {
                cevap = "A";
            }
            else if (RadioButtonList3.SelectedIndex == 1)
            {
                cevap = "B";
            }
            else if (RadioButtonList3.SelectedIndex == 2)
            {
                cevap = "C";
            }
            else if (RadioButtonList3.SelectedIndex == 3)
            {
                cevap = "D";
            }
            if (cevap == oku["cevap"].ToString())
            {
                Session["dsayisi"] = int.Parse(Session["dsayisi"].ToString()) + 1;
            }
            baglanti.Close();
            }
            catch (Exception)
            {
                
                
            }
            
        }

        protected void RadioButtonList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        */





        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}