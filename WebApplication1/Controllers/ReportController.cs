using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ReportController : Controller
    {
       

         public ActionResult OpiniaoOficina()
        {
            ViewData["Chamados"] = new List<Models.OficinaModel>();
            return View("RelatorioAvaliacaoOficinas");
        }
        public ActionResult SlaChamados()
        {
            return View("ReportSlaChamados");
        }
        public ActionResult TempoChamado()
        {
            return View("ReportTempoChamado");
        }


        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult GerarRelatorioOficina()
        {
            try
            {
                 var sdtini = Request["dtini"].ToString();
                 var anoini = sdtini.Substring(0, 4);
                 var mesini = sdtini.Substring(5, 2);
                 var diaini = sdtini.Substring(8, 2);
                 var sdtfim = Request["dtFim"].ToString();
                var anofim = sdtfim.Substring(0, 4);
                var mesfim = sdtfim.Substring(5, 2);
                var diafim = sdtfim.Substring(8, 2);
                var dtini = new DateTime(Int32.Parse(anoini), Int32.Parse(mesini), Int32.Parse(diaini));
                var dtfim = new DateTime(Int32.Parse(anofim), Int32.Parse(mesfim), Int32.Parse(diafim));
                Models.OficinaEspecialista oe = new Models.OficinaEspecialista();
                var dt = oe.MontaListaOficinaAplicativo();
                dt.RemoveAll( x => x.NotaOficina == 0);
                ViewData["Chamados"] = dt;
                return View("RelatorioAvaliacaoOficinas");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
