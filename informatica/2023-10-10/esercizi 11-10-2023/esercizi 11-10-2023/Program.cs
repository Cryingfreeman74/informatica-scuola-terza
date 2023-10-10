using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esercizio_2
{
    internal class Program
    {
        const double SOGLIA1 = 10000.00;
        const double SOGLIA2 = 15000.0;
        const double ALIQUOTA1 = .15;
        const double ALIQUOTA2 = .2;
        const double ALIQUOTA3 = .23;
        static void Main(string[] args)
        {

            double redditoNetto;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Inserire il reddito lordo: ");
            double reddito = double.Parse(Console.ReadLine());

            double imposta = 0.0;
            if (reddito <= SOGLIA1)
            {
                imposta = reddito * ALIQUOTA1;
            }
            else if (reddito <= ALIQUOTA2)
            {
                imposta = SOGLIA1 * ALIQUOTA1 + (reddito - SOGLIA1) * ALIQUOTA2;

            }
            else imposta = (reddito - SOGLIA2) * ALIQUOTA3 + (SOGLIA2 - SOGLIA1) * ALIQUOTA2 + SOGLIA1 * ALIQUOTA1;

            redditoNetto = reddito - imposta;

            Console.WriteLine("L'imposta su {0:C} è {1:C}; di conseguenza il suo reddito netto è {2}", reddito, imposta, redditoNetto);

            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
