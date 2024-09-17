using System;
using System.Dynamic;

namespace BarajaEspañola
{
    public class Carta
    {
        private int numero;
        private Palo tipo;

        public enum Palo
        {
            Oros,
            Copas,
            Espadas,
            Bastos,
            Comodin
        }

        public Carta()
        {
        }

        public Carta(int numero, Palo tipo)
        {
            this.numero = numero;
            this.tipo = tipo;
        }

        public int Numero {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        public Palo Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }
    }
}