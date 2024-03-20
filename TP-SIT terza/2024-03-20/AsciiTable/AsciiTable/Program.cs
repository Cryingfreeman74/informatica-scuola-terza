/* Marco Balducci 3H 21-02-2024
 * tabella valori ascii es da 0 a 127
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiTable
{
    internal class Program
    {
        static string getString(int i) //ritorna la stringa con il char corrispondente, oppure spazio o controllo
        {
            string result = "";

            if (char.IsControl((char)i))
            {
                result = "Controllo";           //caso controllo
            }
            else
            {
                if (char.IsWhiteSpace((char)i))
                {
                    result = "Spazio";          //caso spazio
                }
                else
                {
                    result += (char)i;          //caso char valido
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            //autore
            Console.Title = "Marco Balducci 3H";
            Console.WriteLine("Marco Balducci 3H 2024-02-21");

            int padlength = 10;

            //ciclo fino a 32, perchè 32 * 4 = 128
            for (int i = 0; i < 32; i++)
            {
                    //ciclo le colonne
                    for(int j = 0; j < 4; j++)
                    {   
                        //calcolo valore numerico del char da stampare
                        int number = i + (j * 32);

                        //stampa cella tabella
                        Console.Write($"{number.ToString().PadRight(3)} <--> {getString(i+(j*32)).PadRight(padlength)} | ");
                    }
                    Console.WriteLine();
            }
                Console.ReadKey();
        }
    }
}
