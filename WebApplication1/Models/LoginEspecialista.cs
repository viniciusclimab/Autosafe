using System;
using System.Collections.Generic;
using System.Data;

namespace WebApplication1.Models
{
    public class LoginEspecialista
    {
        DAO.LoginDAO logindao = new DAO.LoginDAO();
        LoginModel loginmodelo = new LoginModel();
        List<ClienteModel> clienteslista = new List<ClienteModel>();
        List<VeiculoModel> veiculoslista = new List<VeiculoModel>();
        List<ApoliceModel> apolicelista = new List<ApoliceModel>();
        List<DependenteModel> dependenteslista = new List<DependenteModel>();
        List<ClienteDependenteModel> clientesdependentes = new List<ClienteDependenteModel>();
        int veiculo_id;
        int dependente_id;
        bool dependentelogado = false;
        //LoginModel loginmodelo = new LoginModel();
        public LoginModel getLogin(string cpf, string senha)
        {

            try
            {

                DataTable dt = logindao.GetLoginSegurado(cpf, senha);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CarregaCamposVeiculo(dt, i);
                        CarregaCamposApolice(dt, i);
                    }
                    CarregaCamposCliente(dt, 0);
                    loginmodelo.apolicemodel = apolicelista;
                    loginmodelo.clientemodel = clienteslista;
                    loginmodelo.dependentemodel = dependenteslista;
                    loginmodelo.listaveiculos = veiculoslista;
                    loginmodelo.clientedep = clientesdependentes;
                    loginmodelo.StatusRetorno = 0;
                }
                else
                {
                    dt = logindao.GetLoginDependente(cpf, senha);
                    dependentelogado = true;
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        CarregaCamposApolice(dt, i);
                        CarregaCamposVeiculo(dt, i);
                        CarregaCamposClienteDependete(dt, i, dependente_id);
                    }
                    CarregaCamposDependeLogin(dt, 0);
                    loginmodelo.apolicemodel = apolicelista;
                    loginmodelo.clientemodel = clienteslista;
                    loginmodelo.dependentemodel = dependenteslista;
                    loginmodelo.listaveiculos = veiculoslista;
                    loginmodelo.clientedep = clientesdependentes;
                    loginmodelo.StatusRetorno = 0;
                }

            }

            catch (Exception ex)
            {

            }
            return loginmodelo;

        }

        private void CarregaCamposVeiculo(DataTable dt, int i)
        {

            VeiculoModel veiculoobj = new VeiculoModel();
            veiculoobj.Ano = Int32.Parse(dt.Rows[i]["ano"].ToString());
            veiculoobj.Chassi = Int32.Parse(dt.Rows[i]["chassi"].ToString());
            veiculo_id = Int32.Parse(dt.Rows[i]["Veiculo_id"].ToString());
            veiculoobj.VeiculoId = veiculo_id;
            veiculoobj.Modelo = dt.Rows[i]["modelo"].ToString();
            veiculoobj.Cor = dt.Rows[i]["cor"].ToString();
            veiculoobj.Fabricante = dt.Rows[i]["fabricante"].ToString();
            int rastreador = Int32.Parse(dt.Rows[i]["possuirastreador"].ToString());
            if (rastreador == 1) veiculoobj.PossuiRastreador = true;
            else veiculoobj.PossuiRastreador = false;
            veiculoobj.Placa = dt.Rows[i]["placa"].ToString();
            veiculoobj.Renavan = dt.Rows[i]["renavan"].ToString();
            veiculoslista.Add(veiculoobj);

        }
        private void CarregaCamposApolice(DataTable dt, int i)
        {
            int apolice_id = Int32.Parse(dt.Rows[i]["Apolice_id"].ToString());
           if(!dependentelogado) CarregaCamposDependente(apolice_id);
            ApoliceModel apoliceobjj = new ApoliceModel();
            apoliceobjj.Veiculo_id = veiculo_id;
            apoliceobjj.ApoliceId = apolice_id;
            apoliceobjj.DataValidade = DateTime.Parse(dt.Rows[i]["DATAVALIDADE"].ToString()).ToShortDateString();
            apoliceobjj.DescricaoUsoVeiculo = dt.Rows[i]["descricaousoveiculo"].ToString();
            apoliceobjj.LocalDaPernoite = dt.Rows[i]["localdapernoite"].ToString();
            apolicelista.Add(apoliceobjj);
        }
        private void CarregaCamposDependente(int apolice_id)
        {
            DataTable dts = logindao.GetDependentes(apolice_id);
            for (int j = 0; j < dts.Rows.Count; j++)
            {
                DependenteModel dependenteobj = new DependenteModel();
                dependenteobj.ClienteId = Int32.Parse(dts.Rows[j]["dependente_id"].ToString());
                dependenteobj.Nome = dts.Rows[j]["Nome"].ToString();
                dependenteobj.DataNasc = DateTime.Parse(dts.Rows[j]["DATANASC"].ToString()).ToShortDateString();
                dependenteobj.Cpf = dts.Rows[j]["CPF"].ToString();
                dependenteobj.Rg = dts.Rows[j]["RG"].ToString();
                dependenteobj.Email = dts.Rows[j]["EMAIL"].ToString();
                dependenteobj.Celular = dts.Rows[j]["CELULAR"].ToString();
                dependenteobj.Endereco = dts.Rows[j]["Endereco"].ToString();
                dependenteobj.Bairro = dts.Rows[j]["Bairro"].ToString();
                dependenteobj.Estado = dts.Rows[j]["Endereco"].ToString();
                dependenteobj.Cidade = dts.Rows[j]["Cidade"].ToString();
                dependenteobj.Cep = Int32.Parse(dts.Rows[j]["CEP"].ToString());
                dependenteobj.NumHabilatacao = dts.Rows[j]["NUMHABILITACAO"].ToString();
                dependenteobj.Categoria = dts.Rows[j]["Categoria"].ToString();
                dependenteobj.DataValidade = DateTime.Parse(dts.Rows[j]["DATADEVALIDADE"].ToString()).ToShortDateString();
                dependenteobj.DataValidade = DateTime.Parse(dts.Rows[j]["DATADEEMISSAO"].ToString()).ToShortDateString();
                dependenteobj.LocalEmissao = dts.Rows[j]["LocalEmissao"].ToString();
                dependenteobj.Apolice_id = apolice_id;
                dependenteslista.Add(dependenteobj);
            }
        }
        private void CarregaCamposCliente(DataTable dt, int i)
        {
            ClienteModel clienteobjj = new ClienteModel();
            clienteobjj.ClienteId = Int32.Parse(dt.Rows[i]["Cliente_id"].ToString());
            clienteobjj.Nome = dt.Rows[i]["Nome"].ToString();
            clienteobjj.DataNasc = DateTime.Parse(dt.Rows[i]["DATANASC"].ToString()).ToShortDateString();
            clienteobjj.Cpf = dt.Rows[i]["CPF"].ToString();
            clienteobjj.Rg = dt.Rows[i]["RG"].ToString();
            clienteobjj.Email = dt.Rows[i]["EMAIL"].ToString();
            clienteobjj.Celular = dt.Rows[i]["CELULAR"].ToString();
            clienteobjj.Endereco = dt.Rows[i]["Endereco"].ToString();
            clienteobjj.Bairro = dt.Rows[i]["Bairro"].ToString();
            clienteobjj.Estado = dt.Rows[i]["Endereco"].ToString();
            clienteobjj.Cidade = dt.Rows[i]["Cidade"].ToString();
            clienteobjj.Cep = Int32.Parse(dt.Rows[i]["CEP"].ToString());
            clienteobjj.NumHabilatacao = dt.Rows[i]["NUMHABILITACAO"].ToString();
            clienteobjj.Categoria = dt.Rows[i]["Categoria"].ToString();
            clienteobjj.DataValidade = DateTime.Parse(dt.Rows[i]["DATADEVALIDADE"].ToString()).ToShortDateString();
            clienteobjj.DataValidade = DateTime.Parse(dt.Rows[i]["DATADEEMISSAO"].ToString()).ToShortDateString();
            clienteobjj.LocalEmissao = dt.Rows[i]["LocalEmissao"].ToString();
            clienteslista.Add(clienteobjj);


        }
        private void CarregaCamposDependeLogin(DataTable dts, int j)
        {
            DependenteModel dependenteobj = new DependenteModel();
            dependente_id = Int32.Parse(dts.Rows[j]["dependente_id"].ToString());
            dependenteobj.ClienteId = dependente_id;
            dependenteobj.Nome = dts.Rows[j]["nomedep"].ToString();
            dependenteobj.DataNasc = DateTime.Parse(dts.Rows[j]["datanascdep"].ToString()).ToShortDateString();
            dependenteobj.NomeMae = dts.Rows[j]["nomemaedep"].ToString();
            dependenteobj.Cpf = dts.Rows[j]["cpfdep"].ToString();
            dependenteobj.Rg = dts.Rows[j]["rgdep"].ToString();
            dependenteobj.Email = dts.Rows[j]["emaildep"].ToString();
            dependenteobj.Telefone = dts.Rows[j]["telefonedep"].ToString();
            dependenteobj.Celular = dts.Rows[j]["celulardep"].ToString();
            dependenteobj.Endereco = dts.Rows[j]["enderecodep"].ToString();
            dependenteobj.Bairro = dts.Rows[j]["bairrodep"].ToString();
            dependenteobj.Estado = dts.Rows[j]["estadodep"].ToString();
            dependenteobj.Cidade = dts.Rows[j]["cidadedep"].ToString();
            dependenteobj.Cep = Int32.Parse(dts.Rows[j]["cepdep"].ToString());
            dependenteobj.NumHabilatacao = dts.Rows[j]["numhadep"].ToString();
            dependenteobj.Categoria = dts.Rows[j]["categoriadep"].ToString();
            dependenteobj.DataValidade = DateTime.Parse(dts.Rows[j]["datavalidadedep"].ToString()).ToShortDateString();
            dependenteobj.DataValidade = DateTime.Parse(dts.Rows[j]["dataemissaodep"].ToString()).ToShortDateString();
            dependenteobj.LocalEmissao = dts.Rows[j]["localemissaodep"].ToString();
            dependenteobj.Apolice_id = Int32.Parse(dts.Rows[j]["Apolice_id"].ToString());
            dependenteslista.Add(dependenteobj);


        }
        private void CarregaCamposClienteDependete(DataTable dt, int i, int dependente_id)
        {
            ClienteDependenteModel clienteobjj = new ClienteDependenteModel();
            clienteobjj.DependenteId = dependente_id;
            clienteobjj.ClienteId = Int32.Parse(dt.Rows[i]["Cliente_id"].ToString());
            clienteobjj.Nome = dt.Rows[i]["Nome"].ToString();
            clienteobjj.DataNasc = DateTime.Parse(dt.Rows[i]["DATANASC"].ToString()).ToShortDateString();
            clienteobjj.Cpf = dt.Rows[i]["CPF"].ToString();
            clienteobjj.Rg = dt.Rows[i]["RG"].ToString();
            clienteobjj.Email = dt.Rows[i]["EMAIL"].ToString();
            clienteobjj.Celular = dt.Rows[i]["CELULAR"].ToString();
            clienteobjj.Endereco = dt.Rows[i]["Endereco"].ToString();
            clienteobjj.Bairro = dt.Rows[i]["Bairro"].ToString();
            clienteobjj.Estado = dt.Rows[i]["Endereco"].ToString();
            clienteobjj.Cidade = dt.Rows[i]["Cidade"].ToString();
            clienteobjj.Cep = Int32.Parse(dt.Rows[i]["CEP"].ToString());
            clienteobjj.NumHabilatacao = dt.Rows[i]["NUMHABILITACAO"].ToString();
            clienteobjj.Categoria = dt.Rows[i]["Categoria"].ToString();
            clienteobjj.DataValidade = DateTime.Parse(dt.Rows[i]["DATADEVALIDADE"].ToString()).ToShortDateString();
            clienteobjj.DataValidade = DateTime.Parse(dt.Rows[i]["DATADEEMISSAO"].ToString()).ToShortDateString();
            clienteobjj.LocalEmissao = dt.Rows[i]["LocalEmissao"].ToString();
            clientesdependentes.Add(clienteobjj);
        }

        public int GetLoginWeb(string cpf, string senha)
        {
            int retorno = 0;
           if( cpf.Length == 11)
            {
                retorno = GetAtendente(cpf, senha); 
            }
           else if (cpf.Length == 14)
            {
               retorno =  GetOficina(cpf, senha);
            }
           else
            {
                retorno = -1;
            }
            return retorno;
        }

        public int GetOficina(string cnpj , string senha)
        {
            int retorno = -1;
            try
            {
                DataTable dt = logindao.GetLoginOficina(cnpj, senha);
                if(dt.Rows.Count > 0)
                {
                    retorno = 2;
                }

            }
            catch(Exception ex)
            {

            }
            return retorno;
        }
        public int GetAtendente(string cpf, string senha)
        {
            int retorno = -1;
            try
            {
                DataTable dt = logindao.GetLoginAtedente(cpf, senha);
                if (dt.Rows.Count > 0)
                {
                    retorno = 0;
                }
               
            }
            catch (Exception ex)
            {

            }
            return retorno;
        }


        public string AtualizaSenha(string cpf, string senha, string datanasc)
        {
            return logindao.AtualizaSenha(cpf, senha, datanasc);
        }
        public string AtualizaSenhaWeb(string cpf, string senha, string datanasc)
        {
            string retorno;

            if(cpf.Length == 11)
            {
                retorno = logindao.AtualizaSenhaAtendente(cpf, senha, datanasc);

            }
            else if (cpf.Length == 14)
            {
                retorno = logindao.AtualizaSenhaOficina(cpf, senha, datanasc);
            }
            else
            {
                retorno = "Cpf ou Cnpj inválidos";
            }
            return retorno;
        }
    }
}