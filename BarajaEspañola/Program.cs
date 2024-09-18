using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaEspañola
{
    internal class Program
    {
        static List<Jugador> jugadores = new List<Jugador>();
        static Baraja baraja = new Baraja();
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        while (!BatallaDeCartas()) ;
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Working progress");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Introduzca una opcion valida");
                        break;
                }
            }
        }

        static int Menu()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌───────────────────────────────────┐
│          MENU  PRINCIPAL          │
├───────────────────────────────────┤
│  (1)  - Batalla de cartas         │
│  (2)  - Poker                     │
│  (0)  - Salir                     │
└───────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 2);

            return option;
        }

        static bool BatallaDeCartas()
        {
            baraja.Barajar();

            Console.WriteLine("Cuantos jugadores van a jugar? (min: 2 ; max: 5)");

            if (int.TryParse(Console.ReadLine(), out int numJugadores) || (numJugadores < 2 || numJugadores > 5))
            {
                for (int i = 0; i < numJugadores; i++)
                    jugadores.Add(new Jugador(i+1));

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

        static List<Jugador> Jugar(List<Jugador> jugadores)
        {
            foreach (var jugador in jugadores.ToList())
            {
                if (jugador.Mano.Count == 0)
                {
                    Console.WriteLine($"Jugador {jugador.Id} se ha quedado sin cartas");
                    jugadores.Remove(jugador);
                }
            }

            Console.WriteLine("-------------------------------------------------");
            foreach (var jugador in jugadores)
                Console.WriteLine($"Jugador {jugador.Id} tiene un total de {jugador.Mano.Count} cartas en la mano");
            Console.WriteLine("-------------------------------------------------");

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
                {
                    ganadores.Add(jugador);
                }
            }

            if (ganadores.Count == 1)
            {
                Jugador ganador = ganadores[0];
                ganador.Mano.Add(ganador.UltimaCarta); 

                foreach (var jugador in jugadores)
                {
                    if (ganador.Id != jugador.Id)
                    {
                        ganador.Mano.Add(jugador.UltimaCarta);
                    }
                }

                foreach (var jugador in jugadores)
                {
                    jugador.Mano.Remove(jugador.UltimaCarta);
                }

                Console.WriteLine($"El Jugador {ganador.Id} ha ganado la ronda");

                jugadores.RemoveAll(j => j.Mano.Count == 0);
            }
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

            return jugadores;
        }
    }
}
