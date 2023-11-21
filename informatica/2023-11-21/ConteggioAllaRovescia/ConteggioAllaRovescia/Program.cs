//Marco Balducci 3H 2023-11-21
//Programma a console che legge un numero e lo stampa rappresentadolo tramite caratteri di un display a 7 segmenti
namespace ConteggioAllaRovescia
{
    internal class Program
    {
        static string[] cifra_0 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_1 = {
            "       ▓",
            "       ▓",
            "       ▓",
            "        ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_2 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
            "▓       ",
            "▓       ",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_3 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_4 = {
            "▓      ▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_5 = {
            " ▓▓▓▓▓▓ ",
            "▓       ",
            "▓       ",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_6 = {
            " ▓▓▓▓▓▓ ",
            "▓       ",
            "▓       ",
            " ▓▓▓▓▓▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_7 = {
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            "        ",
            "       ▓",
            "       ▓",
            "       ▓",
        };

        static string[] cifra_8 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
        };

        static string[] cifra_9 = {
            " ▓▓▓▓▓▓ ",
            "▓      ▓",
            "▓      ▓",
            " ▓▓▓▓▓▓ ",
            "       ▓",
            "       ▓",
            " ▓▓▓▓▓▓ ",
        };

        static int getInt(string messaggio) //lettura intero
        {
            while (true)
            {
                Console.Write(messaggio);
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.WriteLine("Input non valido."); //gestione input non valido
            }
        }

        static void StampaCifra(string[] cifra, int riga, int col) //stampa la cifra data
        {
            
            for(int i = 0; i < cifra.Length; i++)
            {
                Console.SetCursorPosition(col, riga+i);
                Console.WriteLine(cifra[i]);
            }
        }

        static void StampaNumero(int numero, int riga) //stampa il numero
        {
            int col = 0;
            string cifre = numero.ToString();
            for(int i=0; i< cifre.Length; i++) //ciclo tra tutte le cifre del numero
            {
                switch (cifre[i])
                {
                    case '0':
                        StampaCifra(cifra_0, riga, col);
                        break;
                    case '1':
                        StampaCifra(cifra_1, riga, col);
                        break;
                    case '2':
                        StampaCifra(cifra_2, riga, col);
                        break;
                    case '3':
                        StampaCifra(cifra_3, riga, col);
                        break;
                    case '4':
                        StampaCifra(cifra_4, riga, col);
                        break;
                    case '5':
                        StampaCifra(cifra_5, riga, col);
                        break;
                    case '6':
                        StampaCifra(cifra_6, riga, col);
                        break;
                    case '7':
                        StampaCifra(cifra_7, riga, col);
                        break;
                    case '8':
                        StampaCifra(cifra_8, riga, col);
                        break;
                    case '9':
                        StampaCifra(cifra_9, riga, col);
                        break;
                }
                col += 9; //spostamento a destra
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Marco Balducci 3H";
            Console.WriteLine("marco balducci 3H");
            /*
            StampaCifra(cifra_0, 0, 0);
            StampaCifra(cifra_1, 0, 8);
            StampaCifra(cifra_2, 0, 17);
            StampaCifra(cifra_3, 0, 26);
            StampaCifra(cifra_4, 0, 35);
            StampaCifra(cifra_5, 0, 44);
            StampaCifra(cifra_6, 0, 53);
            StampaCifra(cifra_7, 0, 61);
            StampaCifra(cifra_8, 0, 70);
            StampaCifra(cifra_9, 0, 79);
            */

            int number = getInt("inserisci il numero da rappresentare: ");

            (int, int) position = Console.GetCursorPosition(); //ottengo la posizione di partenza
            StampaNumero(number, position.Item2+1);

            //termine programma
            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();

        }
    }
}