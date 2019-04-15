using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// La propiedad SetNumero asignará un valor al atributo numero, previa validación.
        /// </summary>
        /// 

        /// <summary>
        /// ValidarNumero comprobará que el valor recibido sea numérico 
        /// </summary>
        /// <param name="strNumero">string a ser comprobado</param>
        /// <returns>retorno: numero en formato double con el valor convertido o 0 en caso de no poder hacerlo</returns>
        private static double ValidarNumero(string stringNumero)
        {
            bool TryParse = false;
            double numero = 0;
            double auxiliarNumero;

            TryParse = double.TryParse(stringNumero, out auxiliarNumero);
            if (TryParse == true)
            {
                numero = auxiliarNumero;
            }

            return numero;
        }

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, inicializa el atributo del objeto en 0
        /// </summary>

        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="numero">double con el valor que inicializa el objeto</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="stringNumero">string que luego de ser validado y convertido inicializa el objeto</param>
        public Numero(string stringNumero)
        {
            SetNumero = stringNumero;
        }
        #endregion


        /// <summary>
        /// El método BinarioDecimal convertirá un número binario a decimal, en caso de ser posible
        /// </summary>
        /// <param name="binario">string a ser comprobado</param>
        /// <returns>retorno: string del numero binario convertido a double o Valor Invalido en caso de error</returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            double numDecimal = 0;
            int bandera = 0;
            int bl = binario.Length;
            foreach (char b in binario)
            {
                if (b != '0' && b != '1')
                {
                    bandera = 1;
                }
            }
            if (bandera == 0)
            {
                for (int i = 1; i <= bl; i++)
                {
                    byte n = byte.Parse(binario.Substring(bl - i, 1));
                    if (n == 1)
                    {
                        numDecimal += System.Math.Pow(2, i - 1);
                    }
                }
                retorno = "" + numDecimal;
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">double a ser convertido</param>
        /// <returns>retorno: string del valor double en binario o Valor Invalido en caso de no poder convertir</returns>
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        numeroBinario = "0" + numeroBinario;
                    }
                    else
                    {
                        numeroBinario = "1" + numeroBinario;
                    }
                    numero = (int)numero / 2;
                }
            }
            else
            {
                if (numero == 0)
                {
                    numeroBinario = "0";
                }
                else
                {
                    numeroBinario = "Numero Invalido";
                }
            }
            return numeroBinario;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">string a ser convertido</param>
        /// <returns>retorno: string con el equivalente binario del numero convertido a double</returns>
        public string DecimalBinario(string numero)
        {
            string retornoBinario = "";
            double auxiliarNumero = 0;
            auxiliarNumero = double.Parse(numero);
            retornoBinario = DecimalBinario(auxiliarNumero);
            return retornoBinario;

        }

        


        #region operadores
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }
        public static double operator /(Numero numero1, Numero numero2)
        {
            return numero1.numero / numero2.numero;
        }
        #endregion
    }
}