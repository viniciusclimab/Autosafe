using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class OficinaService : ApiController
    {
        // GET api/<controller>
        public List<Models.OficinaModel> Get()
        {
            Models.OficinaEspecialista oe = new Models.OficinaEspecialista();
            return oe.MontaListaOficinaAplicativo();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}