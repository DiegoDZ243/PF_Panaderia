namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmAuditorias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridAuditorias = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pcbImagen = new System.Windows.Forms.PictureBox();
            this.pcbImagen2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAuditorias
            // 
            this.gridAuditorias.AllowUserToAddRows = false;
            this.gridAuditorias.AllowUserToDeleteRows = false;
            this.gridAuditorias.AllowUserToResizeColumns = false;
            this.gridAuditorias.AllowUserToResizeRows = false;
            this.gridAuditorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridAuditorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAuditorias.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAuditorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridAuditorias.ColumnHeadersHeight = 29;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAuditorias.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridAuditorias.Location = new System.Drawing.Point(50, 91);
            this.gridAuditorias.Name = "gridAuditorias";
            this.gridAuditorias.ReadOnly = true;
            this.gridAuditorias.RowHeadersWidth = 51;
            this.gridAuditorias.RowTemplate.Height = 24;
            this.gridAuditorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridAuditorias.Size = new System.Drawing.Size(754, 543);
            this.gridAuditorias.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(219, 33);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(428, 38);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Cambios realizados al inventario";
            // 
            // pcbImagen
            // 
            this.pcbImagen.Image = global::PuntoDeVentaPanaderia.Properties.Resources.control_versiones;
            this.pcbImagen.Location = new System.Drawing.Point(734, 15);
            this.pcbImagen.Name = "pcbImagen";
            this.pcbImagen.Size = new System.Drawing.Size(70, 70);
            this.pcbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagen.TabIndex = 8;
            this.pcbImagen.TabStop = false;
            // 
            // pcbImagen2
            // 
            this.pcbImagen2.Image = global::PuntoDeVentaPanaderia.Properties.Resources.control_versiones;
            this.pcbImagen2.Location = new System.Drawing.Point(50, 15);
            this.pcbImagen2.Name = "pcbImagen2";
            this.pcbImagen2.Size = new System.Drawing.Size(70, 70);
            this.pcbImagen2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbImagen2.TabIndex = 9;
            this.pcbImagen2.TabStop = false;
            // 
            // frmAuditorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 661);
            this.Controls.Add(this.pcbImagen2);
            this.Controls.Add(this.pcbImagen);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gridAuditorias);
            this.Name = "frmAuditorias";
            this.Text = "Visualizador de Auditorias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAuditorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuditorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImagen2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAuditorias;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pcbImagen;
        private System.Windows.Forms.PictureBox pcbImagen2;
    }
}