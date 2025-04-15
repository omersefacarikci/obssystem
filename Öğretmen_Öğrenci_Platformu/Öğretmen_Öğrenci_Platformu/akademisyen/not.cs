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
namespace Öğretmen_Öğrenci_Platformu.akademisyen
{
    public partial class not : Form
    {
        public not()
        {
            InitializeComponent();
        }

        private void not_Load(object sender, EventArgs e)
        {
            try
            {
                vt.conn.Open();
                string query = "SELECT CONCAT(ogrenci_adi, ' ', ogrenci_soyadi) AS OgrenciTamAdi FROM ogrenciler";
                using (SqlCommand command = new SqlCommand(query, vt.conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        guna2ComboBox1.Items.Add(reader["OgrenciTamAdi"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
            }
            try
            {
                vt.conn.Open();
                string query = "SELECT ders_adi AS dersss FROM dersler";

                using (SqlCommand command = new SqlCommand(query, vt.conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        guna2ComboBox2.Items.Add(reader["dersss"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına bağlanırken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
            }

        }
        private void btngiris_Click(object sender, EventArgs e)
        {
            double vizeNotu, finalNotu;
            if (double.TryParse(guna2TextBox1.Text, out vizeNotu) && double.TryParse(guna2TextBox2.Text, out finalNotu))
            {
                double ortalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
                label4.Text = ortalama.ToString("F2");
                if (ortalama >= 40)
                {
                    label6.ForeColor = Color.Green;
                    label6.Text = "Geçti";
                    SaveGradesToDatabase();

                }
                else
                {
                    label6.ForeColor = Color.Red;
                    label6.Text = "Kaldı";
                    SaveGradesToDatabase();
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir vize ve final notu giriniz.");
            }
        }
        private void SaveGradesToDatabase()
        {
            guna2ComboBox1.Items.Add("Ahmet Yılmaz");
            if (guna2ComboBox1.SelectedItem == null || guna2ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Öğrenci veya ders seçilmedi.");
                return;
            }

            string selectedStudent = guna2ComboBox1.SelectedItem.ToString();
            string selectedCourse = guna2ComboBox2.SelectedItem.ToString(); 

            string[] studentParts = selectedStudent.Split(' ');
            if (studentParts.Length < 2)
            {
                MessageBox.Show("Öğrenci adı ve soyadı doğru formatta değil.");
                return;
            }
            string ogrenciAdi = studentParts[0];
            string ogrenciSoyadi = studentParts[1];

            double vizeNotu, finalNotu;
            if (!double.TryParse(guna2TextBox1.Text, out vizeNotu) || !double.TryParse(guna2TextBox2.Text, out finalNotu))
            {
                MessageBox.Show("Vize ve final notlarını geçerli bir sayı olarak giriniz.");
                return;
            }

            double ortalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
            string basariDurumu = ortalama >= 60 ? "Geçti" : "Kaldı";
            string ogrenciNumarasi = null;

            try
            {
                if (vt.conn.State != ConnectionState.Open)
                {
                    vt.conn.Open();
                }
                string query = "SELECT ogrenci_numarasi FROM ogrenciler WHERE ogrenci_adi = @OgrenciAdi AND ogrenci_soyadi = @OgrenciSoyadi";
                using (SqlCommand command = new SqlCommand(query, vt.conn))
                {
                    command.Parameters.AddWithValue("@OgrenciAdi", ogrenciAdi);
                    command.Parameters.AddWithValue("@OgrenciSoyadi", ogrenciSoyadi);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ogrenciNumarasi = reader["ogrenci_numarasi"].ToString();
                        }
                    }
                }

                if (ogrenciNumarasi != null)
                {
                    string insertQuery = "INSERT INTO OgrenciNotlari (OgrenciID, ogrenci_adi, ogrenci_soyadi, VizeNotu, FinalNotu, Ortalama, BasariDurumu, ders_adi) " +
                                         "VALUES (@OgrenciID, @OgrenciAdi, @OgrenciSoyadi, @VizeNotu, @FinalNotu, @Ortalama, @BasariDurumu, @DersAdi)";

                    using (SqlCommand command = new SqlCommand(insertQuery, vt.conn))
                    {
                        command.Parameters.AddWithValue("@OgrenciID", ogrenciNumarasi);
                        command.Parameters.AddWithValue("@OgrenciAdi", ogrenciAdi);
                        command.Parameters.AddWithValue("@OgrenciSoyadi", ogrenciSoyadi);
                        command.Parameters.AddWithValue("@VizeNotu", vizeNotu);
                        command.Parameters.AddWithValue("@FinalNotu", finalNotu);
                        command.Parameters.AddWithValue("@Ortalama", ortalama);
                        command.Parameters.AddWithValue("@BasariDurumu", basariDurumu);
                        command.Parameters.AddWithValue("@DersAdi", selectedCourse); 

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Notlar ve ders başarıyla kaydedildi!");
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not kaydedilirken hata oluştu: " + ex.Message);
            }
            finally
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
            }
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}



    

