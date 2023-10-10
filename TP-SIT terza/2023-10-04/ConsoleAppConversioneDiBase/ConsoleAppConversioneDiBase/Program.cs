/*
 * 3H Balducci Marco 2023/10/04 
 * Esercizio ConsoleApp che legge e controlla un intero e lo converte in base 10, 16 e 2 (1 parte)
 * Esercizio ConsoleApp che legge un intero, lo controlla, legge una base, la controlla, e converte l'intero nella base letta
 */
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConversioneDiBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region autore

            Console.Title = "3H Balducci Marco";
            Console.WriteLine("3H Balducci Marco\n\n");

            #endregion

            #region dichiarazione variabili

            int varInt; //stringa in input convertita in intero
            string stInput; //stringa in input
            bool inputOk; //controllo input
            int baseNumero; //base in cui convertire l'intero

            #endregion

            //prima parte (lettura intero e conversione)
            /*
            #region lettura intero

            do //lettura valore e controllo
            {
                Console.Write("Input valore intero -> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out varInt); //controllo che il numero inserito sia intero

                if (!inputOk) Console.WriteLine("Il valore inserito non è intero, riprova"); //messaggio di errore nel caso non fosse intero

            } while (!inputOk); //ricicla se input non valido

            Console.WriteLine("\nValore inserito = " + varInt);

            #endregion



            #region conversione dati e scrittura

            Console.WriteLine("\nValore in base 10 = " + Convert.ToString(varInt, 10)); //Convert.ToString(numero, base)
            Console.WriteLine("Valore in base 16 = " + Convert.ToString(varInt, 16));
            Console.WriteLine("Valore in base 2 = " + Convert.ToString(varInt, 2));

            #endregion

            */


            //seconda parte (lettura intero e base e conversione)
            #region lettura intero da convertire

            do //lettura valore e controllo
            {
                Console.Write("Input valore intero da convertire -> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out varInt); //controllo che il numero inserito sia intero

                if (!inputOk) Console.WriteLine("Il valore inserito non è intero, riprova\n"); //messaggio di errore nel caso non fosse intero

            } while (!inputOk); //ricicla se input non valido

            Console.WriteLine("\nValore inserito = " + varInt);

            #endregion



            #region lettura base

            do //lettura valore e controllo
            {
                Console.Write("Input base in cui convertire il numero -> ");
                stInput = Console.ReadLine();

                inputOk = int.TryParse(stInput, out baseNumero); //controllo che il numero inserito sia intero

                if (!inputOk) Console.WriteLine("Il valore inserito non è valido, riprova\n"); //messaggio di errore nel caso non fosse intero (base non accettabile)
                //controllo validità base
                else if (baseNumero == 2); 
                else if (baseNumero == 8);
                else if (baseNumero == 10);
                else if (baseNumero == 16);
                else
                {
                    inputOk = false;
                    Console.WriteLine("Base non valida, riprova\n");
                }

            } while (!inputOk); //ricicla se input non valido

            #endregion



            #region Conversione numero e scritura

            Console.WriteLine("\nValore in base " + baseNumero + " = " + Convert.ToString(varInt, baseNumero));

            #endregion



            #region termine programma
            Console.WriteLine("\n\nPremi un tasto per terminare il programma");
            Console.ReadKey();

            #endregion

        }
    }
}
