using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // Guid
using System.Windows.Forms;
using Artech.Architecture.Common.Events;
using Artech.Architecture.Common.Objects;
using Artech.Architecture.Common.Services;
using Artech.Architecture.Common.Services.TeamDev;
using Artech.Architecture.UI.Framework;
using Artech.Architecture.UI.Framework.Services;
using Artech.Common.Controls.Basic;
using Artech.Common.Tracing;
using Artech.FrameworkDE;
using DealerNet.Packages.ServiceDesk.Objetos;
using Microsoft.Practices.CompositeUI.EventBroker;
using ServiceDesk.Gateway.Interfaces;
using UcGenexusCommit.Objetos;

namespace DealerNet.Packages.ServiceDesk
{
    [Guid("3C3DEAE0-66DD-48bd-866D-463C4075385A")]
    //public partial class ServDeskCommit : UserControl
    public partial class ServDeskCommit : AbstractToolWindow
    {
        private readonly IGenexusService _genexusService;
        private IEnumerable<KBObjectHistory> _objectHistories;
        private List<KBObjectHistory> _objetosComitados;
        private string _usr;
        private List<TeamDevUpdateItem> _teamDevUpdateItems;
        private ITeamDevClientUpdate _teamDevClientUpdate;
        readonly CheckBox _ckBoxCommit;

        public ServDeskCommit(IGenexusService genexusService)
        {
            _genexusService = genexusService;
            _objetosComitados = new List<KBObjectHistory>();
            _teamDevUpdateItems = new List<TeamDevUpdateItem>();
            _ckBoxCommit = new CheckBox();
            InitializeComponent();
        }

        public static Guid Guid = typeof(ServDeskCommit).GUID;

        [EventSubscription(UIEvents.AfterOpenKB)]
        public void OnAfterOpenKb(object sender, KBEventArgs args)
        {
            CarregarTelaCommit();
        }

