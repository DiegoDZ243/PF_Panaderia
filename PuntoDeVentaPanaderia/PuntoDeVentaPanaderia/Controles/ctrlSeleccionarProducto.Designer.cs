namespace PuntoDeVentaPanaderia.Controles
{
    partial class ctrlSeleccionarProducto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcbPan = new System.Windows.Forms.PictureBox();
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPan)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbPan
            // 
            this.pcbPan.Location = new System.Drawing.Point(13, 3);
            this.pcbPan.Name = "pcbPan";
            this.pcbPan.Size = new System.Drawing.Size(150, 150);
            this.pcbPan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPan.TabIndex = 0;
            this.pcbPan.TabStop = false;
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeleccionar.Location = new System.Drawing.Point(25, 159);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(129, 24);
            this.chkSeleccionar.TabIndex = 2;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // ctrlSeleccionarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSeleccionar);
            this.Controls.Add(this.pcbPan);
            this.Name = "ctrlSeleccionarProducto";
            this.Size = new System.Drawing.Size(178, 193);
            this.Load += new System.EventHandler(this.ctrlSeleccionarProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbPan;
        private System.Windows.Forms.CheckBox chkSeleccionar;
    }
}
