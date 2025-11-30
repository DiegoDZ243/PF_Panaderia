namespace PuntoDeVentaPanaderia.ControlesUsuario
{
    partial class cuElegirPan
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
            this.chkSeleccionar = new System.Windows.Forms.CheckBox();
            this.pcbPan = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPan)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSeleccionar
            // 
            this.chkSeleccionar.AutoSize = true;
            this.chkSeleccionar.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeleccionar.Location = new System.Drawing.Point(33, 195);
            this.chkSeleccionar.Name = "chkSeleccionar";
            this.chkSeleccionar.Size = new System.Drawing.Size(129, 24);
            this.chkSeleccionar.TabIndex = 4;
            this.chkSeleccionar.Text = "Seleccionar";
            this.chkSeleccionar.UseVisualStyleBackColor = true;
            // 
            // pcbPan
            // 
            this.pcbPan.Location = new System.Drawing.Point(21, 39);
            this.pcbPan.Name = "pcbPan";
            this.pcbPan.Size = new System.Drawing.Size(150, 150);
            this.pcbPan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPan.TabIndex = 3;
            this.pcbPan.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(71, 11);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(53, 23);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "label1";
            // 
            // cuElegirPan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.chkSeleccionar);
            this.Controls.Add(this.pcbPan);
            this.Name = "cuElegirPan";
            this.Size = new System.Drawing.Size(196, 227);
            this.Load += new System.EventHandler(this.cuElegirPan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSeleccionar;
        private System.Windows.Forms.PictureBox pcbPan;
        private System.Windows.Forms.Label lblNombre;
    }
}
