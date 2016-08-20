using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class OficinaServiceController : ApiController
    {
       
        // GET api/<controller>/5
        public List<Models.OficinaModel> Get()
        {
            return Post();
        }

        // POST api/<controller>
        public List<Models.OficinaModel> Post()
        {
            Models.OficinaEspecialista oe = new Models.OficinaEspecialista();
            return oe.MontaListaOficinaAplicativo();
        }
    }
}