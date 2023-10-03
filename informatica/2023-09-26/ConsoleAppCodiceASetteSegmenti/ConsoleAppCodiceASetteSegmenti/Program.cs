/* Marco Balducci 3H 2023/09/20
 * Esercizio a pag 149 del libro: Display a 7 segmenti che mostra il numero 8 e dopo 5 secondi il 9*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppCodiceASetteSegmenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region titolo
            Console.Title = "Programma Digit Autore Marco Balducci 3H"; //imposto l'autore nel titolo della console
            Console.SetCursorPosition(0,0); //il cursore si posiziona a riga 0 colonna 0
            Console.WriteLine("3H Balducci Marco"); //Autore del programma
            #endregion

            #region Visualizza numero otto

            Console.CursorVisible = false; //disattivo la visualizzazione del cursore
            Console.WriteLine(""); //il cursore va a capo e passa alla riga successiva
            Console.WriteLine("Digit display a 7 segmenti");

            //numero otto

            Console.WriteLine("");
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");

            #endregion

            //pausa prima dell'aggiornamento in nove
            Console.WriteLine("\nAspetta 5s e dopo il beep a 4000hz");
            Thread.Sleep(5000);      //pausa di 5000 ms

            Console.Beep(4000, 500); //parametri del beep: frequenza (hz), durata (ms)

            #region Aggiorna in numero nove

            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("  ");

            #endregion

            //fine programma
            
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("                                             ");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("premi un tasto per continuare");
            Console.ReadKey();

        }
    }
}
