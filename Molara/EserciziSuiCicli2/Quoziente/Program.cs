using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoziente
{
    internal class Program
    {
        static int ReadInput(string messaggio)
        {
            int number;

            while (true)
            {
                Console.Write(messaggio);
                if (int.TryParse(Console.ReadLine(), out number)) break;
                else
                {
                    Console.WriteLine("Input non valido, riprova");
                    continue;
                }

            }

            return number;
        }

        static bool IsPositive(int firstNumber, int secondNumber)
        {

            if ((firstNumber >= 0 && secondNumber >= 0) || (firstNumber < 0 && secondNumber < 0)) return true;
            else return false;
        }
        static void Main(string[] args)
        {

            int result = 0;
            

            int Dividendo = ReadInput("Inserisci il dividendo: ");
            int Divisore = ReadInput("Inserisci il divisore: ");

            bool isPositive = IsPositive(Dividendo, Divisore);

            Dividendo = Math.Abs(Dividendo);
            Divisore = Math.Abs(Divisore);

            int temp = Dividendo;


            while (temp >= Divisore)
            {
                temp -= Divisore;
                result++;
            }

            int resto = Dividendo - Divisore * result;

            if (!isPositive) result = -result;

            Console.WriteLine("Il risultato della divisione è: " + result + "; Il resto è: " + resto);

            Console.WriteLine("\n\nPremi un tasto per terminare il programma");
            Console.ReadKey();

        }
    }
}
