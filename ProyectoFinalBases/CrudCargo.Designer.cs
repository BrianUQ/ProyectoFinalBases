namespace ProyectoFinalBases
{
    partial class CrudCargo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrudCargo));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataCargo = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btmLimpiar = new System.Windows.Forms.Button();
            this.btmEliminar = new System.Windows.Forms.Button();
            this.btmActualizar = new System.Windows.Forms.Button();
            this.btmGuardar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btmCerrar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(384, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(170, 21);
            this.txtNombre.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(95, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(170, 21);
            this.txtCodigo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Codigo";
            // 
            // txtSalario
            // 
            this.txtSalario.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalario.Location = new System.Drawing.Point(95, 61);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtSalario.Size = new System.Drawing.Size(170, 21);
            this.txtSalario.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Salario";
            // 
            // dataCargo
            // 
            this.dataCargo.AllowUserToAddRows = false;
            this.dataCargo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Purple;
            this.dataCargo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataCargo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dataCargo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCargo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Salario});
            this.dataCargo.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataCargo.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataCargo.Location = new System.Drawing.Point(41, 188);
            this.dataCargo.Name = "dataCargo";
            this.dataCargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataCargo.Size = new System.Drawing.Size(513, 184);
            this.dataCargo.TabIndex = 17;
            this.dataCargo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCargo_CellDoubleClick);
            // 
            // Codigo
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 172;
            // 
            // Salario
            // 
            this.Salario.HeaderText = "Salario";
            this.Salario.Name = "Salario";
            this.Salario.Width = 200;
            // 
            // btmLimpiar
            // 
            this.btmLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmLimpiar.FlatAppearance.BorderSize = 0;
            this.btmLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmLimpiar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmLimpiar.ForeColor = System.Drawing.Color.White;
            this.btmLimpiar.Location = new System.Drawing.Point(479, 88);
            this.btmLimpiar.Name = "btmLimpiar";
            this.btmLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btmLimpiar.TabIndex = 24;
            this.btmLimpiar.Text = "Limpiar";
            this.btmLimpiar.UseVisualStyleBackColor = false;
            this.btmLimpiar.Click += new System.EventHandler(this.btmLimpiar_Click);
            // 
            // btmEliminar
            // 
            this.btmEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmEliminar.FlatAppearance.BorderSize = 0;
            this.btmEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmEliminar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmEliminar.ForeColor = System.Drawing.Color.White;
            this.btmEliminar.Location = new System.Drawing.Point(398, 159);
            this.btmEliminar.Name = "btmEliminar";
            this.btmEliminar.Size = new System.Drawing.Size(75, 23);
            this.btmEliminar.TabIndex = 23;
            this.btmEliminar.Text = "Eliminar";
            this.btmEliminar.UseVisualStyleBackColor = false;
            this.btmEliminar.Click += new System.EventHandler(this.btmEliminar_Click);
            // 
            // btmActualizar
            // 
            this.btmActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmActualizar.FlatAppearance.BorderSize = 0;
            this.btmActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmActualizar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmActualizar.ForeColor = System.Drawing.Color.White;
            this.btmActualizar.Location = new System.Drawing.Point(479, 159);
            this.btmActualizar.Name = "btmActualizar";
            this.btmActualizar.Size = new System.Drawing.Size(75, 23);
            this.btmActualizar.TabIndex = 22;
            this.btmActualizar.Text = "Actualizar";
            this.btmActualizar.UseVisualStyleBackColor = false;
            this.btmActualizar.Click += new System.EventHandler(this.btmActualizar_Click);
            // 
            // btmGuardar
            // 
            this.btmGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmGuardar.FlatAppearance.BorderSize = 0;
            this.btmGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmGuardar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmGuardar.ForeColor = System.Drawing.Color.White;
            this.btmGuardar.Location = new System.Drawing.Point(317, 159);
            this.btmGuardar.Name = "btmGuardar";
            this.btmGuardar.Size = new System.Drawing.Size(75, 23);
            this.btmGuardar.TabIndex = 21;
            this.btmGuardar.Text = "Guardar";
            this.btmGuardar.UseVisualStyleBackColor = false;
            this.btmGuardar.Click += new System.EventHandler(this.btmGuardar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(41, 161);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBusqueda.Size = new System.Drawing.Size(214, 21);
            this.txtBusqueda.TabIndex = 20;
            // 
            // btmCerrar
            // 
            this.btmCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btmCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btmCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btmCerrar.Image")));
            this.btmCerrar.Location = new System.Drawing.Point(572, 2);
            this.btmCerrar.Name = "btmCerrar";
            this.btmCerrar.Size = new System.Drawing.Size(15, 15);
            this.btmCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btmCerrar.TabIndex = 25;
            this.btmCerrar.TabStop = false;
            this.btmCerrar.Click += new System.EventHandler(this.btmCerrar_Click);
            // 
            // CrudCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(589, 425);
            this.Controls.Add(this.btmCerrar);
            this.Controls.Add(this.btmLimpiar);
            this.Controls.Add(this.btmEliminar);
            this.Controls.Add(this.btmActualizar);
            this.Controls.Add(this.btmGuardar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.dataCargo);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrudCargo";
            this.Text = "CrudCargo";
            ((System.ComponentModel.ISupportInitialize)(this.dataCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataCargo;
        private System.Windows.Forms.Button btmLimpiar;
        private System.Windows.Forms.Button btmEliminar;
        private System.Windows.Forms.Button btmActualizar;
        private System.Windows.Forms.Button btmGuardar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salario;
        private System.Windows.Forms.PictureBox btmCerrar;
    }
}