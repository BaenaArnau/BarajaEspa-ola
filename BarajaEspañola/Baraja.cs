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
        public List<Carta> Robar()
        {
            List<Carta> robarCartas = new List<Carta>();
            while (true)
            {
                Console.WriteLine(@"
Elije la opcion de robo que te guste mas:
1. Robar una carta
2. Robar un numero de cartas alazar
3. Robar el numero de cartas que indiques");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            robarCartas.Add(cartas[0]);
                            cartas.RemoveAt(0);

                            return robarCartas;
                        case 2:
                            Random r = new Random();

                            return Robar(r.Next(0,cartas.Count));
                        case 3:
                            Console.WriteLine($"Escribe el numero de cartas que quieres robar (max: {cartas.Count})");
                            if (int.TryParse(Console.ReadLine(), out int robar))
                            {
                                if (robar < cartas.Count)
                                {
                                    return Robar(robar);
                                }
                                else
                                    Console.WriteLine("Escribe una opcion que no salga del limite de la baraja actual");
                            }
                            else
                                Console.WriteLine("Escribe un numero valido");

                            break;
                        default:
                            Console.WriteLine("Escribe una opcion valida");
                            break;
                    }
                }
                else
                    Console.WriteLine("Introduzca un numero");
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