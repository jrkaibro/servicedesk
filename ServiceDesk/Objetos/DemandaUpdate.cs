
using System.Collections.Generic;

namespace DealerNet.Packages.ServiceDesk.Objetos
{
    public class DemandaUpdate
    {
        public string Demanda_Codigo;
        public string demanda_comentario;
        public string Demanda_Resumo;
        public List<DemandaUpdateObjeto> Objetos;
    }
}
