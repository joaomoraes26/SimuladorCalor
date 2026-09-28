namespace SimuladorCalor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            numPassos = new NumericUpDown();
            lblVelocidade = new Label();
            lblStatus = new Label();
            btnIniciar = new Button();
            btnAplicar = new Button();
            numTempCorpo = new NumericUpDown();
            label6 = new Label();
            cmbMaterialCorpo = new ComboBox();
            label5 = new Label();
            lblInfo = new Label();
            label4 = new Label();
            btnCriar = new Button();
            chkAleatorio = new CheckBox();
            numTemp = new NumericUpDown();
            label3 = new Label();
            cmbMaterial = new ComboBox();
            lblMaterial = new Label();
            numLado = new NumericUpDown();
            label2 = new Label();
            numN = new NumericUpDown();
            label1 = new Label();
            picGrade = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPassos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTempCorpo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTemp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGrade).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(numPassos);
            panel1.Controls.Add(lblVelocidade);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(btnIniciar);
            panel1.Controls.Add(btnAplicar);
            panel1.Controls.Add(numTempCorpo);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cmbMaterialCorpo);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblInfo);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnCriar);
            panel1.Controls.Add(chkAleatorio);
            panel1.Controls.Add(numTemp);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbMaterial);
            panel1.Controls.Add(lblMaterial);
            panel1.Controls.Add(numLado);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(numN);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 781);
            panel1.TabIndex = 0;
            // 
            // numPassos
            // 
            numPassos.Location = new Point(58, 625);
            numPassos.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPassos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPassos.Name = "numPassos";
            numPassos.Size = new Size(120, 23);
            numPassos.TabIndex = 21;
            numPassos.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblVelocidade
            // 
            lblVelocidade.AutoSize = true;
            lblVelocidade.Location = new Point(26, 607);
            lblVelocidade.Name = "lblVelocidade";
            lblVelocidade.Size = new Size(196, 15);
            lblVelocidade.TabIndex = 20;
            lblVelocidade.Text = "Velocidade (passos por atualizacao) ";
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(23, 692);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(210, 80);
            lblStatus.TabIndex = 19;
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.Green;
            btnIniciar.ForeColor = SystemColors.Window;
            btnIniciar.Location = new Point(22, 666);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(206, 23);
            btnIniciar.TabIndex = 18;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnAplicar
            // 
            btnAplicar.Location = new Point(23, 572);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(208, 23);
            btnAplicar.TabIndex = 17;
            btnAplicar.Text = "Aplicar no cubo";
            btnAplicar.UseVisualStyleBackColor = true;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // numTempCorpo
            // 
            numTempCorpo.DecimalPlaces = 2;
            numTempCorpo.Location = new Point(23, 543);
            numTempCorpo.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numTempCorpo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTempCorpo.Name = "numTempCorpo";
            numTempCorpo.Size = new Size(206, 23);
            numTempCorpo.TabIndex = 16;
            numTempCorpo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 525);
            label6.Name = "label6";
            label6.Size = new Size(139, 15);
            label6.TabIndex = 15;
            label6.Text = "Temperatura do cubo (K)";
            // 
            // cmbMaterialCorpo
            // 
            cmbMaterialCorpo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterialCorpo.FormattingEnabled = true;
            cmbMaterialCorpo.Location = new Point(23, 489);
            cmbMaterialCorpo.Name = "cmbMaterialCorpo";
            cmbMaterialCorpo.Size = new Size(206, 23);
            cmbMaterialCorpo.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 471);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 13;
            label5.Text = "Material do Cubo";
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(23, 369);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(210, 90);
            lblInfo.TabIndex = 12;
            lblInfo.Text = "Nenhum cubo selecionado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 354);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 11;
            label4.Text = "Cubo selecionado";
            // 
            // btnCriar
            // 
            btnCriar.Location = new Point(23, 315);
            btnCriar.Name = "btnCriar";
            btnCriar.Size = new Size(205, 23);
            btnCriar.TabIndex = 10;
            btnCriar.Text = "Criar Matriz";
            btnCriar.UseVisualStyleBackColor = true;
            btnCriar.Click += btnCriar_Click;
            // 
            // chkAleatorio
            // 
            chkAleatorio.AutoSize = true;
            chkAleatorio.Location = new Point(25, 276);
            chkAleatorio.Name = "chkAleatorio";
            chkAleatorio.Size = new Size(153, 19);
            chkAleatorio.TabIndex = 9;
            chkAleatorio.Text = "Temperaturas Aleatórias";
            chkAleatorio.UseVisualStyleBackColor = true;
            // 
            // numTemp
            // 
            numTemp.DecimalPlaces = 2;
            numTemp.Location = new Point(25, 230);
            numTemp.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numTemp.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTemp.Name = "numTemp";
            numTemp.Size = new Size(206, 23);
            numTemp.TabIndex = 8;
            numTemp.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 212);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 7;
            label3.Text = "Temperatura Inicial (K)";
            // 
            // cmbMaterial
            // 
            cmbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(26, 167);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(206, 23);
            cmbMaterial.TabIndex = 6;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new Point(26, 149);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(50, 15);
            lblMaterial.TabIndex = 5;
            lblMaterial.Text = "Material";
            // 
            // numLado
            // 
            numLado.DecimalPlaces = 2;
            numLado.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numLado.Location = new Point(26, 101);
            numLado.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numLado.Minimum = new decimal(new int[] { 5, 0, 0, 131072 });
            numLado.Name = "numLado";
            numLado.Size = new Size(205, 23);
            numLado.TabIndex = 3;
            numLado.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 83);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 2;
            label2.Text = "Lado do Cubo (m)";
            // 
            // numN
            // 
            numN.Location = new Point(26, 37);
            numN.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numN.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numN.Name = "numN";
            numN.Size = new Size(206, 23);
            numN.TabIndex = 1;
            numN.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 19);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 0;
            label1.Text = "Tamanho da Matriz (N)";

            // 
            // picGrade
            // 
            picGrade.BackColor = Color.White;
            picGrade.Dock = DockStyle.Fill;
            picGrade.Location = new Point(260, 0);
            picGrade.Name = "picGrade";
            picGrade.Size = new Size(724, 781);
            picGrade.TabIndex = 1;
            picGrade.TabStop = false;
            picGrade.Paint += picGrade_Paint;
            picGrade.MouseClick += picGrade_MouseClick;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 781);
            Controls.Add(picGrade);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Sistema de Troca de Calor";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPassos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTempCorpo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTemp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLado).EndInit();
            ((System.ComponentModel.ISupportInitialize)numN).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGrade).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox picGrade;
        private Label label1;
        private Label label2;
        private NumericUpDown numN;
        private NumericUpDown numLado;
        private ComboBox cmbMaterial;
        private Label lblMaterial;
        private NumericUpDown numTemp;
        private Label label3;
        private Button btnCriar;
        private CheckBox chkAleatorio;
        private Label lblInfo;
        private Label label4;
        private ComboBox cmbMaterialCorpo;
        private Label label5;
        private NumericUpDown numTempCorpo;
        private Label label6;
        private Button btnAplicar;
        private Label lblStatus;
        private Button btnIniciar;
        private System.Windows.Forms.Timer timer1;
        private Label lblVelocidade;
        private NumericUpDown numPassos;
    }
}
