using System.Data;
using System.Collections.Generic;
using System;
using WebApplication1.DAO;
namespace WebApplication1.Models
{
    public class ChamadoEspecialista
    {
        ChamadosDAO chamadodao = new ChamadosDAO();
        public string insereChamado(Models.ChamadoModel objetochamado)
        {
            var msg = string.Empty;
            
            var dt = chamadodao.insChamado(objetochamado.Apolice_id, objetochamado.DocumentoCondutor, objetochamado.PartesVeic,
                objetochamado.RuaAvenida, objetochamado.Bairro, objetochamado.Cidade, objetochamado.Numero,
                objetochamado.veiculolocomove, objetochamado.datahorachamado, objetochamado.descchamado, objetochamado.obschamado
                , objetochamado.quantveicenvolvidos,1);

            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                  var chamado_id =  Int32.Parse(dt.Rows[0]["chamado_id"].ToString());

                    foreach (var item in objetochamado.ListaTerceiros)
                    {
                        chamadodao.inschamadoTerceiro(chamado_id, item.PlacaTerceiro, item.ModeloTerceiro, item.Ruaavenida, item.Bairro, item.numero,
                            item.cidade, item.sentidoviaterceiro, item.partesenvolvidasdoveiculo);
                    }
                    msg = "Chamado nº " + chamado_id + "Aberto com sucesso";
                }
            }
            else
            {
                msg = "Chamado não inserido na base de dados";
            }

