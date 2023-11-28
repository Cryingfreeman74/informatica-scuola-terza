using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombola
{
    internal class Program
    {
        static Random rnd = new Random();
        static int[] mappa = new int[90];
        static int numeriRimasti = 90;
        static void estraiNumero()
        {
            while (true)
            {
                int estratto = rnd.Next(1,91);
                if (mappa[estratto - 1] == 0)
                {
                    mappa[estratto - 1] = estratto;
                    numeriRimasti--;
                    break;
                }
            }
        }
        static void stampaMappa()
        {
            Console.WriteLine("\n\t~~ TOMBOLA ~~\n");

            for(int i=0; i<mappa.Length; i++)
            {
                if (mappa[i] == 0) Console.Write(" # ");
                else 
                {
                    if (mappa[i] < 10) Console.Write(" " + mappa[i] + " ");
                    else Console.Write(" " + mappa[i]);
                }

                if ((i+1) % 10 == 0) Console.WriteLine();
            }

            Console.WriteLine();
        }

        static bool verificaCinquina()
        {
            bool verifica = true;

            for(int i=0; i<5; i++)
            {
                int numero = getInt("Inserisci il numero: ");
                bool found = false;

                for(int j = 0; j < mappa.Length; j++)
                {
                    if (mappa[j] == numero)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found) 
                { 
                    verifica = false;
                    break;
                }
            }

            return verifica;
        }

        static bool verificaDecina()
        {
            bool verifica = true;

            for (int i = 0; i < 10; i++)
            {
                int numero = getInt("Inserisci il numero: ");
                bool found = false;

                for (int j = 0; j < mappa.Length; j++)
                {
                    if (mappa[j] == numero)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    verifica = false;
                    break;
                }
            }

            return verifica;
        }

        static bool verificaTombola()
        {
            bool verifica = true;

            for (int i = 0; i < 15; i++)
            {
                int numero = getInt("Inserisci il numero: ");
                bool found = false;

                for (int j = 0; j < mappa.Length; j++)
                {
                    if (mappa[j] == numero)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    verifica = false;
                    break;
                }
            }

            return verifica;
        }

        static bool Scelta() //ritorna falso se il gioco continua oppure true se deve finire
        {
            Console.WriteLine("~ Estrai numero \t[1]\n~ Verifica Cinquina\t[2]\n~ Verifica Decina\t[3]\n~ Verifica Tombola\t[4]\n~ Genera Schedina\t[5]\n~ Esci dal gioco\t[6]");
            char choice = Console.ReadKey(true).KeyChar;

            switch(choice)
            {
                case '1':
                    estraiNumero();
                    break;
                case '2':
                    if (verificaCinquina()) Console.WriteLine("\n\tComplimenti! Hai fatto Cinquina!");
                    Console.WriteLine("\nPremi un tasto per continuare.");
                    Console.ReadKey();
                    break;
                case '3':
                    if (verificaDecina()) Console.WriteLine("\n\tComplimenti! Hai fatto Decina!");
                    Console.WriteLine("\nPremi un tasto per continuare.");
                    Console.ReadKey();
                    break;
                case '4':
                    if (verificaTombola()) Console.WriteLine("\n\tComplimenti! Hai fatto tombola!");
                    return true;
                case '5':
                    break;
                case '6':
                    return true;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

            return false;
        }

        static int getInt(string messaggio)
        {
            while(true)
            {
                Console.Write(messaggio);
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    if (numero < 1 || numero > 90) Console.WriteLine("Numero non valido, riprova");
                    else return numero;
                }
                else Console.WriteLine("Valore inserito non intero, riprova");   
            }
        }
        static void Main(string[] args)
        {
            

            for(int i=0; i<mappa.Length; i++) 
            {
                mappa[i] = 0;
            }

            while (true)
            {
                stampaMappa();

                if(numeriRimasti == 0)
                {
                    Console.WriteLine("\n\tNumeri finiti!");
                    break;
                }
                if (Scelta()) break;

            }

                Console.WriteLine("\n\nPremi un tasto per terminare il programma.");
            Console.ReadKey();
        }
    }
}
