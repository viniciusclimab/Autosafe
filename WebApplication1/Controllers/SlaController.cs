using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
namespace WebApplication1.Controllers
{
    public class SlaController : Controller
    {
        // GET: Sla
        public ActionResult Index()
        {
            DAO.ChamadosDAO cd = new DAO.ChamadosDAO();
            Models.SlaModel sm = new Models.SlaModel();
            var dt = cd.GetSla();
            if(dt.Rows.Count > 0)
            {
                sm.MinutosAberto = Int32.Parse(dt.Rows[0]["ABERTO"].ToString());
                sm.MinutosAnalise = Int32.Parse(dt.Rows[0]["ANALISE"].ToString());
            }
            ViewData["SLA"] = sm;
            return View("CadastrarSLA");
        }

        // GET: Sla/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sla/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sla/Create
        [HttpPost]
        public ActionResult AlterarSla()
        {
            try
            {
                Models.SlaModel objsla = new Models.SlaModel
                {
                    MinutosAberto = Int32.Parse(Request["abertoid"].ToString()),
                    MinutosAnalise = Int32.Parse(Request["analiseid"].ToString())
                };
                DAO.ChamadosDAO dao = new DAO.ChamadosDAO();
                dao.AtualizaSla(objsla.MinutosAberto, objsla.MinutosAnalise);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sla/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sla/Edit/5
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

        // GET: Sla/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sla/Delete/5
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
