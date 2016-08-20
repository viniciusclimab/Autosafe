using System;
using System.Web.Http;
using WebApplication1.Models;
using System.Collections.Generic;
namespace WebApplication1.Controllers
{
    public class ChamadoServiceController : ApiController
    {
        public string AberturaChamado(int apolice_id, string documentodocondutor, string partesveic,
                                       string ruaavenida, string bairro, string cidade, int numero,
                                       bool veiculolocomove, DateTime datahorachamado, string descchamado,
                                       string observacaochamado, 
                                       string[]veiculosterceiros)
        {
            var ObjetoChamado = new ChamadoModel();
            ObjetoChamado.Apolice_id = apolice_id;
            ObjetoChamado.DocumentoCondutor = documentodocondutor;
            ObjetoChamado.PartesVeic = partesveic;
            ObjetoChamado.RuaAvenida = ruaavenida;
            ObjetoChamado.Bairro = bairro;
            ObjetoChamado.Cidade = cidade;
            ObjetoChamado.Numero = numero;
            ObjetoChamado.veiculolocomove = veiculolocomove;
            ObjetoChamado.datahorachamado = datahorachamado;
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