namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmTablaReporte2
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
            this.gridReporte = new System.Windows.Forms.DataGridView();
            this.btnGrafica = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pcbReporte = new System.Windows.Forms.PictureBox();
            this.pcbReporte2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte2)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReporte.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridReporte.Location = new System.Drawing.Point(34, 124);
            this.gridReporte.Name = "gridReporte";
            this.gridReporte.ReadOnly = true;
            this.gridReporte.RowHeadersWidth = 51;
            this.gridReporte.RowTemplate.Height = 24;
            this.gridReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridReporte.Size = new System.Drawing.Size(754, 599);
            this.gridReporte.TabIndex = 4;
            // 
            // btnGrafica
            // 
            this.btnGrafica.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrafica.Location = new System.Drawing.Point(329, 740);
            this.btnGrafica.Name = "btnGrafica";
            this.btnGrafica.Size = new System.Drawing.Size(163, 66);
            this.btnGrafica.TabIndex = 5;
            this.btnGrafica.Text = "Generar Gráfica";
            this.btnGrafica.UseVisualStyleBackColor = true;
            this.btnGrafica.Click += new System.EventHandler(this.btnGrafica_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(185, 55);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(452, 38);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Reporte Comparativo Entre Meses";
            // 
            // pcbReporte
            // 
            this.pcbReporte.Image = global::PuntoDeVentaPanaderia.Properties.Resources.reporte;
            this.pcbReporte.Location = new System.Drawing.Point(34, 247);
            this.pcbReporte.Name = "pcbReporte";
            this.pcbReporte.Size = new System.Drawing.Size(90, 90);
            this.pcbReporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbReporte.TabIndex = 13;
            this.pcbReporte.TabStop = false;
            // 
            // pcbReporte2
            // 
            this.pcbReporte2.Image = global::PuntoDeVentaPanaderia.Properties.Resources.reporte;
            this.pcbReporte2.Location = new System.Drawing.Point(643, 188);
            this.pcbReporte2.Name = "pcbReporte2";
            this.pcbReporte2.Size = new System.Drawing.Size(90, 90);
            this.pcbReporte2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbReporte2.TabIndex = 14;
            this.pcbReporte2.TabStop = false;
            // 
            // frmTablaReporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 828);
            this.Controls.Add(this.pcbReporte2);
            this.Controls.Add(this.pcbReporte);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnGrafica);
            this.Controls.Add(this.gridReporte);
            this.Name = "frmTablaReporte2";
            this.Text = "Reporte Comparativo Entre Meses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTablaReporte2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReporte2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridReporte;
        private System.Windows.Forms.Button btnGrafica;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pcbReporte;
        private System.Windows.Forms.PictureBox pcbReporte2;
    }
}