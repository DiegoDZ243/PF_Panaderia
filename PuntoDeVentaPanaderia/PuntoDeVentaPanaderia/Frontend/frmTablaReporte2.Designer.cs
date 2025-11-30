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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridReporte = new System.Windows.Forms.DataGridView();
            this.btnGrafica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).BeginInit();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridReporte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridReporte.ColumnHeadersHeight = 29;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridReporte.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridReporte.Location = new System.Drawing.Point(23, 28);
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
            this.btnGrafica.Location = new System.Drawing.Point(330, 633);
            this.btnGrafica.Name = "btnGrafica";
            this.btnGrafica.Size = new System.Drawing.Size(163, 66);
            this.btnGrafica.TabIndex = 5;
            this.btnGrafica.Text = "Generar Gráfica";
            this.btnGrafica.UseVisualStyleBackColor = true;
            this.btnGrafica.Click += new System.EventHandler(this.btnGrafica_Click);
            // 
            // frmTablaReporte2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 709);
            this.Controls.Add(this.btnGrafica);
            this.Controls.Add(this.gridReporte);
            this.Name = "frmTablaReporte2";
            this.Text = "Reporte Comparativo Entre Meses";
            this.Load += new System.EventHandler(this.frmTablaReporte2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridReporte;
        private System.Windows.Forms.Button btnGrafica;
    }
}