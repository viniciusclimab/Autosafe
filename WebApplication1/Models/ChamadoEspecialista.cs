using System.Data;
namespace WebApplication1.Models
{
    public class ChamadoEspecialista
    {
        public string insereChamado(Models.ChamadoModel objetochamado)
        {
            var msg = string.Empty;
            DAO.ChamadosDAO chamadodao = new DAO.ChamadosDAO();
            var dt = chamadodao.insChamado(objetochamado.Apolice_id, objetochamado.DocumentoCondutor, objetochamado.PartesVeic,
                objetochamado.RuaAvenida, objetochamado.Bairro, objetochamado.Cidade, objetochamado.Numero,
                objetochamado.veiculolocomove, objetochamado.datahorachamado, objetochamado.descchamado, objetochamado.obschamado
                , objetochamado.quantveicenvolvidos);

            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                  var chamado_id =  dt.Rows[0]["chamado_id"].ToString();

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