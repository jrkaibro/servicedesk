namespace DealerNet.Packages.ServiceDesk
{
    partial class FrmConsultarDemanda
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
            this.grvDemandas = new System.Windows.Forms.DataGridView();
            this.lblDemandas = new System.Windows.Forms.Label();
            this.btEscolherDemanda = new System.Windows.Forms.Button();
            this.btFirstPage = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btLastPage = new System.Windows.Forms.Button();
            this.txtPagina = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grvDemandas)).BeginInit();
            this.SuspendLayout();
            // 
            // grvDemandas
            // 
            this.grvDemandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDemandas.Location = new System.Drawing.Point(12, 37);
            this.grvDemandas.Name = "grvDemandas";
            this.grvDemandas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grvDemandas.Size = new System.Drawing.Size(440, 417);
            this.grvDemandas.TabIndex = 0;
            this.grvDemandas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvDemandas_CellFormatting);
            // 
            // lblDemandas
            // 
            this.lblDemandas.AutoSize = true;
            this.lblDemandas.Location = new System.Drawing.Point(12, 9);
            this.lblDemandas.Name = "lblDemandas";
            this.lblDemandas.Size = new System.Drawing.Size(58, 13);
            this.lblDemandas.TabIndex = 1;
            this.lblDemandas.Text = "Demandas";
            // 
            // btEscolherDemanda
            // 
            this.btEscolherDemanda.Location = new System.Drawing.Point(346, 463);
            this.btEscolherDemanda.Name = "btEscolherDemanda";
            this.btEscolherDemanda.Size = new System.Drawing.Size(106, 23);
            this.btEscolherDemanda.TabIndex = 2;
            this.btEscolherDemanda.Text = "Escolher Demanda";
            this.btEscolherDemanda.UseVisualStyleBackColor = true;
            this.btEscolherDemanda.Click += new System.EventHandler(this.btEscolherDemanda_Click);
            // 
            // btFirstPage
            // 
            this.btFirstPage.Location = new System.Drawing.Point(123, 463);
            this.btFirstPage.Name = "btFirstPage";
            this.btFirstPage.Size = new System.Drawing.Size(24, 23);
            this.btFirstPage.TabIndex = 3;
            this.btFirstPage.Text = "|<";
            this.btFirstPage.UseVisualStyleBackColor = true;
            this.btFirstPage.Click += new System.EventHandler(this.btFirstPage_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(153, 463);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(24, 23);
            this.btBack.TabIndex = 4;
            this.btBack.Text = "<";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(272, 463);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(24, 23);
            this.btNext.TabIndex = 5;
            this.btNext.Text = ">";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btLastPage
            // 
            this.btLastPage.Location = new System.Drawing.Point(302, 463);
            this.btLastPage.Name = "btLastPage";
            this.btLastPage.Size = new System.Drawing.Size(24, 23);
            this.btLastPage.TabIndex = 6;
            this.btLastPage.Text = ">|";
            this.btLastPage.UseVisualStyleBackColor = true;
            this.btLastPage.Click += new System.EventHandler(this.btLastPage_Click);
            // 
            // txtPagina
            // 
            this.txtPagina.Enabled = false;
            this.txtPagina.Location = new System.Drawing.Point(183, 465);
            this.txtPagina.Name = "txtPagina";
            this.txtPagina.Size = new System.Drawing.Size(83, 20);
            this.txtPagina.TabIndex = 7;
            // 
            // FrmConsultarDemanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 495);
            this.Controls.Add(this.txtPagina);
            this.Controls.Add(this.btLastPage);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btFirstPage);
            this.Controls.Add(this.btEscolherDemanda);
            this.Controls.Add(this.lblDemandas);
            this.Controls.Add(this.grvDemandas);
            this.Name = "FrmConsultarDemanda";
            this.Text = "Demandas";
            this.Load += new System.EventHandler(this.FrmConsultarDemanda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvDemandas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grvDemandas;
        private System.Windows.Forms.Label lblDemandas;
        private System.Windows.Forms.Button btEscolherDemanda;
        private System.Windows.Forms.Button btFirstPage;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btLastPage;
        private System.Windows.Forms.TextBox txtPagina;
    }
}

