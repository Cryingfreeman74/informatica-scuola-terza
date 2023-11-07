using System.Diagnostics;

namespace EsercizioScrittura
{
    internal class Program
    {


        const string FrasiPath = @"..\..\..\frasi.txt"; //path dele frasi
        static char leggiTasto()
        {
            //torna il tasto premuto dall'utente, oppure '\0\ se non ci sono tasti premuti
            if (!Console.KeyAvailable) //se non ci sono tasti premuti, torna immediatamente
                return '\0';
            ConsoleKeyInfo key = Console.ReadKey(true); //con intercept == true non c'è "echo" a video
            return key.KeyChar;
        }

        static string readString(string messaggio)
        {
            Console.Write(messaggio);
            string frase;

            while (true)
            {
                frase = Console.ReadLine();
                if (frase.Length > 0) return frase;
                else Console.WriteLine("frase nulla, riprova");
            }
            
        }

        static double TypeCheck(string frase, out int errori)
        {
            //dichiarazione e partenza cronometro
            System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch();
            cronometro.Restart();

            Console.CursorVisible = false; //cursore non visible

            //dichiarazione colori
            ConsoleColor basic = Console.ForegroundColor;
            ConsoleColor right = ConsoleColor.Green;
            ConsoleColor wrong = ConsoleColor.Red;
            ConsoleColor results = ConsoleColor.DarkCyan;

            //stampa frase
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n" + frase);

            //posizioni relative
            (int, int) position = Console.GetCursorPosition();
            int phrasePosition = position.Item2-1;
            int arrowPosition = position.Item2;

            //stampa apice
            Console.ForegroundColor = basic;
            Console.WriteLine("^");

            
            //dichiarazione posizione primo char ed errori
            int currentChar = 0, errors = 0;



            while (currentChar < frase.Length) //ciclo di inserimento e controllo char
            {

                char insertedChar = leggiTasto(); //ottengo il carattere inserito
                if (insertedChar != '\0') //se non è nullo
                {
                    if (insertedChar == frase[currentChar]) //corretto
                    {
                        Console.SetCursorPosition(currentChar, phrasePosition);
                        Console.ForegroundColor = right;
                        Console.Write(frase[currentChar]);
                        Console.ForegroundColor = basic;
                    } else                                  //sbagliato
                    {
                        Console.SetCursorPosition(currentChar, phrasePosition);
                        Console.ForegroundColor = wrong;
                        Console.Write(frase[currentChar]);
                        Console.ForegroundColor = basic;
                        errors++;
                    }

                    //update posizione carattere
                    currentChar++;

                    //update posizione apice indicativo
                    Console.SetCursorPosition(currentChar-1, arrowPosition);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentChar, arrowPosition);
                    Console.Write("^");
                }
            }

            cronometro.Stop(); //fine cronomtero

            Console.SetCursorPosition(currentChar, arrowPosition);
            Console.Write(" "); //cancellazione apice

            Console.SetCursorPosition(0, arrowPosition + 1);//spostamento cursore alla riga sotto quella dell'apice

            //calcolo velocità
            double timeElapsed = cronometro.ElapsedMilliseconds / 1000.0;
            double lettersPerSecond = frase.Length / timeElapsed + 0.0000001;
            double errorRate = errors / (double)frase.Length;

            //risultati
            errori = errors;
            Console.ForegroundColor = results;
            Console.WriteLine($"Complimenti, hai impiegato {timeElapsed} secondi.\nHai commesso {errors} errori su {frase.Length} caratteri totali.\nTasso di Errore: {errorRate*100:0.00}%\nLa tua velocità media è stata di {lettersPerSecond:0.000} lettere al secondo, o {lettersPerSecond * 60:0.000} al minuto.");
            Console.ForegroundColor = basic;

            Console.CursorVisible = true; //cursore torna visible

            return timeElapsed;
        }
        static void Main(string[] args)
        {
            Console.Title = "Marco Balducci 3H"; //autore come titolo
            Console.WriteLine("Marco Balducci 3H\n"); //autore a video

            Console.WriteLine("Lettura frase da console [1] oppure lettura frase da file [2]?");

            int errori = 0;

            char response = Console.ReadKey().KeyChar;
            if(response == '1')
            {
                //funzione TypeCheck
                string frase = readString("Inserisci la stringa da riprodurre: ");
                TypeCheck(frase, out errori);
            } else if(response == '2')
            {
                //lettura da file
                using (StreamReader sr = new StreamReader(FrasiPath))
                {
                    //variabili di conteggio totale
                    int erroriTotali = 0, totalChars = 0;
                    double totalTimeElapsed = 0;

                    while (!sr.EndOfStream)
                    {
                        string riga = sr.ReadLine();

                        totalChars += riga.Length;

                        totalTimeElapsed += TypeCheck(riga, out errori);
                        erroriTotali += errori;
                    }

                    Console.WriteLine($"Risultati Finali:\nHai impiegato {totalTimeElapsed} secondi.\nHai commesso {erroriTotali} errori su {totalChars} caratteri totali.\nTasso di Errore: {erroriTotali/(double)totalChars * 100:0.00}%\nLa tua velocità media è stata di {totalChars/totalTimeElapsed:0.000} lettere al secondo, o {totalChars / totalTimeElapsed * 60:0.000} al minuto.");

                }
            }

        }
    }
}