using System;
using System.Web.Configuration;
using Kernel.Persistencia;
using System.Data;
namespace WebApplication1.DAO
{
    public class ChamadosDAO
    {
        public string ConnectionString { get; set; }
        public ChamadosDAO()
        {
            try
            {
                ConnectionString = WebConfigurationManager.ConnectionStrings["BANCO"].ConnectionString;
            }
            catch (Exception)
            {

            }
        }
        public DataTable insChamado(int apolice_id, string cpfcnpj, string partesveiculosenvolvida,
            string ruaavenida, string bairro, string cidade, int numero, bool veiclocomove, DateTime datahorachamado,
            string descchamado, string obschaamdo, int quant_veic_env)
        {
            try
            {
                var query = @"INSERT INTO [dbo].[Chamado]([PartesDoVeiculoColidida],[RuaAvenida],[Bairro],[Estado],[Numero]
                            ,[quantidadeterceirosenvolvidos],[veiculoselocomove],[datahoraacidente] ,[statuschamado]
                            ,[apolice_id],[descrissaochamado],[Observacao] ,[copiacnhenviada] ,[copiacompendereco]
                            ,[copiabo],[datahoraaberturachamado],[CPFCONDUTOR])VALUES
                             ('{0}','{1}','{2}','{3}',{4},{5},{6},{7},{8},{9},'{10}','{11}',{12},{13},{14},{15},'{16}')";

                query = string.Format(query, partesveiculosenvolvida, ruaavenida, bairro, cidade, numero, quant_veic_env, veiclocomove,
                                      datahorachamado, 1, apolice_id, descchamado, obschaamdo, false, false, false, DateTime.Now, cpfcnpj);

                SqlHelper.ExecuteNonQuery(ConnectionString, System.Data.CommandType.Text,
                                                                query, null);
                DataTable dt = SqlHelper.ExecuteDataTable(ConnectionString, System.Data.CommandType.Text, "SELECT max(chamado_id) FROM CHAMADO WHERE " +
                   "Cpfcondutor =' " + cpfcnpj + "' and apolice_id = " + apolice_id);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excessão no inschamado" + ex);
                throw;
            }

        }

        public void inschamadoTerceiro(int chamado_id, string placaterc, string modeloterc, string ruaav,
            string bairro, int numero, string cidade, string sentidovia, string partenvolvida)
        {
            try
            {
                var query = @"INSERT INTO chamadoterceirosenvolvidos values('{0}','{1}','{2}','{3}',
                              {4},'{5}','{6}','{7}',{8}";
                query = string.Format(query, partenvolvida, ruaav, bairro, cidade, numero, sentidovia, modeloterc, placaterc, chamado_id);
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, null);
                
            }

            catch(Exception ex)
            {
                Console.WriteLine("Exception no inschamadoterceiro" + ex.StackTrace);
            }
        }

    }
}