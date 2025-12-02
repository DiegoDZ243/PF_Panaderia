namespace PuntoDeVentaPanaderia.ControlesUsuario
{
    partial class cuPanItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcbPan = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPan)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbPan
            // 
            this.pcbPan.Location = new System.Drawing.Point(23, 33);
            this.pcbPan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pcbPan.Name = "pcbPan";
            this.pcbPan.Size = new System.Drawing.Size(149, 150);
            this.pcbPan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPan.TabIndex = 4;
            this.pcbPan.TabStop = false;
            this.pcbPan.Click += new System.EventHandler(this.pcbPan_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(64, 7);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 23);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "label1";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(25, 186);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 23);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "Precio";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(115, 185);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(57, 23);
            this.lblStock.TabIndex = 8;
            this.lblStock.Text = "Precio";
            // 
            // cuPanItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pcbPan);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "cuPanItem";
            this.Size = new System.Drawing.Size(205, 218);
            this.Load += new System.EventHandler(this.cuPanItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbPan;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
    }
}
