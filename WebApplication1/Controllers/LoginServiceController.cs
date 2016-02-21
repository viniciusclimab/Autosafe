using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoginServiceController : ApiController
    {
        
        //private readonly LoginModel[] login = new LoginModel[] {
       // new LoginModel {usuario_id = 1, cpf = "124", senha = "134",tipoperfil = 1 } };
        

        // GET: api/LoginService
        /*
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET: api/LoginService/5
        public LoginModel  Get(string cpf, string senha)
        {

            return Post(cpf, senha);
        }

        // POST: api/LoginService
        public LoginModel Post(string cpf, string senha)
        {
   
            Models.LoginEspecialista logesp = new LoginEspecialista();
            return logesp.getLogin(cpf, senha);

        }
        /*
        // PUT: api/LoginService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginService/5
        public void Delete(int id)
        {
        }
        */
    }
}
