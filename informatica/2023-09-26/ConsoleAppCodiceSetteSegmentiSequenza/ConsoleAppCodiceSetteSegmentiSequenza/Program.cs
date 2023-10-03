/* 
 * Marco Balducci 3H 2023/09/26
 * -Sequenza di numeri da 9 a 0 rappresentati mediante 7 segmenti
 * (esercizio assegnato in classe)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleAppCodiceASetteSegmenti
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region titolo

            //Titolo della console
            Console.Title = "Programma Countdown Digit Autore Marco Balducci 3H";

            //disattivo il cursore
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0); //il cursore si posiziona a riga 0 colonna 0

            Console.WriteLine("3H Balducci Marco"); //Autore
            Console.WriteLine(""); //il cursore va a capo e passa alla riga successiva
            Console.WriteLine("Digit display a 7 segmenti");

            #endregion


            #region Visualizza numero nove

            Console.Beep(4000, 500);

            Console.WriteLine("");
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("     ▓▓        ▓▓");
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");
            Console.WriteLine("               ▓▓");
            Console.WriteLine("               ▓▓");
            Console.WriteLine("               ▓▓");
            Console.WriteLine("               ▓▓");
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");

            #endregion

            #region istruzione utente a video

            //il cursore si posiziona nella riga dell'istruzione per l'utente
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("Aspetta 1s e dopo il beep a 4000hz");

            #endregion

            #region Aggiorna in numero otto

            Thread.Sleep(500);      //pausa di 500 ms
            
            //Beep per il nuovo numero
            Console.Beep(4000, 500); //parametri del beep: frequenza (hz), durata (ms)

            

            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("▓▓");



            #endregion

            #region Aggiorna in numero sette

            //Beep per il nuovo numero
            Thread.Sleep(500);      //pausa di 500 ms

            Console.Beep(4000, 500);


            //segmento c

            Console.SetCursorPosition(5, 5);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("  ");

            //segmento d

            Console.SetCursorPosition(0, 9);
            Console.WriteLine("               ");


            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("   ");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("  ");

            //segmento g
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("               ");

            #endregion

            #region Aggiorna in numero sei

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500);


            //segmento b
            Console.SetCursorPosition(15, 5);
            Console.WriteLine("  ");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine("  ");
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("  ");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("  ");

            //segmento c

            Console.SetCursorPosition(5, 5);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("▓▓");

            //segmento d

            Console.SetCursorPosition(0, 9);
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");


            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("▓▓");

            //segmento g
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");


            #endregion

            #region Aggiorna in numero cinque

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500);


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

            #region Aggiorna in numero quattro

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500); //parametri del beep: frequenza (hz), durata (ms)


            //segmento a
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("               ");

            //segmento b
            Console.SetCursorPosition(15, 5);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("▓▓");


            //segmento g
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("               ");

            #endregion

            #region Aggiorna in numero tre

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500);


            //segmento a
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");


            //segmento c

            Console.SetCursorPosition(5, 5);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("  ");


            //segmento g
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");

            #endregion

            #region aggiorna in numero due

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500);


            //segmento e
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("  ");
            Console.SetCursorPosition(15, 11);
            Console.WriteLine("  ");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("  ");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("  ");

            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("▓▓");

            #endregion

            #region Aggiorna in numero uno

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500);

            

            //segmento a
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("               ");

            //segmento d

            Console.SetCursorPosition(0, 9);
            Console.WriteLine("               ");

            //segmento e
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(15, 11);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("▓▓");

            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("  ");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("  ");

            //segmento g
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("               ");

            #endregion

            #region Aggiorna in numero zero

            Thread.Sleep(500);      //pausa di 500 ms

            //Beep per il nuovo numero
            Console.Beep(4000, 500);


            //segmento a
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");

            //segmento c

            Console.SetCursorPosition(5, 5);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 6);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("▓▓");

            //segmento f

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine("▓▓");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine("▓▓");

            //segmento g
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("       ▓▓▓▓▓▓▓▓");

            #endregion

            #region fine sequenza

            Thread.Sleep(200); //pausa prima dei 3 beep finali
            Console.Beep(4000, 200);
            Thread.Sleep(100);
            Console.Beep(4000, 200);
            Thread.Sleep(100);
            Console.Beep(4000, 200);

            #endregion

            #region fine programma

            Console.SetCursorPosition(0, 17);
            Console.WriteLine("                               "); //eliminare il contenuto della linea

            Console.SetCursorPosition(0, 17);
            Console.WriteLine("premi un tasto per terminare il programma");

            Console.ReadKey();

            #endregion

        }
    }
}
