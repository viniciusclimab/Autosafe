using System.Web.Http;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.DAO;
namespace WebApplication1.Controllers
{
    public class SinistroServiceController : ApiController
    {

        public string Post(string apolice_id, string documentodocondutor, string partesveic,
                                               string ruaavenida, string bairro, string cidade, string numero,
                                               string veiculolocomove, string datahorachamado, string descchamado,
                                               string observacaochamado, string oficina_id, string quantterceiros)
        {
            return Get(apolice_id, documentodocondutor, partesveic, ruaavenida, bairro, cidade, numero, veiculolocomove,
                        datahorachamado, descchamado, observacaochamado, oficina_id, quantterceiros);
        }

        public string Get(string apolice_id, string documentodocondutor, string partesveic,
                                    string ruaavenida, string bairro, string cidade, string numero,
                                    string veiculolocomove, string datahorachamado, string descchamado,
                                    string observacaochamado, string oficina_id, string quantterceiros)
        {
            var cd = new ChamadosDAO();
            try {
        
                /*cd.insChamado(Int32.Parse(apolice_id), documentodocondutor, partesveic,
                    ruaavenida, bairro, cidade, Int32.Parse(numero), false, DateTime.Now, descchamado, observacaochamado, Int32.Parse(quantterceiros),
                    Int32.Parse(oficina_id));*/
            }
            catch(Exception ex)
            {
                throw;
            }
            return "chama nº";

        }
    }
    }

