using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DealerNet.Packages.ServiceDesk.Objetos
{
    [Serializable, XmlRoot(ElementName = "Demandas", Namespace = "")]
    public class Demandas
    {
        [XmlElement(ElementName = "Demandas.Demanda")]   
        public List<Demanda> demandas { get; set; }
    }
}
