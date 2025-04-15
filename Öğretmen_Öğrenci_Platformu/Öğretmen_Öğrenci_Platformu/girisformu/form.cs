
using Microsoft.Data.SqlClient;
using System.Data;
namespace Öğretmen_Öğrenci_Platformu
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
            timer1.Enabled = false;
        }
        private string giristur;
        public void ogrbaglan()
        {
            if (txtogrdogrulama.Text == lbldogrulama.Text)
            {
                vt.conn.Open();
                SqlDataAdapter sorgu = new SqlDataAdapter("SELECT * FROM ogrenciler WHERE ogrenci_numarasi=@ogrkullaniciadi AND ogrenci_sifre=@ogrencisifre", vt.conn);
                sorgu.SelectCommand.Parameters.AddWithValue("@ogrkullaniciadi", txtogrkullaniciadi.Text);
                sorgu.SelectCommand.Parameters.AddWithValue("@ogrencisifre", txtogrencisifre.Text);
                DataTable dt = new DataTable();
                sorgu.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    anasayfa acc = new anasayfa();
                    acc.lbladi.Text = dt.Rows[0]["ogrenci_adi"] + " " + dt.Rows[0]["ogrenci_soyadi"];
                    acc.lbl_ad.Text = dt.Rows[0]["ogrenci_adi"] + " " + dt.Rows[0]["ogrenci_soyadi"];
                    acc.lbl_bol.Text = (string)dt.Rows[0]["ogrenci_bolum"];
                    string tc = dt.Rows[0]["ogrenci_tc"].ToString();
                    string yildiz_tc = tc.Substring(0, 2) + "*******" + tc.Substring(9, 2);
                    acc.lbl_tc.Text = yildiz_tc;
                    acc.lbl_fakulte.Text = (string)dt.Rows[0]["ogrenci_fakulte"];
                    acc.lbl_posta.Text = (string)dt.Rows[0]["ogrenci_email"];
                    acc.lbl_tel.Text = (string)dt.Rows[0]["ogrenci_telefon"];
                    acc.lbl_ogrencinumara.Text = (string)dt.Rows[0]["ogrenci_numarasi"];
                    int ogrenciNo = Convert.ToInt32(dt.Rows[0]["ogrenci_numarasi"]);
                    acc.lbl_sinif.Text = (string)dt.Rows[0]["ogrenci_sinif"];
                    acc.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı! Lütfen tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtogrkullaniciadi.Text = "";
                    txtogrencisifre.Text = "";
                    txtogrdogrulama.Text = "";
                }
                vt.conn.Close();
            }
            else
            {
                MessageBox.Show("Doğrulama kodu hatalı Lütfen tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtogrdogrulama.Text = "";
                progressyuklenme.Value = 0;
                dogrulamaKoduOlustur();
            }
        }
        public void akdbaglan()
        {
            if (txtakddogrulama.Text == lblakddogrulama.Text)
            {
                vt.conn.Open();
                SqlDataAdapter sorgu2 = new SqlDataAdapter("SELECT * FROM ogretmenler WHERE ogretmen_numarasi=@akdkullaniciadi AND ogretmen_sifre=@akdsifre", vt.conn);

                //  SQL Injection "chronos" onayladı.
                // $"SELECT * FROM ogretmenler WHERE ogretmen_numarasi = '{akdkullaniciadi}' AND ogretmen_sifre = '{akdsifre}'"; Saldırılabilir
                sorgu2.SelectCommand.Parameters.AddWithValue("@akdkullaniciadi", txtakdkullaniciadi.Text);
                sorgu2.SelectCommand.Parameters.AddWithValue("@akdsifre", txtakdsifre.Text);
                DataTable dtt = new DataTable();
                sorgu2.Fill(dtt);
                if (dtt.Rows.Count > 0)
                {
                    akademisyen_anasayfa ac = new akademisyen_anasayfa();
                    ac.lblakdadsoyad.Text = dtt.Rows[0]["ogretmen_adi"] + " " + dtt.Rows[0]["ogretmen_soyadi"];
                    ac.lbl_ad2.Text = dtt.Rows[0]["ogretmen_adi"] + " " + dtt.Rows[0]["ogretmen_soyadi"];
                    ac.lbl_bol2.Text = (string)dtt.Rows[0]["ogretmen_bolum"];
                    string tcc = dtt.Rows[0]["ogretmen_tc"].ToString();
                    string yildiz_tcc = tcc.Substring(0, 2) + "*******" + tcc.Substring(9, 2);
                    ac.lbl_tc2.Text = yildiz_tcc;
                    ac.lbl_fakulte2.Text = (string)dtt.Rows[0]["ogretmen_fakulte"];
                    ac.lbl_posta2.Text = (string)dtt.Rows[0]["ogretmen_email"];
                    ac.lbl_tel2.Text = (string)dtt.Rows[0]["ogretmen_telefon"];
                    ac.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı! Lütfen tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtakdkullaniciadi.Text = "";
                    txtakdsifre.Text = "";
                    txtakddogrulama.Text = "";
                }
                vt.conn.Close();
            }
            else
            {
                MessageBox.Show("Doğrulama kodu hatalı Lütfen tekrar deneyiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtakddogrulama.Text = "";
                progressyuklenme.Value = 0;
                dogrulamaKoduOlustur2();
            }
        }
        private void btnogrencigiris_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = true;
            guna2Button2.Visible = false;
            sifregosterbtn_akd.Visible = false;
            label9.Visible = false;
            guna2Separator4.Visible = false;
            txtakddogrulama.Visible = false;
            txtakdkullaniciadi.Visible = false;
            txtakdsifre.Visible = false;
            lblakddogrulama.Visible = false;
            guna2CircleButton2.Visible = false;
            label7.Visible = false;
            guna2Separator3.Visible = false;
            label6.Visible = false;
            btnakdgiris.Visible = false;
            ogrencigirispnl.Visible = true;
            giristur = "ogrenci";
            btnogrencigiris.BorderColor = Color.White;
            btnakademisyengiris.BorderColor = Color.FromArgb(18, 44, 71);
        }
        private void form_Load(object sender, EventArgs e)
        {

        }
        private void btnakademisyengiris_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            guna2Button2.Visible = true;
            sifregosterbtn_akd.Visible = true;
            label9.Visible = true;
            guna2Separator4.Visible = true;
            txtakddogrulama.Visible = true;
            txtakdkullaniciadi.Visible = true;
            txtakdsifre.Visible = true;
            lblakddogrulama.Visible = true;
            guna2CircleButton2.Visible = true;
            label7.Visible = true;
            guna2Separator3.Visible = true;
            label6.Visible = true;
            btnakdgiris.Visible = true;
            ogrencigirispnl.Visible = false;
            giristur = "akademisyen";
            btnakademisyengiris.BorderColor = Color.White;
            btnogrencigiris.BorderColor = Color.FromArgb(18, 44, 71);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressyuklenme.Value < 100)
            {
                progressyuklenme.Value += 2;
            }
            else if (progressyuklenme.Value == 100)
            {

                timer1.Enabled = false;
                if (giristur == "akademisyen")
                {
                    akdbaglan();

                }
                else
                {
                    ogrbaglan();
                }

            }
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtogrdogrulama.Text))
            {
                MessageBox.Show("Doğrulama kodunu girmeniz gerekiyor. Lütfen tekrar deneyin!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                progressyuklenme.Value = 0;
                progressyuklenme.Maximum = 100;
                timer1.Enabled = true;

            }
        }

        private void sifregosterbtn_Click(object sender, EventArgs e)
        {
            if (txtogrencisifre.PasswordChar == '•')
            {
                txtogrencisifre.PasswordChar = '\0';
            }
            else
            {
                txtogrencisifre.PasswordChar = '•';
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            dogrulamaKoduOlustur();
        }

        private void form_Load_1(object sender, EventArgs e)
        {
            dogrulamaKoduOlustur();
            dogrulamaKoduOlustur2();
        }

        void dogrulamaKoduOlustur()
        {
            Random sayi = new Random();
            string randomsayiüretme = string.Join("", Enumerable.Range(0, 6).Select(_ => sayi.Next(1, 10)));
            lbldogrulama.Text = randomsayiüretme;
            txtogrdogrulama.Text = lbldogrulama.Text;
        }
        void dogrulamaKoduOlustur2()
        {
            Random sayi2 = new Random();
            string randomsayiüretme2 = string.Join("", Enumerable.Range(0, 6).Select(_ => sayi2.Next(1, 10)));
            lblakddogrulama.Text = randomsayiüretme2;
            txtakddogrulama.Text = lblakddogrulama.Text;
        }
        private void guna2ControlBox1_MouseEnter(object sender, EventArgs e)
        {
            guna2ControlBox1.FillColor = Color.Red;
        }

        private void guna2ControlBox1_MouseLeave(object sender, EventArgs e)
        {
            guna2ControlBox1.FillColor = Color.White;
        }
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            dogrulamaKoduOlustur2();
        }
        private void guna2CircleButton2_Click_1(object sender, EventArgs e)
        {
            dogrulamaKoduOlustur2();
        }
        private void label11_Click(object sender, EventArgs e)
        {
            akdgirispanel.Visible = false;
            label9.Visible = true;
            guna2Separator4.Visible = true;
            txtakddogrulama.Visible = true;
            txtakdkullaniciadi.Visible = true;
            txtakdsifre.Visible = true;
            lblakddogrulama.Visible = true;
            guna2CircleButton2.Visible = true;
            label7.Visible = true;
            guna2Separator3.Visible = true;
            label6.Visible = true;
            btnakdgiris.Visible = true;
        }
        private void txtogrkullaniciadi_TextChanged(object sender, EventArgs e)
        {

        }
        private void sifregosterbtn_akd_Click_1(object sender, EventArgs e)
        {
            if (txtakdsifre.PasswordChar == '•')
            {
                txtakdsifre.PasswordChar = '\0';
            }
            else
            {
                txtakdsifre.PasswordChar = '•';
            }
        }
        private void btnakdgiris_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtakddogrulama.Text))
            {
                MessageBox.Show("Doğrulama kodunu girmeniz gerekiyor. Lütfen tekrar deneyin!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                progressyuklenme.Value = 0;
                progressyuklenme.Maximum = 100;
                timer1.Enabled = true;

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_MouseEnter(object sender, EventArgs e)
        {
            guna2Button2.FillColor = Color.Maroon;
            guna2Button2.ForeColor = Color.White;
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
            guna2Button2.FillColor = Color.White;
            guna2Button2.ForeColor = Color.Maroon;
        }

        private void guna2Button1_MouseEnter(object sender, EventArgs e)
        {
            guna2Button1.FillColor = Color.Maroon;
            guna2Button1.ForeColor = Color.White;
        }

        private void guna2Button1_MouseLeave(object sender, EventArgs e)
        {
            guna2Button1.FillColor = Color.White;
            guna2Button1.ForeColor = Color.Maroon;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
