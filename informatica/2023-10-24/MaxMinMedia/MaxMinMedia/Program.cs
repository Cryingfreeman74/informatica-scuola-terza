/*
 * Marco Balducci 3H 2023-10-24
 * Programma a console che ricevuti in input un numero indefinito di valori stampa a video il minimo, il massimo e la media.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMinMedia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Marco Balducci 3H"; //autore nel titolo
            Console.WriteLine("Marco Balducci 3H");// autore a video

            string strInput; //stringa in input
            int max=int.MinValue, min = int.MaxValue, number = 0, insertedValues = 0; //inizializzando min e max con i valori minimo e massimo che può avere un int posso fare dei controlli più rapidi
            double media = 0.0;
            bool inputOk, continuare = true; //controllo input e controllo reinserimento

            do
            {

                #region input valore

                do
                {
                    Console.Write("Inserisci un valore intero, oppure < fine > per terminare l'inserimento dei valori e ricevere i valori in output -> "); //richiesta input
                    strInput=Console.ReadLine();

                    if (strInput.ToUpper() == "FINE") { continuare = false; inputOk = true; } //controllo se l'utente vuole terminare, in tal caso non controllo l'input
                    else
                    {
                        inputOk = int.TryParse(strInput, out number); //in questo caso l'utente vuole continuare perciò controllo input
                        if (!inputOk)
                        {
                            Console.WriteLine("Il valore inserito non è intero, riprova"); //messaggio di errore
                        }
                    }

                } while (!inputOk);

                #endregion

                #region massimo, minimo, media

                if (continuare) //se l'utente non desidera uscire
                {
                    insertedValues++; // aumento il numero dei valori inseriti, utile per la media e per l'output
                    if (max < number) max = number;
                    if (min > number) min = number;
                    media = media + number; //la media è la somma di tutti i valori diviso il numero di valori
                }
                else media /= insertedValues; //quando l'utente vuole uscire calcolo la media, fino a prima era solo una somma

                #endregion

            } while (continuare);

            if (insertedValues == 0) Console.WriteLine($"Hai inserito {insertedValues} valori, di conseguenza non c'è alcun minimo, massimo o media..."); //esito se non viene inserito alcun valore
            else Console.WriteLine($"\n\nHai inserito {insertedValues} valori, ecco i risultati:\nMinimo valore inserito: {min}\nMassimo valore inserito: {max}\nMedia dei valori inseriti: {media}"); //esito con almeno un valore

            //termine programma
            Console.WriteLine("\nPremi un tasto per terminare il programma");
            Console.ReadKey();
        }
    }
}
