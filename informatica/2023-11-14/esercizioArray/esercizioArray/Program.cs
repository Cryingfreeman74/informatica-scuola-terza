/*
 *Marco Balducci 3H 14/11/2023 
 * Programma a console che data la lunghezza di un array in input ne crea uno e calcola la media dei valori inseriti e stampa a video sia la media sia i valori maggiori di essa
*/
namespace esercizioArray
{
    internal class Program
    {
        static double leggiDouble(string messaggio) //funzione che legge i double da inserire nell'array
        {

            Console.Write(messaggio);
            double number;

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out number)) break; //controllo casting
                else Console.WriteLine("Il numero inserito non è un double, riprova");
            }
            return number;
        }
        static int leggiIntero(string messaggio) //funzio che legge la lunghezza dell'array
        {
            Console.Write(messaggio);
            int number;

            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out number)) //controllo casting
                {
                    if (number > 0) break;
                    else Console.WriteLine("Il numero deve essere positivo");
                }
                else Console.WriteLine("Il numero inserito non è intero, riprova");
            }
            return number;
        }
        static void Main(string[] args)
        {
            #region autore

            Console.Title = "Marco Balducci 3H";
            Console.WriteLine("#####################\n# Marco Balducci 3H #\n#####################\n\n");

            #endregion

            int length = leggiIntero("Inserisci la lunghezza dell'array: "); //richiesta lunghezza array

            double[] array = new double[length]; //creazione / allocazione memoria array

            double somma = 0.0, media;

            #region inserimento valori in array

            for (int i = 0; i < length; i++)
            {
                array[i] = leggiDouble($"Inserisci il valore con indice {i}: ");
                somma += array[i];
            }

            #endregion

            media = somma/ length; //calcolo media

            Console.Write("\nLa media di tutti i valori inseriti è {0:0.000}\n\nValori maggiori della media: ", media);

            #region stampa valori > media

            for (int i = 0; i < length;i++)
            {
                if (array[i] > media) Console.Write(array[i] + " | ");
            }

            #endregion

        }
    }
}