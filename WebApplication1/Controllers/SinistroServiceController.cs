using System.Web.Http;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.DAO;
namespace WebApplication1.Controllers
{
    public class SinistroServiceController : ApiController
    {

        public string Post(string apolice_id, string documentodocondutor, string partesveic,
                                               string ruaavenida, string bairro, string cidade, string numero,
                                               string veiculolocomove, string datahorachamado, string descchamado,
                                               string observacaochamado, string oficina_id, string quantterceiros)
        {
            return Get(apolice_id, documentodocondutor, partesveic, ruaavenida, bairro, cidade, numero, veiculolocomove,
                        datahorachamado, descchamado, observacaochamado, oficina_id, quantterceiros);
        }

        public string Get(string apolice_id, string documentodocondutor, string partesveic,
                                    string ruaavenida, string bairro, string cidade, string numero,
                                    string veiculolocomove, string datahorachamado, string descchamado,
                                    string observacaochamado, string oficina_id, string quantterceiros)
        {
            var cd = new ChamadosDAO();
            var retorno = string.Empty;
            try {
                descchamado = descchamado.Replace("_", " ");
    
        
                    var dt = cd.insChamado(int.Parse(apolice_id), documentodocondutor, partesveic,
                    ruaavenida, bairro, cidade, 500, false, DateTime.Now, descchamado, observacaochamado, Int32.Parse(quantterceiros),
                    Int32.Parse(oficina_id));
                retorno = dt.Rows[0]["chamado_id"].ToString() + " Não esqueça de enviar a copia da cnh, o Boletim de ocorrência e o B.O para atendimento@autosafe.com.br";
            }
            catch(Exception ex)
            {
                throw;
            }
            return retorno;

        }
    }
    }

