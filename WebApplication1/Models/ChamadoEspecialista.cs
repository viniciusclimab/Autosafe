using System.Data;
using System;
using WebApplication1.DAO;
namespace WebApplication1.Models
{
    public class ChamadoEspecialista
    {
        public string insereChamado(Models.ChamadoModel objetochamado)
        {
            var msg = string.Empty;
            ChamadosDAO chamadodao = new ChamadosDAO();
            var dt = chamadodao.insChamado(objetochamado.Apolice_id, objetochamado.DocumentoCondutor, objetochamado.PartesVeic,
                objetochamado.RuaAvenida, objetochamado.Bairro, objetochamado.Cidade, objetochamado.Numero,
                objetochamado.veiculolocomove, objetochamado.datahorachamado, objetochamado.descchamado, objetochamado.obschamado
                , objetochamado.quantveicenvolvidos);

            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                  var chamado_id =  Int32.Parse(dt.Rows[0]["chamado_id"].ToString());

                    foreach (var item in objetochamado.ListaTerceiros)
                    {
                        chamadodao.inschamadoTerceiro(chamado_id, item.PlacaTerceiro, item.ModeloTerceiro, item.Ruaavenida, item.Bairro, item.numero,
                            item.cidade, item.sentidoviaterceiro, item.partesenvolvidasdoveiculo);
                    }
                    msg = "Chamado nº " + chamado_id + "Aberto com sucesso";
                }
            }
            else
            {
                msg = "Chamado não inserido na base de dados";
            }

            return "";
        }

    }
}