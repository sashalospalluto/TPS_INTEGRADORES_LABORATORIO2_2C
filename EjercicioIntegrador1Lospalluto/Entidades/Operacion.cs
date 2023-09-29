using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;

        #region PROPIEDADES

        public Numeracion PrimerOperando 
        { 
            get 
            {
                return this.primerOperando;           
            } 
            set 
            { 
                this.primerOperando = value;
            } 
        }

        public Numeracion SegundoOperando
        {
            get
            {
                return this.segundoOperando;
            }
            set
            {
                this.segundoOperando = value;
            }
        }

        #endregion

        #region CONSTRUCTORES

        public Operacion (Numeracion primerOperando,  Numeracion segundoOperando)
        {
            this.PrimerOperando = primerOperando;
            this.SegundoOperando = segundoOperando;
        }

        #endregion

        #region METODOS

        public Numeracion Operar(char operador)
        {
            Numeracion numeracion;
            switch (operador)
            {
                case '-':
                    numeracion = this.PrimerOperando - this.SegundoOperando;
                    break;
                case '*':
                    numeracion = this.PrimerOperando * this.SegundoOperando;
                    break;
                case '/':
                    numeracion = this.PrimerOperando / this.SegundoOperando;
                    break;
                default:
                    numeracion = this.PrimerOperando + this.SegundoOperando;
                    break;
            }         

            return numeracion;
        }

        #endregion

    }
}
