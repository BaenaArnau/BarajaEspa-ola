using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BarajaEspañola
{
    public class Baraja
    {
        private List<Carta> cartas;

        /// <summary>
        /// Getter y setter de la lista de cartas de la baraja
        /// </summary>
        public List<Carta> Cartas { get { return cartas; } }

        /// <summary>
        /// Constructor de la clase baraja que añade uno a uno todas las cartas de una baraja española
        /// </summary>
        public Baraja()
        {
            cartas = new List<Carta>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Carta carta = new Carta(j + 1, (Carta.ePalo)i);
                    cartas.Add(carta);
                }
            }
        }

        /// <summary>
        /// Metodo que nos perite barajar de forma random
        /// </summary>
        public void Barajar()
        {
            Random r = new Random();
            List<Carta> newOrder = new List<Carta>();
            int distancia = cartas.Count;

            for (int i = 0; i < distancia; i++)
            {
                int numero = r.Next(0, cartas.Count);

                newOrder.Add(cartas[numero]);
                cartas.RemoveAt(numero);
            }

            cartas = newOrder;
        }

        /// <summary>
        /// Metodo que nos permite elegir como robar
        /// </summary>
        /// <returns>Nos devuelve la lista de cartas robadas</returns>
        public List<Carta> Robar(bool opcion)
        {
            List<Carta> robarCartas = new List<Carta>();
            while (true)
            {
                switch (opcion)
                {
                    case false:
                        robarCartas.Add(cartas[0]);
                        cartas.RemoveAt(0);

                        return robarCartas;
                    case true:
                        Random r = new Random();

                        return Robar(r.Next(0,cartas.Count));
                }
            }
        }

        /// <summary>
        /// Metodo que roba un numero de cartas
        /// </summary>
        /// <param name="numero">Variable que representa el umero de cartas que quieres robar</param>
        /// <returns></returns>
        public List<Carta> Robar(int numero)
        {
            List<Carta> robarCartas = new List<Carta>();
            for (int i = 0; i < numero; i++)
            {
                robarCartas.Add(cartas[0]);
                cartas.RemoveAt(0);
            }

            return robarCartas;
        }
    }
}