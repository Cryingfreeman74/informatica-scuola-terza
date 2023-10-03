/*
 * 3H Balducci Marco 2023/09/27
 * Esercizio che consiste nel ricevere dati in Input tramite console e verificarne il tipo, gestendo la possibilità che l'utente non inserisca il dato giusto.
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
            #region Autore

            Console.Title = "3H Balducci Marco"; //Autore
            Console.WriteLine("3H balducci Marco"); //Autore a video

            #endregion



            #region dichiarazione variabili input e costanti

            string stInput;
            bool inputOk;

            int varInt; //intero letto

            double varDouble; //valore double letto

            //dati alunni
            const int MAXNUMALUNNI = 35; //numero massimo di alunni ammesso
            const int MINNUMALUNNI = 10; //numero minimo di alunni ammesso
            int numAlunni; //numero alunni di una classe

            //dati altezza
            const double MINHEIGHT = .24; //altezza minima essere umano
            const double MAXHEIGHT = 2.51; //altezza massima essere umano
            double height;

            #endregion



            #region lettura e scrittura Intero

            do
            {
                Console.Write("\nInput valore intero -> ");
                stInput = Console.ReadLine(); //lettura stringa

                //conversione stringa in intero
                inputOk = int.TryParse(stInput, out varInt); //converte la stringa in intero e se la conversione ha successo restituisce sia varInt che true, altrimenti falso
                if (!inputOk) Console.WriteLine("Input non valido! Riprova");


            } while (!inputOk); //ricicla se input non valido

            //il numero è valido

            //Scrittura valore intero letto
            Console.WriteLine("valore intero inserito: " + varInt);

            #endregion



            #region lettura e scrittura di un double

            do
            {
                Console.Write("\nInput valore con decimali -> ");
                stInput = Console.ReadLine();

                //Conversione stringa in double
                inputOk = double.TryParse(stInput, out varDouble);

                //controllo correttezza tipo input
                if (!inputOk) Console.WriteLine("Input non valido! Riprova");

            } while (!inputOk);

            //il numero è valido

            //Scrittura valore double letto
            Console.WriteLine("Valore con decimali inserito: " + varDouble);

            #endregion



            #region lettura e scrittura numero alunni di una classe

            do
            {
                Console.Write("\nInput numero alunni presenti nella classe -> ");
                stInput = Console.ReadLine(); //lettura stringa

                //conversione stringa in intero
                inputOk = int.TryParse(stInput, out numAlunni); //converte la stringa in intero e se la conversione ha successo restituisce sia varInt che true, altrimenti falso
                if (!inputOk) Console.WriteLine("L'input inserito non è intero! Riprova");

                //se l'input è di tipo intero, controllo che sia nel range ammesso di valori
                else if(!(numAlunni >= MINNUMALUNNI && numAlunni <= MAXNUMALUNNI)) //if not(valore dentro dal range) -> messaggio di errore all'utente 
                {
                    inputOk = false; //input non valido: l'utente lo dovrà riinserire
                    Console.WriteLine("Numero alunni fuori dal range possibile, il minmo di alunni è 10 mentre il massimo è 35, riprova");
                }


            } while (!inputOk); //ricicla se input non valido

            Console.WriteLine("Il numero degli alunni è: " + numAlunni);

            #endregion



            #region lettura e scrittura altezza di una persona

            do
            {
                Console.Write("\nInput altezza persona in metri-> ");
                stInput = Console.ReadLine(); //lettura stringa

                //conversione stringa in intero
                inputOk = double.TryParse(stInput, out height); //converte la stringa in double e se la conversione ha successo restituisce sia varInt che true, altrimenti falso
                if (!inputOk) Console.WriteLine("L'input inserito non è un'altezza, Riprova");

                //se l'input è di tipo double, controllo che sia nel range ammesso di valori
                else if (height < MINHEIGHT || height > MAXHEIGHT) //if (valore fuori dal range) -> messaggio di errore all'utente 
                {
                    inputOk = false; //input non valido: l'utente lo dovrà riinserire
                    Console.WriteLine("L'altezza inserita non è fisicamente possibile, quella minima è 0,24 m mentre quella massima è di 2,51 m, Riprova");
                }


            } while (!inputOk); //ricicla se input non valido

            Console.WriteLine("L'altezza inserita è: " + height + " m");

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