        private void ServDeskCommit_Load(object sender, EventArgs e)
        {
            //Get the column header cell bounds
            var rect = grdObjetosCommit.GetCellDisplayRectangle(0, -1, true);
            _ckBoxCommit.Size = new Size(16, 18);
            //Change the location of the CheckBox to make it stay on the header
            _ckBoxCommit.Location = rect.Location;
            _ckBoxCommit.CheckedChanged += ckBox_CheckedChanged;
            //Add the CheckBox into the DataGridView
            grdObjetosCommit.Controls.Add(_ckBoxCommit);
            grdObjetosCommit.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        #region Métodos

        private void CarregarTelaCommit()
        {
            _objetosComitados = new List<KBObjectHistory>();
            txtDemandaCommit.Text = string.Empty;
            lblNomeDemandaCommit.Text = string.Empty;
            lblCodDemandaCommit.Text = string.Empty;
            txtComentarioCommit.Text = string.Empty;

            txtUsuarioCommit.Text = _usr = _genexusService.GetUsuario().ToUpper();
            _objectHistories = _genexusService.GetListaObjetosModificados();
            lnkGenexusServer.Text = _genexusService.GetLinkGenexusServer();

            grdObjetosCommit.DataSource = _objectHistories.ToList();
        }

        private void CarregarGridUpdate(IEnumerable<DemandaUpdateObjeto> objetos)
        {
            var lista = objetos.Select(obj => new DemandaUpdateObjeto
            {
                Objeto_Codigo = obj.Objeto_Codigo,
                Objeto_Nome = obj.Objeto_Nome
            }).ToList();

            grdObjetosUpdate.DataSource = lista.ToArray();
        }

        private void RealizarCommit()
        {

            UIServices.TeamDevClient.CheckForBrokenCommits();
            var str = txtComentarioCommit.Text.Trim();
            if (string.IsNullOrEmpty(str))
            {
                StandardMessageBox.Error("É necessário colocar um comentário para o Commit!!");
                txtComentarioCommit.Focus();
            }
            else if (lblCodDemandaCommit.Text.Equals(txtDemandaCommit.Text.Trim()))
            {
                var objetos = new List<Demanda_Objeto>();

                for (var i = 0; i < grdObjetosCommit.Rows.Count; i++)
                {
                    var dr = grdObjetosCommit.Rows[i];
                    if (dr.Cells[0].Value == null) continue;

                    var objKey = string.Format("{0}-{1}", dr.Cells["TipoCommit"].Value, dr.Cells["IdCommit"].Value);

                    foreach (var history in _objectHistories)
                    {
                        if (history.Key.ToString().Equals(objKey))
                        {
                            _objetosComitados.Add(history);
                            var objeto = new Demanda_Objeto
                            {
                                Objeto_ID = Convert.ToInt32(dr.Cells["IdCommit"].Value),
                                Objeto_Nome = dr.Cells["NomeCommit"].Value.ToString(),
                                Objeto_Tipo = ConverterTipoObjeto(dr.Cells["TipoCommit"].Value.ToString()),
                                Objeto_GUID = dr.Cells["TipoCommit"].Value.ToString(),
                                Objeto_Data = Convert.ToDateTime(dr.Cells["ModificadoCommit"].Value),
                                Objeto_Acao = dr.Cells["AçãoCommit"].Value.ToString()
                            };
                            objetos.Add(objeto);
                        }
                    }
                }

                if (_objetosComitados.Count > 0)
                {
                    try
                    {
                        if (_genexusService.RealizarCommit(str, _objetosComitados))
                        {
                            var jsonString = objetos.ToJson();
                            try
                            {
                                _genexusService.EnviarSolucaoObjetos(lblCodDemandaCommit.Text, txtComentarioCommit.Text, jsonString);
                                CarregarTelaCommit();
                            }
                            catch (Exception ex)
                            {
                                TraceManager.Error("Erro ao enviar a solução ao WebDesk !!", ex);
                                CommonServices.Output.AddErrorLine(ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        TraceManager.Error("Erro ao realizar o commit!!", ex);
                        CommonServices.Output.AddErrorLine(ex.Message);
                        throw;
                    }
                }
                else
                {
                    StandardMessageBox.Error("Selecione os objetos a serem comitados !!");
                }
            }
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

        #region Eventos TabCommit

        private void txtDemandaCommit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void grdObjetosCommit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            if (grdObjetosCommit.Columns[e.ColumnIndex].Name != "TipoCommit") return;
            var stringValue = e.Value.ToString();
            e.Value = ConverterTipoObjeto(stringValue);
        }

        private void lblCodDemandaCommit_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCodDemandaCommit.Text))
            {
                btCommit.Enabled = true;
                txtDemandaCommit.Text = lblCodDemandaCommit.Text;
            }
            else
            {
                btCommit.Enabled = false;
            }
        }

        private void txtDemandaCommit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDemandaCommit.Text.Trim())) return;
            var codDemanda = Convert.ToInt32(txtDemandaCommit.Text.Trim());
            var retorno = _genexusService.BuscarDemandaCommit(_usr, codDemanda);
            var lista = retorno.ParseXML<Demandas>();
            if (lista.demandas.Count <= 0)
            {
                lblNomeDemandaCommit.Text = Resources.DemandaNaoEncontrada;
                lblNomeDemandaCommit.ForeColor = Color.Red;
                txtComentarioCommit.Text = string.Empty;
                btCommit.Enabled = false;
            }
            else
            {
                lblNomeDemandaCommit.ForeColor = Color.Blue;
                var demanda = lista.demandas[0];
                txtDemandaCommit.Text = demanda.Codigo;
                txtComentarioCommit.Text = string.Format("{0} - ", demanda.Codigo);
                lblCodDemandaCommit.Text = demanda.Codigo;
                lblNomeDemandaCommit.Text = demanda.Resumo;

                btCommit.Enabled = true;
                txtComentarioCommit.Focus();
            }
        }

        void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_ckBoxCommit.Checked)
            {
                for (var i = 0; i < grdObjetosCommit.RowCount; i++)
                {
                    grdObjetosCommit[0, i].Value = true;
                }
            }
            else
            {
                for (var i = 0; i < grdObjetosCommit.RowCount; i++)
                {
                    grdObjetosCommit[0, i].Value = false;
                }
            }
            grdObjetosCommit.EndEdit();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            CarregarTelaCommit();
        }

        private void btCommit_Click(object sender, EventArgs e)
        {
            RealizarCommit();
        }

        #endregion

        #region Eventos TabUpdate

        private void txtDemandaUpdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDemandaUpdate_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDemandaUpdate.Text.Trim())) return;
            var codDemanda = txtDemandaUpdate.Text.Trim();
            var retornoDemanda = _genexusService.BuscarDemandaUpdate(codDemanda);
            var demandaRetorno = retornoDemanda.ParseJSON<DemandaUpdate>();
            if (demandaRetorno.Objetos == null)
            {
                LimparUpdateTab();
                lblNomeDemandaUpdate.Text = Resources.DemandaNaoEncontrada;
                lblNomeDemandaUpdate.ForeColor = Color.Red;
            }
            else
            {
                lblNomeDemandaUpdate.ForeColor = Color.Blue;
                txtDemandaUpdate.Text = demandaRetorno.Demanda_Codigo;
                TxtComentarioUpdate.Text = demandaRetorno.demanda_comentario;
                lblNomeDemandaUpdate.Text = demandaRetorno.Demanda_Resumo;
                CarregarGridUpdate(demandaRetorno.Objetos);

                _teamDevClientUpdate = _genexusService.BuscarObjetosComitados();
                _teamDevUpdateItems = _teamDevClientUpdate.Items.ToList();

                btUpdate.Enabled = true;
                btUpdate.Focus();
            }
        }

        private void grdObjetosUpdate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            var col = grdObjetosUpdate.Columns[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 0: //Codigo
                    col.Width = 80;
                    break;
                case 1: //Nome
                    var row = grdObjetosUpdate.Rows[e.RowIndex];
                    col.Width = 300;
                    row.Cells[2].Value = VerificarStatusObjeto(e.Value.ToString());
                    break;
                case 2: //Status
                    col.Width = 120;
                    break;
            }
        }

        private string VerificarStatusObjeto(string nomeObjeto)
        {
            return _teamDevUpdateItems.Any(a => a.Name == nomeObjeto) ? "Não Atualizado" : "Atualizado";
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            var listaObj = new List<TeamDevUpdateItem>();

            for (var i = 0; i < grdObjetosUpdate.Rows.Count; i++)
            {
                var nome = grdObjetosUpdate.Rows[i].Cells["Objeto_Nome"].Value.ToString();
                var obj = _teamDevUpdateItems.SingleOrDefault(o => o.Name == nome);
                if (obj != null)
                {
                    listaObj.Add(obj);
                }
            }

            if (_teamDevClientUpdate != null && listaObj.Count > 0)
            {
                MessageBox.Show(_genexusService.RealizarUpdate(_teamDevClientUpdate, listaObj)
                    ? Resources.ServiceDeskUpdadeSucesso
                    : Resources.ServiceDeskUpdadeErro);

                LimparUpdateTab();
            }
        }

        public void LimparUpdateTab()
        {
            txtDemandaUpdate.Text = string.Empty;
            lblNomeDemandaUpdate.Text = string.Empty;
            TxtComentarioUpdate.Text = string.Empty;
            grdObjetosUpdate.DataSource = null;
            btUpdate.Enabled = false;
            _teamDevClientUpdate = null;
            _teamDevUpdateItems = null;
        }

        #endregion

    }
}
