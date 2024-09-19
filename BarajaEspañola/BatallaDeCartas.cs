using System.Collections.Generic;
using System;
using System.Linq;

namespace BarajaEspañola
{
    public class BatallaDeCartas
    {
        static List<Jugador> jugadores = new List<Jugador>();
        static Baraja baraja = new Baraja();

        /// <summary>
        /// Metodo principal del juego BatallaDeCartas
        /// </summary>
        /// <returns>Devuelve un bool que nos permite salir del bucle cuando se ha completado</returns>
        public bool JugarBatallaDeCartas()
        {
            baraja.Barajar();

            Console.WriteLine("Cuantos jugadores van a jugar? (min: 2 ; max: 5)");

            if (int.TryParse(Console.ReadLine(), out int numJugadores) || (numJugadores < 2 || numJugadores > 5))
            {
                for (int i = 0; i < numJugadores; i++)
                    jugadores.Add(new Jugador(i + 1));

                int robar = baraja.Cartas.Count / numJugadores;
                foreach (var jugador in jugadores)
                    jugador.Mano = baraja.Robar(robar);
                while (Jugar(jugadores).Count != 1) ;

                return true;
            }
            else
                Console.WriteLine("Escriba un numero valido");

            return false;
        }

        /// <summary>
        /// Metodo que gestiona la logica de Batalla de cartas
        /// </summary>
        /// <param name="jugadores">Lista de jugadores para empezar este juego</param>
        /// <returns>devuelve la lista de los jugadores que han ganado</returns>
        public List<Jugador> Jugar(List<Jugador> jugadores)
        {
            foreach (var jugador in jugadores.ToList())
            {
                if (jugador.Mano.Count == 0)
                {
                    Console.WriteLine($"Jugador {jugador.Id} se ha quedado sin cartas");
                    jugadores.Remove(jugador);
                }
            }

            ImprimirJugador(jugadores);

            List<Jugador> ganadores = ComprobarCartaAlta(jugadores);

            ComprobarEmpate(jugadores, ganadores);

            return jugadores;
        }

        /// <summary>
        /// Metodo que nos permite encontrar el jugador o jugadores con la carta mas alta
        /// </summary>
        /// <param name="jugadores">Lista de los jugadores que estan jugando la partida</param>
        /// <returns>Devuelve una lista de ganadores de la ronda</returns>
        private static List<Jugador> ComprobarCartaAlta(List<Jugador> jugadores)
        {
            List<Jugador> ganadores = new List<Jugador>();
            int cartaAlta = 0;

            foreach (var jugador in jugadores)
            {
                jugador.SacarCarta();
                Console.WriteLine($"Jugador {jugador.Id} saca la carta {jugador.UltimaCarta.Numero} de {jugador.UltimaCarta.Tipo}");

                if (jugador.UltimaCarta.Numero > cartaAlta)
                {
                    ganadores.Clear();
                    ganadores.Add(jugador);
                    cartaAlta = jugador.UltimaCarta.Numero;
                }
                else if (jugador.UltimaCarta.Numero == cartaAlta)
                    ganadores.Add(jugador);
            }

            return ganadores;
        }

        /// <summary>
        /// Metodo que comprueba si hay un empate y hace las gestiones pertinentes para que desempaten
        /// </summary>
        /// <param name="jugadores">Lista de los jugadores activos en la partida</param>
        /// <param name="ganadores">Lista de los gaadores de la ronda</param>
        private void ComprobarEmpate(List<Jugador> jugadores, List<Jugador> ganadores)
        {
            if (ganadores.Count == 1)
            {
                Jugador ganador = ganadores[0];
                ganador.Mano.Add(ganador.UltimaCarta);

                foreach (var jugador in jugadores)
                {
                    if (ganador.Id != jugador.Id)
                        ganador.Mano.Add(jugador.UltimaCarta);
                }

                foreach (var jugador in jugadores)
                    jugador.Mano.Remove(jugador.UltimaCarta);

                Console.WriteLine($"El Jugador {ganador.Id} ha ganado la ronda");

                jugadores.RemoveAll(j => j.Mano.Count == 0);
            }
            // Si hay empate se ejecuta esta parte del codigo para desempatar con una partida extra
            else
            {
                List<Carta> cartasRondaAnterior = new List<Carta>();
                foreach (var ganador in ganadores.ToList())
                {
                    cartasRondaAnterior.Add(ganador.UltimaCarta);
                    ganador.Mano.Remove(ganador.UltimaCarta);
                }

                Console.WriteLine("Empate! Jugando otra ronda con los jugadores empatados...");
                Jugador ganadorEmpate = Jugar(ganadores)[0];

                foreach (var carta in cartasRondaAnterior)
                    ganadorEmpate.Mano.Add(carta);

                foreach (var jugador in jugadores)
                {
                    if (jugador.Id == ganadorEmpate.Id)
                        jugador.Mano = ganadorEmpate.Mano;
                }
            }
        }

        /// <summary>
        /// Metodo que nos permite imprimir las cartas que les quedan a los jugadores
        /// </summary>
        /// <param name="jugadores">Lista de jugadores en activo</param>
        public static void ImprimirJugador(List<Jugador> jugadores)
        {
            Console.WriteLine("-------------------------------------------------");
            foreach (var jugador in jugadores)
                Console.WriteLine($"Jugador {jugador.Id} tiene un total de {jugador.Mano.Count} cartas en la mano");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}