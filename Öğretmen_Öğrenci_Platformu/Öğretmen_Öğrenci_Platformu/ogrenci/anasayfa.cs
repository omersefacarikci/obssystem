using Microsoft.Data.SqlClient;
namespace Öğretmen_Öğrenci_Platformu;

public partial class anasayfa : Form
{
    public anasayfa()
    {
        InitializeComponent();
    }
    private void guna2ControlBox1_MouseEnter(object sender, EventArgs e)
    {
        guna2ControlBox1.FillColor = Color.Red;
    }

    private void guna2ControlBox1_MouseLeave(object sender, EventArgs e)
    {
        guna2ControlBox1.FillColor = Color.White;
    }

    private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void guna2Button2_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = true;
        label24.Visible = false;
        label25.Visible = false;
        panel8.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        label24.Visible = false;
        label25.Visible = false;
        panel8.Visible = true;
        panel7.Visible = true;
        panel6.Visible = true;
    }

    private void guna2Button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    void ogrencibilgilerinigetir()
    {

    }
    private void anasayfa_Load(object sender, EventArgs e)
    {
        ogrencibilgilerinigetir();
    }

    private void panel6_Paint(object sender, PaintEventArgs e)
    {

    }

    private void guna2Button10_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        label24.Visible = false;
        label25.Visible = false;
        panel8.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
        takvim frm = new takvim();
        frm.ShowDialog();
    }

    private void guna2Button11_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        label24.Visible = true;
        label25.Visible = true;
        panel8.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
        try
        {
            vt.conn.Open();
            string query = "SELECT mezuniyet_tarih FROM ogrenciler WHERE ID = 1";
            SqlCommand command = new SqlCommand(query, vt.conn);
            object result = command.ExecuteScalar();
            if (result != null)
            {
                DateTime mezuniyetTarihi = Convert.ToDateTime(result);
                DateTime simdikiTarih = DateTime.Now;
                if (mezuniyetTarihi > simdikiTarih)
                {
                    TimeSpan fark = mezuniyetTarihi - simdikiTarih;
                    label25.Text = $"Gün {fark.Days}";
                    int kalanSaat = (int)fark.TotalHours;
                    int kalanDakika = (int)fark.TotalMinutes % 60;
                    int kalanSaniye = (int)fark.TotalSeconds % 60;
                    label24.Text = $"{kalanSaat:D2}:{kalanDakika:D2}:{kalanSaniye:D2} ";
                }
                else
                {
                    label24.Text = "Mezuniyet tarihi geçmiş.";
                }
            }
            else
            {
                label24.Text = "Mezuniyet tarihi bulunamadı.";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
        finally
        {
            if (vt.conn.State == System.Data.ConnectionState.Open)
            {
                vt.conn.Close();
            }
        }
    }
    private void guna2ControlBox1_Click(object sender, EventArgs e)
    {

    }

    private void guna2Button13_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        label24.Visible = false;
        label25.Visible = false;
        panel8.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
        int ogrenciNo = 234308001;
        alinandersler alinanDerslerForm = new alinandersler(ogrenciNo);
        alinanDerslerForm.ShowDialog();
    }

    private void guna2Button4_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        label24.Visible = false;
        label25.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
        panel8.Visible = false;
    }

    private void guna2Button5_Click(object sender, EventArgs e)
    {
        panel1.Visible = true;
        panel2.Visible = false;
        label24.Visible = false;
        label25.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
        panel8.Visible = false;

    }

    private void guna2Button14_Click(object sender, EventArgs e)
    {
        panel1.Visible = false;
        panel2.Visible = false;
        label24.Visible = false;
        label25.Visible = false;
        panel7.Visible = false;
        panel6.Visible = false;
        panel8.Visible = false;
        danismanbilgi dn = new danismanbilgi();
        dn.ShowDialog();
    }

    private void guna2Button1_MouseEnter(object sender, EventArgs e)
    {
        guna2Button1.FillColor = Color.White;
        guna2Button1.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button1_MouseLeave(object sender, EventArgs e)
    {
        guna2Button1.ForeColor = Color.White;
        guna2Button1.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button2_MouseEnter(object sender, EventArgs e)
    {
        guna2Button2.FillColor = Color.White;
        guna2Button2.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button2_MouseLeave(object sender, EventArgs e)
    {
        guna2Button2.ForeColor = Color.White;
        guna2Button2.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button14_MouseEnter(object sender, EventArgs e)
    {
        guna2Button14.FillColor = Color.White;
        guna2Button14.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button14_MouseLeave(object sender, EventArgs e)
    {
        guna2Button14.ForeColor = Color.White;
        guna2Button14.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button13_MouseEnter(object sender, EventArgs e)
    {
        guna2Button13.FillColor = Color.White;
        guna2Button13.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button13_MouseLeave(object sender, EventArgs e)
    {
        guna2Button13.ForeColor = Color.White;
        guna2Button13.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button5_MouseEnter(object sender, EventArgs e)
    {
        guna2Button5.FillColor = Color.White;
        guna2Button5.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button5_MouseLeave(object sender, EventArgs e)
    {
        guna2Button5.ForeColor = Color.White;
        guna2Button5.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button10_MouseEnter(object sender, EventArgs e)
    {
        guna2Button10.FillColor = Color.White;
        guna2Button10.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button10_MouseLeave(object sender, EventArgs e)
    {
        guna2Button10.ForeColor = Color.White;
        guna2Button10.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button11_MouseEnter(object sender, EventArgs e)
    {
        guna2Button11.FillColor = Color.White;
        guna2Button11.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button11_MouseLeave(object sender, EventArgs e)
    {
        guna2Button11.ForeColor = Color.White;
        guna2Button11.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button3_MouseEnter(object sender, EventArgs e)
    {
        guna2Button3.FillColor = Color.White;
        guna2Button3.ForeColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2Button3_MouseLeave(object sender, EventArgs e)
    {
        guna2Button3.ForeColor = Color.White;
        guna2Button3.FillColor = Color.FromArgb(18, 44, 71);
    }

    private void guna2ControlBox2_Click(object sender, EventArgs e)
    {

    }
}


