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

        public Numeracion (double valor, Esistema sistema) : this(valor.ToString(), sistema)
        {

        }

        public Numeracion (string valor, Esistema sistema)
        {
            this.InicializarValores(valor, sistema);
        }

        #endregion
        
        #region METODOS

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

        public string ConvertirA (Esistema sistema)
        {
            string conversion = "";
            string valorAbsoluto;
            valorAbsoluto = Math.Floor(this.valorNumerico).ToString();
            valorAbsoluto = Math.Abs(decimal.Parse(valorAbsoluto)).ToString();
            if(valorAbsoluto != "1")
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
                        double.TryParse(this.ConvertirA(Esistema.Decimal), out this.valorNumerico);
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

        public static bool operator != (Esistema sistema, Numeracion numeracion)
        {
            return !(sistema==numeracion);
        }

        public static bool operator == (Numeracion numeracion1, Numeracion numeracion2)
        {
            bool esIgual = false;
            if(numeracion1.Sistema == numeracion2.Sistema)
            {
                esIgual = true;
            }
            return esIgual;
        }

        public static bool operator != (Numeracion numeracion1, Numeracion numeracion2)
        {
            return !(numeracion1==numeracion2);
        }
        #endregion

        #region Unarios

        public static Numeracion operator + (Numeracion numeracion1, Numeracion numeracion2)
        {
            return new Numeracion((numeracion1.valorNumerico + numeracion2.valorNumerico),Esistema.Decimal);
        }

        public static Numeracion operator - (Numeracion numeracion1, Numeracion numeracion2)
        {
            return new Numeracion((numeracion1.valorNumerico - numeracion2.valorNumerico), Esistema.Decimal);
        }
        public static Numeracion operator * (Numeracion numeracion1, Numeracion numeracion2)
        {
            return new Numeracion((numeracion1.valorNumerico * numeracion2.valorNumerico), Esistema.Decimal);
        }
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