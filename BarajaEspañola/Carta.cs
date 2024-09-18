using System;
using System.Dynamic;

namespace BarajaEspañola
{
    public class Carta
    {
        private int numero;
        private ePalo tipo;

        /// <summary>
        /// Enum que represante los palos de una baraja
        /// </summary>
        public enum ePalo
        {
            Oros,
            Copas,
            Espadas,
            Bastos
        }

        /// <summary>
        /// Getter y setter del numero de la carta
        /// </summary>
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        /// <summary>
        /// Getter y setter del tipo de la carta
        /// </summary>
        public ePalo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Constructor vacio de la propia clase
        /// </summary>
        public Carta()
        {
        }

        /// <summary>
        /// Constructor de la clase donde podemos añadirle los atributos en el momento de crearla
        /// </summary>
        /// <param name="numero">Numero que tendra nuestra carta</param>
        /// <param name="tipo">Palo a la que pertenecera nuestra carta</param>
        public Carta(int numero, ePalo tipo)
        {
            this.numero = numero;
            this.tipo = tipo;
        }
    }
}