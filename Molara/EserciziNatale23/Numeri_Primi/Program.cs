namespace Numeri_Primi
{
    internal class Program
    {
        static int[] generaPrimi(int n)
        {
            int sp = 0;
            int[] primi = new int[n];
            for (int counter = 2; sp < n; counter++)
            {
                bool primo = true;
                for (int i = 2; i < counter; i++)
                    if (counter % i == 0)
                    {
                        primo = false;
                        break;
                    }
                if (primo) primi[sp++] = counter;
            }
                
            return primi;

        }
        static void Main(string[] args)
        {
            Console.Write("Inserisci il numero di numeri primi da stampare: ");
            int n = int.Parse(Console.ReadLine());
            int[] numeri = generaPrimi(n);
            for (int i = 0; i < numeri.Length; i++)
                Console.Write(numeri[i] + " ");
        }
    }
}