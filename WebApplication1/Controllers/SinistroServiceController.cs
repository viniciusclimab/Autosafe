using System.Web.Http;
using System;
using System.Collections.Generic;
using WebApplication1.Models;

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
            return "chama nº";

        }
    }
    }

