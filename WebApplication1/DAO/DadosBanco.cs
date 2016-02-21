using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
namespace WebApplication1.DAO
{
    public class DadosBanco
    {
        public string connectionString { get; set; }
        public DadosBanco()
        {
            try {
                connectionString = WebConfigurationManager.ConnectionStrings["BANCO"].ConnectionString;
                 }
            catch (Exception)
            {
             
            }
        }
        // metodo de insert delete e update
        public bool cud(string query)
        {
            bool retorno = false;
            try
            {
                var conn = new SqlConnection(connectionString);
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                retorno = true;
            }
            catch (Exception)
            {

            }
            return retorno;
        }



        public DataTable get(string query)
        {
            return null;
        }
       
    }
}