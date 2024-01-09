/* 
 * Marco Balducci 3H 19-12-2023
 * gioco mastermind che consiste nell'indovinare 4 numeri da 0 a 9 scelti casualmente
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    internal class Program
    {

        #region variabili globali

        static Random rnd = new Random(); //oggetto random
        static int[] urna = new int[10];  //urna per estrazione numeri casuali
        static int urnaPointer = 9, numeri_indovinati;
        static int[] numeri_da_indovinare = new int[4]; //numeri estratti da indovinare

        #endregion

        #region funzioni iniziali di setUp
        static void setUpUrna()
        {
            for (int i = 0; i < urna.Length; i++)
                urna[i] = i; //urna[0] = 0 ...
        }

        static void setUpIndovinare()
        {
            for (int i = 0; i < numeri_da_indovinare.Length; i++)
            {
                int estratto = rnd.Next(urnaPointer);
                urna[estratto] = urna[urnaPointer--];
                numeri_da_indovinare[i] = estratto;
            }
        }

        #endregion

        #region input
        static int[] getints() //legge una stringa di 4 cifre e ritorna un array di 4 interi
        {
            int[] numeri_inseriti = new int[4];
            while (true)
            {
                Console.Write("Inserisci i numeri in questo formato: XXXX --> ");
                string risposta = Console.ReadLine();

                //controllo risposta
                if (risposta.Length < 0 || risposta.Length > 4)
                    Console.WriteLine("Formato non corretto, riprova.");
                else
                {
                    //inserimento numeri nell'array e controllo errori
                    bool error = false;
                    for (int i = 0; i < risposta.Length; i++)
                    {
                        if (int.TryParse(risposta[i].ToString(), out int numero))
                            if (numero < 0 || numero > 9) { Console.WriteLine($" {i + 1}° Numero non valido."); error = true; continue; }
                            else numeri_inseriti[i] = numero;
                        else { Console.WriteLine($" {i + 1}° carattere non intero."); error = true; continue; }
                    }
                    //controllo se c'è stato un errore durante l'inserimento
                    if(error) { Console.WriteLine("riprova"); continue; }

                    return numeri_inseriti;
                }

            }
        }

        #endregion

        #region validazione numeri inseriti
        static byte validation(int number, int position) //ritorna 0 se numero corretto e posizione corretta, 1 se lettera corretta ma posizione diversa, 2 se non presente
        {

            if (numeri_da_indovinare[position] == number) return 0; //controllo subito se è tutto corretto: posizione e numero.

            for (int i = 0; i < numeri_da_indovinare.Length; i++)
                if (numeri_da_indovinare[i] == number) //se lo trova ad una posizione sbagliata
                    return 1;

            return 2; //non trovato
        }

        static byte[] checkNumbers(int[] numeri_inseriti) //ritorna un array di byte con 0 che corrisponde a pos corretta e num corretto, 1 che corrisponde a num corretto e pos errata, 2 che corrisponde a errato completamente.
        {
            byte[] results = new byte[4];
            for (int i = 0; i < numeri_inseriti.Length; i++)
            {
                byte result = validation(numeri_inseriti[i], i); //i è la posizione
                results[i] = result;
            }
            return results;

        }

        #endregion

        #region stampa e interazione
        static void stampaRisultati(byte[] risultati, int[] numeri_inseriti) //stampa i risultati con i colori adeguati
        {
            for (int i = 0; i < risultati.Length; i++)
                if (risultati[i] == 0) { Console.ForegroundColor = ConsoleColor.Green; Console.Write(numeri_inseriti[i]); numeri_indovinati++; }
                else if (risultati[i] == 1) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(numeri_inseriti[i]); }
                else { Console.ForegroundColor = ConsoleColor.Red; Console.Write(numeri_inseriti[i]); }

            Console.ForegroundColor = ConsoleColor.White;
        }

        static int sceltaDifficoltà()
        {
            //menù
            Console.WriteLine("Seleziona la difficoltà:\n [1]\tFacile\n [2]\tMedia\n [3]\tDifficile\n [4]\tImpossibile\n");

            while (true)
            {
                char scelta = Console.ReadKey(true).KeyChar;

                switch (scelta)
                {
                    case '1': //facile
                        return 1;
                    case '2': //media
                        return 2;
                    case '3': //difficile
                        return 3;
                    case '4': //impossibile
                        return 4;
                    default:
                        Console.WriteLine("\tScelta non valida, riprova.");
                        continue;
                }
            }

        }

        #endregion
        static void Main(string[] args)
        {
            //autore a video
            Console.Title = "Marco balducci 3H";
            Console.WriteLine("Marco Balducci 3H");

            setUpUrna();
            setUpIndovinare();

            //titolo
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" __       __                        __                          __       __  __                  __ \r\n|  \\     /  \\                      |  \\                        |  \\     /  \\|  \\                |  \\\r\n| $$\\   /  $$  ______    _______  _| $$_     ______    ______  | $$\\   /  $$ \\$$ _______    ____| $$\r\n| $$$\\ /  $$$ |      \\  /       \\|   $$ \\   /      \\  /      \\ | $$$\\ /  $$$|  \\|       \\  /      $$\r\n| $$$$\\  $$$$  \\$$$$$$\\|  $$$$$$$ \\$$$$$$  |  $$$$$$\\|  $$$$$$\\| $$$$\\  $$$$| $$| $$$$$$$\\|  $$$$$$$\r\n| $$\\$$ $$ $$ /      $$ \\$$    \\   | $$ __ | $$    $$| $$   \\$$| $$\\$$ $$ $$| $$| $$  | $$| $$  | $$\r\n| $$ \\$$$| $$|  $$$$$$$ _\\$$$$$$\\  | $$|  \\| $$$$$$$$| $$      | $$ \\$$$| $$| $$| $$  | $$| $$__| $$\r\n| $$  \\$ | $$ \\$$    $$|       $$   \\$$  $$ \\$$     \\| $$      | $$  \\$ | $$| $$| $$  | $$ \\$$    $$\r\n \\$$      \\$$  \\$$$$$$$ \\$$$$$$$     \\$$$$   \\$$$$$$$ \\$$       \\$$      \\$$ \\$$ \\$$   \\$$  \\$$$$$$$\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ");
            Console.ForegroundColor = ConsoleColor.White;

            int[] numeri_inseriti = new int[4];
            int difficoltà = 16 / sceltaDifficoltà(); //difficoltà 

            //ciclo di gioco
            for (int tentativi = 0; tentativi < difficoltà && numeri_indovinati != 4; tentativi++)
            {
                Console.WriteLine($"\nTentativo numero {tentativi+1} su {difficoltà}");
                numeri_indovinati = 0; //inizializzo i numeri indovinati ad ogni turno

                numeri_inseriti = getints();

                byte[] risultati = checkNumbers(numeri_inseriti);
                stampaRisultati(risultati, numeri_inseriti);
            }

            //controllo vincita
            if (numeri_indovinati == 4) Console.WriteLine("\n\tComplimenti! Hai vinto");
            else Console.WriteLine("\n\tSpiacente, hai perso");

            //termine programma
            Console.WriteLine("\nPremi un tasto per terminare il programma.");
            Console.ReadKey();
        }
    }
}
