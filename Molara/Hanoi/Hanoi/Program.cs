using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    internal class Program
    {
        static void hanoi(int N, char from, char aux, char to)
        {
            if(N == 1)
            {
                //passo base
                Console.WriteLine($"{from} -> {to}");
            }
            else
            {
                //sposto gli n-1 strati nell'aux
                hanoi(N - 1, from, to, aux);

                //sposto lo strato maggiore nel to
                Console.WriteLine($"{from} -> {to}");
                
                //sposto gli n-1 strati nel to
                hanoi(N - 1, aux, from, to);
            }
        }
        static void Main(string[] args)
        {
            hanoi(3, 'A', 'B', 'C');

            
            Console.ReadKey();
        }
    }
}
