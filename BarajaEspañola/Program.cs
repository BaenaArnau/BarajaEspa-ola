using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaEspañola
{
    internal class Program
    {
        static BatallaDeCartas batallaDeCartas = new BatallaDeCartas();

        /// <summary>
        /// Metodo que se ejecuta con el inicio del programa
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        while (!batallaDeCartas.JugarBatallaDeCartas()) ;
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

        /// <summary>
        /// Metodo que gestiona la logica del menu
        /// </summary>
        /// <returns>Devuelve un int que es la opcion de usuario</returns>
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
    }
}
