using System.Media;
using Microsoft.Win32;

namespace DealerNet.Packages.ServiceDesk
{
    partial class FrmUpdate
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
            this.btUpdate = new System.Windows.Forms.Button();
            this.grvObjetos = new System.Windows.Forms.DataGridView();
            this.chkObjeto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblNomeDemanda = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblDemanda = new System.Windows.Forms.Label();
            this.btPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvObjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItens
            // 
            this.lblItens.AutoSize = true;
            this.lblItens.Location = new System.Drawing.Point(14, 167);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(107, 13);
            this.lblItens.TabIndex = 52;
            this.lblItens.Text = "Objetos da Demanda";
            // 
            // txtDemanda
            // 
            this.txtDemanda.Location = new System.Drawing.Point(86, 16);
            this.txtDemanda.Name = "txtDemanda";
            this.txtDemanda.Size = new System.Drawing.Size(140, 20);
            this.txtDemanda.TabIndex = 40;
            this.txtDemanda.Leave += new System.EventHandler(this.txtDemanda_Leave);
            // 
            // lblCodDemanda
            // 
            this.lblCodDemanda.AutoSize = true;
            this.lblCodDemanda.Location = new System.Drawing.Point(249, 23);
            this.lblCodDemanda.Name = "lblCodDemanda";
            this.lblCodDemanda.Size = new System.Drawing.Size(0, 13);
            this.lblCodDemanda.TabIndex = 51;
            this.lblCodDemanda.Visible = false;
            this.lblCodDemanda.TextChanged += new System.EventHandler(this.lblCodDemanda_TextChanged);
            // 
            // btUpdate
            // 
            this.btUpdate.Enabled = false;
            this.btUpdate.Location = new System.Drawing.Point(737, 546);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 50;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // grvObjetos
            // 
            this.grvObjetos.AllowUserToAddRows = false;
            this.grvObjetos.AllowUserToDeleteRows = false;
            this.grvObjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvObjetos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkObjeto});
            this.grvObjetos.Location = new System.Drawing.Point(14, 192);
            this.grvObjetos.Name = "grvObjetos";
            this.grvObjetos.Size = new System.Drawing.Size(798, 348);
            this.grvObjetos.TabIndex = 42;
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
            this.lblNomeDemanda.Location = new System.Drawing.Point(242, 23);
            this.lblNomeDemanda.Name = "lblNomeDemanda";
            this.lblNomeDemanda.Size = new System.Drawing.Size(0, 13);
            this.lblNomeDemanda.TabIndex = 49;
            // 
            // txtComentario
            // 
            this.txtComentario.Enabled = false;
            this.txtComentario.Location = new System.Drawing.Point(14, 86);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(444, 69);
            this.txtComentario.TabIndex = 41;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(11, 58);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(63, 13);
            this.lblComentario.TabIndex = 46;
            this.lblComentario.Text = "Comentário:";
            // 
            // lblDemanda
            // 
            this.lblDemanda.AutoSize = true;
            this.lblDemanda.Location = new System.Drawing.Point(11, 16);
            this.lblDemanda.Name = "lblDemanda";
            this.lblDemanda.Size = new System.Drawing.Size(56, 13);
            this.lblDemanda.TabIndex = 45;
            this.lblDemanda.Text = "Demanda:";
            // 
            // btPreview
            // 
            this.btPreview.Location = new System.Drawing.Point(638, 545);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(75, 23);
            this.btPreview.TabIndex = 53;
            this.btPreview.Text = "Preview";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // FrmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 575);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.txtDemanda);
            this.Controls.Add(this.lblCodDemanda);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.grvObjetos);
            this.Controls.Add(this.lblNomeDemanda);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.lblDemanda);
            this.Name = "FrmUpdate";
            this.Text = "Update dos Objetos por Demanda";
            ((System.ComponentModel.ISupportInitialize)(this.grvObjetos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.TextBox txtDemanda;
        public System.Windows.Forms.Label lblCodDemanda;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.DataGridView grvObjetos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkObjeto;
        public System.Windows.Forms.Label lblNomeDemanda;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblDemanda;
        private System.Windows.Forms.Button btPreview;
    }
}