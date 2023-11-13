namespace multiple5
{
    internal class Program
    {
        static int readInt(string messaggio, string errorMessage)
        {
            int output;

            while (true)
            {
                Console.Write(messaggio);

                if (int.TryParse(Console.ReadLine(), out output))
                {
                    if (output > 0) return output;
                    else Console.WriteLine(errorMessage);
                }
                else Console.WriteLine("Il valore inserito non è valido, riprova");
            }
            
        }
        static void Main(string[] args)
        {
            int N = readInt("Inserisci il numero da cui estrarre i multipli di 5: ", "Il valore inserito deve essere positivo, riprova.");
            int multipleSum = 0;

            for(int i = 5; i<=N; i+= 5)
            {
                multipleSum += i;
            }

            Console.WriteLine($"La somma di tutti i multipli di 5 da 0 a {N} è {multipleSum}");
        }
    }
}