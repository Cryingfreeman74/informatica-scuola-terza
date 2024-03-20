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
        static string getString(int i) //ritorna la stringa con il carattere corrispondente, oppure spazio o controllo
        {
            string result = "";

            if (char.IsControl((char)i)) //caso controllo
            {
                result = "Controllo";
            }
            else
            {
                if (char.IsWhiteSpace((char)i)) //caso spazio
                {
                    result = "Spazio";
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

            //se l'output viene visualizzato male mettere a schermo intero la console
            int padlength = 10;

            //ciclo fino a 32 perchè 32 * 8 = 256
            for (int i = 0; i < 32; i++)
            {
                //ciclo le colonne
                for (int j = 0; j < 8; j++)
                {
                    //calcolo valore numerico del char da stampare
                    int number = i + (j * 32);

                    //stampa cella tabella
                    Console.Write($"{number.ToString().PadRight(3)} <--> {getString(i + (j * 32)).PadRight(padlength)} | ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
