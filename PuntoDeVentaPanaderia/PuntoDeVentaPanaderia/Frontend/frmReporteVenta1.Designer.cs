namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmReporteVenta1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.gridReporte = new System.Windows.Forms.DataGridView();
            this.idPan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInicio = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pcbReporte = new System.Windows.Forms.PictureBox();
            this.pcbReporte2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpInicio
            // 
            this.dtpInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpInicio.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(137, 96);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(245, 38);
            this.dtpInicio.TabIndex = 0;
            this.dtpInicio.Value = new System.DateTime(2024, 11, 28, 12, 32, 0, 0);
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // gridReporte
            // 
            this.gridReporte.AllowUserToAddRows = false;
            this.gridReporte.AllowUserToDeleteRows = false;
            this.gridReporte.AllowUserToResizeColumns = false;
            this.gridReporte.AllowUserToResizeRows = false;
            this.gridReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridReporte.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridReporte.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridReporte.ColumnHeadersHeight = 29;
            this.gridReporte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPan,
            this.nombre,
            this.unidades,
            this.monto});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridReporte.Location = new System.Drawing.Point(39, 134);
            this.gridReporte.Name = "gridReporte";
            this.gridReporte.ReadOnly = true;
            this.gridReporte.RowHeadersWidth = 51;
            this.gridReporte.RowTemplate.Height = 24;
            this.gridReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridReporte.Size = new System.Drawing.Size(754, 599);
            this.gridReporte.TabIndex = 3;
            this.gridReporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridReporte_CellContentClick);
            // 
            // idPan
            // 
            this.idPan.HeaderText = "Clave";
            this.idPan.MinimumWidth = 6;
            this.idPan.Name = "idPan";
            this.idPan.ReadOnly = true;
            this.idPan.Width = 101;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 130;
            // 
            // unidades
            // 
            this.unidades.HeaderText = "Unidades";
            this.unidades.MinimumWidth = 6;
            this.unidades.Name = "unidades";
            this.unidades.ReadOnly = true;
            this.unidades.Width = 144;
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto";
            this.monto.MinimumWidth = 6;
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 111;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInicio.Location = new System.Drawing.Point(157, 67);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(199, 29);
            this.lblInicio.TabIndex = 4;
            this.lblInicio.Text = "Fecha de Inicio:";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFin.Location = new System.Drawing.Point(542, 67);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(173, 29);
            this.lblFin.TabIndex = 7;
            this.lblFin.Text = "Fecha de Fin:";
            // 
            // dtpFin
            // 
            this.dtpFin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpFin.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(510, 96);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(245, 38);
            this.dtpFin.TabIndex = 6;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(324, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(250, 38);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Reporte de Ventas";
            // 
            // pcbReporte
            // 
            this.pcbReporte.Image = global::PuntoDeVentaPanaderia.Properties.Resources.reporte3;
            this.pcbReporte.Location = new System.Drawing.Point(761, 28);
            this.pcbReporte.Name = "pcbReporte";
            this.pcbReporte.Size = new System.Drawing.Size(90, 90);
            this.pcbReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbReporte.TabIndex = 14;
            this.pcbReporte.TabStop = false;
            // 
            // pcbReporte2
            // 
            this.pcbReporte2.Image = global::PuntoDeVentaPanaderia.Properties.Resources.reporte3;
            this.pcbReporte2.Location = new System.Drawing.Point(39, 12);
            this.pcbReporte2.Name = "pcbReporte2";
            this.pcbReporte2.Size = new System.Drawing.Size(90, 90);
            this.pcbReporte2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbReporte2.TabIndex = 15;
            this.pcbReporte2.TabStop = false;
            // 
            // frmReporteVenta1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(883, 761);
            this.Controls.Add(this.pcbReporte2);
            this.Controls.Add(this.pcbReporte);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.gridReporte);
            this.Controls.Add(this.dtpInicio);
            this.Name = "frmReporteVenta1";
            this.Text = "Reporte de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReporteVenta1_FormClosed);
            this.Load += new System.EventHandler(this.frmReporteVenta1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridView gridReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPan;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pcbReporte;
        private System.Windows.Forms.PictureBox pcbReporte2;
    }
}