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
                var msgErro = string.Empty;
                var cpf = Request["cpf"].ToString();
                var senha = Request["senha"].ToString();

                //TRATAMENTO de primeiro request
                if (!string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(senha))
                {
                    var  le = new Models.LoginEspecialista();
                    var tamnaho = cpf.Length;
                    if (tamnaho == 11)
                    {
                        if (le.GetLoginWeb(cpf, senha) == 0)
                        {
                            return RedirectToAction("Index","Chamado");
                        }
                        else
                        {
                             msgErro = "CPF ou senha inválidos favor verificar o mesmo";
                             ViewData["msg"] = msgErro;
                       }
                    }
                    else if(tamnaho == 14) {
                        if (le.GetOficina(cpf, senha) == 2)
                        {
                            return RedirectToAction("IndexOficina", "Chamado", new {cnpj = cpf});

                        }
                        else
                        {
                            msgErro = "CNPJ ou senha inválidos favor verificar o mesmo";
                            ViewData["msg"] = msgErro;
                       }
                    }
                  
                }
                else {
                    msgErro = "Dados em branco favor verificar o mesmo";
                    ViewData["msg"] = msgErro;
                   
                }
                return View("Index");
            }
            catch (Exception)
            {
                return View();
            }
         }
        // GET: LoginWeb/Details/5
        
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
                return Index();
            }

            else return View("EsqueceuSenha");

        }

    }
}
