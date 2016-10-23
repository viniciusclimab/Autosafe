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

            catch (Exception ex)
            {
                Console.WriteLine("Exception no inschamadoterceiro" + ex.StackTrace);
            }
        }

        public DataTable GetChamados()
        {
            var dt = new DataTable();
            try
            {
                var query = @"SELECT CHA.CHAMADO_ID,
       CHA.APOLICE_ID,
	   CHA.DATAHORAABERTURACHAMADO AS DATAHORAACIDENTE,
	   SCHA.NOME as STATUS,
	   CLI.NOME,
	   VEIC.PLACA,
	   VEIC.MODELO,
	   CHA.VEICULOSELOCOMOVE
 FROM CHAMADO AS CHA
 INNER JOIN STATUSCHAMADO AS SCHA ON CHA.STATUSCHAMADO = SCHA.STATUS_ID  
 INNER JOIN APOLICE AS APO ON CHA.APOLICE_ID = APO.APOLICE_ID 
 INNER JOIN CLIENTE AS CLI ON APO.CLIENTE_ID = CLI.CLIENTE_ID
 INNER JOIN VEICULO AS VEIC ON APO.VEICULO_ID = VEIC.VEICULO_ID

";

                dt = SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return dt;
        }

        public DataTable GetChamadosById(int id)
        {
            var dt = new DataTable();
            try
            {
                var query = @"SELECT CHA.CHAMADO_ID,
       CHA.APOLICE_ID,
	   CHA.DATAHORAACIDENTE,
	   SCHA.NOME as STATUS,
	   CLI.NOME,
	   CLI.CPF,
	   CLI.RG,
	   VEIC.CHASSI,
	   CHA.PARTESDOVEICULOCOLIDIDA,
	   CHA.QUANTIDADETERCEIROSENVOLVIDOS,
	   CHA.RUAAVENIDA,CHA.BAIRRO,CHA.ESTADO,CHA.NUMERO,CHA.DESCRISSAOCHAMADO,
	   CHA.OBSERVACAO,CHA.COPIACNHENVIADA,CHA.COPIACOMPENDERECO,CHA.COPIABO,
	   CHA.DATAHORAABERTURACHAMADO,
	   VEIC.PLACA,
	   VEIC.MODELO,
	   CHA.VEICULOSELOCOMOVE
 FROM CHAMADO AS CHA
 INNER JOIN STATUSCHAMADO AS SCHA ON CHA.STATUSCHAMADO = SCHA.STATUS_ID  
 INNER JOIN APOLICE AS APO ON CHA.APOLICE_ID = APO.APOLICE_ID 
 INNER JOIN CLIENTE AS CLI ON APO.CLIENTE_ID = CLI.CLIENTE_ID
 INNER JOIN VEICULO AS VEIC ON APO.VEICULO_ID = VEIC.VEICULO_ID
 where chamado_id = " + id;
                dt = SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return dt;
        }

        public void AtualizaSla(int quantaberto, int quantanalise)
        {
            var query = "UPDATE SLA SET ABERTO = " + quantaberto + " , ANALISE = " + quantanalise + " where sla_Id = 1";
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, query, null);
        }

        public DataTable GetSla()
        {
            var query = "SELECT * FROM SLA";
            return SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
        }

        public void AtualizaChamado(int chamado_id, int statusquevai, DateTime dtEntradaStatusAnt, DateTime dtEntradaAtu, string temponostatus, int STATUSATU)
        {
            try {
                var queryinserehistorico = @"INSERT INTO HistoricoEvolucaoChamado VALUES({0},'{1}','{2}','{3}',{4},{5})";
                queryinserehistorico = string.Format(queryinserehistorico, chamado_id, temponostatus, dtEntradaStatusAnt, dtEntradaAtu, STATUSATU, statusquevai);
                var queryatulizastatus = "UPDATE CHAMADO SET STATUSCHAMADO = " + statusquevai + "WHERE CHAMADO_ID = " + chamado_id;
                //SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, queryinserehistorico, null);
                SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, queryatulizastatus, null);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}