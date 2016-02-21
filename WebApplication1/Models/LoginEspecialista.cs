using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace WebApplication1.Models
{
    public class LoginEspecialista
    {
        DAO.LoginDAO logindao = new DAO.LoginDAO();
        //LoginModel loginmodelo = new LoginModel();
        public LoginModel getLogin(string cpf, string senha)
        {
            LoginModel loginmd = new LoginModel();
            try
            {
                if (cpf.Equals("") || senha.Equals(""))
                {
                    loginmd.tiporetorno = 5;
                    loginmd.datafim = DateTime.Now;
                    loginmd.email = "";
                    loginmd.nome = "";
                    
                }
                else {
                    // fazer uma funcao de validacao de cpf 
                    DataTable dt = logindao.getLogin(cpf, senha);
                    loginmd.datafim = DateTime.Now;
                    loginmd.email = "";
                    loginmd.nome = "";
                    loginmd.tiporetorno = -1;
                    if (dt.Rows.Count > 0)
                    {
                        loginmd.nome = dt.Rows[0]["Nome"].ToString();
                        loginmd.email = dt.Rows[0]["email"].ToString();
                        loginmd.datafim = DateTime.Parse(dt.Rows[0]["dataexpiracao"].ToString());
                        loginmd.tiporetorno = 0;
                    }
                    else loginmd.tiporetorno = 1;

                }
            }
            catch (Exception)
            {

            }
            return loginmd;

        }



    }
}