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
                , objetochamado.quantveicenvolvidos, 1);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    var chamado_id = Int32.Parse(dt.Rows[0]["chamado_id"].ToString());

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
            chamadodao.AtualizaChamado(objetoList.NumSinistro, 2, dtant, dtatu, quantmin.ToString(), 1);

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
            if (chamados.Rows.Count > 0)
            {
                for (int i = 0; i < chamados.Rows.Count; i++)
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
        public List<ChamadoExibicaoAplicativo> ConsultaChamadosByClienteId(int cliente_id)
        {
            var apolices = chamadodao.GetApolicesByClienteId(cliente_id);
            var listaApolices = new List<int>();
            for (int i = 0; i < apolices.Rows.Count; i++)
            {
                listaApolices.Add(Int32.Parse(apolices.Rows[i]["apolice_id"].ToString()));
            }
            var chamados = chamadodao.GetChamadoByApolicesId(listaApolices);
            //MONTA A LISTA DE RETORNO
            var listchamados = new List<ChamadoExibicaoAplicativo>();
            for (int i = 0; i < chamados.Rows.Count; i++)
            {
                var objetochamado = new ChamadoExibicaoAplicativo();
                var copiacnh = chamados.Rows[i]["copiacnhenviada"].ToString();
                var copiacompendereco = chamados.Rows[i]["copiacompendereco"].ToString();
                var copiabo = chamados.Rows[i]["copiabo"].ToString();
                if(copiabo.Equals("True"))
                {
                    objetochamado.BOEntregue = "SIM";
                }
                else
                {
                    objetochamado.BOEntregue = "NÃO";
                }
                if(copiacompendereco.Equals("True"))
                {
                    objetochamado.CompEndEntregue = "SIM";
                }
                else
                {
                    objetochamado.CompEndEntregue = "NÃO";
                }
                if(copiacnh.Equals("True"))
                {
                    objetochamado.CnhEntregue = "SIM";
                }
                else
                {
                    objetochamado.CnhEntregue = "NAO";
                }
                objetochamado.DataHoraChamado = chamados.Rows[i]["datahoraacidente"].ToString();
                objetochamado.DescChamado = chamados.Rows[i]["descrissaochamado"].ToString(); 
                objetochamado.ChamadoNum = Int32.Parse(chamados.Rows[i]["chamado_id"].ToString());
                objetochamado.NomeCondutor = chamados.Rows[i]["nome"].ToString();
                objetochamado.Placa = chamados.Rows[i]["placa"].ToString();
                objetochamado.Modelo = chamados.Rows[i]["modelo"].ToString();
                objetochamado.Status = chamados.Rows[i]["StatusChamado"].ToString();
                objetochamado.TempoDeGuincho = chamados.Rows[i]["tempoguincho"].ToString();

                var dtservicos = chamadodao.GetServicosByChamado_id(objetochamado.ChamadoNum);
                for (int j = 0; j < dtservicos.Rows.Count; j++)
                {
                    var service_id = Int32.Parse(dtservicos.Rows[j]["servicos_id"].ToString());
                    if(service_id == 4)
                    {
                        objetochamado.DescricaoDoNegado = dtservicos.Rows[j]["DescrissaoMotivo"].ToString();
                    }
                    if(service_id == 1)
                    {
                        objetochamado.DescricaoEletrica = dtservicos.Rows[j]["DescrissaoMotivo"].ToString();

                    }
                    if(service_id == 2)
                    {
                        objetochamado.DescricaoMecanica = dtservicos.Rows[j]["DescrissaoMotivo"].ToString();
                    }

                    if (service_id == 3)
                    {
                        objetochamado.DescricaoFunilaria = dtservicos.Rows[j]["DescrissaoMotivo"].ToString();
                    }
                }
                objetochamado.Msg = RetornaMensagem(objetochamado.Status);
                if (String.IsNullOrEmpty(objetochamado.DescricaoMecanica)) objetochamado.DescricaoMecanica = "Reparo não liberado";
                if (String.IsNullOrEmpty(objetochamado.DescricaoFunilaria)) objetochamado.DescricaoFunilaria = "Reparo não liberado";
                if (String.IsNullOrEmpty(objetochamado.DescricaoEletrica)) objetochamado.DescricaoEletrica = "Reparo não liberado";
                if (string.IsNullOrEmpty(objetochamado.TempoDeGuincho)) objetochamado.TempoDeGuincho = "Não enviado para esse chamado";
                if (string.IsNullOrEmpty(objetochamado.DescricaoDoNegado)) objetochamado.DescricaoDoNegado = "Não atende esse chamado";

                listchamados.Add(objetochamado);

            }
            return listchamados;
        }



        public string RetornaMensagem(string status)
        {
            string msg = string.Empty;

            switch (status)
            {
                case "Aberto":
                    msg = "Por gentileza, aguarde a análise do seu sinistro";
                    break;
                case "Em Analise":
                    msg = "Já estamos analisando o seu sinistro, fique atento para novas atualizações e pendência de documentos.";
                    break;
                case "Em Manutenção":
                    msg = "Já  analisamos, agora  o seu veículo foi encaminhado a  oficina e você irá acompanhar os reparos pelo aplicativo.";
                    break;
                case "Manutenção Finalizada":
                    msg = "O serviço já foi finalizado pela oficina. Por favor, retire seu veículo e nos avalie em seguida consultando este sinistro.";
                    break;
                case "Finalizado":
                    msg = "Seu sinistro foi finalizado com sucesso. Se decidir avaliar os serviços de acompanhamento de sinistro e a oficina, pressione o botão Avaliar Serviços";
                    break;
                case "Opiniao Cadastrada":
                    msg = "Muito obrigado por avaliar a oficina e nos avaliar. Utilizaremos esta avaliação para melhorar o atendimento.";
                    break;
                case "Guincho":
                    msg = "Seu Guicnho foi enviado.Abaixo o tempo médio de chegada do mesmo.";
                    break;
                    case "Cancelado pelo Atendente":
                    msg = "Por algo ilicito seu chamado foi cancelado abaixo o motivo do cancelamento";
                    break;

            }
            return msg;

        }
    }
}