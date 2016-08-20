using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        public List<VeiculoModel> listaveiculos = new List<VeiculoModel>();
        public List<ApoliceModel> apolicemodel = new List<ApoliceModel>();
        public List<DependenteModel> dependentemodel = new List<DependenteModel>();
        public List<ClienteModel> clientemodel = new List<ClienteModel>();
        public List<ClienteDependenteModel> clientedep = new List<ClienteDependenteModel>();
        public int StatusRetorno { get; set; }
    }
}