﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CadastrarOpiniaoService : ApiController
    {
        // GET api/<controller>

        // GET api/<controller>/5
        public string Get(int chamadoid,int notaoficina, int notasistema, string descoficina, string descsistema)
        {
            return "Sucesso";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

    }
}