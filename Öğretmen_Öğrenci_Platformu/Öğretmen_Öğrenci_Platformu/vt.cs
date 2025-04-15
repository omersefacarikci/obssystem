using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Öğretmen_Öğrenci_Platformu
{
    class vt
    {
        public static string baglanti = @"Data Source='''''veritabanıadın''''''';Initial Catalog=ogrenciyonetimi;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection conn = new SqlConnection(baglanti);
    }
}
