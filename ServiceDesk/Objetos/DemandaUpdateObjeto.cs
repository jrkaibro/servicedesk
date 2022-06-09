using System.ComponentModel;

namespace DealerNet.Packages.ServiceDesk.Objetos
{
    public class DemandaUpdateObjeto
    {
        [DisplayName("Código")]
        public int Objeto_Codigo { get; set; }
        [DisplayName("Nome")]
        public string Objeto_Nome { get; set; }
        [DisplayName("Status")]
        public string Objeto_Status { get; set; }
    }
}