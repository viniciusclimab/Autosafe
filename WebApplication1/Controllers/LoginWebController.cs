using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginWebController : Controller
    {

        // GET: LoginWeb
        public ActionResult Index()
        {
            try
            {
                string cpf = Request["cpf"].ToString();
                string senha = Request["senha"].ToString();
                if (!String.IsNullOrEmpty(cpf) || !String.IsNullOrEmpty(senha))
                {
                    Models.LoginEspecialista le = new Models.LoginEspecialista();
                    int tamnaho = cpf.Length;

                    if (tamnaho == 11)
                    {
                        if (le.GetLoginWeb(cpf, senha) == 0)
                        {
                            return RedirectToAction("Index","Chamado");
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                    else if(tamnaho == 14) {
                        if (le.GetOficina(cpf, senha) == 2)
                        {
                            return View("HomeOficina");
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                    else {
                        return View("Error");
                    }
                }
                else {
                    return View("Error");
                }

            }
            catch (Exception)
            {
                return View();
            }
         }
        // GET: LoginWeb/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginWeb/Create
        public ActionResult Logars()
        {
            return Logar();
        }

        // POST: LoginWeb/Create
        [HttpPost]
        public ActionResult Logar()
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

        // GET: LoginWeb/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginWeb/Edit/5
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

        // GET: LoginWeb/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginWeb/Delete/5
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
        
        public ActionResult CarregaEsqueceuSenha()
        {
            return View("EsqueceuSenha");
        }

        public ActionResult EsqueceuSenha()
        {
            string cpf = Request["cpf"].ToString();
            string senha = Request["senha"].ToString();
            string datanasc = Request["datanasc"].ToString();
            Models.LoginEspecialista le = new Models.LoginEspecialista();
            var msg = le.AtualizaSenhaWeb(cpf, senha, datanasc);

            if (msg.Equals("Senha alterada com sucesso"))
            {
                return Logar();
            }

            else return View("EsqueceuSenha");

        }

    }
}
