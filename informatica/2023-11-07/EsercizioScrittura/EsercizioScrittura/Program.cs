namespace EsercizioScrittura
{
    internal class Program
    {
        static char leggiTasto()
        {
            //torna il tasto premuto dall'utente, oppure '\0\ se non ci sono tasti premuti
            if (!Console.KeyAvailable) //se non ci sono tasti premuti, torna immediatamente
                return '\0';
            ConsoleKeyInfo key = Console.ReadKey(true); //con intercept == true non c'è "echo" a video
            return key.KeyChar;
        }

        static void TypeCheck(string frase)
        {
            System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch();
            cronometro.Restart();

            Console.CursorVisible = false;

            ConsoleColor basic = Console.ForegroundColor;
            ConsoleColor right = ConsoleColor.Green;
            ConsoleColor wrong = ConsoleColor.Red;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n" + frase);
            Console.ForegroundColor = basic;
            Console.WriteLine("^");

            (int, int) position = Console.GetCursorPosition();
            int phrasePosition = position.Item2;
            int arrowPosition = position.Item2 + 1; 

            int currentChar = 0, errors = 0;



            while (true) 
            {

                char insertedChar = leggiTasto();
                if (insertedChar != '\0')
                {
                    if (insertedChar == frase[currentChar])
                    {
                        Console.SetCursorPosition(currentChar, 2);
                        Console.ForegroundColor = right;
                        Console.Write(frase[currentChar]);
                        Console.ForegroundColor = basic;
                    } else
                    {
                        Console.SetCursorPosition(currentChar, 2);
                        Console.ForegroundColor = wrong;
                        Console.Write(frase[currentChar]);
                        Console.ForegroundColor = basic;
                        errors++;
                    }

                    currentChar++;

                    Console.SetCursorPosition(currentChar-1, 3);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentChar, 3);
                    Console.Write("^");
                }
                if (currentChar == frase.Length)
                {
                    cronometro.Stop();
                    Console.SetCursorPosition(currentChar, 3);
                    Console.Write(" ");
                    Console.SetCursorPosition(0,4);
                    double timeElapsed = cronometro.ElapsedMilliseconds / 1000.0;
                    Console.WriteLine($"Complimenti, hai impiegato {timeElapsed} secondi ed hai commesso {errors} errori.\nLa tua velocità media è stata di {frase.Length/timeElapsed:0.000} lettere al secondo.");
                    break;
                }
            }

            Console.CursorVisible = true;
        }
        static void Main(string[] args)
        {
            Console.Write("Inserisci la frase da riprodurre: ");
            TypeCheck(Console.ReadLine());
        }
    }
}