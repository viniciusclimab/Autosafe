using System.Data;
using System;
using System.Web.Configuration;
using Kernel.Persistencia;

namespace WebApplication1.DAO
{
    public class OficinaDAO
    {
        public string ConnectionString { get; set; }

        public OficinaDAO()
        {
            try
            {
                ConnectionString = WebConfigurationManager.ConnectionStrings["BANCO"].ConnectionString;
            }
            catch (Exception ex)
            {
                Console.Write("Exception no GetOficinaAtivas" + ex.StackTrace);
            }
        }
        //Metodo utilizado para retorno de oficinas ativas para o APP e para consulta web de oficinas 
        public DataTable GetOficinaAtivas()
        {
            try {
                var query = @"select oficina_id,razaosocial,nomefantasia,estado,cidade,bairro,endereco as rua ,numero,
                                 cep,telefoneprincipal,horariofuncionamento
                         from oficina where isativa = 1 ";

                return SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text,query, null);

            }
            catch(Exception ex)
            {
                Console.Write("Exception no GetOficinaAtivas" + ex.StackTrace);
                throw;
            }
      }

        // Metodo utilizado para retorno das notas da oficina para ordenar a lista que aparece no APP
        public DataTable GetNotasOficina(int oficina_id)
        {
            try
            {
                var query = string.Format(@"select co.notaoficina, co.descrissaoOficina from oficinaservicos as os
                                            Inner Join chamadoopiniao as co
                                            on co.chamado_id = os.chamado_id
                                            where os.oficina_id = {0} ", oficina_id);

                return SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);

            }
            catch (Exception ex)
            {
                Console.Write("Exception no GetNotasOficina" + ex.StackTrace);
                throw;
            }

        }
        public DataTable GetServicosOficina(int oficina_id)
        {
            try
            {
                var query = string.Format(@"select s.tiposervico, s.descricao from oficinaservicosprestados as osp
                                            join servicos as s on osp.servicos_id = s.servicos_id
                                             where oficina_id = {0} ", oficina_id);

                return SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);

            }
            catch (Exception ex)
            {
                Console.Write("Exception no GetNotasOficina" + ex.StackTrace);
                throw;
            }
        }
 
    }
}