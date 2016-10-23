using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class SinistroTerceiroServiceController : ApiController
    {
        public string Post(string chamado_id, string partesveicterc, string rua,
                          string bairro, string cidade, string numero, string sentidoviaterc,
                          string modeloterceiro, string placaterceiro)
        {
            return Get(chamado_id, partesveicterc, rua, bairro, cidade, numero, sentidoviaterc,
                            modeloterceiro, placaterceiro);
        }

        public string Get(string chamado_id, string partesveicterc, string rua,
                           string bairro, string cidade, string numero, string sentidoviaterc,
                           string modeloterceiro, string placaterceiro)
        {
            return "Terceiro Inserido";

        }
    }
}