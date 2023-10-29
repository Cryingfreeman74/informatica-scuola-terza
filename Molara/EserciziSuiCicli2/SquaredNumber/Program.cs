using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaredNumber
{
    internal class Program
    {
        static int squaredNumber(int number)
        {
            number = Math.Abs(number);

            int squaredNumber = 0, counter = 0, temp = 0; 

            while(counter < number)
            {
                if(temp % 2 != 0)
                {
                    squaredNumber += temp;
                    counter++;
                }

                temp++;

            }

            return squaredNumber;
        }
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
        static void Main(string[] args)
        {
            int N = ReadInput("Inserisci il numero intero di cui calcolare il quadrato: ");

            int squared = squaredNumber(N);

            Console.WriteLine($"Il quadrato di {N} è {squared}");

            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
