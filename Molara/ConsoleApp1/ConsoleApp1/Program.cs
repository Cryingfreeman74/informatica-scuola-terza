using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int getN()
        {
            while(true)
            {
                Console.Write("Inserisci N: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    if (n > 0) return n;
                    else Console.WriteLine("N deve essere positivo, riprova");
                }
                else Console.WriteLine("Valore inserito non intero, riprova");
            }
        }

        static void printSpaces(int number)
        {
            for (int i = 0; i < number; i++) Console.Write(" ");
        }
        static void Main(string[] args)
        {
            int n = getN(), num = 0;

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < (int)(Math.Pow(2,i)); j++)
                {
                    if (j != 0) num++;
                    printSpaces(1 + 2 * (n - i -1));
                    Console.Write(num);
                }
                num++;
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
