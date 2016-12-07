using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ChamadoController : Controller
    {
        Models.ChamadoEspecialista ce = new Models.ChamadoEspecialista();
        // GET: Chamado
        public ActionResult Index()
        {
            var list = ce.ConsultaChamado(0);
            ViewData["Chamados"] = list; 
            return View("ListaChamados");
        }

        public ActionResult IndexOficina(string cnpj)
        {
            var list = ce.ConsultaChamadoOficina(cnpj);
            ViewData["Chamados"] = list;
            return View("ListaChamadoOficina");
        }

        // GET: Chamado/Details/5
        public ActionResult Detalhes()
        {
            string id = Request.QueryString["Length"];
            int ids = Int32.Parse(id);
            var list = ce.ConsultaChamado(ids);
            ViewData["Chamados"] = list;
            return View("DetalheChamado");
            
        }

        // GET: Chamado/Create
        public ActionResult Alterar()
        {
            string id = Request.QueryString["Length"];
            int ids = Int32.Parse(id);
            var list = ce.AlteraChamado(ids);
            ViewData["Chamados"] = list;
            ViewData["id"] = ids;
            return View("AlteraChamado");
        }

        public ActionResult AlterarOficina(string numchamado)
        {
            string id = numchamado;
            int ids = Int32.Parse(id);
            var list = ce.AlteraChamado(ids);
            ViewData["Chamados"] = list;
            return View("AlteraChamado");
        }


        // POST: Chamado/Create
        
        public ActionResult EnviaOficina()
        {
            try
            {
                var cm = new Models.ChamadoOficinaModel();
                var num = Request["numchamado"].ToString();
                try {
                    cm.EnvioBO = ConvertCheck(Request["inputBo"].ToString());
                }
                catch (Exception){
                    cm.EnvioBO = false;
                }
                try {
                    cm.EnvioComp = ConvertCheck(Request["inputCompRes"].ToString());
                }
                catch (Exception)
                {
                    cm.EnvioComp = false;

                }
                try {
                    cm.EnvioCnh = ConvertCheck(Request["inputCnh"].ToString());
                }
                catch (Exception) { cm.EnvioCnh = false; }
                try { cm.PermiteEletrica = ConvertCheck(Request["inputLiberaEletrica"].ToString()); }
                catch (Exception)
                {
                    cm.PermiteEletrica = false;
                }
                try { cm.PermiteMecanica = ConvertCheck(Request["inputLiberaMecanica"].ToString()); }
                catch (Exception)
                {
                    cm.PermiteMecanica = false;
                }
                try {
                    cm.PermiteFunilaria = ConvertCheck(Request["inputLiberarFunilaria"].ToString()); }
                catch (Exception) {
                    cm.PermiteFunilaria = false; 
                          }
                cm.DescEletrica = Request["taEletrica"].ToString();
                cm.DescMecanica = Request["taMecania"].ToString();
                cm.DescFunilaria = Request["taFunilaria"].ToString();
                Models.ChamadoEspecialista ce = new Models.ChamadoEspecialista();
                ce.AlteraChamadoOficina(cm);
                var list = ce.ConsultaChamado(0);
                ViewData["Chamados"] = list;
                return View("ListaChamados");

            }
            catch
            {
                return View();
            }
        }
   private bool ConvertCheck(string check)
        {
            if (check.Equals("on"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: Chamado/Edit/5


        // GET: Chamado/Delete/5

    }
}
