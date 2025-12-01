namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmInventario
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
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnDescontinuar = new System.Windows.Forms.Button();
            this.btnAgregarPan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvInventario.Location = new System.Drawing.Point(12, 67);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(1069, 452);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestión de inventario";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1106, 55);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::PuntoDeVentaPanaderia.Properties.Resources.lapiz;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(497, 538);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 107);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnDescontinuar
            // 
            this.btnDescontinuar.BackgroundImage = global::PuntoDeVentaPanaderia.Properties.Resources.borrar;
            this.btnDescontinuar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDescontinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescontinuar.Location = new System.Drawing.Point(852, 538);
            this.btnDescontinuar.Name = "btnDescontinuar";
            this.btnDescontinuar.Size = new System.Drawing.Size(111, 107);
            this.btnDescontinuar.TabIndex = 3;
            this.btnDescontinuar.UseVisualStyleBackColor = true;
            this.btnDescontinuar.Click += new System.EventHandler(this.btnDescontinuar_Click);
            // 
            // btnAgregarPan
            // 
            this.btnAgregarPan.AutoSize = true;
            this.btnAgregarPan.BackColor = System.Drawing.Color.Thistle;
            this.btnAgregarPan.BackgroundImage = global::PuntoDeVentaPanaderia.Properties.Resources.boton_mas;
            this.btnAgregarPan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregarPan.FlatAppearance.BorderSize = 0;
            this.btnAgregarPan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarPan.Location = new System.Drawing.Point(133, 538);
            this.btnAgregarPan.Name = "btnAgregarPan";
            this.btnAgregarPan.Size = new System.Drawing.Size(112, 107);
            this.btnAgregarPan.TabIndex = 1;
            this.btnAgregarPan.UseVisualStyleBackColor = false;
            this.btnAgregarPan.Click += new System.EventHandler(this.btnAgregarPan_Click);
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1093, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnDescontinuar);
            this.Controls.Add(this.btnAgregarPan);
            this.Controls.Add(this.dgvInventario);
            this.Name = "frmInventario";
            this.Text = "Adminitración de Inventario";
            this.Load += new System.EventHandler(this.frmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnAgregarPan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDescontinuar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel panel1;
    }
}