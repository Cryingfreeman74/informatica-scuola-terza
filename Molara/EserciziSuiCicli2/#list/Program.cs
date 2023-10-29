using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _list
{
    internal class Program
    {
        static int ReadInput(string messaggio)
        {
            int number;

            while (true)
            {
                Console.Write(messaggio);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0) break;
                    else
                    {
                        Console.WriteLine("Il valore deve essere positivo");
                        continue;
                    }
                }
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

            int M = ReadInput("Inserisci il numero delle righe: ");
            int N = ReadInput("Inserisci il numero delle colonne: ");

            for(int i = 0; i<M; i++)
            {
                Console.WriteLine();
                for(int j = 0; j<N; j++)
                {
                    Console.Write("#");
                }
            }

            Console.WriteLine("\n\nPremere un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
