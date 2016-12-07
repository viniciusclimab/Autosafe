using System.Collections.Generic;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ConsultaChamadoServiceController : ApiController
    {

        // GET api/<controller>/5
        public List<Models.ChamadoExibicaoAplicativo> Get(int cliente_id)
        {
            return Post(cliente_id);
        }

        // POST api/<controller>
        public List<Models.ChamadoExibicaoAplicativo> Post(int cliente_id)
        {
            var chamadoesp = new Models.ChamadoEspecialista();

            return chamadoesp.ConsultaChamadosByClienteId(cliente_id);
        }

       
    }
}