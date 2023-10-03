/*
 * 3H Balducci Marco 2023/09/27
 * Esercizio che consiste nel ricevere dati in Input tramite console e verificare il tipo di dato letto.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputDati
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "3H Balducci Marco"; //Autore
            //dichiarazione variabili input
            string stInput;
            bool inputOk;
            int varInt; //intero letto

            #region lettura Intero

            do
            {
                Console.Write("Input valore intero -> ");
                stInput = Console.ReadLine();

                //conversione stringa in intero
                inputOk = int.TryParse(stInput, out varInt); //converte la stringa in intero e se la conversione ha successo restituisce sia varInt che true, altrimenti falso
                if (!inputOk) Console.WriteLine("Input non valido! Riprova");


            } while (!inputOk); //ricicla se input non valido

            #endregion

            /*
            #region lettura e stampa di una stringa

            Console.Write("Input stringa -> ");
            stInput = Console.ReadLine();

            //Visualizzazione stringa ricevuta in input
            Console.WriteLine("Stringa letta = " + stInput);

            #endregion
            */



            #region Termine programma
            Console.WriteLine("\nPremi un tasto per terminare il programma");
            Console.ReadKey();
            #endregion

        }
    }
}
