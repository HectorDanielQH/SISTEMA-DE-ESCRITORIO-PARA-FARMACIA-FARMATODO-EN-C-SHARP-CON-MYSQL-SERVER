namespace PROYECTO_BASE_II.VENDEDOR.OPCIONES
{
    partial class BUSQUEDA_DE_MEDICAMENTO
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cod_pro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.des_pro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FECHA_ELA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FECHA_VEN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PRECIO = new System.Windows.Forms.TextBox();
            this.CANTIDAD = new System.Windows.Forms.Label();
            this.cantu = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RUTA = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::PROYECTO_BASE_II.Properties.Resources.abort_156539_960_7201;
            this.pictureBox1.InitialImage = global::PROYECTO_BASE_II.Properties.Resources.imgCancelar;
            this.pictureBox1.Location = new System.Drawing.Point(30, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 194);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bus
            // 
            this.bus.Location = new System.Drawing.Point(296, 25);
            this.bus.Name = "bus";
            this.bus.Size = new System.Drawing.Size(299, 20);
            this.bus.TabIndex = 1;
            this.bus.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "BUSQUEDA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CODIGO DEL PRODUCTO:";
            // 
            // cod_pro
            // 
            this.cod_pro.Location = new System.Drawing.Point(742, 25);
            this.cod_pro.Name = "cod_pro";
            this.cod_pro.ReadOnly = true;
            this.cod_pro.Size = new System.Drawing.Size(170, 20);
            this.cod_pro.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DESCRIPCION DEL PRODUCTO:";
            // 
            // des_pro
            // 
            this.des_pro.Location = new System.Drawing.Point(399, 77);
            this.des_pro.Name = "des_pro";
            this.des_pro.ReadOnly = true;
            this.des_pro.Size = new System.Drawing.Size(513, 20);
            this.des_pro.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "FECHA DE ELABORACION:";
            // 
            // FECHA_ELA
            // 
            this.FECHA_ELA.Location = new System.Drawing.Point(371, 130);
            this.FECHA_ELA.Name = "FECHA_ELA";
            this.FECHA_ELA.ReadOnly = true;
            this.FECHA_ELA.Size = new System.Drawing.Size(189, 20);
            this.FECHA_ELA.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(575, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "FECHA DE VENCIMIENTO:";
            // 
            // FECHA_VEN
            // 
            this.FECHA_VEN.Location = new System.Drawing.Point(723, 133);
            this.FECHA_VEN.Name = "FECHA_VEN";
            this.FECHA_VEN.ReadOnly = true;
            this.FECHA_VEN.Size = new System.Drawing.Size(189, 20);
            this.FECHA_VEN.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "PRECIO:";
            // 
            // PRECIO
            // 
            this.PRECIO.Location = new System.Drawing.Point(279, 185);
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.ReadOnly = true;
            this.PRECIO.Size = new System.Drawing.Size(164, 20);
            this.PRECIO.TabIndex = 12;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.AutoSize = true;
            this.CANTIDAD.Location = new System.Drawing.Point(449, 189);
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.Size = new System.Drawing.Size(220, 13);
            this.CANTIDAD.TabIndex = 11;
            this.CANTIDAD.Text = "CANTIDAD DISPONIBLE DEL PRODUCTO:";
            // 
            // cantu
            // 
            this.cantu.Location = new System.Drawing.Point(675, 185);
            this.cantu.Name = "cantu";
            this.cantu.ReadOnly = true;
            this.cantu.Size = new System.Drawing.Size(150, 20);
            this.cantu.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(226, 221);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(685, 280);
            this.dataGridView1.TabIndex = 13;
            // 
            // RUTA
            // 
            this.RUTA.BackColor = System.Drawing.SystemColors.InfoText;
            this.RUTA.Location = new System.Drawing.Point(831, 185);
            this.RUTA.Name = "RUTA";
            this.RUTA.ReadOnly = true;
            this.RUTA.Size = new System.Drawing.Size(80, 20);
            this.RUTA.TabIndex = 14;
            this.RUTA.TextChanged += new System.EventHandler(this.RUTA_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(30, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 279);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PANEL DE CONTROL";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::PROYECTO_BASE_II.Properties.Resources.imgUltimo;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(97, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::PROYECTO_BASE_II.Properties.Resources.imgPrimero;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(16, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 75);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::PROYECTO_BASE_II.Properties.Resources.imgSiguiente;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(97, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::PROYECTO_BASE_II.Properties.Resources.imgAnterior1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(16, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 75);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BUSQUEDA_DE_MEDICAMENTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(932, 517);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RUTA);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cantu);
            this.Controls.Add(this.CANTIDAD);
            this.Controls.Add(this.PRECIO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FECHA_VEN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FECHA_ELA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.des_pro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cod_pro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bus);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BUSQUEDA_DE_MEDICAMENTO";
            this.Text = "BUSQUEDA_DE_MEDICAMENTO";
            this.Load += new System.EventHandler(this.BUSQUEDA_DE_MEDICAMENTO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox bus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cod_pro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox des_pro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FECHA_ELA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FECHA_VEN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PRECIO;
        private System.Windows.Forms.Label CANTIDAD;
        private System.Windows.Forms.TextBox cantu;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox RUTA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}