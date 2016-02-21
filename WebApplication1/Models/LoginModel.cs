using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        public int tiporetorno { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime datafim { get; set; }
    }
}