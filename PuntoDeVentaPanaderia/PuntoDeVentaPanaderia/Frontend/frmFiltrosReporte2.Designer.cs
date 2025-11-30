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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpPanes
            // 
            this.flpPanes.AutoScroll = true;
            this.flpPanes.Location = new System.Drawing.Point(42, 186);
            this.flpPanes.Name = "flpPanes";
            this.flpPanes.Size = new System.Drawing.Size(850, 405);
            this.flpPanes.TabIndex = 1;
            // 
            // dtpMes1
            // 
            this.dtpMes1.CustomFormat = "MMMM/yyyy";
            this.dtpMes1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMes1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes1.Location = new System.Drawing.Point(206, 104);
            this.dtpMes1.Name = "dtpMes1";
            this.dtpMes1.Size = new System.Drawing.Size(205, 31);
            this.dtpMes1.TabIndex = 2;
            this.dtpMes1.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // dtpMes2
            // 
            this.dtpMes2.CustomFormat = "MMMM/yyyy";
            this.dtpMes2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMes2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMes2.Location = new System.Drawing.Point(524, 105);
            this.dtpMes2.Name = "dtpMes2";
            this.dtpMes2.Size = new System.Drawing.Size(205, 31);
            this.dtpMes2.TabIndex = 3;
            this.dtpMes2.Value = new System.DateTime(2025, 2, 1, 0, 0, 0, 0);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporte.Location = new System.Drawing.Point(410, 607);
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
            this.chkSeleccionarTodos.Location = new System.Drawing.Point(711, 153);
            this.chkSeleccionarTodos.Name = "chkSeleccionarTodos";
            this.chkSeleccionarTodos.Size = new System.Drawing.Size(182, 29);
            this.chkSeleccionarTodos.TabIndex = 5;
            this.chkSeleccionarTodos.Text = "Seleccionar Todos";
            this.chkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodos_CheckedChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(200, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(547, 38);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Seleccione los filtros para generar el reporte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mes 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(604, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mes 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seleccione los panes que quiera incluir en el reporte:";
            // 
            // frmFiltrosReporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 689);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.chkSeleccionarTodos);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.dtpMes2);
            this.Controls.Add(this.dtpMes1);
            this.Controls.Add(this.flpPanes);
            this.Name = "frmFiltrosReporte2";
            this.Text = "Filtros Para El Reporte Comparativo";
            this.Load += new System.EventHandler(this.frmFiltrosReporte2_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}