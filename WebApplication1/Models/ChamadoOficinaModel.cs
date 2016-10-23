

namespace WebApplication1.Models
{
    public class ChamadoOficinaModel
    {
        public bool PermiteEletrica { get; set; }
        public bool PermiteFunilaria { get; set; }
        public bool PermiteMecanica { get; set; }
        public bool EnvioCnh { get; set; }
        public bool EnvioBO { get; set; }
        public bool EnvioComp { get; set; }
        public string DescEletrica { get; set; }
        public string DescMecanica { get; set; }
        public string DescFunilaria { get; set; }

    }
}