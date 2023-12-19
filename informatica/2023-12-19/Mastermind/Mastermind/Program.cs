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
        static Random rnd = new Random();
        static int[] urna = new int[10];
        static int urnaPointer = 9, numeri_indovinati, numeri_semi_indovinati; //contatori per output
        static int[] numeri_da_indovinare = new int[4];

        #region funzioni iniziali di setUp
        static void setUpUrna()
        {
            for (int i = 0; i < urna.Length; i++)
                urna[i] = i; //urna[0] = 0 ...
        }

        static void setUpIndovinare() //utilizza l'urna per estrarre 
        {

            for(int i = 0; i<numeri_da_indovinare.Length; i++)
            {
                int estratto = rnd.Next(0, urnaPointer + 1);
                numeri_da_indovinare[i] = urna[estratto];
                urna[estratto] = urna[urnaPointer--];
            }
        }

        #endregion

        #region input
        static int[] getints()
        {
            int[] numeri_inseriti = new int[4];
            while (true)
            {
                Console.Write("Inserisci i numeri in questo formato: XXXX --> ");
                string risposta = Console.ReadLine();

                if (risposta.Length < 0 || risposta.Length > 4)
                    Console.WriteLine("Formato non corretto, riprova.");
                else
                {
                    bool errore = false;
                    for(int i = 0; i < risposta.Length && errore == false; i++)
                    {
                        if (int.TryParse(risposta[i].ToString(), out int numero))
                            if (numero < 0 || numero > 9) { Console.WriteLine($" {i + 1}° Numero non valido, riprova."); errore = true; continue; }
                            else numeri_inseriti[i] = numero;
                        else { Console.WriteLine($" {i+1}° carattere non intero, riprova."); errore = true; continue; }
                    }

                    if (!errore) return numeri_inseriti;
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
            for( int i = 0; i < numeri_inseriti.Length; i++)
            {
                byte result = validation(numeri_inseriti[i], i); //i è la posizione
                results[i] = result;
            }
            return results;

        }

        #endregion

        #region stampa e interazione
        static void stampaRisultati(byte[] risultati, int[] numeri_inseriti) //stampa risultati
        {
            for (int i = 0; i < risultati.Length; i++) //conteggio numeri indovinati e semi-indovinati
                if (risultati[i] == 0) numeri_indovinati++;
                else if (risultati[i] == 1) numeri_semi_indovinati++;

            //messaggio finale
            Console.WriteLine($"\nDei numeri inseriti {numeri_indovinati} sono corretti, mentre {numeri_semi_indovinati} sono nella posizione sbagliata, {4-numeri_indovinati-numeri_semi_indovinati} sono completamente sbagliati.");
        }

        static int sceltaDifficoltà() //scelta difficoltà per l'utente, ritorna il numero per cui dividere la difficoltà iniziale
        {
            while(true)
            {
                //menù a video
                Console.WriteLine("Seleziona la difficoltà:\n [1]\tFacile\n [2]\tMedia\n [3]\tDifficile\n [4]\tMeme\n");
                char scelta = Console.ReadKey(true).KeyChar; //carattere inserito nascosto

                switch (scelta)
                {
                    case '1':
                        return 1;
                    case '2':
                        return 2;
                    case '3':
                        return 4;
                    case '4':
                        return 8;
                    default:
                        Console.WriteLine("\tScelta non valida");
                        continue;
                }
            }
            
        }

        #endregion

        static void Main(string[] args)
        {
            Console.Title = "Marco balducci 3H";
            Console.WriteLine("Marco Balducci 3H");

            //setup urna e numeri da indovinare
            setUpUrna();
            setUpIndovinare();

            //titolo del gioco
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" __       __                        __                          __       __  __                  __ \r\n|  \\     /  \\                      |  \\                        |  \\     /  \\|  \\                |  \\\r\n| $$\\   /  $$  ______    _______  _| $$_     ______    ______  | $$\\   /  $$ \\$$ _______    ____| $$\r\n| $$$\\ /  $$$ |      \\  /       \\|   $$ \\   /      \\  /      \\ | $$$\\ /  $$$|  \\|       \\  /      $$\r\n| $$$$\\  $$$$  \\$$$$$$\\|  $$$$$$$ \\$$$$$$  |  $$$$$$\\|  $$$$$$\\| $$$$\\  $$$$| $$| $$$$$$$\\|  $$$$$$$\r\n| $$\\$$ $$ $$ /      $$ \\$$    \\   | $$ __ | $$    $$| $$   \\$$| $$\\$$ $$ $$| $$| $$  | $$| $$  | $$\r\n| $$ \\$$$| $$|  $$$$$$$ _\\$$$$$$\\  | $$|  \\| $$$$$$$$| $$      | $$ \\$$$| $$| $$| $$  | $$| $$__| $$\r\n| $$  \\$ | $$ \\$$    $$|       $$   \\$$  $$ \\$$     \\| $$      | $$  \\$ | $$| $$| $$  | $$ \\$$    $$\r\n \\$$      \\$$  \\$$$$$$$ \\$$$$$$$     \\$$$$   \\$$$$$$$ \\$$       \\$$      \\$$ \\$$ \\$$   \\$$  \\$$$$$$$\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    ");
            Console.ForegroundColor = ConsoleColor.White;

            int difficoltà = 16 / sceltaDifficoltà(); //difficoltà 

            for (int tentativi = 0; tentativi < difficoltà && numeri_indovinati != 4; tentativi++) //ciclo di gioco
            {
                Console.WriteLine($"\nTentativo numero {tentativi+1} su {difficoltà}");
                numeri_indovinati = 0; //inizializzo i numeri indovinati ad ogni turno
                numeri_semi_indovinati = 0; //inizializzo i numeri semi-indovinati ad ogni turno

                int[] numeri_inseriti = getints(); //ottengo l'array

                byte[] risultati = checkNumbers(numeri_inseriti); //ottengo l'array con i risultati (0 = indovinato, 1 = semi-indovinato, 2 = sbagliato)
                stampaRisultati(risultati, numeri_inseriti); //stampa a video
            }

            if (numeri_indovinati == 4) Console.WriteLine("\n\tComplimenti! Hai vinto"); //se esce perchè ho indovinato
            else Console.WriteLine("\n\tSpiacente, hai perso");                          //altrimenti ha finito i tentativi

            //stampa numeri corretti
            Console.Write("\nNumeri corretti:\n\t");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < numeri_da_indovinare.Length; i++)
                Console.Write(numeri_da_indovinare[i] + " ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            //termine programma
            Console.WriteLine("\nPremi un tasto per terminare il programma.");
            Console.ReadKey();
        }
    }
}
