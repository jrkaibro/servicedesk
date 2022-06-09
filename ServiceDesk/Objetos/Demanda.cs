using System;
using System.Xml.Serialization;

namespace DealerNet.Packages.ServiceDesk.Objetos
{
    [Serializable, XmlRoot(ElementName = "Demandas.Demanda", Namespace = "")]
    public class Demanda
    {
        [XmlElement(ElementName = "Codigo")]   
        public string Codigo { get; set; }
        [XmlElement(ElementName = "Resumo")]   
        public string Resumo { get; set; }
        [XmlElement(ElementName = "Texto")]   
        public string Texto { get; set; }
    }
}
