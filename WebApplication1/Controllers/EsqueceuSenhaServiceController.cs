using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EsqueceuSenhaServiceController : ApiController
    {
        // GET: api/EsqueceuSenhaService
        /*
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET: api/EsqueceuSenhaService/5
        
        public string Get(string cpf, string datanasc, string novasenha)
        {
            return Post(cpf,datanasc,novasenha);
        }
        
        // POST: api/EsqueceuSenhaService
        public string Post(string cpf, string datanasc, string novasenha)
        {
            
            Models.LoginEspecialista le = new Models.LoginEspecialista();
            return le.AtualizaSenha(cpf, novasenha, datanasc);
        }

        /*
        // PUT: api/EsqueceuSenhaService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EsqueceuSenhaService/5
        public void Delete(int id)
        {
        }
        */
    }
}
