using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğretmen_Öğrenci_Platformu
{
    public partial class takvim : Form
    {
        public takvim()
        {
            InitializeComponent();
        }
        int month, year;
        private void takvim_Load(object sender, EventArgs e)
        {
            displaygunler();
        }
        private void displaygunler()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            string monthh = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            label8.Text = monthh + " " + year;
            DateTime ay = new DateTime(year, month, 1);
            int gün = DateTime.DaysInMonth(year, month);
            int hdayoftheweek = Convert.ToInt32(ay.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < hdayoftheweek; i++)
            {
                UserControl1Blank ucblank = new UserControl1Blank();
                daycontaner.Controls.Add(ucblank);
            }
            for (int i = 1; i <= gün; i++)
            {
                UserControl1gunler ucdays = new UserControl1gunler();
                ucdays.days(i);
                daycontaner.Controls.Add(ucdays);
            }

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            daycontaner.Controls.Clear();
            month++;
            string monthh = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            label8.Text = monthh + " " + year;
            DateTime ay = new DateTime(year, month, 1);
            int gün = DateTime.DaysInMonth(year, month);
            int hdayoftheweek = Convert.ToInt32(ay.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < hdayoftheweek; i++)
            {
                UserControl1Blank ucblank = new UserControl1Blank();
                daycontaner.Controls.Add(ucblank);
            }
            for (int i = 1; i <= gün; i++)
            {
                UserControl1gunler ucdays = new UserControl1gunler();
                ucdays.days(i);
                daycontaner.Controls.Add(ucdays);
            }
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            daycontaner.Controls.Clear();
            month--;
            string monthh = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            label8.Text = monthh + " " + year;
            DateTime ay = new DateTime(year, month, 1);
            int gün = DateTime.DaysInMonth(year, month);
            int hdayoftheweek = Convert.ToInt32(ay.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < hdayoftheweek; i++)
            {
                UserControl1Blank ucblank = new UserControl1Blank();
                daycontaner.Controls.Add(ucblank);
            }
            for (int i = 1; i <= gün; i++)
            {
                UserControl1gunler ucdays = new UserControl1gunler();
                ucdays.days(i);
                daycontaner.Controls.Add(ucdays);
            }
        }
    }
}
