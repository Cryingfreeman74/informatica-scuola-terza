using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prezzoAlto
{
    internal class Program
    {
        static double ReadIntInput(string messaggio)
        {
            double number;

            while (true)
            {
                Console.Write(messaggio);
                if (double.TryParse(Console.ReadLine(), out number))
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

            string maxProdotto = "";
            double prezzoMax = 0;
            int numberOfProducts = 0;

            while(true){

                Console.Write("\ninserisci il nome del prodotto o nulla per terminare la lettura: ");
                string nome_prodotto = Console.ReadLine();

                if (nome_prodotto == "") break;

                double prezzo = ReadIntInput("\nInserisci il prezzo del prodotto: ");
                numberOfProducts++;

                if(prezzo > prezzoMax)
                {
                    maxProdotto = nome_prodotto;
                    prezzoMax = prezzo;
                }

            }    

            if(numberOfProducts != 0)
            {
                Console.WriteLine($"\nIl prodotto con il prezzo più alto è {maxProdotto} con il prezzo di {prezzoMax}.");

            } else
            {
                Console.WriteLine("\nNessun prodotto inserito.");
            }

            Console.WriteLine("\nPremi un tasto per terminare il programma");
            Console.ReadKey();

        }
    }
}
