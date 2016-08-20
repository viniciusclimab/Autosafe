using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VeiculoModel
    {
        public int VeiculoId { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Chassi { get; set; }
        public string Fabricante { get; set; }
        public bool PossuiRastreador { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public string Renavan { get; set; }
    }
}