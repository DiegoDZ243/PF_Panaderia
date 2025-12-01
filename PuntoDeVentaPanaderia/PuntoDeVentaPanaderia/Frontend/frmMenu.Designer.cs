namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmMenu
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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVerEmpleados = new System.Windows.Forms.Button();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnRealizarVenta = new System.Windows.Forms.Button();
            this.btnDetallesVentas = new System.Windows.Forms.Button();
            this.btnCompararVentas = new System.Windows.Forms.Button();
            this.btnAuditorias = new System.Windows.Forms.Button();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelContenedor.Controls.Add(this.btnAuditorias);
            this.panelContenedor.Controls.Add(this.lblTitulo);
            this.panelContenedor.Controls.Add(this.btnVerEmpleados);
            this.panelContenedor.Controls.Add(this.btnAgregarEmpleado);
            this.panelContenedor.Controls.Add(this.btnInventario);
            this.panelContenedor.Controls.Add(this.btnRealizarVenta);
            this.panelContenedor.Controls.Add(this.btnDetallesVentas);
            this.panelContenedor.Controls.Add(this.btnCompararVentas);
            this.panelContenedor.Location = new System.Drawing.Point(148, 71);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(720, 497);
            this.panelContenedor.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(269, 54);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Menú Principal";
            // 
            // btnVerEmpleados
            // 
            this.btnVerEmpleados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnVerEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerEmpleados.FlatAppearance.BorderSize = 0;
            this.btnVerEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEmpleados.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnVerEmpleados.ForeColor = System.Drawing.Color.White;
            this.btnVerEmpleados.Location = new System.Drawing.Point(29, 90);
            this.btnVerEmpleados.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVerEmpleados.Name = "btnVerEmpleados";
            this.btnVerEmpleados.Size = new System.Drawing.Size(200, 121);
            this.btnVerEmpleados.TabIndex = 0;
            this.btnVerEmpleados.Text = "VER EMPLEADOS";
            this.btnVerEmpleados.UseVisualStyleBackColor = false;
            this.btnVerEmpleados.Click += new System.EventHandler(this.btnVerEmpleados_Click);
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnAgregarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnAgregarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEmpleado.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAgregarEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(29, 230);
            this.btnAgregarEmpleado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(200, 121);
            this.btnAgregarEmpleado.TabIndex = 1;
            this.btnAgregarEmpleado.Text = "AGREGAR EMPLEADO";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = false;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnInventario.ForeColor = System.Drawing.Color.White;
            this.btnInventario.Location = new System.Drawing.Point(255, 230);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(200, 121);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "INVENTARIO";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnRealizarVenta
            // 
            this.btnRealizarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRealizarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRealizarVenta.FlatAppearance.BorderSize = 0;
            this.btnRealizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRealizarVenta.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnRealizarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRealizarVenta.Location = new System.Drawing.Point(255, 90);
            this.btnRealizarVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRealizarVenta.Name = "btnRealizarVenta";
            this.btnRealizarVenta.Size = new System.Drawing.Size(200, 121);
            this.btnRealizarVenta.TabIndex = 3;
            this.btnRealizarVenta.Text = "REALIZAR VENTA";
            this.btnRealizarVenta.UseVisualStyleBackColor = false;
            this.btnRealizarVenta.Click += new System.EventHandler(this.btnRealizarVenta_Click);
            // 
            // btnDetallesVentas
            // 
            this.btnDetallesVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDetallesVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetallesVentas.FlatAppearance.BorderSize = 0;
            this.btnDetallesVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetallesVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnDetallesVentas.ForeColor = System.Drawing.Color.White;
            this.btnDetallesVentas.Location = new System.Drawing.Point(480, 90);
            this.btnDetallesVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDetallesVentas.Name = "btnDetallesVentas";
            this.btnDetallesVentas.Size = new System.Drawing.Size(200, 121);
            this.btnDetallesVentas.TabIndex = 4;
            this.btnDetallesVentas.Text = "DETALLES VENTAS";
            this.btnDetallesVentas.UseVisualStyleBackColor = false;
            this.btnDetallesVentas.Click += new System.EventHandler(this.btnDetallesVentas_Click);
            // 
            // btnCompararVentas
            // 
            this.btnCompararVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnCompararVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompararVentas.FlatAppearance.BorderSize = 0;
            this.btnCompararVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompararVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCompararVentas.ForeColor = System.Drawing.Color.White;
            this.btnCompararVentas.Location = new System.Drawing.Point(480, 230);
            this.btnCompararVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCompararVentas.Name = "btnCompararVentas";
            this.btnCompararVentas.Size = new System.Drawing.Size(200, 121);
            this.btnCompararVentas.TabIndex = 5;
            this.btnCompararVentas.Text = "COMPARAR VENTAS";
            this.btnCompararVentas.UseVisualStyleBackColor = false;
            this.btnCompararVentas.Click += new System.EventHandler(this.btnCompararVentas_Click);
            // 
            // btnAuditorias
            // 
            this.btnAuditorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(60)))), ((int)(((byte)(132)))));
            this.btnAuditorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditorias.FlatAppearance.BorderSize = 0;
            this.btnAuditorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuditorias.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAuditorias.ForeColor = System.Drawing.Color.White;
            this.btnAuditorias.Location = new System.Drawing.Point(164, 368);
            this.btnAuditorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAuditorias.Name = "btnAuditorias";
            this.btnAuditorias.Size = new System.Drawing.Size(371, 81);
            this.btnAuditorias.TabIndex = 7;
            this.btnAuditorias.Text = "VER AUDITORIAS";
            this.btnAuditorias.UseVisualStyleBackColor = false;
            this.btnAuditorias.Click += new System.EventHandler(this.btnAuditorias_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1024, 638);
            this.Controls.Add(this.panelContenedor);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.Text = "Sistema Panadería - Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnVerEmpleados;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnRealizarVenta;
        private System.Windows.Forms.Button btnDetallesVentas;
        private System.Windows.Forms.Button btnCompararVentas;
        private System.Windows.Forms.Button btnAuditorias;
    }
}