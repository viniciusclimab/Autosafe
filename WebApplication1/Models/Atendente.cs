using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Atendente
    {
       
        public string Nome { get; set; }
        public string  Cpf { get; set; }
        public string senha { get; set; }
        public DateTime datanasc { get; set; }
        public bool Status { get; set; }
    }
}