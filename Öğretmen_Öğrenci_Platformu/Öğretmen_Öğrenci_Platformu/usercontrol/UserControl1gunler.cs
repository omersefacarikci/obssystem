using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Öğretmen_Öğrenci_Platformu
{
    public partial class UserControl1gunler : UserControl
    {
        public UserControl1gunler()
        {
            InitializeComponent();
        }

        private void UserControl1gunler_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            label1.Text = numday + " ";
        }
    }
}
