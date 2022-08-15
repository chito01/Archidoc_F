using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace Archidoc_F.Models
{
    public class ConnexionModel
    {
        protected SqlConnection con = new SqlConnection();
        protected SqlCommand cmd = new SqlCommand();
        protected SqlDataAdapter da = new SqlDataAdapter();
        protected DataSet ds = new DataSet();
        protected DataTable dt = new DataTable();

        protected void connecter()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = "Data Source = CHITOLAMAR; Initial Catalog = ARCHIDOC; Integrated Security = True";
                con.Open();
            }
        }
        protected void deconnecter()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();

            }
        }
}
}
