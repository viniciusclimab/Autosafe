using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChamadoModelExibicao
    {
        
	  
       public string Endereco { get; set; }
        public string CidadeEstado { get; set; }
        public string DeescricaoChamado { get; set; }
        public string ObservacaoChamado { get; set; }
        public string DataHoraAberturaChamado { get; set; }
        public bool CnhEnviada { get; set; }
        public bool BoEnviado { get; set; }
        public bool CompEnd { get; set; }
        public int quantveic { get; set; }
        public int NumSinistro { get; set; }
        public int NumApolice { get; set; }
        public string NomeCliente { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Status { get; set; }
        public string DataHoraChamado { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Chassi { get; set; }
        public string PartesVeiculoColidida { get; set; }
        public int   Prioridade{ get; set; }
        public bool veiclocomove { get; set; }
    }
}