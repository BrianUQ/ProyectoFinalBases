namespace ProyectoFinalBases
{
    partial class CrudBitacora
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Limpiar = new System.Windows.Forms.Button();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.dataBitacora = new System.Windows.Forms.DataGridView();
            this.btmRecargar = new System.Windows.Forms.Button();
            this.btmBuscar = new System.Windows.Forms.Button();
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btmFecha = new System.Windows.Forms.PictureBox();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataBitacora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmFecha)).BeginInit();
            this.SuspendLayout();
            // 
            // Limpiar
            // 
            this.Limpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Limpiar.FlatAppearance.BorderSize = 0;
            this.Limpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.Limpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Limpiar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limpiar.ForeColor = System.Drawing.Color.White;
            this.Limpiar.Location = new System.Drawing.Point(18, 58);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 21;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = false;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(18, 180);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(143, 21);
            this.txtBusqueda.TabIndex = 20;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // dataBitacora
            // 
            this.dataBitacora.AllowUserToAddRows = false;
            this.dataBitacora.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Purple;
            this.dataBitacora.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataBitacora.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dataBitacora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataBitacora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dataBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBitacora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Entrada,
            this.Salida,
            this.Usuario});
            this.dataBitacora.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataBitacora.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataBitacora.Location = new System.Drawing.Point(18, 207);
            this.dataBitacora.Name = "dataBitacora";
            this.dataBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataBitacora.Size = new System.Drawing.Size(540, 184);
            this.dataBitacora.TabIndex = 19;
            // 
            // btmRecargar
            // 
            this.btmRecargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmRecargar.FlatAppearance.BorderSize = 0;
            this.btmRecargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmRecargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmRecargar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmRecargar.ForeColor = System.Drawing.Color.White;
            this.btmRecargar.Location = new System.Drawing.Point(483, 178);
            this.btmRecargar.Name = "btmRecargar";
            this.btmRecargar.Size = new System.Drawing.Size(75, 23);
            this.btmRecargar.TabIndex = 17;
            this.btmRecargar.Text = "Recargar";
            this.btmRecargar.UseVisualStyleBackColor = false;
            this.btmRecargar.Click += new System.EventHandler(this.btmRecargar_Click);
            // 
            // btmBuscar
            // 
            this.btmBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmBuscar.FlatAppearance.BorderSize = 0;
            this.btmBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmBuscar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmBuscar.ForeColor = System.Drawing.Color.White;
            this.btmBuscar.Location = new System.Drawing.Point(177, 58);
            this.btmBuscar.Name = "btmBuscar";
            this.btmBuscar.Size = new System.Drawing.Size(75, 23);
            this.btmBuscar.TabIndex = 16;
            this.btmBuscar.Text = "Buscar";
            this.btmBuscar.UseVisualStyleBackColor = false;
            this.btmBuscar.Click += new System.EventHandler(this.btmBuscar_Click);
            // 
            // Calendario
            // 
            this.Calendario.Location = new System.Drawing.Point(310, 4);
            this.Calendario.Name = "Calendario";
            this.Calendario.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Fecha Inicio";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.Location = new System.Drawing.Point(86, 22);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(166, 21);
            this.txtFecha.TabIndex = 24;
            // 
            // btmFecha
            // 
            this.btmFecha.Image = global::ProyectoFinalBases.Properties.Resources.calendario;
            this.btmFecha.Location = new System.Drawing.Point(258, 28);
            this.btmFecha.Name = "btmFecha";
            this.btmFecha.Size = new System.Drawing.Size(15, 15);
            this.btmFecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btmFecha.TabIndex = 50;
            this.btmFecha.TabStop = false;
            this.btmFecha.Click += new System.EventHandler(this.btmFecha_Click);
            // 
            // Codigo
            // 
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle15;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Entrada
            // 
            this.Entrada.HeaderText = "Entrada";
            this.Entrada.Name = "Entrada";
            this.Entrada.Width = 150;
            // 
            // Salida
            // 
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            this.Salida.Width = 150;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Codigo Usuario";
            // 
            // CrudBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(589, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btmFecha);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Calendario);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.dataBitacora);
            this.Controls.Add(this.btmRecargar);
            this.Controls.Add(this.btmBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrudBitacora";
            this.Text = "CrudBitacora";
            ((System.ComponentModel.ISupportInitialize)(this.dataBitacora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmFecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.DataGridView dataBitacora;
        private System.Windows.Forms.Button btmRecargar;
        private System.Windows.Forms.Button btmBuscar;
        private System.Windows.Forms.MonthCalendar Calendario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.PictureBox btmFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.Label label2;
    }
}