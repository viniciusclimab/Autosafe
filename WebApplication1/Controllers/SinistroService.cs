using System.Web.Http;
using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SinistroService : ApiController
    {

      public string Post(string apolice_id, string documentodocondutor, string partesveic,
                                         string ruaavenida, string bairro, string cidade, string numero,
                                         string veiculolocomove, string datahorachamado, string descchamado,
                                         string observacaochamado,
                                         string[] veiculosterceiros)
            {
                return Get(apolice_id, documentodocondutor, partesveic, ruaavenida, bairro, cidade, numero, veiculolocomove,
                            datahorachamado, descchamado, observacaochamado, veiculosterceiros);
            }

            public string Get(string apolice_id, string documentodocondutor, string partesveic,
                                           string ruaavenida, string bairro, string cidade, string numero,
                                           string veiculolocomove, string datahorachamado, string descchamado,
                                           string observacaochamado,
                                           string[] veiculosterceiros)
            {
                var ObjetoChamado = new ChamadoModel();
                ObjetoChamado.Apolice_id = Int32.Parse(apolice_id);
                ObjetoChamado.DocumentoCondutor = documentodocondutor;


                ObjetoChamado.PartesVeic = partesveic;
                ObjetoChamado.RuaAvenida = ruaavenida;
                ObjetoChamado.Bairro = bairro;
                ObjetoChamado.Cidade = cidade;
                ObjetoChamado.Numero = Int32.Parse(numero);
                ObjetoChamado.veiculolocomove = bool.Parse(veiculolocomove);
                ObjetoChamado.datahorachamado = DateTime.Now;
                ObjetoChamado.descchamado = descchamado;
                ObjetoChamado.obschamado = observacaochamado;
                if (veiculosterceiros != null)
                {
                    var objetoterceiros = new ObjetoTerceiros();
                    var ListaTerc = new List<ObjetoTerceiros>();
                    objetoterceiros.partesenvolvidasdoveiculo = veiculosterceiros[0];
                    objetoterceiros.Ruaavenida = veiculosterceiros[1];
                    objetoterceiros.Bairro = veiculosterceiros[2];
                    objetoterceiros.Estado = veiculosterceiros[3];
                    objetoterceiros.numero = int.Parse(veiculosterceiros[4]);
                    objetoterceiros.sentidoviaterceiro = veiculosterceiros[5];
                    objetoterceiros.ModeloTerceiro = veiculosterceiros[6];
                    objetoterceiros.PlacaTerceiro = veiculosterceiros[7];
                    ListaTerc.Add(objetoterceiros);
                    ObjetoChamado.ListaTerceiros = ListaTerc;
                }
                var chamadoEspecialista = new ChamadoEspecialista();
                return chamadoEspecialista.insereChamado(ObjetoChamado);

            }
           
    }
    }

