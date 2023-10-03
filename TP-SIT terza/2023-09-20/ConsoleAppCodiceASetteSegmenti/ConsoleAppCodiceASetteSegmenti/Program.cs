/* Marco Balducci 3H 2023/09/20
 * Esercizio a pag 149 del libro: Display a 7 segmenti */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodiceASetteSegmenti
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Clear(); //il cursore si posiziona a riga 0 colonna 0

            Console.WriteLine(""); //il cursore va a capo e passa alla riga successiva
            Console.WriteLine("Digit display a 7 segmenti");

            Console.WriteLine("");
            Console.WriteLine("      ▓▓▓▓▓▓▓▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("      ▓▓▓▓▓▓▓▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("     ▓        ▓");
            Console.WriteLine("      ▓▓▓▓▓▓▓▓");




            Console.WriteLine("\nPremi un tasto per continuare");
            Console.ReadKey();

        }
    }
}
