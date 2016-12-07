using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChamadoExibicaoAplicativo
    {
        public int ChamadoNum { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string NomeCondutor { get; set; }
        public string DescChamado { get; set; }
        public string BOEntregue { get; set; }
        public string CnhEntregue { get; set; }
        public string CompEndEntregue { get; set; }
        public string EletricaLiberada { get; set; }
        public string DescricaoEletrica { get; set; }
        public string MecanicaLiberada { get; set; }
        public string DescricaoMecanica { get; set; }
        public string FunilariaLiberada { get; set; }
        public string DescricaoFunilaria { get; set; }
        public string TempoDeGuincho { get; set; }
        public string DescricaoDoNegado { get; set; }
        public string DataHoraChamado { get; set; } 
    }
}