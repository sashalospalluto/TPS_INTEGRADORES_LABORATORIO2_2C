namespace Calculadora
{
    partial class FrmCalculadora
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
            btnOperar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            lblPrimerOperador = new Label();
            lblOperacion = new Label();
            lblSegundoOperador = new Label();
            cmbOperacion = new ComboBox();
            lblResultado = new Label();
            rbdBinario = new RadioButton();
            rbdDecimal = new RadioButton();
            txtPrimerOperador = new TextBox();
            txtSegundoOperador = new TextBox();
            grpSistema = new GroupBox();
            grpSistema.SuspendLayout();
            SuspendLayout();
            // 
            // btnOperar
            // 
            btnOperar.Location = new Point(115, 399);
            btnOperar.Name = "btnOperar";
            btnOperar.Size = new Size(183, 43);
            btnOperar.TabIndex = 3;
            btnOperar.Text = "Operar";
            btnOperar.UseVisualStyleBackColor = true;
            btnOperar.Click += btnOperar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(318, 399);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(183, 43);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(538, 399);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(183, 43);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // lblPrimerOperador
            // 
            lblPrimerOperador.AutoSize = true;
            lblPrimerOperador.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrimerOperador.Location = new Point(106, 281);
            lblPrimerOperador.Name = "lblPrimerOperador";
            lblPrimerOperador.Size = new Size(181, 30);
            lblPrimerOperador.TabIndex = 3;
            lblPrimerOperador.Text = "Primer operador:";
            // 
            // lblOperacion
            // 
            lblOperacion.AutoSize = true;
            lblOperacion.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblOperacion.Location = new Point(356, 281);
            lblOperacion.Name = "lblOperacion";
            lblOperacion.Size = new Size(120, 30);
            lblOperacion.TabIndex = 4;
            lblOperacion.Text = "Operacion:";
            // 
            // lblSegundoOperador
            // 
            lblSegundoOperador.AutoSize = true;
            lblSegundoOperador.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblSegundoOperador.Location = new Point(562, 281);
            lblSegundoOperador.Name = "lblSegundoOperador";
            lblSegundoOperador.Size = new Size(204, 30);
            lblSegundoOperador.TabIndex = 5;
            lblSegundoOperador.Text = "Segundo operador:";
            // 
            // cmbOperacion
            // 
            cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOperacion.FormattingEnabled = true;
            cmbOperacion.Items.AddRange(new object[] { "", "+", "-", "*", "/" });
            cmbOperacion.Location = new Point(332, 327);
            cmbOperacion.Name = "cmbOperacion";
            cmbOperacion.Size = new Size(156, 23);
            cmbOperacion.TabIndex = 1;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultado.Location = new Point(42, 37);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(246, 65);
            lblResultado.TabIndex = 7;
            lblResultado.Text = "Resultado:";
            // 
            // rbdBinario
            // 
            rbdBinario.AutoSize = true;
            rbdBinario.Location = new Point(156, 34);
            rbdBinario.Name = "rbdBinario";
            rbdBinario.Size = new Size(62, 19);
            rbdBinario.TabIndex = 7;
            rbdBinario.Text = "Binario";
            rbdBinario.UseVisualStyleBackColor = true;
            rbdBinario.CheckedChanged += rbdBinario_CheckedChanged;
            // 
            // rbdDecimal
            // 
            rbdDecimal.AutoSize = true;
            rbdDecimal.Checked = true;
            rbdDecimal.Location = new Point(35, 34);
            rbdDecimal.Name = "rbdDecimal";
            rbdDecimal.Size = new Size(68, 19);
            rbdDecimal.TabIndex = 6;
            rbdDecimal.TabStop = true;
            rbdDecimal.Text = "Decimal";
            rbdDecimal.UseVisualStyleBackColor = true;
            rbdDecimal.CheckedChanged += rbdDecimal_CheckedChanged;
            // 
            // txtPrimerOperador
            // 
            txtPrimerOperador.Location = new Point(115, 327);
            txtPrimerOperador.MaxLength = 10;
            txtPrimerOperador.Name = "txtPrimerOperador";
            txtPrimerOperador.Size = new Size(162, 23);
            txtPrimerOperador.TabIndex = 0;
            txtPrimerOperador.TextChanged += txtPrimerOperador_TextChanged;
            txtPrimerOperador.KeyPress += txtPrimerOperador_KeyPress;
            // 
            // txtSegundoOperador
            // 
            txtSegundoOperador.Location = new Point(562, 327);
            txtSegundoOperador.MaxLength = 10;
            txtSegundoOperador.Name = "txtSegundoOperador";
            txtSegundoOperador.Size = new Size(162, 23);
            txtSegundoOperador.TabIndex = 2;
            txtSegundoOperador.TextChanged += txtSegundoOperador_TextChanged;
            txtSegundoOperador.KeyPress += txtSegundoOperador_KeyPress;
            // 
            // grpSistema
            // 
            grpSistema.Controls.Add(rbdDecimal);
            grpSistema.Controls.Add(rbdBinario);
            grpSistema.Location = new Point(283, 162);
            grpSistema.Name = "grpSistema";
            grpSistema.Size = new Size(269, 80);
            grpSistema.TabIndex = 12;
            grpSistema.TabStop = false;
            grpSistema.Text = "Representar resultado en:";
            // 
            // FrmCalculadora
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 493);
            Controls.Add(grpSistema);
            Controls.Add(txtSegundoOperador);
            Controls.Add(txtPrimerOperador);
            Controls.Add(lblResultado);
            Controls.Add(cmbOperacion);
            Controls.Add(lblSegundoOperador);
            Controls.Add(lblOperacion);
            Controls.Add(lblPrimerOperador);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnOperar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCalculadora";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora de Sasha Lospalluto";
            FormClosing += FrmCalculadora_FormClosing;
            Load += FrmCalculadora_Load;
            Click += FrmCalculadora_Click;
            grpSistema.ResumeLayout(false);
            grpSistema.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOperar;
        private Button btnLimpiar;
        private Button btnCerrar;
        private Label lblPrimerOperador;
        private Label lblOperacion;
        private Label lblSegundoOperador;
        private ComboBox cmbOperacion;
        private Label lblResultado;
        private RadioButton rbdBinario;
        private RadioButton rbdDecimal;
        private TextBox txtPrimerOperador;
        private TextBox txtSegundoOperador;
        private GroupBox grpSistema;
    }
}