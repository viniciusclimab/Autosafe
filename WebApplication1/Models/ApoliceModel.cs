using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class ApoliceModel
    {
        public int ApoliceId { get; set; }
        public string DataValidade { get; set; }
        public string LocalDaPernoite { get; set; }
        public string DescricaoUsoVeiculo { get; set; }
        public int Veiculo_id { get; set; }
        
    }
}