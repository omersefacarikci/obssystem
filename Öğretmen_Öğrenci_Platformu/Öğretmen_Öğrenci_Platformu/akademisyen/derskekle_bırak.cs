using Guna.UI2.WinForms;
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
    public partial class derskekle_bırak : Form
    {
        public derskekle_bırak()
        {
            InitializeComponent();
        }
        void akademisyen_ogrenci_ortak_dersler()
        {
            if (vt.conn.State == ConnectionState.Open)
            {
                vt.conn.Close();
            }

            string query = "SELECT d.ID, d.ders_adi,d.ders_kredi,d.ders_akst,d.ders_saati,d.ders_sinif, o.ogretmen_adi, o.ogretmen_soyadi " +
                           "FROM dersler d " +
                           "JOIN ogretmenler o ON d.ders_hocasi = (o.ogretmen_adi + ' ' + o.ogretmen_soyadi);";
            try
            {
                vt.conn.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, vt.conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri getirilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                vt.conn.Close();
            }
        }
        private void dersekle_bırak_Load(object sender, EventArgs e)
        {
            akademisyen_ogrenci_ortak_dersler();
            loadbolumu();
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
                                SELECT ID ,ogrenci_numarasi, ogrenci_adi, ogrenci_soyadi, ogrenci_dogumtarihi, ogrenci_sinif, ogrenci_email, ogrenci_telefon
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
                    guna2DataGridView2.DataSource = ogrenciler;
                    guna2DataGridView2.Columns[0].HeaderText = "ID";
                    guna2DataGridView2.Columns[1].HeaderText = "Öğrenci Numarası"; 
                    guna2DataGridView2.Columns[2].HeaderText = "Adı";
                    guna2DataGridView2.Columns[3].HeaderText = "Soyadı";
                    guna2DataGridView2.Columns[5].HeaderText = "Sınıfı";
                    guna2DataGridView2.RowTemplate.Height = 30;
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
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.SelectedRows.Count > 0 && guna2DataGridView1.SelectedRows.Count > 0)
            {

                int ogrencino = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells["ogrenci_numarasi"].Value);

                int dersId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ID"].Value);
                string dersad = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells["ders_adi"].Value);
                int derskredi = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_kredi"].Value);
                int dersak = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_akst"].Value);
                int derssaat = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_saati"].Value);
                int derssn = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_sinif"].Value);
                AddDersToOgrenci(ogrencino, dersId, dersad, derskredi, dersak, derssaat, derssn);
                MessageBox.Show("Ders başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci ve ders seçin.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AddDersToOgrenci(int ogrencino,int dersId,string dersad,int derskredi,int dersak, int derssaat, int derssn)
        {

            try
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
                vt.conn.Open();
                string query = "INSERT INTO ogrencidersleri (ogrenci_no,dersID,ders_adi,ders_kredi,ders_akst,ders_saati,ders_sinif) VALUES (@ogrenci_no,@dersID,@ders_adi,@ders_kredi,@ders_akst,@ders_saati,@ders_sinif)";
                SqlCommand cmd = new SqlCommand(query, vt.conn);
                cmd.Parameters.AddWithValue("@ogrenci_no", ogrencino);
                cmd.Parameters.AddWithValue("@dersID", dersId);
                cmd.Parameters.AddWithValue("@ders_adi", dersad);
                cmd.Parameters.AddWithValue("@ders_kredi", derskredi);
                cmd.Parameters.AddWithValue("@ders_akst", dersak);
                cmd.Parameters.AddWithValue("@ders_saati", derssaat);
                cmd.Parameters.AddWithValue("@ders_sinif", derssn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
            }
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.SelectedRows.Count > 0 && guna2DataGridView1.SelectedRows.Count > 0)
            {
                int ogrencino = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells["ogrenci_numarasi"].Value);
                int dersId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ID"].Value);
                string dersad = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells["ders_adi"].Value);
                int derskredi = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_kredi"].Value);
                int dersak = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_akst"].Value);
                int derssaat = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_saati"].Value);
                int derssn = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["ders_sinif"].Value);
                RemoveDersFromOgrenci(ogrencino, dersId, dersad, derskredi, dersak, derssaat, derssn);
                MessageBox.Show("Ders başarıyla çıkarıldı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir öğrenci ve ders seçin.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void RemoveDersFromOgrenci(int ogrencino, int dersId, string dersad, int derskredi, int dersak, int derssaat, int derssn)
        {
            try
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
                vt.conn.Open();
                string query = "DELETE FROM ogrencidersleri WHERE ogrenci_no = @ogrenci_no AND dersID = @dersID";
                SqlCommand cmd = new SqlCommand(query, vt.conn);
                cmd.Parameters.AddWithValue("@ogrenci_no", ogrencino);
                cmd.Parameters.AddWithValue("@dersID", dersId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
            }
        }
    }
}
