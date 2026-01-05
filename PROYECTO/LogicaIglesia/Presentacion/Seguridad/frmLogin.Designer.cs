namespace Presentacion
{
    partial class frmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.btnIngresar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 755);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label3.Location = new System.Drawing.Point(250, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(395, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Parroquia Nuestra Señora de Guadalupe ";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label1.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(43, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(808, 45);
            this.label1.TabIndex = 13;
            this.label1.Text = "SISTEMA INTEGRADO DE GESTIÓN PARROQUIAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.panel3.Location = new System.Drawing.Point(0, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(895, 10);
            this.panel3.TabIndex = 10;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.linkLabel1.Location = new System.Drawing.Point(100, 591);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(273, 25);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿No tienes cuenta? Regístrate";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnIngresar.Location = new System.Drawing.Point(150, 495);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(173, 60);
            this.btnIngresar.TabIndex = 7;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.label5.Location = new System.Drawing.Point(63, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(63, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "E-Mail";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(63, 389);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(347, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(63, 250);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 23);
            this.textBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(509, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(419, 631);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.panel2.Location = new System.Drawing.Point(63, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(347, 26);
            this.panel2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(45)))), ((int)(((byte)(120)))));
            this.panel4.Location = new System.Drawing.Point(63, 389);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(347, 26);
            this.panel4.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(15, 716);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(475, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "__________________________________________";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1231, 769);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}

