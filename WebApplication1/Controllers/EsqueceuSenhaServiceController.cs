using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class EsqueceuSenhaServiceController : ApiController
    {
        public string Get(string cpf, string datanasc, string novasenha)
        {
            return Post(cpf,datanasc,novasenha);
        }
        
        public string Post(string cpf, string datanasc, string novasenha)
        {
            
            LoginEspecialista le = new LoginEspecialista();
            return le.AtualizaSenha(cpf, novasenha, datanasc);
        }
        
    }
}
