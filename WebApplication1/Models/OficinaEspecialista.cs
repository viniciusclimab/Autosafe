using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class OficinaEspecialista
    {
        private DAO.OficinaDAO oficinaDao;
        public OficinaEspecialista()
        {
            oficinaDao = new DAO.OficinaDAO();

        }

        public List<OficinaModel> MontaListaOficinaAplicativo()
        {
            try
            {
                #region OficinaDadosGerais
                var oficinas = oficinaDao.GetOficinaAtivas();
                var listoficinas = new List<OficinaModel>();
                for (int i = 0; i < oficinas.Rows.Count; i++)
                {
                    var id = Int32.Parse(oficinas.Rows[i]["oficina_id"].ToString());
                    var oficinamodel = new OficinaModel
                    {
                        Oficina_id = id,
                        NomeFantasia = oficinas.Rows[i]["razaosocial"].ToString(),
                        Endereco = string.Format("{0} Nº{1},{2}", oficinas.Rows[i]["rua"].ToString(),
                                                            oficinas.Rows[i]["numero"].ToString(),
                                                            oficinas.Rows[i]["bairro"].ToString()),
                        Cep = oficinas.Rows[i]["cep"].ToString(),
                        CidadeEstado = string.Format("Cidade: {0}, {1}", oficinas.Rows[i]["cidade"].ToString(),
                                                                                   oficinas.Rows[i]["estado"].ToString()),
                        HorarioFuncionamento = oficinas.Rows[i]["horariofuncionamento"].ToString(),
                        Telefone = oficinas.Rows[i]["telefoneprincipal"].ToString(),
                        Email = oficinas.Rows[i]["email"].ToString()
                    };

                    #endregion

                    #region OficinaServicos

                    var servicos = oficinaDao.GetServicosOficina(id);
                    var listservicos = new List<Servicos>();


                    if (servicos != null)
                    {

                        for (int j = servicos.Rows.Count - 1; j >= 0; j--)
                        {
                            var objetoServico = new Servicos
                            {
                                TipoServico = servicos.Rows[j]["tiposervico"].ToString(),
                                DescrissaoServico = servicos.Rows[j]["descricao"].ToString()
                            };
                            listservicos.Add(objetoServico);
                        }
                    }
                    else
                    {
                        var objetoservico = new Servicos
                        {
                            TipoServico = "Não Cadastrado",
                            DescrissaoServico = "Não Cadastrado"
                        };
                        listservicos.Add(objetoservico);
                    }
                    oficinamodel.ListaDeServicos = listservicos;
                    #endregion
                    #region NotaseOpinioesOficina
                    var notas = oficinaDao.GetNotasOficina(id);
                    var listopinioes = new List<OpiniaoModel>();
                    if (notas.Rows.Count > 0)
                    {
                        var medianotas = 0;
                        for (int j = 0; j < notas.Rows.Count; j++)
                        {
                            var opinioes = new OpiniaoModel();
                            if (j != 0)
                            {
                                if (listopinioes.Count < 3)
                                {
                                    opinioes.Nota = Int32.Parse(notas.Rows[j]["notaoficina"].ToString());
                                    medianotas = medianotas + opinioes.Nota;
                                    opinioes.JustificativaNota = notas.Rows[j]["descrissaoOficina"].ToString();
                                    listopinioes.Add(opinioes);
                                }
                                else
                                {
                                    medianotas = medianotas + Int32.Parse(notas.Rows[j]["notaoficina"].ToString());
                                }

                            }
                            else
                            {
                                opinioes.Nota = Int32.Parse(notas.Rows[j]["notaoficina"].ToString());
                                medianotas = opinioes.Nota;
                                opinioes.JustificativaNota = notas.Rows[j]["descrissaoOficina"].ToString();
                                listopinioes.Add(opinioes);
                            }
                        }
                        oficinamodel.NotaOficina = (medianotas / notas.Rows.Count);
                    }
                    else
                    {

                        var objetoopiniao = new OpiniaoModel
                        {
                            JustificativaNota = "Nota não cadastrada",
                            Nota = 0

                        };
                        oficinamodel.NotaOficina = 0;
                        listopinioes.Add(objetoopiniao);
                    }
                    oficinamodel.ListaDeOpinioes = listopinioes;
                    listoficinas.Add(oficinamodel);
                }

                #endregion
                #region OrdenacaoPorNota
                var ordena = listoficinas.OrderByDescending(o => o.NotaOficina);
                var listatratada = new List<OficinaModel>();
                foreach (var item in ordena)
                {
                    listatratada.Add(item);

                }
                #endregion
                return listatratada;
            }
            catch (Exception)
            {
                throw;
            }

        }
    } }