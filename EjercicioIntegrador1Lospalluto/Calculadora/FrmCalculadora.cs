using Entidades;

namespace Calculadora
{
    public partial class FrmCalculadora : Form
    {
        private Operacion calculadora;
        private Numeracion primerOperando;
        private Numeracion resultado;
        private Numeracion segundoOperando;
        private Esistema sistema;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (txtPrimerOperador.Text.Length > 0 && txtSegundoOperador.Text.Length > 0)
            {
                primerOperando = new Numeracion(txtPrimerOperador.Text, Esistema.Decimal);
                segundoOperando = new Numeracion(txtSegundoOperador.Text, Esistema.Decimal);
                calculadora = new Operacion(primerOperando, segundoOperando);

                this.SetResultado();
            }
        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la calculadora?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; //no deja que se cierre el boton
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrimerOperador.Clear();
            txtSegundoOperador.Clear();
            cmbOperacion.SelectedIndex = 0;
            lblResultado.Text = "Resultado: ";
            this.rbdDecimal.Checked = true;
            this.rbdBinario.Checked = false;
            resultado = new Numeracion("null", Esistema.Decimal);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbdBinario_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbdBinario.Checked)
            {
                this.rbdBinario.Checked = true;
                this.btnOperar_Click(sender, e);
            }
            else
            {
                this.rbdBinario.Checked = false;
            }
        }

        private void rbdDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbdDecimal.Checked)
            {
                this.rbdDecimal.Checked = true;
                this.btnOperar_Click(sender, e);
            }
            else
            {
                this.rbdDecimal.Checked = false;
            }
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
            lblResultado.Text = "Resultado: ";
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {
            lblResultado.Text = "Resultado: ";
        }

        private void txtPrimerOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEntradaNumerica(sender, e);
        }
        private void txtSegundoOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarEntradaNumerica(sender, e);
        }
        
        /// <summary>
        /// Realiza la operacion aritmetica
        /// </summary>
        private void SetResultado()
        {
            Numeracion numero;

            if (cmbOperacion.SelectedItem.ToString() == "")
            {
                numero = calculadora.Operar('1');
            }
            else
            {
                numero = calculadora.Operar(char.Parse(cmbOperacion.SelectedItem.ToString()));
            }

            string conversion;
            if (rbdBinario.Checked)
            {
                conversion = numero.ConvertirA(Esistema.Binario);
            }
            else
            {
                conversion = numero.ConvertirA(Esistema.Decimal);
            }

            lblResultado.Text = "Resultado: " + conversion;
        }

        /// <summary>
        /// Valida los caracteres que se ingresan a los textbox, solo permite numeros y una sola coma
        /// </summary>
        /// <param name="sender">objeto de tipo textbox</param>
        /// <param name="e">parametro que toma los caracteres que se van escribiendo en el textbox</param>
        private void ValidarEntradaNumerica(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true; // Ignora caracteres que no sean números ni comas
            }

            // Verifica que solo se permita una coma y que no se ingrese otra
            if ((e.KeyChar == ',') && (textBox.Text.IndexOf(',') > -1))
            {
                e.Handled = true; // Ya hay una coma, no permitir otra
            }
        }

    }
}