using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaEspañola
{
    internal class Program
    {
        public static Baraja baraja = new Baraja();
        static void Main(string[] args)
        {
            baraja.PrepararBaraja();
            baraja.Barajar();
        }
    }
}
