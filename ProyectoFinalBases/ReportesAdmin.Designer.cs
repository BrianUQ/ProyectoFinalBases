namespace ProyectoFinalBases
{
    partial class ReportesAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.btmGenerar1 = new System.Windows.Forms.Button();
            this.btmGenerar2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reporte Sucursales";
            // 
            // btmGenerar1
            // 
            this.btmGenerar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmGenerar1.FlatAppearance.BorderSize = 0;
            this.btmGenerar1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmGenerar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmGenerar1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmGenerar1.ForeColor = System.Drawing.Color.White;
            this.btmGenerar1.Location = new System.Drawing.Point(212, 52);
            this.btmGenerar1.Name = "btmGenerar1";
            this.btmGenerar1.Size = new System.Drawing.Size(75, 23);
            this.btmGenerar1.TabIndex = 25;
            this.btmGenerar1.Text = "Generar";
            this.btmGenerar1.UseVisualStyleBackColor = false;
            // 
            // btmGenerar2
            // 
            this.btmGenerar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btmGenerar2.FlatAppearance.BorderSize = 0;
            this.btmGenerar2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btmGenerar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmGenerar2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmGenerar2.ForeColor = System.Drawing.Color.White;
            this.btmGenerar2.Location = new System.Drawing.Point(212, 106);
            this.btmGenerar2.Name = "btmGenerar2";
            this.btmGenerar2.Size = new System.Drawing.Size(75, 23);
            this.btmGenerar2.TabIndex = 27;
            this.btmGenerar2.Text = "Generar";
            this.btmGenerar2.UseVisualStyleBackColor = false;
            this.btmGenerar2.Click += new System.EventHandler(this.btmGenerar2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Reporte Empleados";
            // 
            // ReportesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(573, 386);
            this.Controls.Add(this.btmGenerar2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btmGenerar1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportesAdmin";
            this.Text = "ReportesAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmGenerar1;
        private System.Windows.Forms.Button btmGenerar2;
        private System.Windows.Forms.Label label2;
    }
}