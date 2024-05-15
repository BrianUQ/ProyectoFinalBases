namespace ProyectoFinalBases
{
    partial class CrudEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btmGuardar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btmActualizar = new System.Windows.Forms.Button();
            this.btmEliminar = new System.Windows.Forms.Button();
            this.dataEmpleado = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBusquedaEmpleado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cedula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefono";
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
            this.btmGuardar.TabIndex = 5;
            this.btmGuardar.Text = "Guardar";
            this.btmGuardar.UseVisualStyleBackColor = false;
            this.btmGuardar.Click += new System.EventHandler(this.btmGuardar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(95, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(160, 21);
            this.txtCodigo.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(350, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(95, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 21);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(350, 61);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(160, 21);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(95, 105);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(160, 21);
            this.textBox4.TabIndex = 10;
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
            this.btmActualizar.TabIndex = 11;
            this.btmActualizar.Text = "Actualizar";
            this.btmActualizar.UseVisualStyleBackColor = false;
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
            this.btmEliminar.TabIndex = 12;
            this.btmEliminar.Text = "Eliminar";
            this.btmEliminar.UseVisualStyleBackColor = false;
            this.btmEliminar.Click += new System.EventHandler(this.btmEliminar_Click);
            // 
            // dataEmpleado
            // 
            this.dataEmpleado.AllowUserToAddRows = false;
            this.dataEmpleado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Purple;
            this.dataEmpleado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataEmpleado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dataEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataEmpleado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmpleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataEmpleado.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataEmpleado.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataEmpleado.Location = new System.Drawing.Point(41, 188);
            this.dataEmpleado.Name = "dataEmpleado";
            this.dataEmpleado.Size = new System.Drawing.Size(513, 184);
            this.dataEmpleado.TabIndex = 13;
            // 
            // Codigo
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle7;
            this.Codigo.HeaderText = "Columna";
            this.Codigo.Name = "Codigo";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cedula";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Direccion";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Telefono";
            this.Column4.Name = "Column4";
            // 
            // txtBusquedaEmpleado
            // 
            this.txtBusquedaEmpleado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusquedaEmpleado.Location = new System.Drawing.Point(41, 161);
            this.txtBusquedaEmpleado.Name = "txtBusquedaEmpleado";
            this.txtBusquedaEmpleado.Size = new System.Drawing.Size(244, 21);
            this.txtBusquedaEmpleado.TabIndex = 14;
            this.txtBusquedaEmpleado.TextChanged += new System.EventHandler(this.txtBusquedaEmpleado_TextChanged);
            // 
            // CrudEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(589, 425);
            this.Controls.Add(this.txtBusquedaEmpleado);
            this.Controls.Add(this.dataEmpleado);
            this.Controls.Add(this.btmEliminar);
            this.Controls.Add(this.btmActualizar);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btmGuardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrudEmpleado";
            this.Text = "CrudEnpleado";
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btmGuardar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btmActualizar;
        private System.Windows.Forms.Button btmEliminar;
        private System.Windows.Forms.DataGridView dataEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox txtBusquedaEmpleado;
    }
}