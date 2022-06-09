using System;
using System.Data;
using System.Xml;
using ServiceDesk.Gateway.Interfaces;

namespace ServiceDesk.Gateway
{
    public class Gateway
    {
        private readonly IGenexusService _genexusService;
        
        public Gateway(IGenexusService genexusService)
        {
            _genexusService = genexusService;            
        }

        public DataTable ListarDemanda(int skip)
        {
            var lDataTable = new DataTable();
            var lXmlRetorno = _genexusService.BuscarDemandaCommit(_genexusService.GetUsuario(), 0, skip);

            if (string.IsNullOrEmpty(lXmlRetorno)) return lDataTable;
            var lXmlDocument = new XmlDocument();
            lXmlDocument.LoadXml(lXmlRetorno);

            var lXmlNodeList = lXmlDocument.GetElementsByTagName("Demandas.Demanda");

            // ReSharper disable once AssignNullToNotNullAttribute
            lDataTable.Columns.Add("Codigo", Type.GetType("System.Int32"));
            // ReSharper disable once AssignNullToNotNullAttribute
            lDataTable.Columns.Add("Resumo", Type.GetType("System.String"));
            
            foreach (var lXmlNode in lXmlNodeList)
            {
                var lDataRow = lDataTable.NewRow();
                var lXmlElement = (XmlElement)lXmlNode;

                lDataRow["Codigo"] = Convert.ToInt32(lXmlElement.GetElementsByTagName("Codigo")[0].InnerText);
                lDataRow["Resumo"] = lXmlElement.GetElementsByTagName("Resumo")[0].InnerText;
            
                lDataTable.Rows.Add(lDataRow);
            }

            return lDataTable;
        }
    }
}
