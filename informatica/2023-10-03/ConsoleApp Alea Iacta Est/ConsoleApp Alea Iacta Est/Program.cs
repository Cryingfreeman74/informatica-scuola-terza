/*
 * 3H Balducci Marco 2023/10/03
 * Gioco di dadi in cui si può puntare su un numero.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp_Alea_Iacta_Est
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "3H Balducci Marco"
            Console.WriteLine("3H Balducci Marco\n\n")

            #region dichiarazione dati

            const int MINIMUMBET = 1;
            const int MULTIPLIER = 10;
            const int MAXIMUMNUMBER = 12, MINIMUMNUMBER = 2;

            int sesterzi = 50, bet, betNumber, result1, result2, resultSum;

            string stInput;

            char response;

            bool inputOk, playing = true;

            Random rnd = new Random();

            #endregion

            #region partita

            do
            {

                #region lettura dati in input

                do
                {
                    Console.Write("Quanti sesterzi vuoi puntare? minimo: " + MINIMUMBET + "; massimo: " + sesterzi + " -> ");
                    stInput = Console.ReadLine();

                    inputOk = int.TryParse(stInput, out bet);

                    if (!inputOk) Console.WriteLine("Il numero dei sesterzi da puntare inseriti non è valido, riprova.\n");
                    else if (bet < MINIMUMBET || bet > sesterzi)
                    {
                        inputOk = false;
                        Console.WriteLine("Il numero dei sesterzi da puntare inseriti non è ammesso, deve essere compreso tra " + MINIMUMBET + " e " + sesterzi + "\n");
                    }

                } while (!inputOk);

                #endregion

                #region scelta numero su cui puntare

                do
                {
                    Console.Write("Su quale numero vuoi puntare? [" + MINIMUMNUMBER + " - " + MAXIMUMNUMBER + "] -> ");
                    stInput = Console.ReadLine();

                    inputOk = int.TryParse(stInput, out betNumber);

                    if (!inputOk) Console.WriteLine("Il numero su cui puntare inserito non è valido, riprova. \n");
                    else if (betNumber < MINIMUMNUMBER || betNumber > MAXIMUMNUMBER)
                    {
                        inputOk = false;
                        Console.WriteLine("Il numero su cui puntare inserito non è ammesso, deve essere compreso tra " + MINIMUMNUMBER + " e " + MAXIMUMNUMBER + "\n");
                    }

                } while (!inputOk);

                #endregion

                #region lancio dadi

                result1 = rnd.Next(1, 7);
                result2 = rnd.Next(1, 7);
                resultSum = result1 + result2;

                Console.WriteLine("Lancio dadi ...");

                Thread.Sleep(500);
                Console.WriteLine("Risultato dado 1: " + result1 + "\nRisultato dado 2: " + result2 + "\nRisultato finale: " + resultSum);

                #endregion

                #region controllo esito lancio

                if (betNumber == resultSum)
                {
                    Console.Write("Complimenti, hai vinto! ");
                    sesterzi = sesterzi - bet + bet * MULTIPLIER;
                }
                else
                {
                    Console.Write("Peccato, hai perso. ");
                    sesterzi -= bet;
                }

                Console.WriteLine("I tuoi sesterzi ammontano a " + sesterzi + "\n");


                #endregion

                #region fine round

                if (sesterzi > 0)
                {
                    do
                    {
                        Console.Write("Vuoi continuare a giocare? [Y/N] -> ");
                        stInput = Console.ReadLine();

                        inputOk = Char.TryParse(stInput, out response);

                        if (!inputOk) Console.WriteLine("Risposta inserita non valida, riprova \n");
                        else if (response == 'N') playing = false;

                    } while (!inputOk);
                }
                else playing = false;
                    

                #endregion

            } while (playing);

            #endregion

            #region esito finale

            Console.WriteLine("\nHai terminato la partita con " + sesterzi + " sesterzi.\n");

            #endregion

            Console.WriteLine("Premi un tasto per terminare il programma.");
            Console.ReadKey();
        }
    }
}
