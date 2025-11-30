namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmFiltroReporte
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
            this.flpPanes = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpPanes
            // 
            this.flpPanes.AutoScroll = true;
            this.flpPanes.Location = new System.Drawing.Point(111, 72);
            this.flpPanes.Name = "flpPanes";
            this.flpPanes.Size = new System.Drawing.Size(850, 405);
            this.flpPanes.TabIndex = 0;
            // 
            // frmFiltroReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 554);
            this.Controls.Add(this.flpPanes);
            this.Name = "frmFiltroReporte";
            this.Text = "frmFiltroReporte";
            this.Load += new System.EventHandler(this.frmFiltroReporte_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPanes;
    }
}