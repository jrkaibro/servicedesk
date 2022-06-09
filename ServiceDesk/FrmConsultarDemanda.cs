using System;
using System.Windows.Forms;
using ServiceDesk.Gateway;
using ServiceDesk.Gateway.Interfaces;

namespace DealerNet.Packages.ServiceDesk
{
    public partial class FrmConsultarDemanda : Form
    {
        private readonly IGenexusService _genexusService;
        private readonly FrmCommit _frmCommit;
        private readonly FrmUpdate _frmUpdate;

        private int mintPageSize = 10;
        private int mintPageCount = 0;
        private int _mintCurrentPage = 1;

        public FrmConsultarDemanda(IGenexusService genexusService, FrmCommit frmCommit = null, FrmUpdate frmUpdate = null)
        {
            _genexusService = genexusService;
            _frmCommit = frmCommit;
            _frmUpdate = frmUpdate;
            InitializeComponent();
        }

        private void FrmConsultarDemanda_Load(object sender, EventArgs e)
        {
            LoadPage();
        }

        private void LoadPage()
        {
            var skip = (_mintCurrentPage * mintPageSize);

            var lGateway = new Gateway(_genexusService);
            var lDataTable = lGateway.ListarDemanda(skip);
            grvDemandas.DataSource = lDataTable;
            
            // Show Status
            txtPagina.Text = String.Format("{0} / {1}", (_mintCurrentPage + 1), mintPageCount);
        }

        private void btEscolherDemanda_Click(object sender, EventArgs e)
        {
            if (grvDemandas.CurrentRow == null || string.IsNullOrEmpty(grvDemandas.CurrentRow.Cells[0].Value.ToString()))
                return;
            if (_frmCommit != null)
            {
                _frmCommit.lblNomeDemanda.Text = grvDemandas.CurrentRow.Cells[1].Value.ToString();
                _frmCommit.lblNomeDemanda.Refresh();
                _frmCommit.lblCodDemanda.Text = grvDemandas.CurrentRow.Cells[0].Value.ToString();
                _frmCommit.lblCodDemanda.Refresh(); 
            }
            else if(_frmUpdate != null)
            {
                _frmUpdate.lblNomeDemanda.Text = grvDemandas.CurrentRow.Cells[1].Value.ToString();
                _frmUpdate.lblNomeDemanda.Refresh();
                _frmUpdate.lblCodDemanda.Text = grvDemandas.CurrentRow.Cells[0].Value.ToString();
                _frmUpdate.lblCodDemanda.Refresh(); 
            }
                                        
            Close();
        }

        private void grvDemandas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            var col = grvDemandas.Columns[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    col.Width = 60;
                    break;
                case 1:
                    col.Width = 320;
                    break;
            }
        }

        #region Paginação do Grid

        private void GoFirst()
        {
            _mintCurrentPage = 0;

            LoadPage();
        }

        private void GoPrevious()
        {
            if (_mintCurrentPage == mintPageCount)
                _mintCurrentPage = mintPageCount - 1;

            _mintCurrentPage--;

            if (_mintCurrentPage < 1)
                _mintCurrentPage = 0;

            LoadPage();
        }

        private void GoNext()
        {
            _mintCurrentPage++;

            if (_mintCurrentPage > (mintPageCount - 1))
                _mintCurrentPage = mintPageCount - 1;

            LoadPage();
        }

        private void GoLast()
        {
            _mintCurrentPage = mintPageCount - 1;

            LoadPage();
        }

        private void btFirstPage_Click(object sender, EventArgs e)
        {
            GoFirst();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            GoPrevious();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            GoNext();
        }

        private void btLastPage_Click(object sender, EventArgs e)
        {
            GoLast();
        }

        #endregion

    }
}
