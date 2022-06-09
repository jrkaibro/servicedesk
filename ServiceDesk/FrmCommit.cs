using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Services;
using Artech.Architecture.UI.Framework.Services;
using Artech.Common.Controls.Basic;
using Artech.Common.Tracing;
using DealerNet.Packages.ServiceDesk.Objetos;
using ServiceDesk.Gateway.Interfaces;
using UcGenexusCommit.Objetos;

namespace DealerNet.Packages.ServiceDesk
{
    public partial class FrmCommit : Form
    {
        private readonly IGenexusService _genexusService;
        private readonly IEnumerable<KBObjectHistory> _objectHistories;
        private readonly List<KBObjectHistory> _objetosComitados;
        private string _usr;

        public FrmCommit(IGenexusService genexusService, IEnumerable<KBObjectHistory> objectHistories)
        {
            _genexusService = genexusService;
            _objectHistories = objectHistories;
            _objetosComitados = new List<KBObjectHistory>();
            InitializeComponent();
        }
        
        #region Métodos

        private void CarregarTela()
        {
            txtUsuario.Text = _usr = _genexusService.GetUsuario();

            lnkGenexusServer.Text = _genexusService.GetLinkGenexusServer();

            var dsObjetos = new DataSet();
            var tbObjetos = new DataTable("Objetos");

            //Estrutura do DataTable
            tbObjetos.Columns.Add("Id");
            tbObjetos.Columns.Add("Nome");
            tbObjetos.Columns.Add("Tipo");
            tbObjetos.Columns.Add("Guid");
            tbObjetos.Columns.Add("Modificado");
            tbObjetos.Columns.Add("Acão");
            tbObjetos.Columns.Add("Usuário");

            foreach (var history in _objectHistories)
            {
                //Criando Registros 
                var row = tbObjetos.NewRow();

                row["Id"] = history.Id;
                row["Nome"] = history.ObjectName;
                row["Tipo"] = ConverterTipoObjeto(history.Type.ToString());
                row["Guid"] = history.Type.ToString();
                row["Modificado"] = history.LastChange;
                row["Acão"] = history.Operation.ToString();
                row["Usuário"] = history.Username;

                tbObjetos.Rows.Add(row);
            }
            dsObjetos.Tables.Add(tbObjetos);

            grvObjetos.DataSource = dsObjetos.Tables[0];            
        }

        private void CarregarTelaBusca()
        {
            var f = new FrmConsultarDemanda(_genexusService, this);
            f.ShowDialog();
            txtComentario.Focus();
        }

        #region Conversão

        private static string ConverterTipoObjeto(string guid)
        {
            switch (guid)
            {
                case "2a9e9aba-d2de-4801-ae7f-5e3819222daf":
                    return "DataProvider";
                case "ffd44be7-3bb4-4d01-9e7e-d1c1a3c095af":
                    return "DataSelector";
                case "19abc6ff-2cd2-0000-0006-6d172bc2333b":
                    return "DataView";
                case "00972a17-9975-449e-aab1-d26165d51393":
                    return "Domain";
                case "9fb193d9-64a4-4d30-b129-ff7c76830f7e":
                    return "Image";
                case "7706bd3b-212a-1000-0006-8aaeb59068b9":
                    return "Index";
                case "88313f43-5eb2-0000-0028-e8d9f5bf9588":
                    return "Language";
                case "84a12160-f59b-4ad7-a683-ea4481ac23e9":
                    return "Procedure";
                case "447527b5-9210-4523-898b-5dccb17be60a":
                    return "SDT";
                case "1db606f2-af09-4cf9-a3b5-b481519d28f6":
                    return "Transaction";
                case "c9584656-94b6-4ccd-890f-332d11fc2c25":
                    return "WebPanel";
                case "198e8ea4-1d49-4c9c-8a9a-417024baa9d1":
                    return "WorkPanel";
                case "adbb33c9-0906-4971-833c-998de27e0676":
                    return "Attribute";
                case "280c149c-48b2-4284-a532-0c999df9e006":
                    return "Diagram";
                case "c163e562-42c6-4158-ad83-5b21a14cf30e":
                    return "ExternalObject";
                case "857ca50e-7905-0000-0007-c5d9ff2975ec":
                    return "Table";
                case "07135890-56fc-489b-b408-063722fa9f7d":
                    return "WorkWithPlus";
                case "c84ec0ea-d159-46e2-a118-2108860379bb":
                    return "Preferences";
                case "00000000-0000-0000-0000-000000000008":
                    return "Folder";
                case "87313f43-5eb2-41d7-9b8c-e8d9f5bf9588":
                    return "Group";
                default:
                    return guid;
            }
        }

