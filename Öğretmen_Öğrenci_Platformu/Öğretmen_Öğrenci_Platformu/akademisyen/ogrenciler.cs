using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
namespace Öğretmen_Öğrenci_Platformu
{
    public partial class ogrenciler : Form
    {
        public ogrenciler()
        {
            InitializeComponent();
        }
        public string GetOgretmenBolum(int id)
        {
            string ogretmenBolum = string.Empty;
            try
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
                vt.conn.Open();
                string sorgu = "SELECT ogretmen_bolum FROM ogretmenler WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(sorgu, vt.conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ogretmenBolum = reader["ogretmen_bolum"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                vt.conn.Close();
            }
            return ogretmenBolum;
        }
        public DataTable ogrencilergetir(string ogretmenBolum)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
                vt.conn.Open();
                string sorgu = @"
                                SELECT ogrenci_numarasi, ogrenci_adi, ogrenci_soyadi, ogrenci_dogumtarihi, ogrenci_sinif, ogrenci_email, ogrenci_telefon
                                FROM ogrenciler 
                                WHERE ogrenci_bolum = @ogretmenBolum";
                SqlCommand cmd = new SqlCommand(sorgu, vt.conn);
                cmd.Parameters.AddWithValue("@ogretmenBolum", ogretmenBolum);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                vt.conn.Close();
            }
            return dataTable;
        }
        private void loadbolumu()
        {
            int id = 1; 
            string ogretmenBolum = GetOgretmenBolum(id);

            if (!string.IsNullOrEmpty(ogretmenBolum))
            {
                DataTable ogrenciler = ogrencilergetir(ogretmenBolum);

                if (ogrenciler.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = ogrenciler;
                    guna2DataGridView1.Columns[0].HeaderText = "Öğrenci Numarası"; 
                    guna2DataGridView1.Columns[1].HeaderText = "Adı";
                    guna2DataGridView1.Columns[2].HeaderText = "Soyadı";
                    guna2DataGridView1.Columns[3].HeaderText = "Doğum Tarihi";
                    guna2DataGridView1.Columns[4].HeaderText = "Sınıfı";
                    guna2DataGridView1.Columns[5].HeaderText = "E-Posta";
                    guna2DataGridView1.Columns[6].HeaderText = "Telefon";
                    guna2DataGridView1.RowTemplate.Height = 30;
                }
                else
                {
                    MessageBox.Show("Hiç öğrenci bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Bölüm bilgisi alınamadı.");
            }
        }

        private void ogrenciler_Load(object sender, EventArgs e)
        {
            loadbolumu();
        }
    }
}
