using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoginServiceController : ApiController
    {
        
        public LoginModel  Get(string cpf, string senha)
        {

            return Post(cpf, senha);
        }
        public LoginModel Post(string cpf, string senha)
        {
   
            LoginEspecialista logesp = new LoginEspecialista();
            return logesp.getLogin(cpf, senha);

        }
    }
}
