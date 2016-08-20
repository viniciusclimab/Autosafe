using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AtendenteController : Controller
    {
        // GET: Atendente
        public ActionResult Index()
        {
            return Create();
        }

        // GET: Atendente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Atendente/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Atendente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Atendente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Atendente/Edit/5
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

        // GET: Atendente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Atendente/Delete/5
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
