/* Marco Balducci 3H 21-02-2024
 * Tabella Valori Unicode con range di stampa
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeTable
{
    internal class Program
    {
        static string getString(int i) //ritorna il char corrispondente oppure controllo / spazio con il padright già effettuato
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
            Console.OutputEncoding = Encoding.Unicode;

            int padlength = 10;
            int left, right;

            //lettura range
            while (true)
            {
                Console.Write("Inserisci il range di valori per stampare la tabella. \nValore sinistro: ");
                if(!int.TryParse(Console.ReadLine(), out left))
                {
                    Console.WriteLine("Valore non intero, riprova.");
                    continue;
                } else if(!(left >= 0 && left < 8192 * 8) || left % 8 != 0) //controllo input 1
                {
                    Console.WriteLine("Valore non valido, riprova.\nConsiglio: valore deve essere compreso tra 0 e 65535 e deve essere multiplo di 8.");
                    continue;
                }
                Console.Write("Valore destro: ");
                if(!int.TryParse(Console.ReadLine(), out right))
                {
                    Console.WriteLine("Valore non intero, riprova.");
                    continue;
                }
                else if (!(right > left && right <= 8192 * 8) || right % 8 != 0) //controllo input 2
                {
                    Console.WriteLine("Valore non valido, riprova. \nConsiglio: valore deve essere compreso tra 0 e 65536, deve essere maggiore del valore inserito precedentemente e deve essere multiplo di 8.");
                    continue;
                }

                break;

            }

            int range = right - left; //calcolo range

            for (int i = 0; i < range / 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int number = i + left + (j * range / 8);

                    //stampa cell tabella
                    Console.Write($"{number.ToString().PadRight(5)} <--> {getString(i + (j * 8192)).PadRight(padlength)} | ");
                }
                //stampa nuova linea
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
