using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string DataNasc { get; set; }
        public string NomeMae { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int Cep { get; set; }
        public string  NumHabilatacao { get; set; }
        public string Categoria { get; set; }
        public string DataEmissao { get; set; }
        public string DataValidade { get; set; }
        public string LocalEmissao { get; set; }

    }
}