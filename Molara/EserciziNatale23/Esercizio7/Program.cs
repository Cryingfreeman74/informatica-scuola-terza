namespace Esercizio7
{
    internal class Program
    {
        //primo metodo
        static void GeneraPrimiFino(int n)
        {
            int[] numeri = new int[n]; //numeri da 0 a n
            for (int i = 2; i < n; i++) numeri[i] = i;
            int[] primi = new int[n]; //numeri effettivamente primi

            for(int i = 2; i < n; i++)
            {
                bool primo = true;
                for(int j = 2;  j < i; j++)
                    if (numeri[i] % numeri[j] == 0)
                    {
                        primo = false;
                        break;
                    }
                if(primo) primi[i] = numeri[i];
            }

            //stampa senza output
            for (int i = 0; i < n; i++) if (primi[i] != 0) Console.Write("");

        }

        //metodo di eratostene
        static void GeneraPrimiFinoEratostene(int n)
        {
            bool[] primi = new bool[n];

            for (int i = 2; i < n; i++) primi[i] = true;

            for (int i = 2; i < n; i++)
            {
                if (primi[i])
                    for (int j = 2; ; j++)
                        if (i * j < n) primi[i * j] = false;
                        else break;
            }

            //stampa senza output
            for (int i = 0; i < n; i++) if (primi[i]) Console.Write("");

        }
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch cronometro = new System.Diagnostics.Stopwatch();
            Console.WriteLine("valori\t\tMetodo 1\tMetodo di Eratostene");

            for (int i = 0; i<10; i++)
            {
                int valori = 10 * (int)Math.Pow(10, i);
                cronometro.Restart();
                GeneraPrimiFino(valori);
                cronometro.Stop();
                long tempo1 = cronometro.ElapsedMilliseconds;
                cronometro.Restart();
                GeneraPrimiFinoEratostene(valori);
                cronometro.Stop();
                long tempo2 = cronometro.ElapsedMilliseconds;
                Console.WriteLine($"{valori}\t\t{tempo1}\t\t{tempo2}");
            }
            
        }
    }
}