        #endregion

        #endregion

        #region EventosAutomáticos

        private void FrmCommit_Load(object sender, EventArgs e)
        {
            CarregarTela();
        }   
        
        private void grvObjetos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            var col = grvObjetos.Columns[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 1: //Id
                    col.Width = 40;
                    break;
                case 2: //Nome
                    col.Width = 220;
                    break;
                case 3: //Tipo
                    col.Width = 90;
                    break;
                case 4: //Guid
                    col.Visible = false;
                    break;
                case 5: //Modificado
                    col.Width = 120;
                    break;
                case 6: //Ação
                    col.Width = 70;
                    break;
                case 7: //Usuário
                    col.Width = 170;
                    break;
            }
        }

        private void lblCodDemanda_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCodDemanda.Text))
            {
                btCommit.Enabled = true;
                txtDemanda.Text = lblCodDemanda.Text;
            }
            else
            {
                btCommit.Enabled = false;
            }
        }

        private void txtDemanda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDemanda.Text.Trim()))
            {
                CarregarTelaBusca();
            }
            else
            {
                var codDemanda = Convert.ToInt32(txtDemanda.Text.Trim());
                var retorno = _genexusService.BuscarDemandaCommit(_usr, codDemanda);//_wsServdeskDemandas.Execute(_usr, codDemanda);
                if (String.IsNullOrEmpty(retorno))
                {
                    CarregarTelaBusca();
                    btCommit.Enabled = false;
                }
                else
                {
                    var lista = retorno.ParseXML<Demandas>();
                    if (lista.demandas.Count > 0)
                    {
                        var demanda = lista.demandas[0];
                        txtDemanda.Text = demanda.Codigo;
                        lblCodDemanda.Text = demanda.Codigo;
                        lblNomeDemanda.Text = demanda.Resumo;

                        btCommit.Enabled = true;
                        txtComentario.Focus();
                    }
                    else
                    {
                        CarregarTelaBusca();
                    }
                }
            }
        }

        #endregion

        private void btCommit_Click(object sender, EventArgs e)
        {
            RealizarCommit();
        }
        
        private void RealizarCommit()
        {
           try
            {
                UIServices.TeamDevClient.CheckForBrokenCommits();
                var str = txtComentario.Text.Trim();
                if (string.IsNullOrEmpty(str))
                {
                    StandardMessageBox.Error("É necessário colocar um comentário para o Commit!!");
                    txtComentario.Focus();
                }
                else if (lblCodDemanda.Text.Equals(txtDemanda.Text.Trim()))
                {
                    var objetos = new List<Demanda_Objeto>();

                    for (var i = 0; i < grvObjetos.Rows.Count; i++)
                    {
                        var dr = grvObjetos.Rows[i];
                        if (dr.Cells[0].Value == null) continue;

                        foreach (var history in _objectHistories)
                        {
                            if (history.Id.ToString(CultureInfo.InvariantCulture).Equals(dr.Cells[1].Value))
                            {
                                _objetosComitados.Add(history);
                            }
                        }

                        var objeto = new Demanda_Objeto
                        {
                            Objeto_ID = Convert.ToInt32(dr.Cells[1].Value),
                            Objeto_Nome = dr.Cells[2].Value.ToString(),
                            Objeto_Tipo = dr.Cells[3].Value.ToString(),
                            Objeto_GUID = dr.Cells[4].Value.ToString(),
                            Objeto_Data = Convert.ToDateTime(dr.Cells[5].Value),
                            Objeto_Acao = dr.Cells[6].Value.ToString()
                        };
                        objetos.Add(objeto);
                    }

                    if (_objetosComitados.Count > 0)
                    {
                        CommonServices.Output.SelectOutput("Team Development");
                        CommonServices.Output.Show("Team Development");

                        _genexusService.RealizarCommit(str, _objetosComitados);

                        var jsonString = objetos.ToJson();
                        _genexusService.EnviarSolucaoObjetos(lblCodDemanda.Text, txtComentario.Text, jsonString);
                    }
                    else
                    {
                        StandardMessageBox.Error("Selecione os objetos a serem comitados!!");
                    }
                }
            }
            catch (Exception ex)
            {
                TraceManager.Error("Erro ao realizar o commit!!", ex);
                CommonServices.Output.AddErrorLine(ex.Message);
            }
        }
    }
}
