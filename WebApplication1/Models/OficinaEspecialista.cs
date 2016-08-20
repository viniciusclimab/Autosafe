using System;
using System.Collections.Generic;
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
            var ListaDeOficinas = new List<OficinaModel>();
            try {
                var oficinas = oficinaDao.GetOficinaAtivas();
                for (int i = 0; i < oficinas.Rows.Count; i++)
                {
                    var ObjetoOficina = new Models.OficinaModel();
                    var id = Int32.Parse(oficinas.Rows[i]["oficina_id"].ToString());
                    ObjetoOficina.NomeFantasia = oficinas.Rows[i]["razaosocial"].ToString();
                    ObjetoOficina.Endereco = string.Format("{0} Nº{1},{2}", oficinas.Rows[i]["rua"].ToString(),
                                                            oficinas.Rows[i]["numero"].ToString(),
                                                            oficinas.Rows[i]["bairro"].ToString());
                    ObjetoOficina.Cep = oficinas.Rows[i]["cep"].ToString();
                    ObjetoOficina.CidadeEstado = string.Format("Cidade: {0}, {1}", oficinas.Rows[i]["cidade"].ToString(),
                                                                                   oficinas.Rows[i]["estado"].ToString());
                    ObjetoOficina.HorarioFuncionamento = oficinas.Rows[i]["horariofuncionamento"].ToString();
                    ObjetoOficina.Telefone = oficinas.Rows[i]["telefoneprincipal"].ToString();
                    var servicosOficina = oficinaDao.GetServicosOficina(id);
                    var servicos = new List<Servicos>();
                    if (servicosOficina != null)
                    {
                        for (int j = 0; j < servicosOficina.Rows.Count; j++)
                        {
                            var objetoServico = new Servicos();
                            objetoServico.TipoServico = servicosOficina.Rows[j]["tiposervico"].ToString();
                            objetoServico.DescrissaoServico = servicosOficina.Rows[j]["descricao"].ToString();

                            servicos.Add(objetoServico);
                        }
                    }
                    ObjetoOficina.ListaDeServicos = servicos;

                    var dtnotas = oficinaDao.GetNotasOficina(id);
                    var opinioes = new List<string>();
                    if (dtnotas.Rows.Count > 0)
                    {
                        int notamedia = 0;
                        for (int j = 0; j < dtnotas.Rows.Count; j++)
                        {
                            notamedia = notamedia + Int32.Parse(dtnotas.Rows[j]["notaoficina"].ToString());
                            var opiniao = dtnotas.Rows[j]["descrissaoOficina"].ToString();

                            if (!string.IsNullOrEmpty(opiniao)) opinioes.Add(opiniao);
                        }
                        notamedia = notamedia / dtnotas.Rows.Count;
                        ObjetoOficina.ListaDeOpinioes = opinioes;
                        ObjetoOficina.NotaOficina = notamedia;
                    }
                    else
                    {
                        ObjetoOficina.NotaOficina = 0;
                        var listOpinioes = new List<String>();
                        listOpinioes.Add("Oficina sem Opiniões Cadastradas");
                        ObjetoOficina.ListaDeOpinioes = listOpinioes;

                    }
                    ListaDeOficinas.Add(ObjetoOficina);
                    ListaDeOficinas.Sort();

                }
                return ListaDeOficinas;
            }
            catch ( Exception ex)
            {
                Console.WriteLine("Exception no MontaListaDeOficinas" +ex.StackTrace);
                throw;
            }
    }
    } }