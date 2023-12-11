/*Marco Balducci 3H 28-11-2023
 * ConsoleApp che permette di giocare a tombola, con la possibilità di controllare cinquina, decina, tombola e di vedere il tabellone aggiornato ad ogni turno
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Tombola
{
    internal class Program
    {
        #region variabili globali

        static Random rnd = new Random();
        static int[] mappa = new int[90];
        static int[] urna = new int[90];
        static int numPalline = 90;
        static bool stampaScheda = false;
        static string schedina = "";

        #endregion

        #region estrazione numero
        static int estraiNumero() //ritorna il numero estratto oppure -1 se sono già stati estratti tutti i numeri
        {
            if (numPalline > 0) //controllo se non sono già stati estratti tutti i numeri
            {
                int estratto = rnd.Next(0, numPalline); //estraggo un indice
                int output = urna[estratto]; //ottengo il valore relativo a quell'indice
                urna[estratto] = urna[numPalline-1]; //swap ultimo valore nella posizione del valore estratto
                numPalline--; //diminuisco il numero delle palline per limitare il range delle palline estraibili
                return output;
            }
            else return -1;
        }

        #endregion

        #region funzioni setUp
        static void setUpUrna() //riempie l'urna con i numeri da 1 a 90
        {
            for(int i = 0; i<urna.Length; i++)
                urna[i] = i + 1;
        }

        static void setUpMappa() //riempe la mappa di 0
        {
            for (int i = 0; i < mappa.Length; i++)
                mappa[i] = 0;
        }

        #endregion

        #region stampa mappa
        static void stampaMappa()
        {
            Console.WriteLine("\nMarco Balducci 3H\n\n"); //autore
            Console.WriteLine("\n\t~~ TOMBOLA ~~\n"); //Titolo

            for(int i=0; i<mappa.Length; i++)
            {
                if (mappa[i] == 0) Console.Write(" # "); //stampo # se il numero non è ancora uscito
                else 
                {
                    if (mappa[i] < 10) Console.Write(" " + mappa[i] + " "); //stampo numero + 2 spazi se il numero è di una cifra
                    else Console.Write(" " + mappa[i]); //stampo numero + 1 spazio se il numero è di 2 cifre
                }

                if ((i+1) % 10 == 0) Console.WriteLine(); //ogni 10 numeri va a capo
            }

            Console.WriteLine();
        }

        #endregion

        #region verifica vincita
        static bool verificaCinquina()
        {
            bool verifica = true;

            for(int i=0; i<5; i++) //controllo se i 5 numeri inseriti sono usciti
            {
                int numero = getInt("Inserisci il numero: ");

                if (mappa[numero - 1] != numero) { Console.WriteLine("\nNumero inserito non presente, spiacente, non hai fatto Cinquina!\n"); verifica = false; break; } //caso in cui il numero inserito non è presente
            }

            return verifica;
        }

        static bool verificaDecina()
        {
            bool verifica = true;

            for (int i = 0; i < 10; i++) //controllo se i 10 numeri inseriti sono usciti
            {
                int numero = getInt("Inserisci il numero: ");

                if (mappa[numero - 1] != numero) { Console.WriteLine("\nNumero inserito non presente, spiacente, non hai fatto Decina!\n");  verifica = false; break; } //caso in cui il numero inserito non è presente
            }

            return verifica;
        }

        static bool verificaTombola()
        {
            bool verifica = true;

            for (int i = 0; i < 15; i++) //controllo se i 15 numeri inseriti sono usciti
            {
                int numero = getInt("Inserisci il numero: ");

                if (mappa[numero-1] != numero) { Console.WriteLine("\nNumero inserito non presente, spiacente, non hai fatto Tombola!\n"); verifica = false; break; } //caso in cui il numero inserito non è presente
            }

            return verifica;
        }

        #endregion

        #region generazione schedina
        static void generaSchedina()
        {
            int[] scheda = new int[27]; //array che rappresenta la scheda

            for (int i = 0; i < scheda.Length; i++)
                scheda[i] = 1; //inizializzo tutti i valori ad uno per poter distinguere gli spazi in seguito

            for(int i = 0; i<3; i++) //ciclo una volta per riga
            {
                int[] spazi = new int[4];

                for(int count = 0; count <4; count ++) //ottengo le posizioni degli spazi
                {
                    int estratto = rnd.Next(0, 9);
                    spazi[count] = estratto;
                    for (int j = 0; j < count; j++) //controllo che non sia già uscito il numero estratto
                        if (estratto == spazi[j])
                        {
                            count--;
                            break;
                        }

                }

                for(int j = 0; j<spazi.Length; j++)
                    scheda[i*9 + spazi[j]] = 0; //riempio scheda con gli spazi una riga a ciclo

                for (int j = 0; j <9; j++) //riempio la scheda con i numeri
                {
                    if (scheda[i*9 + j] == 0) //se alla posizione data c'è uno 0 allora corrisponde ad uno spazio, e non viene assegnato nessun numero
                        continue;
                    else
                    {
                        int estratto;
                        if (j == 0) estratto = rnd.Next(1, 10);
                        else estratto = rnd.Next(j * 10, (j + 1) * 10);
                        scheda[i*9 + j] = estratto;
                        for(int k  = 0; k < i*9 + j; k++) //controllo che non sia già uscito il numero estratto
                        {
                            if (scheda[k] == estratto)
                            {
                                j--;
                                break;
                            }
                        }
                    }
                }
            }

            //crezione stringa schedina

            schedina = "---------------------------"; //inizializzo la stringa
            stampaScheda = true; //valore che verrà usato nel main per stampare la scheda

            for(int i = 0; i< scheda.Length; i++) //formattazione stringa ed inserimento numeri
            {
                if (i % 9 == 0) schedina += "\n";
                if (scheda[i] == 0) schedina += "## ";
                else if (scheda[i] < 10)
                    schedina += " " + scheda[i].ToString() + " ";
                else schedina += scheda[i].ToString() + " ";
            }
            schedina += "\n---------------------------";

        }

        #endregion

        #region aggiornamento valori mappa
        static void aggiornaMappa(int numero) //sostituisce il valore alla posizione numero-1 con il valore numero
        {
            mappa[numero-1] = numero;
        }

        #endregion

        #region funzione di scelta per l'utente
        static bool Scelta() //ritorna falso se il gioco continua oppure true se deve finire
        {
            Console.WriteLine("~ Estrai numero \t[1]\n~ Verifica Cinquina\t[2]\n~ Verifica Decina\t[3]\n~ Verifica Tombola\t[4]\n~ Genera Schedina\t[5]\n~ Esci dal gioco\t[6]");
            char choice = Console.ReadKey(true).KeyChar;

            Console.Clear();

            switch(choice)
            {
                case '1': //estrazione numero e controllo disponibilità palline
                    int estratto = estraiNumero();
                    if (estratto != -1) aggiornaMappa(estratto); //il numero estratto viene aggiunto
                    else //i numeri estraibili sono terminati, gioco terminato.
                    {
                        Console.WriteLine("\n\t~~Palline terminate!~~\n");
                        return true;
                    }
                    break;
                case '2': //controllo Cinquina
                    if (verificaCinquina()) Console.WriteLine("\n\tComplimenti! Hai fatto Cinquina!");
                    Console.WriteLine("\nPremi un tasto per continuare.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '3': //controllo Decina
                    if (verificaDecina()) Console.WriteLine("\n\tComplimenti! Hai fatto Decina!");
                    Console.WriteLine("\nPremi un tasto per continuare.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '4': //controllo Tombola
                    if (verificaTombola()) { Console.WriteLine("\n\tComplimenti! Hai fatto tombola!"); return true; }
                    Console.WriteLine("\nPremi un tasto per continuare.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case '5': //generazione schedina
                    generaSchedina();
                    break;
                case '6': //uscita dal gioco
                    return true;
                default: //scelta non valida
                    Console.WriteLine("Scelta non valida");
                    break;
            }

            return false; //ritorna falso ogni volta che non viene ritornato true prima
        }

        #endregion

        #region funzione per ottenere un intero compreso tra 1 e 90
        static int getInt(string messaggio)
        {
            while(true)
            {
                Console.Write(messaggio); //messaggio in input così posso utilizzare la stessa funzione + volte ;)
                if (int.TryParse(Console.ReadLine(), out int numero)) //controllo se il numero è intero
                {
                    if (numero < 1 || numero > 90) Console.WriteLine("Numero non valido, riprova"); //controllo valore nel range accettabile
                    else return numero;
                }
                else Console.WriteLine("Valore inserito non intero, riprova");   
            }
        }

        #endregion

        #region main e ciclo di gioco
        static void Main(string[] args)
        {

            setUpMappa(); //riempio la mappa di 0

            setUpUrna(); //riempio l'urna con i numeri da 1 a 90

            while (true) //ciclo di gioco
            {
                stampaMappa();

                if (stampaScheda)
                {
                    stampaScheda = false;
                    Console.WriteLine("\n" + schedina + "\n");
                }

                if (Scelta()) break; //scelta torna true se il gioco termina
            }

            //termine Programma
            Console.WriteLine("\nPremi un tasto per terminare il programma.");
            Console.ReadKey();
        }

        #endregion
    }
}
