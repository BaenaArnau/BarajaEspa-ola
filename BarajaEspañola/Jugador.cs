using System.Collections.Generic;

namespace BarajaEspañola
{
    public class Jugador
    {
        private int id;
        private Carta ultimaCarta;
        private List<Carta> mano;

        public Jugador()
        {
        }

        public Jugador(int id)
        {
            this.id = id;
            this.mano = new List<Carta>();
        }

        public void SacarCarta()
        {
            ultimaCarta = mano[0];
        }

        public int Id { get { return id; } }

        public List<Carta> Mano
        {
            get { return mano;}
            set { mano = value; }
        }

        public Carta UltimaCarta
        {
            get { return ultimaCarta; }
            set { ultimaCarta = value; }
        }
    }
}