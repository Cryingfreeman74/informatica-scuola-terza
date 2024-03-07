/* Marco Balducci 3H 21-02-2024
 * tabella valori ascii da 0 a 127
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiTableEstesa
{
    internal class Program
    {
        static string getString(int i)
        {
            string result = "";

            if (char.IsControl((char)i))
            {
                result = "Controllo";
            }
            else
            {
                if (char.IsWhiteSpace((char)i))
                {
                    result = "Spazio";
                }
                else
                {
                    result += (char)i;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            //se l'output viene visualizzato male mettere a schermo intero la console
            int padlength = 10;
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int number = i + (j * 32);

                    Console.Write($"{number.ToString().PadRight(3)} <--> {getString(i + (j * 32)).PadRight(padlength)} | ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
