using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Guna.UI2.WinForms;
using System.Windows.Forms.DataVisualization.Charting;
using Öğretmen_Öğrenci_Platformu.akademisyen;

namespace Öğretmen_Öğrenci_Platformu
{
    public partial class akademisyen_anasayfa : Form
    {
        public akademisyen_anasayfa()
        {
            InitializeComponent();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2ControlBox1_MouseEnter(object sender, EventArgs e)
        {
            guna2ControlBox1.FillColor = Color.Red;
        }
        private void guna2ControlBox1_MouseLeave(object sender, EventArgs e)
        {
            guna2ControlBox1.FillColor = Color.White;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            panel2.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
            ogrenciler ogre = new ogrenciler();
            ogre.ShowDialog();
        }
        private void akademisyen_anasayfa_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chart1.ChartAreas.Add(chartArea);
            Series series = new Series("Öğrenci Sayıları")
            {
                ChartType = SeriesChartType.Column,
                BorderWidth = 3,
                Color = System.Drawing.Color.Orange
            };
            series.Points.AddXY(2020, 57);
            series.Points.AddXY(2021, 40);
            series.Points.AddXY(2022, 67);
            series.Points.AddXY(2023, 50);
            series.Points.AddXY(2024, 60);
            series.Points.AddXY(2025, 60);

            chart1.Series.Add(series);

            chart1.Titles.Add("Yıllara Göre Öğrenci Sayıları");
            chart1.Titles[0].Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold);
            chart1.ChartAreas[0].AxisX.Title = "Yıllar";
            chart1.ChartAreas[0].AxisY.Title = "Öğrenci Sayısı";

            chart1.ChartAreas[0].AxisX.Interval = 1;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel7.Visible = true;
            panel8.Visible = true;
            panel10.Visible = true;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;

            derskekle_bırak dsb = new derskekle_bırak();
            dsb.ShowDialog();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;

            takvim frm = new takvim();
            frm.ShowDialog();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void guna2Button4_MouseEnter(object sender, EventArgs e)
        {
            guna2Button4.FillColor = Color.White;
            guna2Button4.ForeColor = Color.FromArgb(18, 44, 71);
        }

        private void guna2Button4_MouseLeave(object sender, EventArgs e)
        {
            guna2Button4.ForeColor = Color.White;
            guna2Button4.FillColor = Color.FromArgb(18, 44, 71);
        }

        private void guna2Button5_MouseEnter(object sender, EventArgs e)
        {
            btnakdogrenci.FillColor = Color.White;
            btnakdogrenci.ForeColor = Color.FromArgb(18, 44, 71);
        }

        private void guna2Button5_MouseLeave(object sender, EventArgs e)
        {
            btnakdogrenci.ForeColor = Color.White;
            btnakdogrenci.FillColor = Color.FromArgb(18, 44, 71);
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

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;
            not nt = new not();
            nt.ShowDialog();
        }

        private void guna2Button5_MouseEnter_1(object sender, EventArgs e)
        {

        }

        private void btnakdogrenci_MouseEnter(object sender, EventArgs e)
        {
            btnakdogrenci.FillColor = Color.White;
            btnakdogrenci.ForeColor = Color.FromArgb(18, 44, 71);
        }

        private void btnakdogrenci_MouseLeave(object sender, EventArgs e)
        {
            btnakdogrenci.ForeColor = Color.White;
            btnakdogrenci.FillColor = Color.FromArgb(18, 44, 71);
        }

        private void guna2Button5_MouseEnter_2(object sender, EventArgs e)
        {
            guna2Button5.FillColor = Color.White;
            guna2Button5.ForeColor = Color.FromArgb(18, 44, 71);
        }

        private void guna2Button5_MouseLeave_1(object sender, EventArgs e)
        {
            guna2Button5.ForeColor = Color.White;
            guna2Button5.FillColor = Color.FromArgb(18, 44, 71);
        }
    }
}