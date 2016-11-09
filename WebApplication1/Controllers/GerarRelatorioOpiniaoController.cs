using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class GerarRelatorioOpiniaoController : ApiController
    {


        // GET api/<controller>/5
        public  IEnumerable<Models.Teste> Get(string ini, string fim)
        {
            return new List<Models.Teste>(new List<Models.Teste>
            {
                new Models.Teste("Oficina MM",5),
                new Models.Teste("Oficina Monstrao",2),
                new Models.Teste("Dois Irmaos",1)

            });
        }

        // POST api/<controller>
        public void Post(string ini, string fim)
        {
            Get(ini,fim);
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