            return "";
        }

        public List<ChamadoModelExibicao> ConsultaChamado(int id)
        {
            var list = new List<ChamadoModelExibicao>();
            var dt = new DataTable();
            if (id == 0)
            {
                dt = chamadodao.GetChamados();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    var objetoList = new ChamadoModelExibicao
                    {
                        NomeCliente = dt.Rows[i]["NOME"].ToString(),
                        Modelo = dt.Rows[i]["MODELO"].ToString(),
                        NumApolice = Int32.Parse(dt.Rows[i]["APOLICE_ID"].ToString()),
                        NumSinistro = Int32.Parse(dt.Rows[i]["CHAMADO_ID"].ToString()),
                        Placa = dt.Rows[i]["PLACA"].ToString(),
                        Status = dt.Rows[i]["STATUS"].ToString(),
                        DataHoraChamado = dt.Rows[i]["DATAHORAACIDENTE"].ToString(),
                        veiclocomove = bool.Parse(dt.Rows[i]["VEICULOSELOCOMOVE"].ToString())
                    };

                    if (i < 2)
                    {
                        objetoList.Prioridade = 3;
                    }
                    else if (i < 5)
                    {
                        objetoList.Prioridade = 2;
                    }
                    else
                    {
                        objetoList.Prioridade = 1;
                    }
                    list.Add(objetoList);
                }

            }
            else
            {
                dt = chamadodao.GetChamadosById(id);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                    var objetoList = new ChamadoModelExibicao
                    {
                        DeescricaoChamado = dt.Rows[i]["DESCRISSAOCHAMADO"].ToString(),
                        Endereco = "Rua: " + dt.Rows[i]["RUAAVENIDA"].ToString() +
                        ", Bairro: "+ dt.Rows[i]["BAIRRO"].ToString() + "Nº "+ dt.Rows[i]["NUMERO"].ToString()
                        ,CidadeEstado = "Cidade: "+ dt.Rows[i]["ESTADO"].ToString(),
                        ObservacaoChamado = dt.Rows[i]["OBSERVACAO"].ToString(),
                        DataHoraAberturaChamado = dt.Rows[i]["DATAHORAABERTURACHAMADO"].ToString(),
                        PartesVeiculoColidida = dt.Rows[i]["PARTESDOVEICULOCOLIDIDA"].ToString(),
                        quantveic = Int32.Parse(dt.Rows[i]["QUANTIDADETERCEIROSENVOLVIDOS"].ToString()),
                        BoEnviado = bool.Parse(dt.Rows[i]["COPIABO"].ToString()),
                        CnhEnviada = bool.Parse(dt.Rows[i]["COPIACNHENVIADA"].ToString()),
                        CompEnd = bool.Parse(dt.Rows[i]["COPIACOMPENDERECO"].ToString()),
                        Chassi = dt.Rows[i]["CHASSI"].ToString(),
                        RG = dt.Rows[i]["RG"].ToString(),
                        CPF = dt.Rows[i]["CPF"].ToString(),
                        NomeCliente = dt.Rows[i]["NOME"].ToString(),
                        Modelo = dt.Rows[i]["MODELO"].ToString(),
                        NumApolice = Int32.Parse(dt.Rows[i]["APOLICE_ID"].ToString()),
                        NumSinistro = Int32.Parse(dt.Rows[i]["CHAMADO_ID"].ToString()),
                        Placa = dt.Rows[i]["PLACA"].ToString(),
                        Status = dt.Rows[i]["STATUS"].ToString(),
                        DataHoraChamado = dt.Rows[i]["DATAHORAACIDENTE"].ToString(),
                        veiclocomove = bool.Parse(dt.Rows[i]["VEICULOSELOCOMOVE"].ToString())
                    };

                    if (i < 2)
                    {
                        objetoList.Prioridade = 3;
                    }
                    else if (i < 5)
                    {
                        objetoList.Prioridade = 2;
                    }
                    else
                    {
                        objetoList.Prioridade = 1;
                    }
                    list.Add(objetoList);
                }

            }
            return list;
        }
        public List<ChamadoModelExibicao> AlteraChamado(int id)
        {
            var list = new List<ChamadoModelExibicao>();
            var dt = new DataTable();
               
               dt = chamadodao.GetChamadosById(id);
            int i = 0;
                    var objetoList = new ChamadoModelExibicao
                    {
                        DeescricaoChamado = dt.Rows[i]["DESCRISSAOCHAMADO"].ToString(),
                        Endereco = "Rua: " + dt.Rows[i]["RUAAVENIDA"].ToString() +
                        ", Bairro: " + dt.Rows[i]["BAIRRO"].ToString() + "Nº " + dt.Rows[i]["NUMERO"].ToString()
                        ,
                        CidadeEstado = "Cidade: " + dt.Rows[i]["ESTADO"].ToString(),
                        ObservacaoChamado = dt.Rows[i]["OBSERVACAO"].ToString(),
                        DataHoraAberturaChamado = dt.Rows[i]["DATAHORAABERTURACHAMADO"].ToString(),
                        PartesVeiculoColidida = dt.Rows[i]["PARTESDOVEICULOCOLIDIDA"].ToString(),
                        quantveic = Int32.Parse(dt.Rows[i]["QUANTIDADETERCEIROSENVOLVIDOS"].ToString()),
                        BoEnviado = bool.Parse(dt.Rows[i]["COPIABO"].ToString()),
                        CnhEnviada = bool.Parse(dt.Rows[i]["COPIACNHENVIADA"].ToString()),
                        CompEnd = bool.Parse(dt.Rows[i]["COPIACOMPENDERECO"].ToString()),
                        Chassi = dt.Rows[i]["CHASSI"].ToString(),
                        RG = dt.Rows[i]["RG"].ToString(),
                        CPF = dt.Rows[i]["CPF"].ToString(),
                        NomeCliente = dt.Rows[i]["NOME"].ToString(),
                        Modelo = dt.Rows[i]["MODELO"].ToString(),
                        NumApolice = Int32.Parse(dt.Rows[i]["APOLICE_ID"].ToString()),
                        NumSinistro = Int32.Parse(dt.Rows[i]["CHAMADO_ID"].ToString()),
                        Placa = dt.Rows[i]["PLACA"].ToString(),
                        Status = "Em Análise",
                        DataHoraChamado = dt.Rows[i]["DATAHORAACIDENTE"].ToString(),
                        veiclocomove = bool.Parse(dt.Rows[i]["VEICULOSELOCOMOVE"].ToString())
                    };
                    list.Add(objetoList);
            var dtant = DateTime.Parse(objetoList.DataHoraChamado);
            var dtatu = DateTime.Now;
            TimeSpan span = Convert.ToDateTime(dtatu) - Convert.ToDateTime(dtant);
            var quantmin = span.Minutes;
            chamadodao.AtualizaChamado(objetoList.NumSinistro, 2,dtant,dtatu, quantmin.ToString(),1);
            
            return list;
        }
        public List<ChamadoModelExibicao> AlteraChamadoOficina(Models.ChamadoOficinaModel cm)
        {
            var list = new List<ChamadoModelExibicao>();
            var dt = new DataTable();

            dt = chamadodao.GetChamadosById(7);
            int i = 0;
            var objetoList = new ChamadoModelExibicao
            {
                DeescricaoChamado = dt.Rows[i]["DESCRISSAOCHAMADO"].ToString(),
                Endereco = "Rua: " + dt.Rows[i]["RUAAVENIDA"].ToString() +
                ", Bairro: " + dt.Rows[i]["BAIRRO"].ToString() + "Nº " + dt.Rows[i]["NUMERO"].ToString()
                ,
                CidadeEstado = "Cidade: " + dt.Rows[i]["ESTADO"].ToString(),
                ObservacaoChamado = dt.Rows[i]["OBSERVACAO"].ToString(),
                DataHoraAberturaChamado = dt.Rows[i]["DATAHORAABERTURACHAMADO"].ToString(),
                PartesVeiculoColidida = dt.Rows[i]["PARTESDOVEICULOCOLIDIDA"].ToString(),
                quantveic = Int32.Parse(dt.Rows[i]["QUANTIDADETERCEIROSENVOLVIDOS"].ToString()),
                BoEnviado = bool.Parse(dt.Rows[i]["COPIABO"].ToString()),
                CnhEnviada = bool.Parse(dt.Rows[i]["COPIACNHENVIADA"].ToString()),
                CompEnd = bool.Parse(dt.Rows[i]["COPIACOMPENDERECO"].ToString()),
                Chassi = dt.Rows[i]["CHASSI"].ToString(),
                RG = dt.Rows[i]["RG"].ToString(),
                CPF = dt.Rows[i]["CPF"].ToString(),
                NomeCliente = dt.Rows[i]["NOME"].ToString(),
                Modelo = dt.Rows[i]["MODELO"].ToString(),
                NumApolice = Int32.Parse(dt.Rows[i]["APOLICE_ID"].ToString()),
                NumSinistro = Int32.Parse(dt.Rows[i]["CHAMADO_ID"].ToString()),
                Placa = dt.Rows[i]["PLACA"].ToString(),
                Status = "Em Análise",
                DataHoraChamado = dt.Rows[i]["DATAHORAACIDENTE"].ToString(),
                veiclocomove = bool.Parse(dt.Rows[i]["VEICULOSELOCOMOVE"].ToString())
            };
            list.Add(objetoList);
            var dtant = DateTime.Parse(objetoList.DataHoraChamado);
            var dtatu = DateTime.Now;
            TimeSpan span = Convert.ToDateTime(dtatu) - Convert.ToDateTime(dtant);
            var quantmin = span.Minutes;
            
            chamadodao.AtualizaChamado(objetoList.NumSinistro, 3, dtant, dtatu, quantmin.ToString(), 2);

            return list;


        }
        public List<ChamadoOficinaExibicao> ConsultaChamadoOficina(string cnpj)
        {
            var listaTratada = new List<ChamadoOficinaExibicao>();
            var chamados = chamadodao.GetChamadoByOficinaCnpj(cnpj);
            if(chamados.Rows.Count > 0)
            {
                for(int i = 0; i < chamados.Rows.Count; i++)
                {
                    var chamadoOficina = new ChamadoOficinaExibicao
                    {
                    NumeroDoChamado = Int32.Parse(chamados.Rows[i]["chamado_id"].ToString()),
                    NomeCliente = chamados.Rows[i]["nome"].ToString(),
                    CPF = chamados.Rows[i]["cpf"].ToString(),
                    Modelo = chamados.Rows[i]["modelo"].ToString(),
                    Placa = chamados.Rows[i]["placa"].ToString(),
                    Chassi = chamados.Rows[i]["chassi"].ToString(),
                    Status = chamados.Rows[i]["nomecha"].ToString(),
                    data = chamados.Rows[i]["datahoraaberturachamado"].ToString()
                    };
                    listaTratada.Add(chamadoOficina);
                }

            }

            return listaTratada;
        }

    }
}