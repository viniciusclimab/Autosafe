using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Globalization;
namespace WebApplication1.DAO
{
    public class LoginDAO
    {
        public string ConnectionString { get; set; }
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
        public DataTable GetLoginSegurado(string cpf, string senha)
        {
            DataTable dt = new DataTable();
            try
            {
                
                string query = "select cli.Cliente_id ,cli.Nome ,cli.DATANASC,cli.CPF,cli.RG,cli.EMAIL,cli.CELULAR, cli.Endereco,cli.Bairro," +
                     "cli.Estado,cli.Cidade,cli.CEP,cli.NUMHABILITACAO, cli.CATEGORIA, cli.DATADEVALIDADE, cli.DATADEEMISSAO,"+
                     "cli.LocalEmissao,apo.Apolice_id,apo.DATADEVALIDADE as DATAVALIDADE, apo.descricaousoveiculo,apo.localdapernoite,veic.Veiculo_id, veic.modelo," +
                     " veic.cor,veic.chassi,veic.fabricante, veic.possuirastreador,veic.ano,veic.placa,veic.renavan" +
                     " From Cliente as cli JOIN Apolice as apo ON cli.Cliente_id = apo.Cliente_id" +
                     " JOIN Veiculo as veic ON veic.Veiculo_id = apo.Veiculo_id" +
                     " WHERE cli.CPF = '" + cpf + "' AND cli.senha = '" + senha + "'";
                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
            }

            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        public DataTable GetDependentes(int apolice_id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select dep.dependente_id,dep.Nome,dep.DATANASC,dep.CPF,dep.RG,dep.EMAIL," +
 "dep.CELULAR,dep.Endereco,dep.Bairro,dep.Estado,dep.Cidade," +
 "dep.CEP,dep.NUMHABILITACAO,dep.CATEGORIA,dep.DATADEVALIDADE," +
 "dep.DATADEEMISSAO,dep.LocalEmissao" + " from apolicedependente as apo" +
 " join dependente as dep on apo.dependente_id = dep.dependente_id where apolice_id = " + apolice_id;


                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
            }

            catch (Exception ex)
            {

            }
            return dt;

        }
        public DataTable GetLoginDependente(string cpf, string senha)
        {
            DataTable dt = new DataTable();
            try {
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@cpf", SqlDbType.VarChar);
                parametros[0].Value = cpf;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("@senha", SqlDbType.VarChar);
                parametros[1].Value = senha;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("@tipoconsulta", SqlDbType.Int);
                parametros[2].Value = 2;
                parametros[2].Direction = ParameterDirection.Input;
                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.StoredProcedure, "SPGetDadosAcesso", parametros);

            }
           catch(Exception ex)
            {
                
            }
            return dt;
        }
        public DataTable GetLoginAtedente(string cpf , string senha)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from Atendente where cpf = '" + cpf + "' and senha = '" + senha+"'";
                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
            }

            catch (Exception ex)
            {

            }
            return dt;


        }
        public DataTable GetLoginOficina(string cnpj, string senha)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select * from Oficina where cnpi = '" + cnpj + "' and senha = '" + senha+"'";
                dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
            }

            catch (Exception ex)
            {

            }
            return dt;

        }
        public string AtualizaSenha(string cpf, string senha, string datanasc)
        {
            string msg = null;
            CultureInfo provider = CultureInfo.InvariantCulture;
            try
            {
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("cpf", SqlDbType.VarChar);
                parametros[0].Value = cpf;
                parametros[0].Direction = ParameterDirection.Input;
               
                var selectcli = "SPCONSULTACLI";
                var selectdep = "SPCONSULTADEP";

                DataTable dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.StoredProcedure, selectcli, parametros);
                DataTable dtdep = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.StoredProcedure, selectdep, parametros);

                DateTime dts = new DateTime();
                dts.AddDays(Int32.Parse(datanasc.Substring(0, 2)));
                dts.AddMonths(Int32.Parse(datanasc.Substring(4, 2)));
                dts.AddYears(Int32.Parse(datanasc.Substring(6, 2)));
                

                if (dtdep.Rows.Count > 0) {
                    var date0 = dtdep.Rows[0]["datanasc"].ToString();
                    date0 = date0.Substring(0, 10);
                     var date = DateTime.ParseExact(date0, "dd/MM/yyyy", provider.DateTimeFormat);

                        if (date.Equals(DateTime.ParseExact(datanasc, "dd/MM/yyyy", provider.DateTimeFormat)))
                        {
                        Kernel.Persistencia.SqlHelper.ExecuteDataTable(
                           ConnectionString, CommandType.Text, "update dependente set senha = '" + senha + "' where cpf = '" +
                           cpf+"'", null);
                        msg = "Senha alterada com sucesso";

                    }
                    else
                    {
                        msg = "Data de nascimento invalida";
                    }

                }
                   else if (dt.Rows.Count > 0)
                {
                    var date0 = dt.Rows[0]["datanasc"].ToString();
                    date0 = date0.Substring(0, 10);

                    DateTime dtss = new DateTime();
                    dtss.AddDays(Int32.Parse(datanasc.Substring(0, 2)));
                    dtss.AddMonths(Int32.Parse(datanasc.Substring(3, 2)));
                    dtss.AddYears(Int32.Parse(datanasc.Substring(6, 2)));



                    var date1 =  DateTime.ParseExact(date0, "dd/MM/yyyy", provider.DateTimeFormat);
                    if(date1.Equals(DateTime.ParseExact(datanasc, "dd/MM/yyyy", provider.DateTimeFormat)))
                    {
                        Kernel.Persistencia.SqlHelper.ExecuteDataTable(
                          ConnectionString, CommandType.Text, "update cliente set senha = '" + senha + "' where cpf = '" +
                          cpf + "'", null);
                        msg = "Senha alterada com sucesso";

                    }
                    else
                    {
                        msg = "Data de nascimento invalida";
                    }

                }

                else
                {
                    msg = "CPF não cadastrado";
                }
                /*
                string query = "SPATUALIZASENHA";
                var parametros = new SqlParameter[4];
                parametros[0] = new SqlParameter("cpf", SqlDbType.VarChar);
                parametros[0].Value = cpf;
                parametros[0].Direction = ParameterDirection.Input;
                parametros[1] = new SqlParameter("senha", SqlDbType.VarChar);
                parametros[1].Value = senha;
                parametros[1].Direction = ParameterDirection.Input;
                parametros[2] = new SqlParameter("datanasc", SqlDbType.DateTime);
                parametros[2].Value = datanasc;
                parametros[2].Direction = ParameterDirection.Input;
                parametros[3] = new SqlParameter("msg", SqlDbType.VarChar);
                parametros[3].Value = msg;
                parametros[3].Direction = ParameterDirection.Output;
                Kernel.Persistencia.SqlHelper.ExecuteDataTable(
                    ConnectionString, CommandType.StoredProcedure, query,parametros);
                    */
            }

            catch (Exception ex)
            {
                msg = "Erro ao atualizar a senha, Exception:" + ex;
            }

            return msg;

        }
        public string AtualizaSenhaOficina(string cnpj, string senha, string datacadastro)
        {
            string msg;
            string ano = datacadastro.Substring(0, 4);
            string mes = datacadastro.Substring(5, 2);
            string dia = datacadastro.Substring(8,2);
            datacadastro = dia + "/" + mes + "/" + ano;
            try { 
            string query = "SPGETOFICINA";
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("cnpj", SqlDbType.VarChar);
            parametros[0].Value = cnpj;
            parametros[0].Direction = ParameterDirection.Input;
            DataTable dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.StoredProcedure, query, parametros);
            CultureInfo provider = CultureInfo.InvariantCulture;

            if (dt.Rows.Count > 0)
            {
                string datacad = dt.Rows[0]["datacadast"].ToString();
                datacad = datacad.Substring(0, 10);
                var datanascimento = DateTime.ParseExact(datacad, "dd/MM/yyyy", provider);
                var datafornecida = DateTime.ParseExact(datacadastro, "dd/MM/yyyy", provider);
                if (datanascimento.Equals(datafornecida))
                {
                    query = "update oficina set senha = '" + senha + "' where cnpi = '" + cnpj + "'";
                    Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
                    msg = "Senha alterada com sucesso";
                }
                else
                {
                    msg = "Data de nascimento invalida";
                }
            }
            else
            {
                msg = "Cpf não cadastrado";
            }
        }
            catch(Exception ex)
            {
                msg = "Erro não reconhecido contate o administrador "+ex;

            }

            return msg;
        }
        public string AtualizaSenhaAtendente(string cpf, string senha, string datanasc)
        {
            string msg;
            try
            {
                var data1 = datanasc;
                var date2 = datanasc;
                var data3 = datanasc;
                string ano = data1.Substring(0, 4);
                string mes = date2.Substring(5, 2);
                string dia = data3.Substring(8, 2);
                datanasc = dia + "/" + mes + "/" + ano; 
                string query = "SPGETATENDENTE";
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("cpf", SqlDbType.VarChar);
                parametros[0].Value = cpf;
                parametros[0].Direction = ParameterDirection.Input;
                DataTable dt = Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.StoredProcedure, query, parametros);
                CultureInfo provider = CultureInfo.InvariantCulture;
                
                if (dt.Rows.Count > 0)
                {
                    string datanascs = dt.Rows[0]["datanasc"].ToString();
                    datanascs = datanascs.Substring(0, 10);
                    var datanascimento = DateTime.ParseExact(datanascs, "dd/MM/yyyy", provider);
                    var datafornecida = DateTime.ParseExact(datanasc, "dd/MM/yyyy", provider);
                    if (datanascimento.Equals(datafornecida))
                    {
                        query = "update atendente set senha = '" + senha + "' where cpf = '" + cpf + "'";
                        Kernel.Persistencia.SqlHelper.ExecuteDataTable(ConnectionString, CommandType.Text, query, null);
                        msg = "Senha alterada com sucesso";
                    }
                    else
                    {
                        msg = "Data de nascimento invalida";
                    }
                }
                else
                {
                    msg = "Cpf não cadastrado";
                }
            }
            catch(Exception ex)
            {
                msg = "Erro não reconhecido contate o administrador "+ex;

            }

            return msg;
        }


    }
    }
