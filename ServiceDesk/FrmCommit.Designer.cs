namespace DealerNet.Packages.ServiceDesk
{
    partial class FrmCommit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblItens = new System.Windows.Forms.Label();
            this.txtDemanda = new System.Windows.Forms.TextBox();
            this.lblCodDemanda = new System.Windows.Forms.Label();
            this.btCommit = new System.Windows.Forms.Button();
            this.grvObjetos = new System.Windows.Forms.DataGridView();
            this.chkObjeto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblNomeDemanda = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblDemanda = new System.Windows.Forms.Label();
            this.lblCommit = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lnkGenexusServer = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grvObjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItens
            // 
            this.lblItens.AutoSize = true;
            this.lblItens.Location = new System.Drawing.Point(20, 246);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(88, 13);
            this.lblItens.TabIndex = 39;
            this.lblItens.Text = "Pending Commits";
            // 
            // txtDemanda
            // 
            this.txtDemanda.Location = new System.Drawing.Point(92, 95);
            this.txtDemanda.Name = "txtDemanda";
            this.txtDemanda.Size = new System.Drawing.Size(140, 20);
            this.txtDemanda.TabIndex = 1;
            this.txtDemanda.Leave += new System.EventHandler(this.txtDemanda_Leave);
            // 
            // lblCodDemanda
            // 
            this.lblCodDemanda.AutoSize = true;
            this.lblCodDemanda.Location = new System.Drawing.Point(255, 102);
            this.lblCodDemanda.Name = "lblCodDemanda";
            this.lblCodDemanda.Size = new System.Drawing.Size(0, 13);
            this.lblCodDemanda.TabIndex = 37;
            this.lblCodDemanda.Visible = false;
            this.lblCodDemanda.TextChanged += new System.EventHandler(this.lblCodDemanda_TextChanged);
            // 
            // btCommit
            // 
            this.btCommit.Enabled = false;
            this.btCommit.Location = new System.Drawing.Point(743, 625);
            this.btCommit.Name = "btCommit";
            this.btCommit.Size = new System.Drawing.Size(75, 23);
            this.btCommit.TabIndex = 36;
            this.btCommit.Text = "Commit";
            this.btCommit.UseVisualStyleBackColor = true;
            this.btCommit.Click += new System.EventHandler(this.btCommit_Click);
            // 
            // grvObjetos
            // 
            this.grvObjetos.AllowUserToAddRows = false;
            this.grvObjetos.AllowUserToDeleteRows = false;
            this.grvObjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvObjetos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkObjeto});
            this.grvObjetos.Location = new System.Drawing.Point(20, 271);
            this.grvObjetos.Name = "grvObjetos";
            this.grvObjetos.Size = new System.Drawing.Size(798, 348);
            this.grvObjetos.TabIndex = 22;
            this.grvObjetos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvObjetos_CellFormatting);
            // 
            // chkObjeto
            // 
            this.chkObjeto.FillWeight = 40F;
            this.chkObjeto.HeaderText = "";
            this.chkObjeto.MinimumWidth = 20;
            this.chkObjeto.Name = "chkObjeto";
            this.chkObjeto.Width = 40;
            // 
            // lblNomeDemanda
            // 
            this.lblNomeDemanda.AutoSize = true;
            this.lblNomeDemanda.ForeColor = System.Drawing.Color.Blue;
            this.lblNomeDemanda.Location = new System.Drawing.Point(248, 102);
            this.lblNomeDemanda.Name = "lblNomeDemanda";
            this.lblNomeDemanda.Size = new System.Drawing.Size(0, 13);
            this.lblNomeDemanda.TabIndex = 34;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(20, 165);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(444, 69);
            this.txtComentario.TabIndex = 2;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(17, 137);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(63, 13);
            this.lblComentario.TabIndex = 30;
            this.lblComentario.Text = "Comentário:";
            // 
            // lblDemanda
            // 
            this.lblDemanda.AutoSize = true;
            this.lblDemanda.Location = new System.Drawing.Point(17, 95);
            this.lblDemanda.Name = "lblDemanda";
            this.lblDemanda.Size = new System.Drawing.Size(56, 13);
            this.lblDemanda.TabIndex = 29;
            this.lblDemanda.Text = "Demanda:";
            // 
            // lblCommit
            // 
            this.lblCommit.AutoSize = true;
            this.lblCommit.Location = new System.Drawing.Point(17, 13);
            this.lblCommit.Name = "lblCommit";
            this.lblCommit.Size = new System.Drawing.Size(60, 13);
            this.lblCommit.TabIndex = 27;
            this.lblCommit.Text = "Commit To:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(17, 48);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 28;
            this.lblUsuario.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(92, 48);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(140, 20);
            this.txtUsuario.TabIndex = 31;
            // 
            // lnkGenexusServer
            // 
            this.lnkGenexusServer.AutoSize = true;
            this.lnkGenexusServer.Location = new System.Drawing.Point(92, 13);
            this.lnkGenexusServer.Name = "lnkGenexusServer";
            this.lnkGenexusServer.Size = new System.Drawing.Size(0, 13);
            this.lnkGenexusServer.TabIndex = 33;
            // 
            // FrmCommit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 653);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.txtDemanda);
            this.Controls.Add(this.lblCodDemanda);
            this.Controls.Add(this.btCommit);
            this.Controls.Add(this.grvObjetos);
            this.Controls.Add(this.lblNomeDemanda);
            this.Controls.Add(this.lnkGenexusServer);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.lblDemanda);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblCommit);
            this.Name = "FrmCommit";
            this.Text = "Commitar Objetos por Demanda";
            this.Load += new System.EventHandler(this.FrmCommit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvObjetos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.TextBox txtDemanda;
        public System.Windows.Forms.Label lblCodDemanda;
        private System.Windows.Forms.Button btCommit;
        private System.Windows.Forms.DataGridView grvObjetos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkObjeto;
        public System.Windows.Forms.Label lblNomeDemanda;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblDemanda;
        private System.Windows.Forms.Label lblCommit;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.LinkLabel lnkGenexusServer;
    }
}