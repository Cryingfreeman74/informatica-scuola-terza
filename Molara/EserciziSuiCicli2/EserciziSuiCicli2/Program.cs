using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moltiplicazione
{
    internal class Program
    {
        static int ReadInput()
        {
            int number;

            while (true)
            {
                Console.Write("Inserisci il primo fattore: ");
                if (int.TryParse(Console.ReadLine(), out number)) break;
                else
                {
                    Console.WriteLine("Input non valido, riprova");
                    continue;
                }

            }

            return number;
        }

        static bool IsPositive(int firstNumber, int secondNumber) {

            if ((firstNumber >= 0 && secondNumber >= 0) || (firstNumber < 0 && secondNumber < 0)) return true; 
            else return false;
        }

        static void Main(string[] args)
        {
            int result = 0;

            int firstFactor = ReadInput();
            int secondFactor = ReadInput();

            bool isPositive = IsPositive(firstFactor, secondFactor);

            firstFactor = Math.Abs(firstFactor);
            secondFactor = Math.Abs(secondFactor);

            for(int i = 0; i < secondFactor; i++)
            {
                result += firstFactor;
            }

            if(!isPositive) result = -result;

            Console.Write("Il risultato della moltiplicazione è: " + result);

            Console.WriteLine("\n\nPremi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
