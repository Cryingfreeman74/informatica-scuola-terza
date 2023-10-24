using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloPi
{
    internal class Program
    {

        const double LATO = 1.0;

        static void Main(string[] args)
        {

            Random rnd = new Random();

            for (long j = 1; j < 100000000000; j *= 10)
            {
                long puntiTotali = j;

                long puntiCerchio = 0;

                for (long i = 0; i < puntiTotali; i++)
                {
                    double x = rnd.NextDouble() * LATO; //ottengo un valore casuale tra 0  e lato
                    double y = rnd.NextDouble() * LATO;
                    if (x * x + y * y <= LATO) puntiCerchio++;
                }

                double Pi = 4 * ((double)puntiCerchio / (double)puntiTotali);

                Console.WriteLine($"{puntiTotali} --> pi greco: {Pi}");

            } 
            


            Console.ReadKey();
        
        }
    }
}
