using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        public string cpf { get; set; }
        public int usuario_id { get; set; }
        public string  senha { get; set; }
        public int  tipoperfil { get; set; }
        public string  nome { get; set; }


    }
}