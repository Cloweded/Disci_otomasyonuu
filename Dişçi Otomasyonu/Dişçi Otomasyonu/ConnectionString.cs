using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dişçi_Otomasyonu
{
    class ConnectionString
    {

        public SqlConnection GetCon()
        
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\USER\DOCUMENTS\DISDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return baglanti;
        }



    }
}
