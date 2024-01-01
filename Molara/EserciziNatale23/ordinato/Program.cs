namespace ordinato
{
    internal class Program
    {
        static bool ordinato(int[] vettore)
        {
            for (int i = 0; i < vettore.Length - 1; i++)
                if (vettore[i + 1] < vettore[i]) return false;
            return true;
        }
        static void Main(string[] args)
        {
            int[] vettore = {1,2, 3, 4,2, 5};
            Console.WriteLine(ordinato(vettore));
            int[] vettore2 = {1, 2, 3, 4, 5};
            Console.WriteLine(ordinato(vettore2));
        }
    }
}