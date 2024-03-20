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
        static int getInt(string s) //ottiene l'input dall'utente e lo verifica
        {
            while (true)
            {
                Console.Write(s);
                if (int.TryParse(Console.ReadLine(), out int number) && (number >= 0 && number < 65536)) return number;
                else Console.WriteLine("Input non valido, riprova.");
            }
        }
        static string getString(int i) //ritorna il char corrispondente oppure controllo / spazio con il padright già effettuato
        {
            string result = "";

            if (char.IsControl((char)i))        //caso char di controllo
                result = "Controllo";
            else
            {
                if (char.IsWhiteSpace((char)i)) //caso spazio
                    result = "Spazio";
                else
                    result += (char)i;          //caso char valido
            }
            return result; 
        }
        static void Main(string[] args)
        {
            //autore
            Console.Title = "Marco Balducci 3H";
            Console.WriteLine("Marco Balducci 3H 2024-02-21");

            //imposto l'output per supportare l'unicode
            Console.OutputEncoding = Encoding.Unicode;
                                                                                                                                                                                 
            int padlength = 10;
            int left, right;    //rispettivamente valore sinstro e destro del range

            //lettura input
            left = getInt("Inserisci il valore più basso del range di caratteri da Stampare: ");
            while (true)
            {
                //right deve essere maggiore di left
                right = getInt("Inserisci il valore più alto del range di caratteri da Stampare: ");
                if (right > left) break;
                else Console.WriteLine($"il valore appena inserito deve essere più grande del primo ({left}), riprova");
            }
            

            int columnCounter = 8;

            //stampa caratteri
            for(int number = left; number <= right; number++)
            {
                //condizione di capolinea
                if (columnCounter == 8) { Console.Write("\n| "); columnCounter = 0; }

                //stampa cella tabella
                Console.Write($"{number.ToString().PadRight(5)} <--> {getString(number).PadRight(padlength)} | ");
                columnCounter++;
            }

            Console.ReadKey();
        }
    }
}
