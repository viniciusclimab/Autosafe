using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChamadoOficinaExibicao
    {
        public int NumeroDoChamado { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Chassi { get; set; }
        public string Status { get; set; }
        public string data { get; set; }

    }
}