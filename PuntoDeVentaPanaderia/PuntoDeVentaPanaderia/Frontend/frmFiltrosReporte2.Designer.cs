namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmFiltrosReporte2
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
            this.dtpMes1 = new System.Windows.Forms.DateTimePicker();
            this.dtpMes2 = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.chkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMes1 = new System.Windows.Forms.Label();
            this.lblMes2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPanes
            // 
            this.flpPanes.AutoScroll = true;
            this.flpPanes.Location = new System.Drawing.Point(21, 121);
            this.flpPanes.Name = "flpPanes";
            this.flpPanes.Size = new System.Drawing.Size(850, 451);
            this.flpPanes.TabIndex = 3;
            // 
            // dtpMes1
            // 
            this.dtpMes1.CustomFormat = "MMMM/yyyy";
            this.dtpMes1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMes1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes1.Location = new System.Drawing.Point(175, 37);
            this.dtpMes1.Name = "dtpMes1";
            this.dtpMes1.Size = new System.Drawing.Size(205, 31);
            this.dtpMes1.TabIndex = 0;
            this.dtpMes1.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // dtpMes2
            // 
            this.dtpMes2.CustomFormat = "MMMM/yyyy";
            this.dtpMes2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMes2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes2.Location = new System.Drawing.Point(493, 38);
            this.dtpMes2.Name = "dtpMes2";
            this.dtpMes2.Size = new System.Drawing.Size(205, 31);
            this.dtpMes2.TabIndex = 1;
            this.dtpMes2.Value = new System.DateTime(2025, 2, 1, 0, 0, 0, 0);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporte.Location = new System.Drawing.Point(418, 659);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(122, 70);
            this.btnGenerarReporte.TabIndex = 4;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // chkSeleccionarTodos
            // 
            this.chkSeleccionarTodos.AutoSize = true;
            this.chkSeleccionarTodos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSeleccionarTodos.Location = new System.Drawing.Point(696, 86);
            this.chkSeleccionarTodos.Name = "chkSeleccionarTodos";
            this.chkSeleccionarTodos.Size = new System.Drawing.Size(182, 29);
            this.chkSeleccionarTodos.TabIndex = 2;
            this.chkSeleccionarTodos.Text = "Seleccionar Todos";
            this.chkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodos_CheckedChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(200, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(579, 38);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Seleccione los filtros para generar el reporte";
            // 
            // lblMes1
            // 
            this.lblMes1.AutoSize = true;
            this.lblMes1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes1.Location = new System.Drawing.Point(243, 6);
            this.lblMes1.Name = "lblMes1";
            this.lblMes1.Size = new System.Drawing.Size(64, 28);
            this.lblMes1.TabIndex = 7;
            this.lblMes1.Text = "Mes 1";
            // 
            // lblMes2
            // 
            this.lblMes2.AutoSize = true;
            this.lblMes2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblMes2.Location = new System.Drawing.Point(570, 6);
            this.lblMes2.Name = "lblMes2";
            this.lblMes2.Size = new System.Drawing.Size(67, 28);
            this.lblMes2.TabIndex = 8;
            this.lblMes2.Text = "Mes 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seleccione los panes que quiera incluir en el reporte:";
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.lblMes2);
            this.pnlMain.Controls.Add(this.lblMes1);
            this.pnlMain.Controls.Add(this.chkSeleccionarTodos);
            this.pnlMain.Controls.Add(this.dtpMes2);
            this.pnlMain.Controls.Add(this.dtpMes1);
            this.pnlMain.Controls.Add(this.flpPanes);
            this.pnlMain.Location = new System.Drawing.Point(31, 67);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(885, 586);
            this.pnlMain.TabIndex = 10;
            // 
            // frmFiltrosReporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(941, 740);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGenerarReporte);
            this.Name = "frmFiltrosReporte2";
            this.Text = "Filtros Para El Reporte Comparativo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFiltrosReporte2_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPanes;
        private System.Windows.Forms.DateTimePicker dtpMes1;
        private System.Windows.Forms.DateTimePicker dtpMes2;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.CheckBox chkSeleccionarTodos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMes1;
        private System.Windows.Forms.Label lblMes2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlMain;
    }
}