using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Toma los datos ingresados, realiza la operacion y devuelve el resultado
        /// </summary>
        /// <param name="num1">primer operando</param>
        /// <param name="num2">segundo operando</param>
        /// <param name="operador">caracter que indica la operacion a realizar (+ - / *)</param>
        /// <returns>retorna un double con el resultado de la operacion</returns>
        private double Operar(string numero1, string numero2, string operador)
        {

            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calculadora = new Calculadora();

            return calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Confirma la operacion y muestra el resultado de la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultado = "";
            resultado = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperadores.Text)).ToString();
            this.lblResultado.Text = resultado;
        }

        /// <summary>
        /// Limpia el contenido de los textboxs, el combobox y el label de resultado
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperadores.ResetText();
        }
        // <summary>
        /// Reinicia la calculadora 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Convierte el resultado mostrado de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            this.lblResultado.Text = numero.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// Convierte el resulta mostrado de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();
            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
        }
        /// <summary>
        /// Cierra la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
    }
}