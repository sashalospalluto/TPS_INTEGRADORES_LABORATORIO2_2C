using System.Drawing;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public enum Esistema
    {
        Decimal,
        Binario
    }
    public class Numeracion
    {
        private Esistema sistema;
        private double valorNumerico;

        #region PROPIEDADES
        public Esistema Sistema
        {
            get
            {
                return this.sistema;
            }
        }

        public string Valor
        {
            get
            {
                return this.ConvertirA(this.Sistema);
            }
        }
        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor que recibe el valor numerico y el tipo de sistema en el que esta escrito el valor
        /// </summary>
        /// <param name="valor"> valor numerico</param>
        /// <param name="sistema">Tipo de sistema en formato Esistema</param>
        public Numeracion (double valor, Esistema sistema) : this(valor.ToString(), sistema)
        {

        }

        /// <summary>
        /// Constructor que recibe el valor numerico y el tipo de sistema en el que esta escrito el valor
        /// </summary>
        /// <param name="valor">valor numerico en formato stribg</param>
        /// <param name="sistema">Tipo de sistema en formato Esistema</param>
        public Numeracion (string valor, Esistema sistema)
        {
            this.InicializarValores(valor, sistema);
        }

        #endregion
        
        #region METODOS

        /// <summary>
        /// Convierte un valor binario en decimal
        /// </summary>
        /// <param name="valor"> Valor numerico</param>
        /// <returns>El valor numerico decimal en formato double</returns>
        private double BinarioADecimal(string valor)
        {
            string aux;
            int numeroSolo;
            double nroDecimal =double.Parse(valor);
            int contador = valor.Length;

            if(EsBinario(valor))
            {
                for (int i = 0; i < contador; i++)
                {
                    aux = valor.Substring(valor.Length - 1, 1); //tomo solo el ultimo caracter del string
                    int.TryParse(aux, out numeroSolo); //lo convierto a entero 

                    if (numeroSolo == 1) // solo si es 1 lo elevo y lo sumo
                    {
                        nroDecimal = (int)Math.Pow(2, i) + nroDecimal;
                    }
                    
                    valor = valor.Remove(valor.Length - 1); //elimino el ultimo caracter del string
                }            
            }

            return nroDecimal;
        }

        /// <summary>
        /// Convierte el valor numerico al sistema pasado por parametro
        /// </summary>
        /// <param name="sistema">Sistema numerico al que se quiere convertir</param>
        /// <returns>El valor numerico convertido en formato string</returns>
        public string ConvertirA (Esistema sistema)
        {
            string conversion = "";
            long aux;
            string valorAbsoluto;
            aux = (long)Math.Floor(this.valorNumerico);
            valorAbsoluto = aux.ToString();
            valorAbsoluto = Math.Abs(decimal.Parse(valorAbsoluto)).ToString();
            if(valorAbsoluto != "1" && valorAbsoluto != "0")
            {
                if (sistema == Esistema.Binario) //verifico que se quiera convertir a binario
                {
                    if(this.Sistema != sistema) //verifico que esté en sistema decimal
                    {
                        conversion = this.DecimalABinario(valorAbsoluto);
                        this.sistema = sistema;
                    }
                    else
                    {
                        conversion = valorAbsoluto;
                    }
                }
                else
                {
                    if (this.Sistema != sistema) //verifico que esté en sistema binario
                    {
                        conversion = this.BinarioADecimal(valorAbsoluto).ToString();
                        this.sistema = sistema;
                    }
                    else
                    {
                        conversion = valorAbsoluto;
                    }
                }
            }
            else
            {
                conversion = valorAbsoluto;
            }
            return conversion;
        }

        /// <summary>
        /// Convierte el valor numerico decimal pasado por parametro INT a formato binario
        /// </summary>
        /// <param name="valor">valor numerico a convertir</param>
        /// <returns>valor numerico convertido a binario</returns>
        private string DecimalABinario (int valor)
        {
            string binario = "";
       
            while (valor > 1)
            {
                if (valor % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                valor = valor / 2;
            }

            binario = '1' + binario;

            return binario;
        }

        /// <summary>
        /// Convierte el valor numerico decimal pasado por parametro STRING a formato binario
        /// </summary>
        /// <param name="valor">valor numerico a convertir</param>
        /// <returns>valor numerico convertido a binario, si no se pudo convertir devuelve un mensaje de error</returns>
        private string DecimalABinario(string valor)
        {
            int binario;
            string resultado = "Numero invalido";

            if (int.TryParse(valor, out binario))
            {
                resultado = DecimalABinario(binario);
            }

            return resultado;
        }

        /// <summary>
        /// Valida si el numero pasado por parametro es binario
        /// </summary>
        /// <param name="valor">valor numerico</param>
        /// <returns>true si es binario, caso contrario retorna false</returns>
        private bool EsBinario(string valor)
        {
            bool esBinario = false;

            foreach (var i in valor)
            {
                if(i == '0' || i == '1')
                {
                    esBinario = true;
                }
                else
                {
                    esBinario = false;
                    break;
                }
            }

            return esBinario;
        }

        /// <summary>
        /// Inicializa los valores del objeto
        /// </summary>
        /// <param name="valor">valor numerico</param>
        /// <param name="sistema">sistema del valor numerico</param>
        private void InicializarValores(string valor, Esistema sistema)
        {
            this.sistema = sistema;

            if (double.TryParse(valor, out double numero)) //valido si es un numero
            {
                this.valorNumerico = numero; //lo guardo

                if (sistema == this)
                {
                    if (sistema == Esistema.Binario)
                    {
                        this.sistema = Esistema.Decimal;
                        double.TryParse(this.Valor, out this.valorNumerico);
                    }
                }
                else
                {
                    this.valorNumerico = double.MinValue;
                }

            }
        }

        #endregion

        #region OPERADORES

        #region Binarios

        /// <summary>
        /// Valida si un numero esta escrito en el sistema pasado por parametro
        /// </summary>
        /// <param name="sistema">tipo de sistema de tipo Esistema</param>
        /// <param name="numeracion">valor numerico</param>
        /// <returns>True si el numero esta escrito en el sistema, caso contrario devuelve false</returns>
        public static bool operator == (Esistema sistema, Numeracion numeracion)
        {
            bool esIgual = true;
            if(sistema == Esistema.Binario)
            {
                if(!numeracion.EsBinario(numeracion.valorNumerico.ToString()))
                {
                    esIgual= false;
                }
            }
            return esIgual;
        }

        /// <summary>
        /// Valida si un numero NO esta escrito en el sistema pasado por parametro
        /// </summary>
        /// <param name="sistema">tipo de sistema de tipo Esistema</param>
        /// <param name="numeracion">valor numerico</param>
        /// <returns>True si el numero NO esta escrito en el sistema, caso contrario devuelve false</returns>
        public static bool operator != (Esistema sistema, Numeracion numeracion)
        {
            return !(sistema==numeracion);
        }

        /// <summary>
        /// Valida que dos numeros esten escritos en el mismo sistema
        /// </summary>
        /// <param name="numeracion1">valor numerico</param>
        /// <param name="numeracion2">valor numerico</param>
        /// <returns>True si estan escritos en el mismo sistema, caso contrario devuelve false</returns>
        public static bool operator == (Numeracion numeracion1, Numeracion numeracion2)
        {
            bool esIgual = false;
            if(numeracion1.Sistema == numeracion2.Sistema)
            {
                esIgual = true;
            }
            return esIgual;
        }

        /// <summary>
        /// Valida que dos numeros NO esten escritos en el mismo sistema
        /// </summary>
        /// <param name="numeracion1">valor numerico</param>
        /// <param name="numeracion2">valor numerico</param>
        /// <returns>True si NO estan escritos en el mismo sistema, caso contrario devuelve false</returns>
        public static bool operator != (Numeracion numeracion1, Numeracion numeracion2)
        {
            return !(numeracion1==numeracion2);
        }
        #endregion

        #region Unarios

        /// <summary>
        /// Suma dos valores numericos
        /// </summary>
        /// <param name="numeracion1">valor numerico</param>
        /// <param name="numeracion2">valor numerico</param>
        /// <returns>nuevo objeto de tipo Numeracion</returns>
        public static Numeracion operator + (Numeracion numeracion1, Numeracion numeracion2)
        {
            return new Numeracion((numeracion1.valorNumerico + numeracion2.valorNumerico),Esistema.Decimal);
        }

        /// <summary>
        /// Resta dos valores numericos
        /// </summary>
        /// <param name="numeracion1">valor numerico</param>
        /// <param name="numeracion2">valor numerico</param>
        /// <returns>nuevo objeto de tipo Numeracion</returns>
        public static Numeracion operator - (Numeracion numeracion1, Numeracion numeracion2)
        {
            return new Numeracion((numeracion1.valorNumerico - numeracion2.valorNumerico), Esistema.Decimal);
        }

        /// <summary>
        /// Multiplica dos valores numericos
        /// </summary>
        /// <param name="numeracion1">valor numerico</param>
        /// <param name="numeracion2">valor numerico</param>
        /// <returns>nuevo objeto de tipo Numeracion</returns>
        public static Numeracion operator * (Numeracion numeracion1, Numeracion numeracion2)
        {
            return new Numeracion((numeracion1.valorNumerico * numeracion2.valorNumerico), Esistema.Decimal);
        }

        /// <summary>
        /// Divide dos valores numericos
        /// </summary>
        /// <param name="numeracion1">valor numerico</param>
        /// <param name="numeracion2">valor numerico</param>
        /// <returns>nuevo objeto de tipo Numeracion</returns>
        public static Numeracion operator / (Numeracion numeracion1, Numeracion numeracion2)
        {
            Numeracion numeracion;

            if(numeracion2.valorNumerico!=0)
            {
                numeracion = new Numeracion(numeracion1.valorNumerico/numeracion2.valorNumerico, Esistema.Decimal);
            }
            else
            {
                numeracion = new Numeracion(double.MinValue, Esistema.Decimal);
            }

            return numeracion;
        }
        #endregion

        #endregion

    }
}