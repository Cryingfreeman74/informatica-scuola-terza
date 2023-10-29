using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppIndovinaMacchina
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number, lowGuess = 0, highGuess = 100, guess = 50;
            bool inputOk, guessed = false;
            string strInput;
            char charInput = ' ';
            Random rnd = new Random();

            Console.WriteLine("Pensa ad un numero da 1 a 100.\nIl programma proverà ad indovinare il numero e lei dovrà rispondere < se il suo numero è più piccolo, > se è + grande mentre = se indovina.\nQuando sei pronto premi un tasto.");
            Console.ReadKey();

            do
            {
                guess = rnd.Next(lowGuess, highGuess + 1);

                Console.WriteLine("\nIl suo numero è per caso " + guess + " ?");
                charInput = Console.ReadKey().KeyChar;

                
                switch (charInput)
                {
                    case '<':
                        highGuess = guess;
                        break;
                    case '>':
                        lowGuess = guess;
                        break;
                    case '=':
                        guessed = true;
                        break;
                }

            } while (!guessed);

            Console.WriteLine("\ntrovato! il numero era " + guess);
            Console.ReadKey();
        }
    }
}
