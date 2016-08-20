using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChamadoModel
    {
        public int Apolice_id { get; set; }
        public string DocumentoCondutor { get; set; }
        public string PartesVeic { get; set; }
        public string RuaAvenida { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }
        public bool veiculolocomove { get; set; }
        public DateTime datahorachamado { get; set; }
        public string descchamado { get; set; }
        public string obschamado { get; set; }
        public int quantveicenvolvidos { get; set; }
        public List<Models.ObjetoTerceiros> ListaTerceiros { get; set; }
    }
}