/*
 * 3H Balducci Marco 2023/10/10
 * Gioco di dadi in cui si può puntare su un numero, valore portafoglio si aggiorna in base all'esito della puntata.
 * Ciclo di gioco che termina quando vuole l'utente.
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
            Console.Title = "3H Balducci Marco";       //autore Titolo console
            Console.WriteLine("3H Balducci Marco\n\n");//autore a video

            #region dichiarazione dati

            const int MINIMUMBET = 1;                        //scommessa minima
            const int MULTIPLIER = 10;                       // moltiplicatore vincita
            const int MAXIMUMNUMBER = 12, MINIMUMNUMBER = 2; //minimo e massimo numero su cui puntare
            const int INITIALSESTERZI = 50;                  //sesterzi iniziali

            int sesterzi, bet, betNumber, result1, result2, resultSum;

            string stInput; //input utente

            char response; //risposta ai quesiti Y/N

            bool inputOk, playing = true, anotherGame; // controllo input utente, continuo Gioco e nuovo Gioco

            Random rnd = new Random(); //random number per lancio dadi

            #endregion

            #region gioco

            do
            {

                sesterzi = INITIALSESTERZI; //assegnazione valore iniziale deo sesterzi

                #region partita

                do //ciclo di gioco
                {

                    #region scelta sesterzi da puntare

                    do
                    {
                        //istruzioni all'utente
                        Console.Write("\nQuanti sesterzi vuoi puntare? minimo: " + MINIMUMBET + "; massimo: " + sesterzi + " -> ");
                        stInput = Console.ReadLine();

                        inputOk = int.TryParse(stInput, out bet); //controllo valore inserito

                        if (!inputOk) Console.WriteLine("Il numero dei sesterzi da puntare inseriti non è valido, riprova.\n"); //input non intero
                        else if (bet < MINIMUMBET || bet > sesterzi) //input non rientra nel range consentito
                        {
                            inputOk = false;
                            Console.WriteLine("Il numero dei sesterzi da puntare inseriti non è ammesso, deve essere compreso tra " + MINIMUMBET + " e " + sesterzi + "\n"); //spiegazione errore
                        }

                    } while (!inputOk);

                    #endregion

                    #region scelta numero su cui puntare

                    do
                    {
                        //istruzioni all'utente
                        Console.Write("\nSu quale numero vuoi puntare? [" + MINIMUMNUMBER + " - " + MAXIMUMNUMBER + "] -> ");
                        stInput = Console.ReadLine();

                        inputOk = int.TryParse(stInput, out betNumber); //controllo valore intero

                        if (!inputOk) Console.WriteLine("Il numero su cui puntare inserito non è valido, riprova. \n"); //input non intero
                        else if (betNumber < MINIMUMNUMBER || betNumber > MAXIMUMNUMBER) // input fuori dal range consentito
                        {
                            inputOk = false;
                            Console.WriteLine("Il numero su cui puntare inserito non è ammesso, deve essere compreso tra " + MINIMUMNUMBER + " e " + MAXIMUMNUMBER + "\n"); //spiegazione errore
                        }

                    } while (!inputOk);

                    #endregion

                    #region lancio dadi

                    result1 = rnd.Next(1, 7); //esito primo dado
                    result2 = rnd.Next(1, 7); //esito secondo dado
                    resultSum = result1 + result2; //somma degli esiti

                    Console.WriteLine("\nLancio dadi ..."); //suspense

                    Thread.Sleep(500);
                    Console.WriteLine("Risultato dado 1: " + result1 + "\nRisultato dado 2: " + result2 + "\nRisultato finale: " + resultSum); //risultati del lancio a video

                    #endregion

                    #region controllo esito lancio

                    if (betNumber == resultSum) //se il numero su cui l'utente ha puntato è uguale al risultato, l'utente vince
                    {
                        Console.Write("Complimenti, hai vinto! ");
                        sesterzi = sesterzi - bet + bet * MULTIPLIER; //aggiunta sesterzi
                    }
                    else                        //altrimenti perde
                    {
                        Console.Write("Peccato, hai perso. ");
                        sesterzi -= bet;                              //rimozione sesterzi
                    }

                    Console.WriteLine("\nI tuoi sesterzi ammontano a " + sesterzi + "\n"); //sesterzi rimasti


                    #endregion

                    #region fine round

                    if (sesterzi > 0) //controllo bancarotta
                    {
                        //richiesta altro round
                        Console.Write("Vuoi continuare a giocare? [Y/N] -> "); //lettura risposta
                        response = Console.ReadKey().KeyChar;

                        if (response == 'Y' || response == 'y') playing = true; //controllo risposta
                        else playing = false;

                    }
                    else
                    {
                        Console.WriteLine("\nSei in bancarotta, fine partita.");
                        playing = false; //se bancarotta skip scelta
                    }

                    #endregion

                } while (playing);

                #endregion

                #region esito finale

                Console.WriteLine("\nHai terminato la partita con " + sesterzi + " sesterzi.\n"); //partita finita, ammontare finale di sesterzi a video

                #endregion

                #region richiesta nuova partita
                
                Console.Write("\n\nVuoi avviare una nuova partita e ricominciare? [Y/N] -> ");
                response = Console.ReadKey().KeyChar;   //lettura risposta

                if (response == 'Y' || response == 'y') //controllo risposta
                {
                    Console.Clear(); //pulizia console per nuova partita
                    anotherGame = true;
                }
                else anotherGame = false;

                #endregion

            } while (anotherGame);

            #endregion

            //termine programma
            Console.WriteLine("\n\nPremi un tasto per terminare il programma.");
            Console.ReadKey();
        }
    }
}
