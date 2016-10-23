using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OficinaModel
    {
        public int Oficina_id { get; set; }
        public string Email { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string CidadeEstado { get; set; }
        public string HorarioFuncionamento { get; set; }
        public List<Servicos> ListaDeServicos { get; set; }
        public int NotaOficina { get; set; }
        public List<OpiniaoModel>ListaDeOpinioes  { get; set; }
        public string Telefone { get; set; }
    }
}