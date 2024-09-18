using System.Collections.Generic;

namespace BarajaEspañola
{
    public class Jugador
    {
        private int id;
        private Carta ultimaCarta;
        private List<Carta> mano;

        /// <summary>
        /// Getter del atributo privado id
        /// </summary>
        public int Id { get { return id; } }

        /// <summary>
        /// Getter y setter de la lista privada de cartas
        /// </summary>
        public List<Carta> Mano
        {
            get { return mano; }
            set { mano = value; }
        }

        /// <summary>
        /// Getter y setter de la ultima carta que ha sacado el jugador
        /// </summary>
        public Carta UltimaCarta
        {
            get { return ultimaCarta; }
            set { ultimaCarta = value; }
        }

        /// <summary>
        /// Constructor vacio de la clase jugador 
        /// </summary>
        public Jugador()
        {
        }

        /// <summary>
        /// Constructor con id de la clase jugador
        /// </summary>
        /// <param name="id">numero para identificar al jugador</param>
        public Jugador(int id)
        {
            this.id = id;
            this.mano = new List<Carta>();
        }

        /// <summary>
        /// Metodo que saca la primera carta de la mano
        /// </summary>
        public void SacarCarta()
        {
            ultimaCarta = mano[0];
        }
    }
}