using System;
using System.Web.Configuration;
using Kernel.Persistencia;
using System.Data;
using System.Collections.Generic;
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
            string descchamado, string obschaamdo, int quant_veic_env, int oficina_id)
        {
            try
            {
                var query = @"INSERT INTO [dbo].[Chamado]([PartesDoVeiculoColidida],[RuaAvenida],[Bairro],[Estado],[Numero]
                            ,[quantidadeterceirosenvolvidos],[veiculoselocomove],[datahoraacidente] ,[statuschamado]
                            ,[apolice_id],[descrissaochamado],[Observacao] ,[copiacnhenviada] ,[copiacompendereco]
                            ,[copiabo],[datahoraaberturachamado],[CPFCONDUTOR],oficina_id)VALUES
                             ('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}',{8},{9},'{10}','{11}','{12}','{13}','{14}','{15}','{16}',{17})";

                query = string.Format(query, partesveiculosenvolvida, ruaavenida, bairro, cidade, numero, quant_veic_env, veiclocomove,
                                      datahorachamado, 1, apolice_id, descchamado, "vazio", false, false, false, DateTime.Now, cpfcnpj,oficina_id);

                SqlHelper.ExecuteNonQuery(ConnectionString, System.Data.CommandType.Text,
                                                                query, null);
                DataTable dt = SqlHelper.ExecuteDataTable(ConnectionString, System.Data.CommandType.Text, "SELECT max(chamado_id) as chamado_id FROM CHAMADO WHERE " +
                   " apolice_id = " + apolice_id);
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

        public DataTable GetChamadoByOficinaCnpj(string cnpj)
        {
            var query = @"select cha.chamado_id,cli.nome,cli.cpf,veic.modelo,veic.placa,veic.chassi,sta.nome as nomecha,cha.datahoraaberturachamado
                          from oficina as ofi
                          join chamado as cha on ofi.oficina_id = cha.oficina_id  
                          join apolice as apo on cha.apolice_id = apo.apolice_id
                          join cliente as cli on cli.cliente_id = apo.cliente_id
                          join veiculo as veic on veic.veiculo_id = apo.veiculo_id
                          join StatusChamado as sta on sta.Status_id = cha.statuschamado
                          where ofi.cnpi = '"+cnpj+ @"' and
                          cha.statuschamado in(3,4)  order by cha.statuschamado;";
            return SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);

        }

        public DataTable GetChamadoByApolicesId(List<int>apolicesId)
        {
            var where = "( ";
            var dt = new DataTable();
            try
            {
                for (int i = 0; i < apolicesId.Count; i++)
                {
                    where = where + apolicesId[i].ToString() + ", ";
                }

                var query = @"select 
cha.chamado_id,
cha.copiacnhenviada,
cha.copiacompendereco,
cha.copiabo,
cha.datahoraacidente,
cha.descrissaochamado,
cli.nome,
veic.modelo,
veic.placa,
cha.tempoguincho,
sc.Nome as StatusChamado
from chamado as cha
join apolice as apo on cha.apolice_id = apo.apolice_id
join cliente as cli on apo.cliente_id = cli.cliente_id
join veiculo as veic on apo.veiculo_id = veic.veiculo_id
join statuschamado as sc on sc.status_id = statuschamado
where cha.apolice_id in " + where + " 0)";

                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text,
                    query, null);
            }
            catch(Exception ex)
            {

            }

            return dt;


        }

        public DataTable GetApolicesByClienteId(int cliente_id)
        {
            var dt = new DataTable();

            try
            {
                var query = @"SELECT APO. APOLICE_ID FROM CLIENTE AS CLI
                         JOIN APOLICE AS APO ON CLI.CLIENTE_ID = APO.CLIENTE_ID 
                         WHERE CLI.CLIENTE_ID = " + cliente_id;

                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);

            }
            catch(Exception ex)
            {

            }
            return dt;
            }
        public DataTable GetServicosByChamado_id(int chamado_id)
        {
            var dt = new DataTable();

            try
            {
                var query = @"SELECT * from chamadoservicos where chamado_id =  " + chamado_id;

                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);

            }
            catch (Exception ex)
            {

            }
            return dt;



        }

    }
}