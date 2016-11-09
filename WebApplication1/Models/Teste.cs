using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Teste
    {
        private string v1;
        private int v2;

        public Teste(string v1, int v2)
        {
            Name = v1;
            Quantity= v2;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}