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
    public partial class alinandersler : Form
    {
        private int ogrenciNo;
        public alinandersler()
        {
            InitializeComponent();

        }
        private void alinandersler_load(object sender, EventArgs e)
        {
            GetirOgrenciDersleri();
        }
    
        public alinandersler(int ogrenciNo)
        {
            InitializeComponent();
            this.ogrenciNo = ogrenciNo; 
        }
        private void GetirOgrenciDersleri()
        {
            try
            {
                if (vt.conn.State == ConnectionState.Open)
                {
                    vt.conn.Close();
                }
                vt.conn.Open();
                string query = @"
                SELECT d.ID AS DersID, d.ders_adi AS DersAdı, d.ders_kredi AS Kredi, 
                       d.ders_akst AS AKTS, d.ders_saati AS Saat, d.ders_sinif AS Sınıf
                FROM ogrencidersleri od
                JOIN dersler d ON od.dersID = d.ID
                WHERE od.ogrenci_no = @ogrenciNo";
                SqlCommand cmd = new SqlCommand(query, vt.conn);
                cmd.Parameters.AddWithValue("@ogrenciNo", ogrenciNo);
                DataTable dataTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Kayıtlı ders bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                vt.conn.Close(); 
            }
        }

    }
}

