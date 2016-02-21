using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Kernel;
using System.Web.Configuration;
namespace WebApplication1.DAO
{
    public class LoginDAO
    {
        public string  ConnectionString { get; set; }
        public LoginDAO()
        {
            try
            {
                ConnectionString = WebConfigurationManager.ConnectionStrings["BANCO"].ConnectionString;
            }
            catch (Exception)
            {

            }
        }
        public DataTable getLogin(string cpf, string senha)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM CLIENTE WHERE CPF = '" + cpf + "'  AND SENHA = '" + senha + "'";
                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString,CommandType.Text,query, null);
            }

            catch(Exception ex)
            {

            }
            return dt;
        }
    }
}