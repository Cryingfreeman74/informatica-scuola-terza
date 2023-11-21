//Marco Balducci 3H 2023-11-21
//App a console che simula un pianoforte, ad un tasto premuto viene suonata la rispettiva nota
namespace pianoforte
{
    internal class Program
    {
        // Indice -->               0    1    2    3    4    5    6    7    8    9    10   11
        // Nota -->                 DO   RE   MI   FA   SOL  LA   SI  DO#  RE#  FA#  SOL#  LA#
        static char[] keyboard = { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'w', 'e', 't', 'y', 'u' };
        static int[] sound_freq = { 262, 294, 330, 349, 392, 440, 494, 277, 311, 370, 415, 466 };

        static char leggiTasto() //input non bloccante
        {
            //torna il tasto premuto dall'utente, oppure '\0\' se non ci sono tasti premuti
            if (!Console.KeyAvailable) //se non ci sono tasti premuti, torna immediatamente
                return '\0';
            ConsoleKeyInfo key = Console.ReadKey(true); //con intercept == true non c'è "echo" a video
            return key.KeyChar;
        }

        static int FrequenzaNota(char nota) //ritorna la frequenza della nota se la trova, altrimenti 0
        {
            for (int i = 0; i < keyboard.Length; i++)
            {
                if (nota == keyboard[i]) return sound_freq[i];
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Console.Title = "Marco Balducci 3H"; //autore
            Console.WriteLine("Marco Balducci 3H\n");

            Thread task = new Thread(() => { });

            Console.WriteLine("Pianoforte! a w s e d f t g y h u j\nPremere q per terminare");
            while (true) //ciclo del programma
            {
                char tasto = leggiTasto(); //lettura input

                if (tasto != '\0') //se viene premuto qualcosa
                {
                    if (tasto == 'q') break;
                    int frequenza = FrequenzaNota(tasto);

                    if (frequenza != 0) Console.Beep(FrequenzaNota(tasto), 400); //se la frequenza è valida la suono
                }

            }
        }
    }
}