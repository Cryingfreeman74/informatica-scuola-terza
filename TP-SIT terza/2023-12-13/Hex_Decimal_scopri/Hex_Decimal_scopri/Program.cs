/*
 *Marco Balducci 3H 2023-12-13
 *Programma di conversione Hex - Decimale dato dal professore e di cui capire il funzionamento
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex_Decimal_scopri
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Scrivi il numero esadecimale: ");
            string hex = Console.ReadLine().ToUpper();

            #region Conversion Hex to Dec

            int pos = 0; //posizione da destra
            int dec = 0; //risultato conversione

            foreach (char c in hex)
            {
                int n = 0; //valore decimale del char
                if (c >= '0' && c <= '9')
                {
                    n = c - '0'; //char - char 0 = valore decimale di char
                } else if ( c >= 'A' && c <= 'F')
                {
                    n = c - 55; //55 = valore Ascii di A - 10, di conseguenza char - (char A - 10) = valore decimale di char tra A e F
                } else
                {
                    Console.WriteLine("Errore, il numero non è un esadecimale valido");
                    Console.ReadKey();
                    return; //nel caso non fosse un hex valido viene richiesto l'input
                }
                dec = dec + n * (int)Math.Pow(16, hex.Length - pos - 1); //viene moltiplicato n * il suo peso, dato da 16 ^ (pos da sx -1)
                pos++;
            }
            Console.WriteLine(dec);
            Console.ReadKey();
            #endregion
        }
    }
}
